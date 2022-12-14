using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using JoystickVisualizer.Properties;


namespace JoystickVisualizer {
    public partial class Axis2D : UserControl {
        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_AxisCenterX = Settings.Default.Axis_CenterValue;
        private int m_AxisCenterY = Settings.Default.Axis_CenterValue;
        private int m_AxisMaximumX = Settings.Default.Axis_MaxValue;
        private int m_AxisMaximumY = Settings.Default.Axis_MaxValue;
        private int m_DotSize = Settings.Default.UI_Default_2dDotSize;
        private int m_XValue = Settings.Default.Axis_CenterValue;
        private int m_YValue = Settings.Default.Axis_CenterValue;
        private bool m_RenderFrame = true;
        private string m_Label = "";
        private Font labelFont = SystemFonts.DefaultFont;

        #region Public Properties
        public int AxisCenterX {
            get { return m_AxisCenterX; }
            set {
                m_AxisCenterX = value;
                this.Refresh();
            }
        }

        public int AxisCenterY {
            get { return m_AxisCenterY; }
            set {
                m_AxisCenterY = value;
                this.Refresh();
            }
        }

        public int AxisMaximumX {
            get { return m_AxisMaximumX; }
            set {
                m_AxisMaximumX = value;
                this.Refresh();
            }
        }

        public int AxisMaximumY {
            get { return m_AxisMaximumY; }
            set {
                m_AxisMaximumY = value;
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

        [Description("Sets the current X value"),
                Category("Control Defaults"),
                DefaultValue(32767),
                Browsable(true)]
        public int XValue {
            get { return m_XValue; }
            set {
                m_XValue = value;
                this.Refresh();
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

        #region Public functions
        public int GetDotSize() {
            return m_DotSize;
        }

        public void SetDotSize(int sizeInPixels) {
            m_DotSize = sizeInPixels;
            this.Refresh();
        }
        #endregion Public functions


        public Axis2D() {
            InitializeComponent();

            if (this.Enabled) {
                // Setup class members
                this.ResizeRedraw = true;
            }
        }

        #region Event Handlers
        private void Form_Paint(object sender, PaintEventArgs e) {
            if (this.Enabled) {
                // Draw the frame
                if (m_RenderFrame) {
                    //e.Graphics.FillRectangle(frameBrush, 0, 0, this.Width, this.Height);
                    e.Graphics.DrawRectangle(Globals.framePen, 0, 0, this.Width, this.Height);
                }

                // Draw centering crosshairs
                Globals.DrawCrosshairs(CrosshairDirection.Both, e.Graphics, ref Globals.crosshairsPen, this.Height, this.Width, m_DotSize, true, true);

                // Draw the dot
                e.Graphics.FillEllipse(Globals.dotBrush, MapValueToRangeX(m_XValue) + 1, MapValueToRangeY(m_YValue) + 1, m_DotSize - 2, m_DotSize - 2);

                // Draw the text label
                e.Graphics.DrawString(m_Label, labelFont, Globals.frameBrush, 2, 1);

                // Update the tooltip
                ToolTip = $"{this.Name}: ({XValue},{YValue})";
            }
        }

        private void Form_Resize(object sender, EventArgs e) {
            if (this.Enabled) {
                // Recalculate font size
                labelFont = new Font(
                    SystemFonts.DefaultFont.Name,
                    (this.ClientSize.Width < 110) ? SystemFonts.DefaultFont.Size - 2 : SystemFonts.DefaultFont.Size,
                    SystemFonts.DefaultFont.Style,
                    SystemFonts.DefaultFont.Unit,
                    SystemFonts.DefaultFont.GdiCharSet,
                    SystemFonts.DefaultFont.GdiVerticalFont);

                //this.Refresh();
            }
        }
        #endregion Event Handlers

        #region Private Methods
        private float MapValueToRangeX(int InputValue) {
            int MaxRightPosition = this.Width - m_DotSize;

            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxRightPosition * InputValue / m_AxisMaximumX;
            return positionExact;
        }

        private float MapValueToRangeY(int InputValue) {
            int MaxBottomPosition = this.Height - m_DotSize;

            // Formula to map input range to output range
            //   output = output_start + ((output_end - output_start) / (input_end - input_start)) * (value - input_start)

            float positionExact = MaxBottomPosition * InputValue / m_AxisMaximumY;
            return positionExact;
        }
        #endregion Private Methods
    }
}
