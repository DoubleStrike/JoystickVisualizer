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
        int MaxRightPosition = 0;
        int m_Value = 32767;

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
        #endregion Public Properties


        public Axis1DHorizontal() {
            InitializeComponent();

            CalculateMaxPosition();
        }

        private void Axis1D_Paint(object sender, PaintEventArgs e) {
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.Graphics formGraphics;
            formGraphics = this.CreateGraphics();
            formGraphics.FillEllipse(myBrush, new Rectangle(MapValueToRange(), 0, this.Height, this.Height));
            myBrush.Dispose();
            formGraphics.Dispose();
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
            //output = output_start + ((output_end - output_start) / (input_end - input_start)) * (input - input_start)
            float positionExact = MaxRightPosition * Value / 65535;
            return (int)positionExact;
        }
    }
}
