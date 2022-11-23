using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using JoystickVisualizer.Properties;
using SharpDX.DirectInput;

namespace JoystickVisualizer.UserControls {
    public partial class Buttons : UserControl {
        private const int GRID_SIZE = 4;

        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_SectionHeight = 0;
        private int m_SectionWidth = 0;
        private bool m_Button0Down = false;
        private bool m_Button1Down = false;
        private bool m_Button2Down = false;
        private bool m_Button3Down = false;
        private bool m_Button4Down = false;
        private bool m_Button5Down = false;
        private bool m_Button6Down = false;
        private bool m_Button7Down = false;
        private bool m_Button8Down = false;
        private string m_Label = "Buttons";

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
                switch (value.Offset) {
                    case JoystickOffset.Buttons0:
                        m_Button0Down = value.Value == 128;
                        break;
                    case JoystickOffset.Buttons1:
                        m_Button1Down = value.Value == 128;
                        break;
                    case JoystickOffset.Buttons2:
                        m_Button2Down = value.Value == 128;
                        break;
                    case JoystickOffset.Buttons3:
                        m_Button3Down = value.Value == 128;
                        break;
                    case JoystickOffset.Buttons4:
                        m_Button4Down = value.Value == 128;
                        break;
                    case JoystickOffset.Buttons5:
                        m_Button5Down = value.Value == 128;
                        break;
                    case JoystickOffset.Buttons6:
                        m_Button6Down = value.Value == 128;
                        break;
                    case JoystickOffset.Buttons7:
                        m_Button7Down = value.Value == 128;
                        break;
                    case JoystickOffset.Buttons8:
                        m_Button8Down = value.Value == 128;
                        break;
                    default:
                        break;
                }

                this.Refresh();
            }
        }
        #endregion Public Properties


        public Buttons() {
            InitializeComponent();

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

                // Draw the 9 sections as needed
                if (m_Button0Down) FillInGridSection(0, ref e);
                if (m_Button1Down) FillInGridSection(1, ref e);
                if (m_Button2Down) FillInGridSection(2, ref e);
                if (m_Button3Down) FillInGridSection(3, ref e);
                if (m_Button4Down) FillInGridSection(4, ref e);
                if (m_Button5Down) FillInGridSection(5, ref e);
                if (m_Button6Down) FillInGridSection(6, ref e);
                if (m_Button7Down) FillInGridSection(7, ref e);
                if (m_Button8Down) FillInGridSection(8, ref e);

                // Update the tooltip
                ToolTip = $"('{this.Name}': B0='{m_Button0Down}', B2='{m_Button1Down}', B3='{m_Button2Down}', B4='{m_Button3Down}')";
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
