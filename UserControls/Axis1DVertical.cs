using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using JoystickVisualizer.Properties;


namespace JoystickVisualizer {
    public partial class Axis1DVertical : UserControl {
        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_AxisCenter = Settings.Default.Axis_CenterValue;
        private int m_AxisMaximum = Settings.Default.Axis_MaxValue;
        private int m_Value = Settings.Default.Axis_CenterValue;
        private bool m_RenderFrame = true;
        private string m_Label = "";
        private StringFormat strF = new StringFormat();

        #region Public Properties
        public int AxisCenter {
            get { return m_AxisCenter; }
            set {
                m_AxisCenter = value;
                this.Refresh();
            }
        }

        public int AxisMaximum {
            get { return m_AxisMaximum; }
            set {
                m_AxisMaximum = value;
                this.Refresh();
            }
        }

        public string TextLabel {
            get {
                return m_Label;
            }
            set {
                m_Label = value;
            }
        }

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
                this.Refresh();
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
            }

            strF.Alignment = StringAlignment.Far;
        }

        #region Event Handlers
        private void Form_Paint(object sender, PaintEventArgs e) {
            if (this.Enabled) {
                // Draw the frame
                if (m_RenderFrame) {
                    //e.Graphics.FillRectangle(frameBrush, 0, 0, this.Width, this.Height);
                    e.Graphics.DrawRectangle(Globals.framePen, 0, 0, this.Width, this.Height);
                }

                // Draw centering crosshair
                Globals.DrawCrosshairs(CrosshairDirection.Horizontal, e.Graphics, ref Globals.crosshairsPen, this.Height, this.Width, 0, true, true);

                // Draw the dot
                e.Graphics.FillEllipse(Globals.dotBrush, 0, MapValueToRange(m_Value) + 1, this.Width - 2, this.Width - 2);

                // Draw the text label
                e.Graphics.TranslateTransform(14, 0);
                e.Graphics.RotateTransform(90);
                e.Graphics.DrawString(m_Label, SystemFonts.DefaultFont, Globals.frameBrush, 2, 1);

                // Update the tooltip
                ToolTip = $"({this.Name}: {Value})";
            }
        }

        private void Form_Resize(object sender, EventArgs e) {
            //if (this.Enabled) this.Refresh();
        }
        #endregion Event Handlers

        #region Private Methods
        private float MapValueToRange(int InputValue) {
            int MaxBottomPosition = this.Height - this.Width;

            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxBottomPosition * InputValue / m_AxisMaximum;
            return positionExact;
        }
        #endregion Private Methods
    }
}
