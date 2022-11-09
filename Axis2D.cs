using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class Axis2D : UserControl {
        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_DotSize = Globals.DEFAULT_2D_DOT_SIZE;
        private int m_XValue = Globals.DEFAULT_AXIS_VALUE;
        private int m_YValue = Globals.DEFAULT_AXIS_VALUE;
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

        [Description("Sets the current X value"),
                Category("Control Defaults"),
                DefaultValue(32767),
                Browsable(true)]
        public int XValue {
            get { return m_XValue; }
            set {
                m_XValue = value;
                this.Invalidate();
                this.Update();
            }
        }

        [Description("Sets the current Y value"),
                Category("Control Defaults"),
                DefaultValue(32767),
                Browsable(true)]
        public int YValue {
            get { return m_YValue; }
            set {
                m_YValue = value;
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

        #region Public functions
        public int GetDotSize() {
            return m_DotSize;
        }

        public void SetDotSize(int sizeInPixels) {
            m_DotSize = sizeInPixels;
        }
        #endregion Public functions


        public Axis2D() {
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

                // Draw centering crosshairs
                Globals.DrawCrosshairs(CrosshairDirection.Both, e.Graphics, ref crosshairsPen, this.Height, this.Width, m_DotSize, true, true);

                // Draw the dot
                e.Graphics.FillEllipse(dotBrush, MapValueToRangeX(m_XValue) + 1, MapValueToRangeY(m_YValue) + 1, m_DotSize - 2, m_DotSize - 2);

                // Update the tooltip
                ToolTip = $"'{this.Name}': ('{XValue}','{YValue}')";
            }
        }

        private void Form_Resize(object sender, EventArgs e) {
            if (this.Enabled) {
                this.Invalidate();
                this.Update();
            }
        }

        private float MapValueToRangeX(int InputValue) {
            int MaxRightPosition = this.Width - m_DotSize;

            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxRightPosition * InputValue / Globals.MAX_AXIS_VALUE;
            return positionExact;
        }

        private float MapValueToRangeY(int InputValue) {
            int MaxBottomPosition = this.Height - m_DotSize;

            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxBottomPosition * InputValue / Globals.MAX_AXIS_VALUE;
            return positionExact;
        }
    }
}
