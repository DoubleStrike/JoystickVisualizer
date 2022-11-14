using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class Axis1DHorizontal : UserControl {
        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_Value = Globals.DEFAULT_AXIS_VALUE;
        private bool m_RenderFrame = true;
        private string m_Label = "";

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
                DefaultValue(32767),
                Browsable(true)]
        public int Value {
            get { return m_Value; }
            set {
                m_Value = value;
                this.Invalidate();
                this.Update();
            }
        }

        [Description("Sets whether the frame should be rendered"),
                Category("Control Defaults"),
                DefaultValue(true),
                Browsable(true)]
        public bool RenderFrame {
            get { return m_RenderFrame; }
            set { m_RenderFrame = value; }
        }
        #endregion Public Properties


        public Axis1DHorizontal() {
            InitializeComponent();

            if (this.Enabled) {
                // Setup class members
                this.ResizeRedraw = true;
            }
        }

        private void Form_Paint(object sender, PaintEventArgs e) {
            if (this.Enabled) {
                // Draw the frame
                if (m_RenderFrame) {
                    //e.Graphics.FillRectangle(frameBrush, 0, 0, this.Width, this.Height);
                    e.Graphics.DrawRectangle(Globals.framePen, 0, 0, this.Width, this.Height);
                }

                // Draw centering crosshair
                Globals.DrawCrosshairs(CrosshairDirection.Vertical, e.Graphics, ref Globals.crosshairsPen, this.Height, this.Width, 0, true, true);

                // Draw the dot
                e.Graphics.FillEllipse(Globals.dotBrush, MapValueToRange(m_Value) + 1, 0, this.Height - 2, this.Height - 2);

                // Draw the text label
                e.Graphics.DrawString(m_Label, SystemFonts.DefaultFont, Globals.frameBrush, 2, 1);

                // Update the tooltip
                ToolTip = $"('{this.Name}': '{Value}')";
            }
        }

        private void Form_Resize(object sender, EventArgs e) {
            //if (this.Enabled) this.Refresh();
        }

        private float MapValueToRange(int InputValue) {
            int MaxRightPosition = this.Width - this.Height;

            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)
            float positionExact = MaxRightPosition * InputValue / Globals.MAX_AXIS_VALUE;
            return positionExact;
        }
    }
}
