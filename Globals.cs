using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoystickVisualizer {
    internal class Globals {
        #region Variables
        public const int BORDER_THICKNESS = 4;
        public const int CROSSHAIR_THICKNESS = 1;
        public const int DOT_SIZE = 20;

        public static Color DefaultDotColor = Color.Black;
        public static Color DefaultFrameColor = Color.Blue;

        public static DashStyle CenterLineDashStyle = DashStyle.DashDot;
        public static DashStyle DotWidthLineDashStyle = DashStyle.Dot;

        public enum CrosshairDirection {
            Vertical = 0,
            Horizontal = 1,
            Both = 2,
        }
        #endregion Variables

        #region Methods
        /// <summary>
        /// Draws a set of center and dot-width crosshairs
        /// </summary>
        /// <param name="direction">The Globals.CrosshairDirection to draw: Vertical, Horizontal, or Both</param>
        /// <param name="drawingSurface">A reference to a form's drawing surface</param>
        /// <param name="pen">A reference to the pen to use</param>
        /// <param name="height"></param>
        /// <param name="width"></param>
        /// <param name="drawDotWidthLines"></param>
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
                        pen.DashStyle = CenterLineDashStyle;
                        drawingSurface.DrawLine(pen, width / 2, 0, width / 2, height);
                        drawingSurface.DrawLine(pen, 0, width / 2, height, width / 2);
                    }

                    if (drawDotWidthLines) {
                        pen.DashStyle = DotWidthLineDashStyle;
                        drawingSurface.DrawLine(pen, (width - DOT_SIZE) / 2, 0, (width - DOT_SIZE) / 2, height);
                        drawingSurface.DrawLine(pen, (width + DOT_SIZE) / 2, 0, (width + DOT_SIZE) / 2, height);
                        drawingSurface.DrawLine(pen, 0, (height - DOT_SIZE) / 2, width, (height - DOT_SIZE) / 2);
                        drawingSurface.DrawLine(pen, 0, (height + DOT_SIZE) / 2, width, (height + DOT_SIZE) / 2);
                    }

                    break;
            }
        }
        #endregion Methods
    }
}
