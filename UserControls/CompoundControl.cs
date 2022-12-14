using SharpDX.DirectInput;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using JoystickVisualizer.Properties;

namespace JoystickVisualizer {
    public partial class CompoundControl : UserControl {
        #region Private members
        private Joystick m_joystickToUse;

        private JoystickUpdate[] m_joystickDataBuffer;
        #endregion Private members

        #region Public Properties
        [Description("The Anchor property of the contained TableLayoutPanel"),
                Category("Control Defaults"),
                Browsable(true)]
        public AnchorStyles InternalTableAnchor {
            get { return squareTableLayout.Anchor; }
            set {
                squareTableLayout.Anchor = value;
                this.Refresh();
            }
        }
        #endregion Public Properties

        #region Public functions
        public void SetDarkMode(bool darkModeOn = true) {
            if (darkModeOn) {
                squareTableLayout.BackColor = Settings.Default.UI_DarkModeBackground;
            } else {
                squareTableLayout.BackColor = SystemColors.Control;
            }
        }

        public void SetDotSize(int sizeInPixels) {
            if (sizeInPixels == 0) return;

            int scaledSize = (int)(sizeInPixels / 3);

            axisXY.SetDotSize(sizeInPixels);
            axisRotXRotY.SetDotSize(scaledSize);
        }

        public void SetJoystickToUse(JoystickSelection selectedStick) {
            if (selectedStick == JoystickSelection.Right) {
                m_joystickToUse = Globals.joystickR;
            } else if (selectedStick == JoystickSelection.Left) {
                m_joystickToUse = Globals.joystickL;
            }
        }

        public void StartPolling() {
            if (m_joystickToUse != null) {
                SetCurrentState();

                // Start the polling timer
                PollingTimer.Enabled = true;
            }
        }

        public void UpdatePollingInterval(int milliseconds) {
            PollingTimer.Interval = milliseconds;
        }
        #endregion Public functions

        public CompoundControl() {
            InitializeComponent();
        }

        #region Event Handlers
        private void CompoundControl_Load(object sender, EventArgs e) {
            KeepSticksSquare();

            PollingTimer.Interval = Settings.Default.Timer_PollingIntervalMs;

            // Setup labels
            axisRotXRotY.TextLabel = "RX+RY";
            axisZ.TextLabel = "Z";
            axisXY.TextLabel = "X+Y";
            axisSlider0.TextLabel = "S0";
            axisSlider1.TextLabel = "S1";
            axisRotZ.TextLabel = "RZ";
            povHat1.TextLabel = "POV";
        }

        private void CompoundControl_Resize(object sender, EventArgs e) {
            KeepSticksSquare();
            buttons1.Size = axisRotXRotY.Size;
        }

        private void PollingTimer_Tick(object sender, EventArgs e) {
            // Poll events from joystick
            m_joystickDataBuffer = Globals.PollJoystick(m_joystickToUse);

            if (m_joystickDataBuffer != null && m_joystickDataBuffer.Length > 0) {
                foreach (JoystickUpdate state in m_joystickDataBuffer) {
                    // Check the type of input
                    if ((int)state.Offset <= 28) {
                        #region Input is an Axis event ----------------------------------
                        switch (state.Offset) {
                            case JoystickOffset.X:
                                axisXY.XValue = state.Value;
                                break;
                            case JoystickOffset.Y:
                                axisXY.YValue = state.Value;
                                break;
                            case JoystickOffset.Z:
                                axisZ.Value = axisZ.AxisMaximum - state.Value;
                                break;
                            case JoystickOffset.RotationX:
                                axisRotXRotY.XValue = state.Value;
                                break;
                            case JoystickOffset.RotationY:
                                axisRotXRotY.YValue = axisRotXRotY.AxisMaximumY - state.Value;
                                break;
                            case JoystickOffset.RotationZ:
                                axisRotZ.Value = state.Value;
                                break;
                            case JoystickOffset.Sliders0:
                                axisSlider0.Value = axisSlider0.AxisMaximum - state.Value;
                                break;
                        }
                        #endregion Input is an Axis event ----------------------------------
                    } else if ((int)state.Offset == 32 || (int)state.Offset == 36 || (int)state.Offset == 40 || (int)state.Offset == 44) {
                        #region Input is a POV Hat event --------------------------------
                        povHat1.Value = state.Value;
                        #endregion Input is a POV Hat event --------------------------------
                    } else if ((int)state.Offset >= 48 && (int)state.Offset <= 150) {
                        #region Input is a button event ---------------------------------
                        buttons1.CurrentEvent = state;

#if false
                        if (state.Value == 128) {
                            Debug.WriteLine($"Button press:   {state}");
                        } else if (state.Value == 0) {
                            Debug.WriteLine($"Button release: {state}");
                        }
#endif
#endregion Input is a button events --------------------------------
                    }


                    //Debug.WriteLine($"Received state: {state}");
                }
            }
        }
        #endregion Event Handlers

        #region Private Methods
        private void SetCurrentState() {
            // Read current axis values
            JoystickState state = m_joystickToUse.GetCurrentState();

            if (state != null) {
                axisXY.XValue = state.X;
                axisXY.YValue = state.Y;
                axisZ.Value = axisZ.AxisMaximum - state.Z;
                axisRotXRotY.XValue = state.RotationX;
                axisRotXRotY.YValue = axisRotXRotY.AxisMaximumY - state.RotationY;
                axisRotZ.Value = state.RotationZ;
                axisSlider0.Value = axisSlider0.AxisMaximum - state.Sliders[0];
            }
        }

        private void KeepGridSquare() {
            // Size of the Axis2D control
            int tableWidth = squareTableLayout.Width;
            int tableHeight = squareTableLayout.Height;

            // Size of the control
            int interiorWidth = this.ClientSize.Width;
            int interiorHeight = this.ClientSize.Height;

            if (interiorHeight > interiorWidth) {
                tableHeight = tableWidth = interiorWidth;
            } else if (interiorWidth > interiorHeight) {
                tableHeight = tableWidth = interiorHeight;
            }

            squareTableLayout.Size = new Size(tableWidth, tableHeight);
        }

        private void KeepMinistickSquare() {
            // Size of the XY grid
            int ministickSize = (int)(this.axisXY.Height * (2.0f / 7.0f));

            axisRotXRotY.Size = new Size(ministickSize, ministickSize);
        }

        private void KeepSticksSquare() {
            KeepGridSquare();
            KeepMinistickSquare();
        }
        #endregion Private Methods
    }
}
