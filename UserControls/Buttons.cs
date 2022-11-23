using SharpDX.DirectInput;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using JoystickVisualizer.Properties;

namespace JoystickVisualizer.UserControls {
    public partial class Buttons : UserControl {
        private const int GRID_SIZE = 4;

        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_SectionHeight = 0;
        private int m_SectionWidth = 0;
        private int m_bitMask = 0;
        private string m_Label = "B";

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
                // Calculate button offset and exit if over 15
                int buttonOffset = (int)value.Offset - 48;
                if (buttonOffset > 15) return;

                // Apply the offset to the bitmask:
                //      if the button is pressed (its value==128) we add the value to the mask
                //      if the button is released (its value==0) we subtract the value from the mask
                m_bitMask = (value.Value == 128) ? m_bitMask + (int)Math.Pow(2, buttonOffset) : m_bitMask - (int)Math.Pow(2, buttonOffset);

                this.Refresh();
            }
        }
        #endregion Public Properties


        public Buttons() {
            InitializeComponent();

            Debug.Assert(GRID_SIZE <= 4, "Grid size too large - grids up to 4x4 are supported.");
            boxBrush = new SolidBrush(Settings.Default.UI_ButtonColor);
        }

        #region Event Handlers
        private void Form_Paint(object sender, PaintEventArgs e) {
            if (this.Enabled) {
                // Draw the text label
                e.Graphics.DrawString(m_Label, SystemFonts.DefaultFont, Globals.frameBrush, 2, 1);

                // Calculate width of each grid section based on current size
                m_SectionWidth = this.Width / GRID_SIZE;
                // Calculate height of each grid section based on current size
                m_SectionHeight = this.Height / GRID_SIZE;

                // Draw the sections as needed
                for (int j = 0; j < GRID_SIZE * GRID_SIZE; j++) {
                    if ((m_bitMask & (int)Math.Pow(2, j)) == (int)Math.Pow(2, j)) FillInGridSection(j, ref e);
                }

                // Update the tooltip
                ToolTip = $"('{this.Name}': BitMask='{m_bitMask}')";
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
            // Use integer modulo and division to calculate column/row offsets
            return (ButtonPosition % GRID_SIZE) * m_SectionWidth;
        }

        private int RectStartingPointY(int ButtonPosition) {
            // Use integer modulo and division to calculate column/row offsets
            return (ButtonPosition / GRID_SIZE) * m_SectionHeight;
        }
        #endregion Private Methods
    }
}
