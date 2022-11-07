namespace JoystickVisualizer {
    partial class Axis1D {
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
            this.OuterFrame = new ShapeControl.ShapeControl();
            this.InnerDot = new ShapeControl.ShapeControl();
            this.SuspendLayout();
            // 
            // OuterFrame
            // 
            this.OuterFrame.AnimateBorder = false;
            this.OuterFrame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OuterFrame.Blink = false;
            this.OuterFrame.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.OuterFrame.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.OuterFrame.BorderWidth = 3;
            this.OuterFrame.CenterColor = System.Drawing.Color.White;
            this.OuterFrame.Connector = ShapeControl.ConnecterType.Center;
            this.OuterFrame.Direction = ShapeControl.LineDirection.None;
            this.OuterFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OuterFrame.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.OuterFrame.Location = new System.Drawing.Point(0, 0);
            this.OuterFrame.Name = "OuterFrame";
            this.OuterFrame.Shape = ShapeControl.ShapeType.Rectangle;
            this.OuterFrame.ShapeImage = null;
            this.OuterFrame.ShapeImageRotation = 0;
            this.OuterFrame.ShapeImageTexture = null;
            this.OuterFrame.ShapeStorageLoadFile = "";
            this.OuterFrame.ShapeStorageSaveFile = "";
            this.OuterFrame.Size = new System.Drawing.Size(200, 40);
            this.OuterFrame.SurroundColor = System.Drawing.Color.White;
            this.OuterFrame.TabIndex = 0;
            this.OuterFrame.Tag2 = "";
            this.OuterFrame.UseGradient = true;
            this.OuterFrame.Vibrate = false;
            // 
            // InnerDot
            // 
            this.InnerDot.AnimateBorder = false;
            this.InnerDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.InnerDot.Blink = false;
            this.InnerDot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.InnerDot.BorderStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.InnerDot.BorderWidth = 0;
            this.InnerDot.CenterColor = System.Drawing.Color.Black;
            this.InnerDot.Connector = ShapeControl.ConnecterType.Center;
            this.InnerDot.Direction = ShapeControl.LineDirection.None;
            this.InnerDot.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.InnerDot.Location = new System.Drawing.Point(34, 0);
            this.InnerDot.Name = "InnerDot";
            this.InnerDot.Shape = ShapeControl.ShapeType.Ellipse;
            this.InnerDot.ShapeImage = null;
            this.InnerDot.ShapeImageRotation = 0;
            this.InnerDot.ShapeImageTexture = null;
            this.InnerDot.ShapeStorageLoadFile = "";
            this.InnerDot.ShapeStorageSaveFile = "";
            this.InnerDot.Size = new System.Drawing.Size(40, 40);
            this.InnerDot.SurroundColor = System.Drawing.Color.Black;
            this.InnerDot.TabIndex = 1;
            this.InnerDot.Tag2 = "";
            this.InnerDot.UseGradient = true;
            this.InnerDot.Vibrate = false;
            this.InnerDot.Paint += new System.Windows.Forms.PaintEventHandler(this.InnerDot_Paint);
            // 
            // Axis1D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.InnerDot);
            this.Controls.Add(this.OuterFrame);
            this.Name = "Axis1D";
            this.Size = new System.Drawing.Size(200, 40);
            this.Resize += new System.EventHandler(this.Axis1D_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ShapeControl.ShapeControl OuterFrame;
        private ShapeControl.ShapeControl InnerDot;
    }
}
