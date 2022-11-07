namespace JoystickVisualizer {
    partial class Axis1DHorizontal {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // Axis1DHorizontal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.DoubleBuffered = true;
            this.Name = "Axis1DHorizontal";
            this.Size = new System.Drawing.Size(200, 40);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Axis1D_Paint);
            this.Resize += new System.EventHandler(this.Axis1D_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
