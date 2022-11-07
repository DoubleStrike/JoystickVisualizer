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
        #region Private members
        // VKB's device names - complete with weird extra spaces
        private const string GLADIATOR_LEFT_NAME = " VKBsim Gladiator EVO  L  ";
        private const string GLADIATOR_RIGHT_NAME = " VKBsim Gladiator EVO  R  ";

        private const int POLLING_SLEEP_MS = 100;

        // Initialize DirectInput
        private readonly DirectInput directInput;

        // Joystick GUIDs
        private Guid joystickLGuid = Guid.Empty;
        private Guid joystickRGuid = Guid.Empty;

        // Joystick state
        private bool joystickLFound = false;
        private bool joystickRFound = false;

        // Joystick objects
        private Joystick joystickL;
        private Joystick joystickR;

        // Joystick data buffers
        private JoystickUpdate[] dataLeftStick;
        private JoystickUpdate[] dataRightStick;
        #endregion Private members

        public Form1() {
            InitializeComponent();

            directInput = new DirectInput();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Try to bind the joysticks, else throw an error and exit
            if (!BindJoysticks()) {
                Debug.WriteLine("No joystick/Gamepad found.");
                Environment.Exit(1);
            }

            ActivateJoysticks();


            // Poll events from joystick
            while (true) {
                dataLeftStick = PollJoystick(joystickL);
                dataRightStick = PollJoystick(joystickR);

                foreach (JoystickUpdate state in dataLeftStick)
                    Debug.WriteLine($"Left: '{state}'");

                foreach (JoystickUpdate state in dataRightStick)
                    Debug.WriteLine($"Right: '{state}'");

                // Sleep for the defined delay
                System.Threading.Thread.Sleep(POLLING_SLEEP_MS);
            }
        }

        /// <summary>
        /// Instantiates Joystick objects given proper GUIDs, sets buffer sizes, and performs Acquire() on the sticks
        /// </summary>
        private void ActivateJoysticks() {
            if (joystickLFound) {
                // Instantiate the joystick
                joystickL = new Joystick(directInput, joystickLGuid);
                Debug.WriteLine($"Found Left Joystick/Gamepad with GUID: '{joystickLGuid}'");

                // Set BufferSize in order to use buffered data
                joystickL.Properties.BufferSize = 128;

                // Acquire the joysticks
                joystickL.Acquire();
            }

            if (joystickRFound) {
                // Instantiate the joystick
                joystickR = new Joystick(directInput, joystickRGuid);
                Debug.WriteLine($"Found Right Joystick/Gamepad with GUID: '{joystickRGuid}'");

                // Set BufferSize in order to use buffered data
                joystickR.Properties.BufferSize = 128;

                // Acquire the joysticks
                joystickR.Acquire();
            }
        }

        /// <summary>
        /// Iterates through device instances from DirectInput and saves the left/right stick GUIDs and marks them as found
        /// </summary>
        /// <returns>true if at least one joystick was bound successfully</returns>
        private bool BindJoysticks() {
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

            return (joystickLFound || joystickRFound);
        }

        /// <summary>
        /// Calls Poll() on the Joystick object and returns its buffered data
        /// </summary>
        /// <param name="stickToPoll">the Joystick object to poll</param>
        /// <returns>the contents of the data buffer as a JoystickUpdate[]</returns>
        private JoystickUpdate[] PollJoystick(Joystick stickToPoll) {
            if (stickToPoll == null) return null;

            stickToPoll.Poll();
            return stickToPoll.GetBufferedData();
        }
    }
}
