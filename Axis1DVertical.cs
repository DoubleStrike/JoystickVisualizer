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
    public partial class Axis1DVertical : UserControl {
        private int MaxBottomPosition = 0;
        private int m_Value = 32767;
        private bool m_RenderFrame = true;
        private SolidBrush dotBrush;
        private SolidBrush frameBrush;
        private Pen framePen;
        private Pen crosshairsPen;

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
            get { return m_RenderFrame; }
            set { m_RenderFrame = value; }
        }
        #endregion Public Properties


        public Axis1DVertical() {
            InitializeComponent();

            // Setup class members
            this.ResizeRedraw = true;
            dotBrush = new SolidBrush(Globals.DEFAULT_DOT_COLOR);
            frameBrush = new SolidBrush(Globals.DEFAULT_FRAME_COLOR);
            framePen = new Pen(Globals.DEFAULT_FRAME_COLOR, Globals.BORDER_THICKNESS);
            crosshairsPen = new Pen(Globals.DEFAULT_FRAME_COLOR, Globals.CROSSHAIR_THICKNESS);

            CalculateMaxPosition();
        }

        private void Form_Paint(object sender, PaintEventArgs e) {
            // Draw the frame
            if (m_RenderFrame) {
                //e.Graphics.FillRectangle(frameBrush, new Rectangle(0, 0, this.Width, this.Height));
                e.Graphics.DrawRectangle(framePen, new Rectangle(0, 0, this.Width, this.Height));
            }

            // Draw centering crosshair
            Globals.DrawCrosshairs(Globals.CrosshairDirection.Horizontal, e.Graphics, ref crosshairsPen, this.Height, this.Width, true, true);

            // Draw the dot
            e.Graphics.FillEllipse(dotBrush, new Rectangle(0, MapValueToRange(m_Value), this.Width, this.Width));
        }

        private void Form_Resize(object sender, EventArgs e) {
            CalculateMaxPosition();
            this.Invalidate();
            this.Update();
        }

        private void CalculateMaxPosition() {
            MaxBottomPosition = this.Height - this.Width;
        }

        private int MapValueToRange(int InputValue) {
            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxBottomPosition * InputValue / 65535;
            return (int)positionExact;
        }
    }
}
