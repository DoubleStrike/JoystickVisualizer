using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class Axis1DHorizontal : UserControl {
        private const int BORDER_THICKNESS = 4;

        private int MaxRightPosition = 0;
        private int m_Value = 32767;
        private Color m_DotColor = Color.Black;
        private Color m_FrameColor = Color.Blue;
        private SolidBrush dotBrush;
        private SolidBrush frameBrush;
        private Pen framePen;

        #region Public Properties
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
            get;
            set;
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


        public Axis1DHorizontal() {
            InitializeComponent();

            // Setup class members
            this.ResizeRedraw = true;
            dotBrush = new SolidBrush(m_DotColor);
            frameBrush = new SolidBrush(m_FrameColor);
            framePen = new Pen(m_FrameColor, BORDER_THICKNESS);

            CalculateMaxPosition();
        }

        private void Axis1D_Paint(object sender, PaintEventArgs e) {
            // Draw the frame
            if (RenderFrame) {
                //e.Graphics.FillRectangle(frameBrush, new Rectangle(0, 0, this.Width, this.Height));
                e.Graphics.DrawRectangle(framePen, new Rectangle(0, 0, this.Width, this.Height));
            }

            // Draw the dot
            e.Graphics.FillEllipse(dotBrush, new Rectangle(MapValueToRange(), 0, this.Height, this.Height));
        }

        private void Axis1D_Resize(object sender, EventArgs e) {
            CalculateMaxPosition();
            this.Invalidate();
            this.Update();
        }

        private void CalculateMaxPosition() {
            MaxRightPosition = this.Width - this.Height;
        }

        private int MapValueToRange() {
            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxRightPosition * Value / 65535;
            return (int)positionExact;
        }
    }
}
