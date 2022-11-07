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
            this.RightStickY = new System.Windows.Forms.VScrollBar();
            this.RightStickX = new System.Windows.Forms.HScrollBar();
            this.lblRightStick = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.LeftRoll = new JoystickVisualizer.Axis1DHorizontal();
            this.LeftPitch = new JoystickVisualizer.Axis1DVertical();
            this.LeftTwist = new JoystickVisualizer.Axis1DHorizontal();
            this.RightTwist = new JoystickVisualizer.Axis1DHorizontal();
            this.Left2D = new JoystickVisualizer.Axis2D();
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
            this.PanelLeft.Controls.Add(this.Left2D);
            this.PanelLeft.Controls.Add(this.LeftRoll);
            this.PanelLeft.Controls.Add(this.LeftPitch);
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
            this.lblLeftStick.Location = new System.Drawing.Point(3, 0);
            this.lblLeftStick.Name = "lblLeftStick";
            this.lblLeftStick.Size = new System.Drawing.Size(300, 29);
            this.lblLeftStick.TabIndex = 0;
            this.lblLeftStick.Text = "Left Stick";
            this.lblLeftStick.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PanelRight
            // 
            this.PanelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelRight.Controls.Add(this.RightTwist);
            this.PanelRight.Controls.Add(this.RightStickY);
            this.PanelRight.Controls.Add(this.RightStickX);
            this.PanelRight.Controls.Add(this.lblRightStick);
            this.PanelRight.Location = new System.Drawing.Point(363, 15);
            this.PanelRight.Margin = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(308, 296);
            this.PanelRight.TabIndex = 1;
            // 
            // RightStickY
            // 
            this.RightStickY.Location = new System.Drawing.Point(151, 31);
            this.RightStickY.Maximum = 65535;
            this.RightStickY.Name = "RightStickY";
            this.RightStickY.Size = new System.Drawing.Size(17, 250);
            this.RightStickY.TabIndex = 4;
            // 
            // RightStickX
            // 
            this.RightStickX.Location = new System.Drawing.Point(32, 143);
            this.RightStickX.Maximum = 65535;
            this.RightStickX.Name = "RightStickX";
            this.RightStickX.Size = new System.Drawing.Size(250, 17);
            this.RightStickX.TabIndex = 3;
            // 
            // lblRightStick
            // 
            this.lblRightStick.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRightStick.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.flowLayoutPanel1.Controls.Add(this.PanelRight);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(690, 326);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // LeftRoll
            // 
            this.LeftRoll.CausesValidation = false;
            this.LeftRoll.DotColor = "Black";
            this.LeftRoll.FrameColor = "Blue";
            this.LeftRoll.Location = new System.Drawing.Point(35, 231);
            this.LeftRoll.Name = "LeftRoll";
            this.LeftRoll.Size = new System.Drawing.Size(200, 20);
            this.LeftRoll.TabIndex = 6;
            // 
            // LeftPitch
            // 
            this.LeftPitch.CausesValidation = false;
            this.LeftPitch.DotColor = "Black";
            this.LeftPitch.FrameColor = "Blue";
            this.LeftPitch.Location = new System.Drawing.Point(241, 51);
            this.LeftPitch.Name = "LeftPitch";
            this.LeftPitch.Size = new System.Drawing.Size(20, 200);
            this.LeftPitch.TabIndex = 5;
            // 
            // LeftTwist
            // 
            this.LeftTwist.CausesValidation = false;
            this.LeftTwist.DotColor = "Black";
            this.LeftTwist.FrameColor = "Blue";
            this.LeftTwist.Location = new System.Drawing.Point(3, 272);
            this.LeftTwist.Name = "LeftTwist";
            this.LeftTwist.Size = new System.Drawing.Size(300, 20);
            this.LeftTwist.TabIndex = 4;
            // 
            // RightTwist
            // 
            this.RightTwist.CausesValidation = false;
            this.RightTwist.DotColor = "Black";
            this.RightTwist.FrameColor = "Blue";
            this.RightTwist.Location = new System.Drawing.Point(3, 272);
            this.RightTwist.Name = "RightTwist";
            this.RightTwist.Size = new System.Drawing.Size(300, 20);
            this.RightTwist.TabIndex = 5;
            // 
            // Left2D
            // 
            this.Left2D.DotColor = "Black";
            this.Left2D.FrameColor = "Blue";
            this.Left2D.Location = new System.Drawing.Point(35, 51);
            this.Left2D.Name = "Left2D";
            this.Left2D.Size = new System.Drawing.Size(150, 150);
            this.Left2D.TabIndex = 7;
            // 
            // JoystickStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 326);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer PollingTimer;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Label lblLeftStick;
        private System.Windows.Forms.Label lblRightStick;
        private System.Windows.Forms.HScrollBar RightStickX;
        private System.Windows.Forms.VScrollBar RightStickY;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Axis1DHorizontal LeftTwist;
        private Axis1DHorizontal RightTwist;
        private Axis1DVertical LeftPitch;
        private Axis1DHorizontal LeftRoll;
        private Axis2D Left2D;
    }
}

