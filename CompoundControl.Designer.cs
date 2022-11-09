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
            this.squareTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.axisZ = new JoystickVisualizer.Axis1DVertical();
            this.axisSlider0 = new JoystickVisualizer.Axis1DVertical();
            this.axisSlider1 = new JoystickVisualizer.Axis1DVertical();
            this.axisRotZ = new JoystickVisualizer.Axis1DHorizontal();
            this.axisXY = new JoystickVisualizer.Axis2D();
            this.axisRotXRotY = new JoystickVisualizer.Axis2D();
            this.squareTableLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // squareTableLayout
            // 
            this.squareTableLayout.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.squareTableLayout.ColumnCount = 4;
            this.squareTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.squareTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.squareTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.squareTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.squareTableLayout.Controls.Add(this.axisZ, 0, 1);
            this.squareTableLayout.Controls.Add(this.axisSlider0, 2, 1);
            this.squareTableLayout.Controls.Add(this.axisSlider1, 3, 1);
            this.squareTableLayout.Controls.Add(this.axisRotZ, 1, 2);
            this.squareTableLayout.Controls.Add(this.axisXY, 1, 1);
            this.squareTableLayout.Controls.Add(this.axisRotXRotY, 1, 0);
            this.squareTableLayout.Location = new System.Drawing.Point(0, 0);
            this.squareTableLayout.Name = "squareTableLayout";
            this.squareTableLayout.RowCount = 3;
            this.squareTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.squareTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.squareTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.squareTableLayout.Size = new System.Drawing.Size(362, 344);
            this.squareTableLayout.TabIndex = 0;
            // 
            // axisZ
            // 
            this.axisZ.CausesValidation = false;
            this.axisZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisZ.Location = new System.Drawing.Point(3, 63);
            this.axisZ.Name = "axisZ";
            this.axisZ.Size = new System.Drawing.Size(24, 248);
            this.axisZ.TabIndex = 0;
            this.axisZ.ToolTip = "(\'32768\')";
            this.axisZ.Value = 32768;
            // 
            // axisSlider0
            // 
            this.axisSlider0.CausesValidation = false;
            this.axisSlider0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisSlider0.Location = new System.Drawing.Point(305, 63);
            this.axisSlider0.Name = "axisSlider0";
            this.axisSlider0.Size = new System.Drawing.Size(24, 248);
            this.axisSlider0.TabIndex = 1;
            this.axisSlider0.ToolTip = "(\'32768\')";
            this.axisSlider0.Value = 32768;
            // 
            // axisSlider1
            // 
            this.axisSlider1.CausesValidation = false;
            this.axisSlider1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisSlider1.Location = new System.Drawing.Point(335, 63);
            this.axisSlider1.Name = "axisSlider1";
            this.axisSlider1.Size = new System.Drawing.Size(24, 248);
            this.axisSlider1.TabIndex = 2;
            this.axisSlider1.ToolTip = "(\'32768\')";
            this.axisSlider1.Value = 32768;
            // 
            // axisRotZ
            // 
            this.axisRotZ.CausesValidation = false;
            this.axisRotZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisRotZ.Location = new System.Drawing.Point(33, 317);
            this.axisRotZ.Name = "axisRotZ";
            this.axisRotZ.Size = new System.Drawing.Size(266, 24);
            this.axisRotZ.TabIndex = 3;
            this.axisRotZ.ToolTip = "(\'32768\')";
            this.axisRotZ.Value = 32768;
            // 
            // axisXY
            // 
            this.axisXY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axisXY.Location = new System.Drawing.Point(33, 63);
            this.axisXY.Name = "axisXY";
            this.axisXY.Size = new System.Drawing.Size(266, 248);
            this.axisXY.TabIndex = 5;
            this.axisXY.ToolTip = "(\'32768\',\'32768\')";
            this.axisXY.XValue = 32768;
            this.axisXY.YValue = 32768;
            // 
            // axisRotXRotY
            // 
            this.axisRotXRotY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.axisRotXRotY.Location = new System.Drawing.Point(136, 3);
            this.axisRotXRotY.Name = "axisRotXRotY";
            this.axisRotXRotY.Size = new System.Drawing.Size(59, 54);
            this.axisRotXRotY.TabIndex = 6;
            this.axisRotXRotY.ToolTip = "(\'32768\',\'32768\')";
            this.axisRotXRotY.XValue = 32768;
            this.axisRotXRotY.YValue = 32768;
            // 
            // CompoundControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(991, 722);
            this.Controls.Add(this.squareTableLayout);
            this.Name = "CompoundControl";
            this.Text = "CompoundControl";
            this.Load += new System.EventHandler(this.CompoundControl_Load);
            this.Resize += new System.EventHandler(this.CompoundControl_Resize);
            this.squareTableLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel squareTableLayout;
        private Axis1DVertical axisZ;
        private Axis1DVertical axisSlider0;
        private Axis1DVertical axisSlider1;
        private Axis1DHorizontal axisRotZ;
        private Axis2D axisXY;
        private Axis2D axisRotXRotY;
    }
}