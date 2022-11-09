using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class Axis1DVertical : UserControl {
        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_Value = Globals.DEFAULT_AXIS_VALUE;
        private bool m_RenderFrame = true;
        private SolidBrush dotBrush;
        private SolidBrush frameBrush;
        private Pen framePen;
        private Pen crosshairsPen;

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


        public Axis1DVertical() {
            InitializeComponent();

            if (this.Enabled) {
                // Setup class members
                this.ResizeRedraw = true;
                dotBrush = new SolidBrush(Globals.DEFAULT_DOT_COLOR);
                frameBrush = new SolidBrush(Globals.DEFAULT_FRAME_COLOR);
                framePen = new Pen(Globals.DEFAULT_FRAME_COLOR, Globals.BORDER_THICKNESS);
                crosshairsPen = new Pen(Globals.DEFAULT_FRAME_COLOR, Globals.CROSSHAIR_THICKNESS);
            }
        }

        private void Form_Paint(object sender, PaintEventArgs e) {
            if (this.Enabled) {
                // Draw the frame
                if (m_RenderFrame) {
                    //e.Graphics.FillRectangle(frameBrush, new Rectangle(0, 0, this.Width, this.Height));
                    e.Graphics.DrawRectangle(framePen, new Rectangle(0, 0, this.Width, this.Height));
                }

                // Draw centering crosshair
                Globals.DrawCrosshairs(CrosshairDirection.Horizontal, e.Graphics, ref crosshairsPen, this.Height, this.Width, 0, true, true);

                // Draw the dot
                e.Graphics.FillEllipse(dotBrush, 0, MapValueToRange(m_Value) + 1, this.Width - 2, this.Width - 2);

                // Update the tooltip
                ToolTip = $"('{Value}')";
            }
        }

        private void Form_Resize(object sender, EventArgs e) {
            if (this.Enabled) {
                this.Invalidate();
                this.Update();
            }
        }

        private float MapValueToRange(int InputValue) {
            int MaxBottomPosition = this.Height - this.Width;

            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxBottomPosition * InputValue / Globals.MAX_AXIS_VALUE;
            return positionExact;
        }
    }
}
