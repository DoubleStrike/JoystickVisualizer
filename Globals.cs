using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoystickVisualizer {
    internal class Globals {
        #region Variables
        public const int DEFAULT_AXIS_VALUE = 32768;
        public const int MAX_AXIS_VALUE = 65535;
        public const int BORDER_THICKNESS = 4;
        public const int CROSSHAIR_THICKNESS = 1;
        public const int DOT_SIZE = 20;

        public readonly static Color DEFAULT_DOT_COLOR = SystemColors.HotTrack;
        public readonly static Color DEFAULT_FRAME_COLOR = SystemColors.Info;

        public readonly static DashStyle CenterLineDashStyle = DashStyle.DashDot;
        public readonly static DashStyle DotWidthLineDashStyle = DashStyle.Dot;
        public readonly static float[] CenterDashValues = { 5, 10 };
        public readonly static float[] DotWidthDashValues = { 1, 2 };

        public enum CrosshairDirection {
            Vertical = 0,
            Horizontal = 1,
            Both = 2,
        }
        #endregion Variables

        #region External Calls
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn
         (int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(System.IntPtr hObject);
        #endregion External Calls

        #region Methods
        /// <summary>
        /// Draws a set of center and dot-width crosshairs
        /// </summary>
        /// <param name="direction">The Globals.CrosshairDirection to draw: Vertical, Horizontal, or Both</param>
        /// <param name="drawingSurface">A reference to a form's drawing surface</param>
        /// <param name="pen">A reference to the pen to use</param>
        /// <param name="height">The height of the control</param>
        /// <param name="width">The width of the control</param>
        /// <param name="drawCenterLine">Whether to draw one line at the exact center</param>
        /// <param name="drawDotWidthLines">Whether to draw a pair of lines on each side of the center range</param>
        public static void DrawCrosshairs(CrosshairDirection direction, Graphics drawingSurface, ref Pen pen, int height, int width, bool drawCenterLine = true, bool drawDotWidthLines = false) {
            if (drawingSurface == null) return;

            switch (direction) {
                case CrosshairDirection.Vertical:
                    if (drawCenterLine) {
                        pen.DashStyle = CenterLineDashStyle;
                        drawingSurface.DrawLine(pen, width / 2, 0, width / 2, height);
                    }

                    if (drawDotWidthLines) {
                        pen.DashStyle = DotWidthLineDashStyle;
                        drawingSurface.DrawLine(pen, (width - DOT_SIZE) / 2, 0, (width - DOT_SIZE) / 2, height);
                        drawingSurface.DrawLine(pen, (width + DOT_SIZE) / 2, 0, (width + DOT_SIZE) / 2, height);
                    }

                    break;
                case CrosshairDirection.Horizontal:
                    if (drawCenterLine) {
                        pen.DashStyle = CenterLineDashStyle;
                        drawingSurface.DrawLine(pen, 0, height / 2, width, height / 2);
                    }

                    if (drawDotWidthLines) {
                        pen.DashStyle = DotWidthLineDashStyle;
                        drawingSurface.DrawLine(pen, 0, (height - DOT_SIZE) / 2, width, (height - DOT_SIZE) / 2);
                        drawingSurface.DrawLine(pen, 0, (height + DOT_SIZE) / 2, width, (height + DOT_SIZE) / 2);
                    }

                    break;
                case CrosshairDirection.Both:
                    if (drawCenterLine) {
                        pen.DashPattern = CenterDashValues;
                        drawingSurface.DrawLine(pen, width / 2, 0, width / 2, height);
                        drawingSurface.DrawLine(pen, 0, height / 2, width, height / 2);
                    }

                    if (drawDotWidthLines) {
                        pen.DashPattern = DotWidthDashValues;
                        drawingSurface.DrawLine(pen, (width - DOT_SIZE) / 2, 0, (width - DOT_SIZE) / 2, height);
                        drawingSurface.DrawLine(pen, (width + DOT_SIZE) / 2, 0, (width + DOT_SIZE) / 2, height);
                        drawingSurface.DrawLine(pen, 0, (height - DOT_SIZE) / 2, width, (height - DOT_SIZE) / 2);
                        drawingSurface.DrawLine(pen, 0, (height + DOT_SIZE) / 2, width, (height + DOT_SIZE) / 2);
                    }

                    break;
            }
        }

        static public bool NearlyEquals(double x, double y, double tolerance = 0.01d) {
            var diff = Math.Abs(x - y);
            return diff <= tolerance ||
                   diff <= Math.Max(Math.Abs(x), Math.Abs(y)) * tolerance;
        }

        // Call this function on form Paint
        //private void Form_Paint(object sender, PaintEventArgs e) {
        //    System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, CornerRadius, CornerRadius);
        //    this.Region = System.Drawing.Region.FromHrgn(ptr);
        //    DeleteObject(ptr);
        //}
        #endregion Methods
    }
}
