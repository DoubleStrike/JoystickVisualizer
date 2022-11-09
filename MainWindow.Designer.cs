namespace JoystickVisualizer {
    partial class MainWindow {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LeftStick = new JoystickVisualizer.CompoundControl();
            this.RightStick = new JoystickVisualizer.CompoundControl();
            this.FlowPanelCenter = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.spacer1 = new System.Windows.Forms.PictureBox();
            this.chkKeepOnTop = new System.Windows.Forms.CheckBox();
            this.spacer2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPollingTime = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.FlowPanelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spacer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spacer2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.LeftStick, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RightStick, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.FlowPanelCenter, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1144, 467);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // LeftStick
            // 
            this.LeftStick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftStick.Location = new System.Drawing.Point(3, 3);
            this.LeftStick.MinimumSize = new System.Drawing.Size(200, 200);
            this.LeftStick.Name = "LeftStick";
            this.LeftStick.Size = new System.Drawing.Size(466, 461);
            this.LeftStick.TabIndex = 0;
            // 
            // RightStick
            // 
            this.RightStick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightStick.Location = new System.Drawing.Point(675, 3);
            this.RightStick.MinimumSize = new System.Drawing.Size(200, 200);
            this.RightStick.Name = "RightStick";
            this.RightStick.Size = new System.Drawing.Size(466, 461);
            this.RightStick.TabIndex = 1;
            // 
            // FlowPanelCenter
            // 
            this.FlowPanelCenter.Controls.Add(this.lblTitle);
            this.FlowPanelCenter.Controls.Add(this.spacer1);
            this.FlowPanelCenter.Controls.Add(this.chkKeepOnTop);
            this.FlowPanelCenter.Controls.Add(this.spacer2);
            this.FlowPanelCenter.Controls.Add(this.label1);
            this.FlowPanelCenter.Controls.Add(this.txtPollingTime);
            this.FlowPanelCenter.Controls.Add(this.btnSet);
            this.FlowPanelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlowPanelCenter.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowPanelCenter.Location = new System.Drawing.Point(475, 3);
            this.FlowPanelCenter.Name = "FlowPanelCenter";
            this.FlowPanelCenter.Size = new System.Drawing.Size(194, 461);
            this.FlowPanelCenter.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Candara", 30F);
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(182, 98);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Joystick Visualizer";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // spacer1
            // 
            this.spacer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spacer1.Location = new System.Drawing.Point(44, 101);
            this.spacer1.Name = "spacer1";
            this.spacer1.Size = new System.Drawing.Size(100, 30);
            this.spacer1.TabIndex = 2;
            this.spacer1.TabStop = false;
            // 
            // chkKeepOnTop
            // 
            this.chkKeepOnTop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkKeepOnTop.AutoSize = true;
            this.chkKeepOnTop.Location = new System.Drawing.Point(49, 137);
            this.chkKeepOnTop.Name = "chkKeepOnTop";
            this.chkKeepOnTop.Size = new System.Drawing.Size(90, 17);
            this.chkKeepOnTop.TabIndex = 1;
            this.chkKeepOnTop.Text = "Keep On Top";
            this.chkKeepOnTop.UseVisualStyleBackColor = true;
            this.chkKeepOnTop.CheckedChanged += new System.EventHandler(this.chkKeepOnTop_CheckedChanged);
            // 
            // spacer2
            // 
            this.spacer2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.spacer2.Location = new System.Drawing.Point(44, 160);
            this.spacer2.Name = "spacer2";
            this.spacer2.Size = new System.Drawing.Size(100, 30);
            this.spacer2.TabIndex = 3;
            this.spacer2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 193);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Polling time (ms)";
            // 
            // txtPollingTime
            // 
            this.txtPollingTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPollingTime.Location = new System.Drawing.Point(44, 209);
            this.txtPollingTime.Name = "txtPollingTime";
            this.txtPollingTime.Size = new System.Drawing.Size(100, 20);
            this.txtPollingTime.TabIndex = 5;
            this.txtPollingTime.Text = "20";
            // 
            // btnSet
            // 
            this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSet.Location = new System.Drawing.Point(56, 235);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 6;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1144, 467);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(630, 250);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.FlowPanelCenter.ResumeLayout(false);
            this.FlowPanelCenter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spacer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spacer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CompoundControl LeftStick;
        private CompoundControl RightStick;
        private System.Windows.Forms.FlowLayoutPanel FlowPanelCenter;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox spacer1;
        private System.Windows.Forms.CheckBox chkKeepOnTop;
        private System.Windows.Forms.PictureBox spacer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPollingTime;
        private System.Windows.Forms.Button btnSet;
    }
}