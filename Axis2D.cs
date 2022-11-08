using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class Axis2D : UserControl {
        private int MaxBottomPosition = 0;
        private int MaxRightPosition = 0;
        private int m_XValue = 32767;
        private int m_YValue = 32767;
        private bool m_RenderFrame = true;
        private Color m_DotColor = Color.Black;
        private Color m_FrameColor = Color.Blue;
        private SolidBrush dotBrush;
        private SolidBrush frameBrush;
        private Pen framePen;
        private Pen crosshairsPen;

        #region Public Properties
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

        [Description("HTML color code of the frame color"),
                Category("Control Defaults"),
                DefaultValue("#0000FF"),
                Browsable(true)]
        public string FrameColor {
            get { return ColorTranslator.ToHtml(m_FrameColor); }
            set { m_FrameColor = (value == "") ? Color.Blue : ColorTranslator.FromHtml(value); }
        }

        [Description("HTML color code of the dot color"),
                Category("Control Defaults"),
                DefaultValue("#000000"),
                Browsable(true)]
        public string DotColor {
            get { return ColorTranslator.ToHtml(m_DotColor); }
            set { m_DotColor = (value == "") ? Color.Black : ColorTranslator.FromHtml(value); }
        }
        #endregion Public Properties


        public Axis2D() {
            InitializeComponent();

            // Setup class members
            this.ResizeRedraw = true;
            dotBrush = new SolidBrush(m_DotColor);
            frameBrush = new SolidBrush(m_FrameColor);
            framePen = new Pen(m_FrameColor, Globals.BORDER_THICKNESS);
            crosshairsPen = new Pen(m_FrameColor, Globals.CROSSHAIR_THICKNESS);

            CalculateMaxPositions();
        }

        private void Form_Paint(object sender, PaintEventArgs e) {
            // Draw the frame
            if (m_RenderFrame) {
                //e.Graphics.FillRectangle(frameBrush, new Rectangle(0, 0, this.Width, this.Height));
                e.Graphics.DrawRectangle(framePen, new Rectangle(0, 0, this.Width, this.Height));
            }

            // Draw centering crosshairs
            e.Graphics.DrawLine(crosshairsPen, 0, this.Width / 2, this.Height, this.Width / 2);
            e.Graphics.DrawLine(crosshairsPen, this.Height / 2, 0, this.Height / 2, this.Width);

            // Draw the dot
            e.Graphics.FillEllipse(dotBrush, new Rectangle(MapValueToRangeX(m_XValue), MapValueToRangeY(m_YValue), Globals.DOT_SIZE, Globals.DOT_SIZE));
        }

        private void Form_Resize(object sender, EventArgs e) {
            CalculateMaxPositions();
            this.Invalidate();
            this.Update();
        }

        private void CalculateMaxPositions() {
            MaxBottomPosition = this.Height - Globals.DOT_SIZE;
            MaxRightPosition = this.Width - Globals.DOT_SIZE;
        }

        private int MapValueToRangeX(int InputValue) {
            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxRightPosition * InputValue / 65535;
            return (int)positionExact;
        }

        private int MapValueToRangeY(int InputValue) {
            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxBottomPosition * InputValue / 65535;
            return (int)positionExact;
        }
    }
}
