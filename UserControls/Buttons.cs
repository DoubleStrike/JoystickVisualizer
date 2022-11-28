using SharpDX.DirectInput;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using JoystickVisualizer.Properties;

namespace JoystickVisualizer.UserControls {
    public partial class Buttons : UserControl {
        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_SectionHeight = 0;
        private int m_SectionWidth = 0;
        private int m_GridCols = 1;
        private int m_GridRows = 1;
        private string m_Label = "B";
        private bool[] m_buttonPressedState;

        private SolidBrush boxBrush;

        #region Public Properties
        public string TextLabel {
            get {
                return m_Label;
            }
            set {
                m_Label = value;
            }
        }

        public string ToolTip {
            get {
                return toolTip.GetToolTip(this);
            }
            set {
                toolTip.SetToolTip(this, value);
            }
        }

        public JoystickUpdate CurrentEvent {
            set {
                // Calculate button offset (JoystickOffset.Buttons0 is enum value of 48)
                int buttonOffset = (int)value.Offset - 48;

                // Set the button pressed state:
                //      TRUE if the button is pressed (its value == 128)
                //      FALSE if the button is released (its value == 0)
                m_buttonPressedState[buttonOffset] = value.Value == 128;

                this.Refresh();
            }
        }
        #endregion Public Properties


        public Buttons() {
            InitializeComponent();

            boxBrush = new SolidBrush(Settings.Default.UI_ButtonColor);

            // Load grid count from settings
            m_GridCols = Settings.Default.Button_GridCols;
            m_GridRows = Settings.Default.Button_GridRows;

            // Setup boolean array for button pressed states
            m_buttonPressedState = new bool[m_GridCols * m_GridRows];
        }

        #region Event Handlers
        private void Form_Paint(object sender, PaintEventArgs e) {
            if (this.Enabled) {
                // Draw the text label
                e.Graphics.DrawString(m_Label, SystemFonts.DefaultFont, Globals.frameBrush, 2, 1);

                // Calculate width of each grid section based on current size
                m_SectionWidth = this.Width / m_GridCols;
                // Calculate height of each grid section based on current size
                m_SectionHeight = this.Height / m_GridRows;

                // Draw the sections as needed
                for (int j = 0; j < m_GridCols * m_GridRows; j++) {
                    if (m_buttonPressedState[j]) FillInGridSection(j, ref e);
                }

                // Update the tooltip
                ToolTip = $"({this.Name}: Button states 0-{m_GridCols * m_GridRows})";
            }
        }

        private void Form_Resize(object sender, EventArgs e) {
            if (this.Enabled) this.Refresh();
        }
        #endregion Event Handlers

        #region Private Methods
        private void FillInGridSection(int buttonNumber, ref PaintEventArgs e) {
            e.Graphics.FillRectangle(boxBrush, RectStartingPointX(buttonNumber), RectStartingPointY(buttonNumber), m_SectionWidth, m_SectionHeight);
            e.Graphics.DrawString(buttonNumber.ToString(), SystemFonts.DefaultFont, Globals.frameBrush, RectStartingPointX(buttonNumber) + 1, RectStartingPointY(buttonNumber) + 1);
        }

        private int RectStartingPointX(int ButtonPosition) {
            // Use integer modulo to calculate column/row offsets
            return (ButtonPosition % m_GridCols) * m_SectionWidth;
        }

        private int RectStartingPointY(int ButtonPosition) {
            // Use integer division to calculate column/row offsets6
            return (ButtonPosition / m_GridCols) * m_SectionHeight;
        }
        #endregion Private Methods
    }
}
