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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JoystickStatus));
            this.PollingTimer = new System.Windows.Forms.Timer(this.components);
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LeftThrottle = new JoystickVisualizer.Axis1DVertical();
            this.Left2D = new JoystickVisualizer.Axis2D();
            this.LeftTwist = new JoystickVisualizer.Axis1DHorizontal();
            this.lblLeftStick = new System.Windows.Forms.Label();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RightSlider = new JoystickVisualizer.Axis1DVertical();
            this.RightThrottle = new JoystickVisualizer.Axis1DVertical();
            this.Right2D = new JoystickVisualizer.Axis2D();
            this.RightTwist = new JoystickVisualizer.Axis1DHorizontal();
            this.lblRightStick = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.PanelLeft.SuspendLayout();
            this.PanelRight.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PollingTimer
            // 
            this.PollingTimer.Interval = 200;
            this.PollingTimer.Tick += new System.EventHandler(this.PollingTimer_Tick);
            // 
            // PanelLeft
            // 
            this.PanelLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelLeft.Controls.Add(this.label5);
            this.PanelLeft.Controls.Add(this.label4);
            this.PanelLeft.Controls.Add(this.label1);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Th";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(289, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Z";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "X,Y";
            // 
            // LeftThrottle
            // 
            this.LeftThrottle.CausesValidation = false;
            this.LeftThrottle.Location = new System.Drawing.Point(4, 145);
            this.LeftThrottle.Name = "LeftThrottle";
            this.LeftThrottle.Size = new System.Drawing.Size(20, 120);
            this.LeftThrottle.TabIndex = 8;
            this.LeftThrottle.ToolTip = "(\'32768\')";
            this.LeftThrottle.Value = 32768;
            // 
            // Left2D
            // 
            this.Left2D.Location = new System.Drawing.Point(44, 32);
            this.Left2D.Name = "Left2D";
            this.Left2D.Size = new System.Drawing.Size(220, 220);
            this.Left2D.TabIndex = 7;
            this.Left2D.ToolTip = "(\'32768\',\'32768\')";
            this.Left2D.XValue = 32768;
            this.Left2D.YValue = 32768;
            // 
            // LeftTwist
            // 
            this.LeftTwist.CausesValidation = false;
            this.LeftTwist.Location = new System.Drawing.Point(3, 272);
            this.LeftTwist.Name = "LeftTwist";
            this.LeftTwist.Size = new System.Drawing.Size(300, 20);
            this.LeftTwist.TabIndex = 4;
            this.LeftTwist.ToolTip = "(\'32768\')";
            this.LeftTwist.Value = 32768;
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
            this.PanelRight.Controls.Add(this.label7);
            this.PanelRight.Controls.Add(this.label6);
            this.PanelRight.Controls.Add(this.label3);
            this.PanelRight.Controls.Add(this.label2);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(283, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Slid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Th";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "X,Y";
            // 
            // RightSlider
            // 
            this.RightSlider.CausesValidation = false;
            this.RightSlider.Location = new System.Drawing.Point(283, 37);
            this.RightSlider.Name = "RightSlider";
            this.RightSlider.Size = new System.Drawing.Size(20, 120);
            this.RightSlider.TabIndex = 10;
            this.RightSlider.ToolTip = "(\'32768\')";
            this.RightSlider.Value = 32768;
            // 
            // RightThrottle
            // 
            this.RightThrottle.CausesValidation = false;
            this.RightThrottle.Location = new System.Drawing.Point(3, 145);
            this.RightThrottle.Name = "RightThrottle";
            this.RightThrottle.Size = new System.Drawing.Size(20, 120);
            this.RightThrottle.TabIndex = 9;
            this.RightThrottle.ToolTip = "(\'32768\')";
            this.RightThrottle.Value = 32768;
            // 
            // Right2D
            // 
            this.Right2D.Location = new System.Drawing.Point(43, 37);
            this.Right2D.Name = "Right2D";
            this.Right2D.Size = new System.Drawing.Size(220, 220);
            this.Right2D.TabIndex = 8;
            this.Right2D.ToolTip = "(\'32768\',\'32768\')";
            this.Right2D.XValue = 32768;
            this.Right2D.YValue = 32768;
            // 
            // RightTwist
            // 
            this.RightTwist.CausesValidation = false;
            this.RightTwist.Location = new System.Drawing.Point(3, 272);
            this.RightTwist.Name = "RightTwist";
            this.RightTwist.Size = new System.Drawing.Size(300, 20);
            this.RightTwist.TabIndex = 5;
            this.RightTwist.ToolTip = "(\'32768\')";
            this.RightTwist.Value = 32768;
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
            // JoystickStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(711, 326);
            this.Controls.Add(this.flowLayoutPanel1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JoystickStatus";
            this.Text = "Joystick Status";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.JoystickStatus_FormClosing);
            this.Load += new System.EventHandler(this.JoystickStatus_Load);
            this.PanelLeft.ResumeLayout(false);
            this.PanelLeft.PerformLayout();
            this.PanelRight.ResumeLayout(false);
            this.PanelRight.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

