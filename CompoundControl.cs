using SharpDX.DirectInput;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static JoystickVisualizer.Globals;

namespace JoystickVisualizer {
    public partial class CompoundControl : UserControl {
        #region Private members
        private Joystick m_joystickToUse;

        private JoystickUpdate[] m_joystickDataBuffer;
        #endregion Private members

        #region Public functions
        public void SetDarkMode(bool darkModeOn = true) {
            if (darkModeOn) {
                squareTableLayout.BackColor = SystemColors.ControlDarkDark;
            } else {
                squareTableLayout.BackColor = SystemColors.Control;
            }
        }

        public void SetJoystickToUse(JoystickSelection selectedStick) {
            if (selectedStick == JoystickSelection.Right) {
                m_joystickToUse = Globals.joystickR;
            } else if (selectedStick == JoystickSelection.Left) {
                m_joystickToUse = Globals.joystickL;
            }
        }

        public void StartPolling() {
            if (m_joystickToUse != null) PollingTimer.Enabled = true;
        }

        public void UpdatePollingInterval(int milliseconds) {
            PollingTimer.Interval = milliseconds;
        }
        #endregion Public functions

        public CompoundControl() {
            InitializeComponent();
        }

        private void CompoundControl_Load(object sender, EventArgs e) {
            KeepGridSquare();

            PollingTimer.Interval = Globals.POLLING_INTERVAL_MS;
        }

        private void CompoundControl_Resize(object sender, EventArgs e) {
            KeepGridSquare();
            KeepMinistickSquare();
        }

        private void KeepGridSquare() {
            // Size of the Axis2D control
            int tableWidth = squareTableLayout.Width;
            int tableHeight = squareTableLayout.Height;

            // Size of the control
            int interiorWidth = this.ClientSize.Width;
            int interiorHeight = this.ClientSize.Height;

            //Debug.Print($"TableGrid before ('{ministickWidth}', '{ministickHeight}')");
            if (interiorHeight > interiorWidth) {
                tableHeight = tableWidth = interiorWidth;
            } else if (interiorWidth > interiorHeight) {
                tableHeight = tableWidth = interiorHeight;
            }

            squareTableLayout.Size = new Size(tableWidth, tableHeight);
            //Debug.Print($"TableGrid after ('{ministickWidth}', '{ministickHeight}')");
        }

        private void KeepMinistickSquare() {
            // Size of the Axis2D control
            int ministickSize = axisRotXRotY.Width;

            // Size of the XY grid
            int xyGridSize = this.axisXY.Height;

            Debug.Print($"Ministick before ('{axisRotXRotY.Width}', '{axisRotXRotY.Height}')");
            ministickSize = (int)(xyGridSize * (2.0f / 7.0f));

            axisRotXRotY.Size = new Size(ministickSize, ministickSize);
            Debug.Print($"Ministick after ('{axisRotXRotY.Width}', '{axisRotXRotY.Height}')");
        }

        private void PollingTimer_Tick(object sender, EventArgs e) {
            // Poll events from joystick
            m_joystickDataBuffer = Globals.PollJoystick(m_joystickToUse);

            if (m_joystickDataBuffer != null && m_joystickDataBuffer.Length > 0) {
                foreach (JoystickUpdate state in m_joystickDataBuffer) {
                    switch (state.Offset) {
                        case JoystickOffset.X:
                            axisXY.XValue = state.Value;
                            break;
                        case JoystickOffset.Y:
                            axisXY.YValue = state.Value;
                            break;
                        case JoystickOffset.Z:
                            axisZ.Value = Globals.MAX_AXIS_VALUE - state.Value;
                            break;
                        case JoystickOffset.RotationX:
                            axisRotXRotY.XValue = state.Value;
                            break;
                        case JoystickOffset.RotationY:
                            axisRotXRotY.YValue = Globals.MAX_AXIS_VALUE - state.Value;
                            break;
                        case JoystickOffset.RotationZ:
                            axisRotZ.Value = state.Value;
                            break;
                        case JoystickOffset.Sliders0:
                            axisSlider0.Value = Globals.MAX_AXIS_VALUE - state.Value;
                            break;
                    }

                    //Debug.WriteLine($"Right: '{state}'");
                }
            }
        }
    }
}
