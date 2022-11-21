using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace JoystickVisualizer {
    public partial class PovHat : UserControl {
        private const int POV_DOT_SIZE = 20;

        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_Value = Globals.DEFAULT_AXIS_VALUE;
        private int m_centerX = 0;
        private int m_centerY = 0;
        private int m_x = 0;
        private int m_y = 0;
        private string m_Label = "";
        private Font labelFont = SystemFonts.DefaultFont;

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

        [Description("Sets the current value"),
                Category("Control Defaults"),
                DefaultValue(-1),
                Browsable(true)]
        public int Value {
            get { return m_Value; }
            set {
                m_Value = value;
                this.Refresh();
            }
        }
        #endregion Public Properties


        public PovHat() {
            InitializeComponent();

            if (this.Enabled) {
                // Setup class members
                this.ResizeRedraw = true;
            }
        }

        private void PovHat_Paint(object sender, PaintEventArgs e) {
            if (this.Enabled) {
                // Calculate the line endpoint and store in m_x, m_y
                CalculateLineEndpoint(out m_x, out m_y);

                // Recalculate the centerpoints
                m_centerX = Width / 2;
                m_centerY = Height / 2;

                if (m_Value != -1) {
                    // Draw the POV line
                    e.Graphics.DrawLine(Globals.povHatPen, m_centerX, m_centerY, m_x, m_y);
                    e.Graphics.FillEllipse(Globals.dotBrush, m_x - POV_DOT_SIZE / 2, m_y - POV_DOT_SIZE / 2, POV_DOT_SIZE, POV_DOT_SIZE);
                }

                // Draw the text label
                e.Graphics.DrawString(m_Label, labelFont, Globals.frameBrush, 2, 1);

                // Update the tooltip
                ToolTip = $"('{this.Name}': '{Value}')";
            }
        }

        private void CalculateLineEndpoint(out int x, out int y) {
            // Hide/show the image as needed
            switch (m_Value) {
                case 0:
                    x = m_centerX;
                    y = 0;
                    break;
                case 4500:
                    x = Width;
                    y = 0;
                    break;
                case 9000:
                    x = Width;
                    y = m_centerY;
                    break;
                case 13500:
                    x = Width;
                    y = Height;
                    break;
                case 18000:
                    x = m_centerX;
                    y = Height;
                    break;
                case 22500:
                    x = 0;
                    y = Height;
                    break;
                case 27000:
                    x = 0;
                    y = m_centerY;
                    break;
                case 31500:
                    x = 0;
                    y = 0;
                    break;
                case -1:
                default:
                    x = m_centerX;
                    y = m_centerY;
                    break;
            }
        }
    }
}
