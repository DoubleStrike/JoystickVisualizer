namespace JoystickVisualizer {
    partial class JoystickStatus {
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
            this.PollingTimer = new System.Windows.Forms.Timer(this.components);
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.lblLeftStick = new System.Windows.Forms.Label();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.lblRightStick = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.LeftThrottle = new JoystickVisualizer.Axis1DVertical();
            this.Left2D = new JoystickVisualizer.Axis2D();
            this.LeftTwist = new JoystickVisualizer.Axis1DHorizontal();
            this.RightSlider = new JoystickVisualizer.Axis1DVertical();
            this.RightThrottle = new JoystickVisualizer.Axis1DVertical();
            this.Right2D = new JoystickVisualizer.Axis2D();
            this.RightTwist = new JoystickVisualizer.Axis1DHorizontal();
            this.PanelLeft.SuspendLayout();
            this.PanelRight.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PollingTimer
            // 
            this.PollingTimer.Enabled = true;
            this.PollingTimer.Interval = 200;
            this.PollingTimer.Tick += new System.EventHandler(this.PollingTimer_Tick);
            // 
            // PanelLeft
            // 
            this.PanelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLeft.Controls.Add(this.LeftThrottle);
            this.PanelLeft.Controls.Add(this.Left2D);
            this.PanelLeft.Controls.Add(this.LeftTwist);
            this.PanelLeft.Controls.Add(this.lblLeftStick);
            this.PanelLeft.Location = new System.Drawing.Point(15, 15);
            this.PanelLeft.Margin = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(308, 296);
            this.PanelLeft.TabIndex = 0;
            // 
            // lblLeftStick
            // 
            this.lblLeftStick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLeftStick.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeftStick.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblLeftStick.Location = new System.Drawing.Point(4, 0);
            this.lblLeftStick.Name = "lblLeftStick";
            this.lblLeftStick.Size = new System.Drawing.Size(300, 29);
            this.lblLeftStick.TabIndex = 0;
            this.lblLeftStick.Text = "Left Stick";
            this.lblLeftStick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PanelRight
            // 
            this.PanelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRight.Controls.Add(this.RightSlider);
            this.PanelRight.Controls.Add(this.RightThrottle);
            this.PanelRight.Controls.Add(this.Right2D);
            this.PanelRight.Controls.Add(this.RightTwist);
            this.PanelRight.Controls.Add(this.lblRightStick);
            this.PanelRight.Location = new System.Drawing.Point(384, 15);
            this.PanelRight.Margin = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(308, 296);
            this.PanelRight.TabIndex = 1;
            // 
            // lblRightStick
            // 
            this.lblRightStick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRightStick.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRightStick.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lblRightStick.Location = new System.Drawing.Point(3, 0);
            this.lblRightStick.Name = "lblRightStick";
            this.lblRightStick.Size = new System.Drawing.Size(300, 31);
            this.lblRightStick.TabIndex = 2;
            this.lblRightStick.Text = "Right Stick";
            this.lblRightStick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.PanelLeft);
            this.flowLayoutPanel1.Controls.Add(this.AlwaysOnTop);
            this.flowLayoutPanel1.Controls.Add(this.PanelRight);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(711, 326);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // AlwaysOnTop
            // 
            this.AlwaysOnTop.AutoSize = true;
            this.AlwaysOnTop.Location = new System.Drawing.Point(346, 8);
            this.AlwaysOnTop.Name = "AlwaysOnTop";
            this.AlwaysOnTop.Size = new System.Drawing.Size(15, 14);
            this.AlwaysOnTop.TabIndex = 2;
            this.AlwaysOnTop.UseVisualStyleBackColor = true;
            this.AlwaysOnTop.CheckedChanged += new System.EventHandler(this.AlwaysOnTop_CheckedChanged);
            // 
            // LeftThrottle
            // 
            this.LeftThrottle.CausesValidation = false;
            this.LeftThrottle.Location = new System.Drawing.Point(4, 145);
            this.LeftThrottle.Name = "LeftThrottle";
            this.LeftThrottle.Size = new System.Drawing.Size(20, 120);
            this.LeftThrottle.TabIndex = 8;
            // 
            // Left2D
            // 
            this.Left2D.Location = new System.Drawing.Point(44, 32);
            this.Left2D.Name = "Left2D";
            this.Left2D.Size = new System.Drawing.Size(220, 220);
            this.Left2D.TabIndex = 7;
            // 
            // LeftTwist
            // 
            this.LeftTwist.CausesValidation = false;
            this.LeftTwist.Location = new System.Drawing.Point(3, 272);
            this.LeftTwist.Name = "LeftTwist";
            this.LeftTwist.Size = new System.Drawing.Size(300, 20);
            this.LeftTwist.TabIndex = 4;
            // 
            // RightSlider
            // 
            this.RightSlider.CausesValidation = false;
            this.RightSlider.Location = new System.Drawing.Point(283, 37);
            this.RightSlider.Name = "RightSlider";
            this.RightSlider.Size = new System.Drawing.Size(20, 120);
            this.RightSlider.TabIndex = 10;
            // 
            // RightThrottle
            // 
            this.RightThrottle.CausesValidation = false;
            this.RightThrottle.Location = new System.Drawing.Point(3, 145);
            this.RightThrottle.Name = "RightThrottle";
            this.RightThrottle.Size = new System.Drawing.Size(20, 120);
            this.RightThrottle.TabIndex = 9;
            // 
            // Right2D
            // 
            this.Right2D.Location = new System.Drawing.Point(43, 37);
            this.Right2D.Name = "Right2D";
            this.Right2D.Size = new System.Drawing.Size(220, 220);
            this.Right2D.TabIndex = 8;
            // 
            // RightTwist
            // 
            this.RightTwist.CausesValidation = false;
            this.RightTwist.Location = new System.Drawing.Point(3, 272);
            this.RightTwist.Name = "RightTwist";
            this.RightTwist.Size = new System.Drawing.Size(300, 20);
            this.RightTwist.TabIndex = 5;
            // 
            // JoystickStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(711, 326);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "JoystickStatus";
            this.Text = "Joystick Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PanelLeft.ResumeLayout(false);
            this.PanelRight.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer PollingTimer;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Label lblLeftStick;
        private System.Windows.Forms.Label lblRightStick;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Axis1DHorizontal LeftTwist;
        private Axis1DHorizontal RightTwist;
        private Axis2D Left2D;
        private Axis2D Right2D;
        private System.Windows.Forms.CheckBox AlwaysOnTop;
        private Axis1DVertical LeftThrottle;
        private Axis1DVertical RightSlider;
        private Axis1DVertical RightThrottle;
    }
}

