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
            this.LeftStickZ = new System.Windows.Forms.HScrollBar();
            this.LeftStickY = new System.Windows.Forms.VScrollBar();
            this.LeftStickX = new System.Windows.Forms.HScrollBar();
            this.lblLeftStick = new System.Windows.Forms.Label();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.RightStickZ = new System.Windows.Forms.HScrollBar();
            this.RightStickY = new System.Windows.Forms.VScrollBar();
            this.RightStickX = new System.Windows.Forms.HScrollBar();
            this.lblRightStick = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.axis1D1 = new JoystickVisualizer.Axis1D();
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
            this.PanelLeft.Controls.Add(this.axis1D1);
            this.PanelLeft.Controls.Add(this.LeftStickZ);
            this.PanelLeft.Controls.Add(this.LeftStickY);
            this.PanelLeft.Controls.Add(this.LeftStickX);
            this.PanelLeft.Controls.Add(this.lblLeftStick);
            this.PanelLeft.Location = new System.Drawing.Point(15, 15);
            this.PanelLeft.Margin = new System.Windows.Forms.Padding(10, 10, 20, 10);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(308, 296);
            this.PanelLeft.TabIndex = 0;
            // 
            // LeftStickZ
            // 
            this.LeftStickZ.Location = new System.Drawing.Point(24, 278);
            this.LeftStickZ.Maximum = 65535;
            this.LeftStickZ.Name = "LeftStickZ";
            this.LeftStickZ.Size = new System.Drawing.Size(250, 17);
            this.LeftStickZ.TabIndex = 3;
            // 
            // LeftStickY
            // 
            this.LeftStickY.Location = new System.Drawing.Point(142, 29);
            this.LeftStickY.Maximum = 65535;
            this.LeftStickY.Name = "LeftStickY";
            this.LeftStickY.Size = new System.Drawing.Size(17, 250);
            this.LeftStickY.TabIndex = 2;
            // 
            // LeftStickX
            // 
            this.LeftStickX.Location = new System.Drawing.Point(24, 143);
            this.LeftStickX.Maximum = 65535;
            this.LeftStickX.Name = "LeftStickX";
            this.LeftStickX.Size = new System.Drawing.Size(250, 17);
            this.LeftStickX.TabIndex = 1;
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
            this.PanelRight.Controls.Add(this.RightStickZ);
            this.PanelRight.Controls.Add(this.RightStickY);
            this.PanelRight.Controls.Add(this.RightStickX);
            this.PanelRight.Controls.Add(this.lblRightStick);
            this.PanelRight.Location = new System.Drawing.Point(363, 15);
            this.PanelRight.Margin = new System.Windows.Forms.Padding(20, 10, 10, 10);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(308, 296);
            this.PanelRight.TabIndex = 1;
            // 
            // RightStickZ
            // 
            this.RightStickZ.Location = new System.Drawing.Point(32, 277);
            this.RightStickZ.Maximum = 65535;
            this.RightStickZ.Name = "RightStickZ";
            this.RightStickZ.Size = new System.Drawing.Size(250, 17);
            this.RightStickZ.TabIndex = 5;
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
            // axis1D1
            // 
            this.axis1D1.Location = new System.Drawing.Point(24, 199);
            this.axis1D1.Name = "axis1D1";
            this.axis1D1.Size = new System.Drawing.Size(200, 40);
            this.axis1D1.TabIndex = 4;
            // 
            // JoystickStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 326);
            this.Controls.Add(this.flowLayoutPanel1);
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
        private System.Windows.Forms.HScrollBar LeftStickX;
        private System.Windows.Forms.VScrollBar LeftStickY;
        private System.Windows.Forms.HScrollBar LeftStickZ;
        private System.Windows.Forms.HScrollBar RightStickX;
        private System.Windows.Forms.VScrollBar RightStickY;
        private System.Windows.Forms.HScrollBar RightStickZ;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Axis1D axis1D1;
    }
}

