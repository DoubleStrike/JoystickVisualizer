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
        #endregion Public Properties


        public Axis2D() {
            InitializeComponent();

            // Setup class members
            this.ResizeRedraw = true;
            dotBrush = new SolidBrush(Globals.DEFAULT_DOT_COLOR);
            frameBrush = new SolidBrush(Globals.DEFAULT_FRAME_COLOR);
            framePen = new Pen(Globals.DEFAULT_FRAME_COLOR, Globals.BORDER_THICKNESS);
            crosshairsPen = new Pen(Globals.DEFAULT_FRAME_COLOR, Globals.CROSSHAIR_THICKNESS);

            CalculateMaxPositions();
        }

        private void Form_Paint(object sender, PaintEventArgs e) {
            // Draw the frame
            if (m_RenderFrame) {
                //e.Graphics.FillRectangle(frameBrush, new Rectangle(0, 0, this.Width, this.Height));
                e.Graphics.DrawRectangle(framePen, new Rectangle(0, 0, this.Width, this.Height));
            }

            // Draw centering crosshairs
            Globals.DrawCrosshairs(Globals.CrosshairDirection.Both, e.Graphics, ref crosshairsPen, this.Height, this.Width, true, true);

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
