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
        private const int PovDotSize = 20;

        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_Value = Globals.DEFAULT_AXIS_VALUE;
        private int m_x = 0;
        private int m_y = 0;

        #region Public Properties
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

        #region Public functions
        #endregion Public functions


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

                if (m_Value != -1) {
                    // Draw the POV line
                    e.Graphics.DrawLine(Globals.povHatPen, Width / 2, Height / 2, m_x, m_y);
                    e.Graphics.FillEllipse(Globals.dotBrush, m_x - PovDotSize / 2, m_y - PovDotSize / 2, PovDotSize, PovDotSize);
                }

                // Update the tooltip
                ToolTip = $"('{this.Name}': '{Value}')";
            }
        }

        private void CalculateLineEndpoint(out int x, out int y) {
            // Hide/show the image as needed
            switch (m_Value) {
                case 0:
                    x = Width / 2;
                    y = 0;
                    break;
                case 4500:
                    x = Width;
                    y = 0;
                    break;
                case 9000:
                    x = Width;
                    y = Height / 2;
                    break;
                case 13500:
                    x = Width;
                    y = Height;
                    break;
                case 18000:
                    x = Width / 2;
                    y = Height;
                    break;
                case 22500:
                    x = 0;
                    y = Height;
                    break;
                case 27000:
                    x = 0;
                    y = Height / 2;
                    break;
                case 31500:
                    x = 0;
                    y = 0;
                    break;
                case -1:
                default:
                    x = Width / 2;
                    y = Height / 2;
                    break;
            }
        }
    }
}
