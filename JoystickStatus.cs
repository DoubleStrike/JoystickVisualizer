using SharpDX.DirectInput;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace JoystickVisualizer {
    [Obsolete]
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
            if (!Globals.BindJoysticks()) {
                MessageBox.Show("No joystick/Gamepad found.", "No devices", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            if (Globals.ActivateJoysticks()) PollingTimer.Enabled = true;
        }

        private void JoystickStatus_FormClosing(object sender, FormClosingEventArgs e) {
            // Unacquire any active joysticks
            Globals.UnacquireJoysticks();
        }

        private void PollingTimer_Tick(object sender, EventArgs e) {
            // Poll events from joystick
            dataLeftStick = Globals.PollJoystick(Globals.joystickL);
            dataRightStick = Globals.PollJoystick(Globals.joystickR);

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
