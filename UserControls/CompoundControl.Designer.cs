namespace JoystickVisualizer {
    partial class CompoundControl {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.squareTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.topTableSection = new System.Windows.Forms.TableLayoutPanel();
            this.PollingTimer = new System.Windows.Forms.Timer(this.components);
            this.axisRotXRotY = new JoystickVisualizer.Axis2D();
            this.povHat1 = new JoystickVisualizer.PovHat();
            this.buttons1 = new JoystickVisualizer.Buttons();
            this.axisZ = new JoystickVisualizer.Axis1DVertical();
            this.axisSlider0 = new JoystickVisualizer.Axis1DVertical();
            this.axisSlider1 = new JoystickVisualizer.Axis1DVertical();
            this.axisRotZ = new JoystickVisualizer.Axis1DHorizontal();
            this.axisXY = new JoystickVisualizer.Axis2D();
            this.squareTableLayout.SuspendLayout();
            this.topTableSection.SuspendLayout();
            this.SuspendLayout();
            // 
            // squareTableLayout
            // 
            this.squareTableLayout.ColumnCount = 4;
            this.squareTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.squareTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.squareTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.squareTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.squareTableLayout.Controls.Add(this.topTableSection, 0, 0);
            this.squareTableLayout.Controls.Add(this.axisZ, 0, 1);
            this.squareTableLayout.Controls.Add(this.axisSlider0, 2, 1);
            this.squareTableLayout.Controls.Add(this.axisSlider1, 3, 1);
            this.squareTableLayout.Controls.Add(this.axisRotZ, 1, 2);
            this.squareTableLayout.Controls.Add(this.axisXY, 1, 1);
            this.squareTableLayout.Location = new System.Drawing.Point(0, 0);
            this.squareTableLayout.Name = "squareTableLayout";
            this.squareTableLayout.RowCount = 3;
            this.squareTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.squareTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.squareTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.squareTableLayout.Size = new System.Drawing.Size(344, 367);
            this.squareTableLayout.TabIndex = 0;
            // 
            // topTableSection
            // 
            this.topTableSection.ColumnCount = 5;
            this.squareTableLayout.SetColumnSpan(this.topTableSection, 4);
            this.topTableSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topTableSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topTableSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topTableSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topTableSection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.topTableSection.Controls.Add(this.axisRotXRotY, 2, 0);
            this.topTableSection.Controls.Add(this.povHat1, 4, 0);
            this.topTableSection.Controls.Add(this.buttons1, 0, 0);
            this.topTableSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topTableSection.Location = new System.Drawing.Point(3, 3);
            this.topTableSection.Name = "topTableSection";
            this.topTableSection.RowCount = 1;
            this.topTableSection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topTableSection.Size = new System.Drawing.Size(338, 67);
            this.topTableSection.TabIndex = 1;
            // 
            // PollingTimer
            // 
            this.PollingTimer.Tick += new System.EventHandler(this.PollingTimer_Tick);
            // 
            // axisRotXRotY
            // 
            this.axisRotXRotY.AxisCenterX = 32767;
            this.axisRotXRotY.AxisCenterY = 32767;
            this.axisRotXRotY.AxisMaximumX = 65535;
            this.axisRotXRotY.AxisMaximumY = 65535;
            this.axisRotXRotY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisRotXRotY.Location = new System.Drawing.Point(114, 0);
            this.axisRotXRotY.Margin = new System.Windows.Forms.Padding(0);
            this.axisRotXRotY.Name = "axisRotXRotY";
            this.axisRotXRotY.Size = new System.Drawing.Size(110, 67);
            this.axisRotXRotY.TabIndex = 9;
            this.axisRotXRotY.TextLabel = "";
            this.axisRotXRotY.ToolTip = "Axis2D: (32767,32767)";
            // 
            // povHat1
            // 
            this.povHat1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.povHat1.Location = new System.Drawing.Point(224, 0);
            this.povHat1.Margin = new System.Windows.Forms.Padding(0);
            this.povHat1.Name = "povHat1";
            this.povHat1.Size = new System.Drawing.Size(114, 67);
            this.povHat1.TabIndex = 8;
            this.povHat1.TextLabel = "";
            this.povHat1.ToolTip = "(PovHat: 32767)";
            this.povHat1.Value = 32767;
            // 
            // buttons1
            // 
            this.buttons1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttons1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttons1.Location = new System.Drawing.Point(0, 0);
            this.buttons1.Margin = new System.Windows.Forms.Padding(0);
            this.buttons1.Name = "buttons1";
            this.buttons1.Size = new System.Drawing.Size(114, 67);
            this.buttons1.TabIndex = 1;
            this.buttons1.TextLabel = "B";
            this.buttons1.ToolTip = "(Buttons: Button states 0-16)";
            // 
            // axisZ
            // 
            this.axisZ.AxisCenter = 32767;
            this.axisZ.AxisMaximum = 65535;
            this.axisZ.CausesValidation = false;
            this.axisZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisZ.Location = new System.Drawing.Point(3, 76);
            this.axisZ.Name = "axisZ";
            this.axisZ.Size = new System.Drawing.Size(28, 250);
            this.axisZ.TabIndex = 0;
            this.axisZ.TextLabel = "";
            this.axisZ.ToolTip = "(Axis1DVertical: 32767)";
            // 
            // axisSlider0
            // 
            this.axisSlider0.AxisCenter = 32767;
            this.axisSlider0.AxisMaximum = 65535;
            this.axisSlider0.CausesValidation = false;
            this.axisSlider0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisSlider0.Location = new System.Drawing.Point(277, 76);
            this.axisSlider0.Name = "axisSlider0";
            this.axisSlider0.Size = new System.Drawing.Size(28, 250);
            this.axisSlider0.TabIndex = 1;
            this.axisSlider0.TextLabel = "";
            this.axisSlider0.ToolTip = "(Axis1DVertical: 32767)";
            // 
            // axisSlider1
            // 
            this.axisSlider1.AxisCenter = 32767;
            this.axisSlider1.AxisMaximum = 65535;
            this.axisSlider1.CausesValidation = false;
            this.axisSlider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisSlider1.Location = new System.Drawing.Point(311, 76);
            this.axisSlider1.Name = "axisSlider1";
            this.axisSlider1.Size = new System.Drawing.Size(30, 250);
            this.axisSlider1.TabIndex = 2;
            this.axisSlider1.TextLabel = "";
            this.axisSlider1.ToolTip = "(Axis1DVertical: 32767)";
            // 
            // axisRotZ
            // 
            this.axisRotZ.AxisCenter = 32767;
            this.axisRotZ.AxisMaximum = 65535;
            this.axisRotZ.CausesValidation = false;
            this.axisRotZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisRotZ.Location = new System.Drawing.Point(37, 332);
            this.axisRotZ.Name = "axisRotZ";
            this.axisRotZ.Size = new System.Drawing.Size(234, 32);
            this.axisRotZ.TabIndex = 3;
            this.axisRotZ.TextLabel = "";
            this.axisRotZ.ToolTip = "(Axis1DHorizontal: 32767)";
            // 
            // axisXY
            // 
            this.axisXY.AxisCenterX = 32767;
            this.axisXY.AxisCenterY = 32767;
            this.axisXY.AxisMaximumX = 65535;
            this.axisXY.AxisMaximumY = 65535;
            this.axisXY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisXY.Location = new System.Drawing.Point(37, 76);
            this.axisXY.Name = "axisXY";
            this.axisXY.Size = new System.Drawing.Size(234, 250);
            this.axisXY.TabIndex = 5;
            this.axisXY.TextLabel = "";
            this.axisXY.ToolTip = "Axis2D: (32767,32767)";
            // 
            // CompoundControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.squareTableLayout);
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "CompoundControl";
            this.Size = new System.Drawing.Size(347, 370);
            this.Load += new System.EventHandler(this.CompoundControl_Load);
            this.Resize += new System.EventHandler(this.CompoundControl_Resize);
            this.squareTableLayout.ResumeLayout(false);
            this.topTableSection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel squareTableLayout;
        private Axis1DVertical axisZ;
        private Axis1DVertical axisSlider0;
        private Axis1DVertical axisSlider1;
        private Axis1DHorizontal axisRotZ;
        private Axis2D axisXY;
        private System.Windows.Forms.Timer PollingTimer;
        private Buttons buttons1;
        private System.Windows.Forms.TableLayoutPanel topTableSection;
        private Axis2D axisRotXRotY;
        private PovHat povHat1;
    }
}