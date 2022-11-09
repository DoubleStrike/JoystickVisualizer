using SharpDX.DirectInput;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class JoystickStatus : Form {
        #region Private members
        // Joystick data buffers
        private JoystickUpdate[] dataLeftStick;
        private JoystickUpdate[] dataRightStick;
        #endregion Private members

        public JoystickStatus() {
            InitializeComponent();
        }

        private void JoystickStatus_Load(object sender, EventArgs e) {
            PollingTimer.Interval = Globals.POLLING_INTERVAL_MS;

            // Try to bind the joysticks, else throw an error and exit
            if (!BindJoysticks()) {
                MessageBox.Show("No joystick/Gamepad found.", "No devices", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            ActivateJoysticks();
            PollingTimer.Enabled = true;
        }

        private void JoystickStatus_FormClosing(object sender, FormClosingEventArgs e) {
            // Unacquire any active joysticks
            if (Globals.joystickLAcquired) Globals.joystickL.Unacquire();
            if (Globals.joystickRAcquired) Globals.joystickR.Unacquire();
        }

        /// <summary>
        /// Instantiates Joystick objects given proper GUIDs, sets buffer sizes, and performs Acquire() on the sticks.  Only call after BindJoysticks().
        /// </summary>
        private void ActivateJoysticks() {
            if (Globals.joystickLFound) {
                // Instantiate the joystick
                Globals.joystickL = new Joystick(Globals.directInput, Globals.joystickLGuid);
                //Debug.WriteLine($"Found Left Joystick/Gamepad with GUID: '{joystickLGuid}'");

                // Set BufferSize in order to use buffered data
                Globals.joystickL.Properties.BufferSize = 128;

                // Acquire the joystick
                Globals.joystickL.Acquire();
                Globals.joystickLAcquired = true;
            }

            if (Globals.joystickRFound) {
                // Instantiate the joystick
                Globals.joystickR = new Joystick(Globals.directInput, Globals.joystickRGuid);
                //Debug.WriteLine($"Found Right Joystick/Gamepad with GUID: '{joystickRGuid}'");

                // Set BufferSize in order to use buffered data
                Globals.joystickR.Properties.BufferSize = 128;

                // Acquire the joystick
                Globals.joystickR.Acquire();
                Globals.joystickRAcquired = true;
            }
        }

        /// <summary>
        /// Iterates through device instances from DirectInput and saves the left/right stick GUIDs and marks them as found
        /// </summary>
        /// <returns>true if at least one joystick was bound successfully</returns>
        private bool BindJoysticks() {
            foreach (DeviceInstance thisDevice in Globals.directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices)) {
                Debug.WriteLine($"Device instance found: '{thisDevice.InstanceName}'");

                if (thisDevice.InstanceName == Globals.GLADIATOR_LEFT_NAME) {
                    Globals.joystickLFound = true;
                    Globals.joystickLGuid = thisDevice.InstanceGuid;
                } else if (thisDevice.InstanceName == Globals.GLADIATOR_RIGHT_NAME) {
                    Globals.joystickRFound = true;
                    Globals.joystickRGuid = thisDevice.InstanceGuid;
                } else if (thisDevice.InstanceName == Globals.GLADIATOR_RIGHT_SEM_NAME) {
                    Globals.joystickRFound = true;
                    Globals.joystickRGuid = thisDevice.InstanceGuid;
                } else {
                    Debug.WriteLine("Unplanned extra device found.");
                }
            }

            return (Globals.joystickLFound || Globals.joystickRFound);
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

        private void PollingTimer_Tick(object sender, EventArgs e) {
            // Poll events from joystick
            dataLeftStick = PollJoystick(Globals.joystickL);
            dataRightStick = PollJoystick(Globals.joystickR);

            if (dataLeftStick != null && dataLeftStick.Length > 0) {
                foreach (JoystickUpdate state in dataLeftStick) {
                    switch (state.Offset) {
                        case JoystickOffset.X:
                            Left2D.XValue = state.Value;
                            break;
                        case JoystickOffset.Y:
                            Left2D.YValue = state.Value;
                            break;
                        case JoystickOffset.Z:
                            LeftThrottle.Value = Globals.MAX_AXIS_VALUE - state.Value;
                            break;
                        case JoystickOffset.RotationZ:
                            LeftTwist.Value = state.Value;
                            break;
                    }

                    //Debug.WriteLine($"Left: '{state}'");
                }
            }

            if (dataRightStick != null && dataRightStick.Length > 0) {
                foreach (JoystickUpdate state in dataRightStick) {
                    switch (state.Offset) {
                        case JoystickOffset.X:
                            Right2D.XValue = state.Value;
                            break;
                        case JoystickOffset.Y:
                            Right2D.YValue = state.Value;
                            break;
                        case JoystickOffset.Z:
                            RightThrottle.Value = Globals.MAX_AXIS_VALUE - state.Value;
                            break;
                        case JoystickOffset.RotationZ:
                            RightTwist.Value = state.Value;
                            break;
                        case JoystickOffset.Sliders0:
                            RightSlider.Value = Globals.MAX_AXIS_VALUE - state.Value;
                            break;
                    }

                    //Debug.WriteLine($"Right: '{state}'");
                }
            }
        }

        private void AlwaysOnTop_CheckedChanged(object sender, EventArgs e) {
            this.TopMost = AlwaysOnTop.Checked;
        }
    }
}
