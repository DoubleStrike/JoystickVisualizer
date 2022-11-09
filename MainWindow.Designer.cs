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
            this.compoundControl1 = new JoystickVisualizer.CompoundControl();
            this.SuspendLayout();
            // 
            // compoundControl1
            // 
            this.compoundControl1.BackColor = System.Drawing.SystemColors.InfoText;
            this.compoundControl1.Location = new System.Drawing.Point(12, 12);
            this.compoundControl1.Name = "compoundControl1";
            this.compoundControl1.Size = new System.Drawing.Size(331, 304);
            this.compoundControl1.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.compoundControl1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private CompoundControl compoundControl1;
    }
}