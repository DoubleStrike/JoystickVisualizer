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

        private const int POLLING_SLEEP_MS = 100;


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

            foreach (DeviceInstance thisDevice in directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices)) {
                Debug.WriteLine($"Device instance found: '{thisDevice.InstanceName}'");

                if (thisDevice.InstanceName == GLADIATOR_LEFT_NAME) {
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

            // Set BufferSize in order to use buffered data
            joystickL.Properties.BufferSize = 128;
            joystickR.Properties.BufferSize = 128;

            // Acquire the joysticks
            joystickL.Acquire();
            joystickR.Acquire();


            // Poll events from joystick
            while (true) {
                joystickL.Poll();
                JoystickUpdate[] dataLeftStick = joystickL.GetBufferedData();
                foreach (JoystickUpdate state in dataLeftStick)
                    Debug.WriteLine($"Left: '{state}'");

                joystickR.Poll();
                JoystickUpdate[] dataRightStick = joystickR.GetBufferedData();
                foreach (JoystickUpdate state in dataRightStick)
                    Debug.WriteLine($"Right: '{state}'");

                // Sleep for the defined delay
                System.Threading.Thread.Sleep(POLLING_SLEEP_MS);
            }
        }
    }
}
