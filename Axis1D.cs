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
    public partial class Axis1D : UserControl {
        bool InitialPaintDone = false;
        int MaxRightPosition = 0;

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
            get;
            set;
        }
        #endregion Public Properties


        public Axis1D() {
            InitializeComponent();

            CalculateMaxPosition();
        }

        private void Axis1D_Resize(object sender, EventArgs e) {
            CalculateMaxPosition();
        }

        private void InnerDot_Paint(object sender, PaintEventArgs e) {
            // Only center it the first time the control is painted
            if (!InitialPaintDone) {
                CenterTheDot();
                InitialPaintDone = true;
            }

            InnerDot.Left = MapValueToRange();
        }

        private void CenterTheDot() {
            // Set the width and height of the dot to match the frame height to keep it circular
            InnerDot.Height = InnerDot.Width = OuterFrame.Height;

            InnerDot.Left = MapValueToRange();
            InnerDot.Top = 0;
        }

        private void CalculateMaxPosition() {
            MaxRightPosition = OuterFrame.Width - OuterFrame.Height;
        }

        private int MapValueToRange() {
            //output = output_start + ((output_end - output_start) / (input_end - input_start)) * (input - input_start)

            return MaxRightPosition * (Value / 65535);
        }
    }
}
