﻿using System;
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
        private const int BORDER_THICKNESS = 4;
        private const int CROSSHAIR_THICKNESS = 1;

        private int MaxBottomPosition = 0;
        private int m_Value = 32767;
        private bool m_RenderFrame = true;
        private Color m_DotColor = Color.Black;
        private Color m_FrameColor = Color.Blue;
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


        public Axis1DVertical() {
            InitializeComponent();

            // Setup class members
            this.ResizeRedraw = true;
            dotBrush = new SolidBrush(m_DotColor);
            frameBrush = new SolidBrush(m_FrameColor);
            framePen = new Pen(m_FrameColor, BORDER_THICKNESS);
            crosshairsPen = new Pen(m_FrameColor, CROSSHAIR_THICKNESS);

            CalculateMaxPosition();
        }

        private void Form_Paint(object sender, PaintEventArgs e) {
            // Draw the frame
            if (m_RenderFrame) {
                //e.Graphics.FillRectangle(frameBrush, new Rectangle(0, 0, this.Width, this.Height));
                e.Graphics.DrawRectangle(framePen, new Rectangle(0, 0, this.Width, this.Height));
            }

            // Draw centering crosshair
            e.Graphics.DrawLine(crosshairsPen, 0, this.Width / 2, this.Height / 2, this.Width);

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
