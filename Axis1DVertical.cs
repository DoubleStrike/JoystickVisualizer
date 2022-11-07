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

        private int MaxBottomPosition = 0;
        private int m_Value = 32767;
        private Color m_DotColor = Color.Black;
        private Color m_FrameColor = Color.Blue;

        #region Public Properties
        [Description("Sets the Minimum value"),
                Category("Control Defaults"),
                DefaultValue(0),
                Browsable(true)]
        public int Minimum {
            get;
            set;
        }

        [Description("Sets the Maximum value"),
                Category("Control Defaults"),
                DefaultValue(65535),
                Browsable(true)]
        public int Maximum {
            get;
            set;
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

        [Description("HTML color code of the frame color"),
                Category("Control Defaults"),
                DefaultValue("#0000ff"),
                Browsable(true)]
        public string FrameColor {
            get { return ColorTranslator.ToHtml(m_FrameColor); }
            set { m_FrameColor = (value == "") ? Color.Aquamarine : ColorTranslator.FromHtml(value); }
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

            CalculateMaxPosition();
        }

        private void Axis1D_Paint(object sender, PaintEventArgs e) {

            SolidBrush dotBrush = new SolidBrush(m_DotColor);
            //SolidBrush frameBrush = new SolidBrush(m_FrameColor);
            Pen framePen = new Pen(m_FrameColor, BORDER_THICKNESS);
            Graphics formGraphics = this.CreateGraphics();

            // Draw the frame
            //formGraphics.FillRectangle(frameBrush, new Rectangle(0, 0, this.Width, this.Height));
            formGraphics.DrawRectangle(framePen, new Rectangle(0, 0, this.Width, this.Height));

            // Draw the dot
            formGraphics.FillEllipse(dotBrush, new Rectangle(0, MapValueToRange(), this.Width, this.Width));

            dotBrush.Dispose();
            formGraphics.Dispose();
        }

        private void Axis1D_Resize(object sender, EventArgs e) {
            CalculateMaxPosition();
            this.Invalidate();
            this.Update();
        }

        private void CalculateMaxPosition() {
            MaxBottomPosition = this.Height - this.Width;
        }

        private int MapValueToRange() {
            //output = output_start + ((output_end - output_start) / (input_end - input_start)) * (input - input_start)
            float positionExact = MaxBottomPosition * Value / 65535;
            return (int)positionExact;
        }
    }
}