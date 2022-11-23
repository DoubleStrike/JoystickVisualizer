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
        private int m_bitMask = 0;
        private int m_GridCols = 1;
        private int m_GridRows = 1;
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
                // Calculate button offset and exit if over 15, since grid can be a max of 16 cells
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

            boxBrush = new SolidBrush(Settings.Default.UI_ButtonColor);

            // Ensure grid is no greater than 16 cells since bitmask is max of 16-bit integer
            m_GridCols = Settings.Default.Button_GridCols;
            m_GridRows = Settings.Default.Button_GridRows;
            if (m_GridCols * m_GridRows > 16) { m_GridCols = m_GridRows = 4; }
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
