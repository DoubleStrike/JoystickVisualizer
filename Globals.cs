using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoystickVisualizer {
    internal class Globals {
        public const int BORDER_THICKNESS = 4;
        public const int CROSSHAIR_THICKNESS = 1;
        public const int DOT_SIZE = 20;

        public static Color DefaultDotColor = Color.Black;
        public static Color DefaultFrameColor = Color.Blue;

        public enum CrosshairDirection {
            Vertical = 0,
            Horizontal = 1,
        }


        public static void DrawCrosshairs(CrosshairDirection direction, System.Drawing.Graphics drawingSurface) {

        }
    }
}
