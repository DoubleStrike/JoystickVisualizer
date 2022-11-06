using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class Form1 : Form {
        // VKB's device names - complete with weird extra spaces
        private const string GLADIATOR_LEFT_NAME = " VKBsim Gladiator EVO  L  ";
        private const string GLADIATOR_RIGHT_NAME = " VKBsim Gladiator EVO  R  ";


        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Initialize DirectInput
            DirectInput directInput = new DirectInput();

            // Joystick GUIDs
            Guid joystickLGuid = Guid.Empty;
            Guid joystickRGuid = Guid.Empty;

            // Joystick counter
            bool joystickLFound = false;
            bool joystickRFound = false;

            //foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices)) {
            foreach (DeviceInstance thisDevice in directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices)) {
                Debug.WriteLine($"Device instance found: '{thisDevice.InstanceName}'");

                if(thisDevice.InstanceName == GLADIATOR_LEFT_NAME) {
                    joystickLFound = true;
                    joystickLGuid = thisDevice.InstanceGuid;
                } else if (thisDevice.InstanceName == GLADIATOR_RIGHT_NAME) {
                    joystickRFound = true;
                    joystickRGuid = thisDevice.InstanceGuid;
                } else {
                    Debug.WriteLine("Unplanned extra device found.");
                }
            }

            // If Joystick not found, throws an error and exits
            if (!joystickLFound && !joystickRFound) {
                Debug.WriteLine("No joystick/Gamepad found.");
                Environment.Exit(1);
            }

            // Instantiate the joysticks
            Joystick joystickL = new Joystick(directInput, joystickLGuid);
            Debug.WriteLine($"Found Left Joystick/Gamepad with GUID: '{joystickLGuid}'");

            Joystick joystickR = new Joystick(directInput, joystickRGuid);
            Debug.WriteLine($"Found Right Joystick/Gamepad with GUID: '{joystickRGuid}'");








            //// Query all suported ForceFeedback effects
            //var allEffects = joystick.GetEffects();
            //foreach (var effectInfo in allEffects)
            //    Debug.WriteLine("Effect available {0}", effectInfo.Name);

            //// Set BufferSize in order to use buffered data.
            //joystick.Properties.BufferSize = 128;

            //// Acquire the joystick
            //joystick.Acquire();

            //// Poll events from joystick
            //while (true) {
            //    joystick.Poll();
            //    JoystickUpdate[] datas = joystick.GetBufferedData();
            //    foreach (var state in datas)
            //        Debug.WriteLine(state);
            //}
        }
    }
}
