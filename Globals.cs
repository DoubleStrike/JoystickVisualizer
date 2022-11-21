using SharpDX.DirectInput;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq.Expressions;

namespace JoystickVisualizer {
    #region Enums
    public enum CrosshairDirection {
        Vertical = 0,
        Horizontal = 1,
        Both = 2,
    }

    public enum JoystickSelection {
        Right = 0,
        Left = 1,
    }
    #endregion Enums

    internal class Globals {
        #region Constants and read-only
        // Access object for DirectInput
        public static readonly DirectInput directInput = new DirectInput();

        // VKB's device name prefixes, with words glommed together and lowercased
        public const string GLADIATOR_L_GLOMMED = "vkbsimgladiatorevol";
        public const string GLADIATOR_R_GLOMMED = "vkbsimgladiatorevor";

        // Polling timeout
        public const int POLLING_INTERVAL_MS = 50;

        // Axis values
        public const int DEFAULT_AXIS_VALUE = 32768;
        public const int MAX_AXIS_VALUE = 65535;

        // Visual style
        public const int BORDER_THICKNESS = 4;
        public const int CROSSHAIR_THICKNESS = 1;
        public const int DEFAULT_2D_DOT_SIZE = 20;
        public const int POV_LINE_THICKNESS = 8;
        public readonly static Color DEFAULT_DOT_COLOR = SystemColors.GradientInactiveCaption;
        public readonly static Color DEFAULT_FRAME_COLOR = SystemColors.Info;
        public readonly static Color POV_LINE_COLOR = Color.Red;
        public readonly static DashStyle CenterLineDashStyle = DashStyle.DashDot;
        public readonly static DashStyle DotWidthLineDashStyle = DashStyle.Dot;
        public readonly static float[] CenterDashValues = { 5, 10 };
        public readonly static float[] DotWidthDashValues = { 1, 2 };
        #endregion Constants

        #region Variables
        // Joystick GUIDs
        public static Guid joystickLGuid = Guid.Empty;
        public static Guid joystickRGuid = Guid.Empty;

        // Joystick state
        public static bool joystickLFound = false;
        public static bool joystickRFound = false;
        public static bool joystickLAcquired = false;
        public static bool joystickRAcquired = false;

        // Joystick objects
        public static Joystick joystickL;
        public static Joystick joystickR;

        // Visual style
        public static SolidBrush dotBrush = new SolidBrush(Globals.DEFAULT_DOT_COLOR);
        public static SolidBrush frameBrush = new SolidBrush(Globals.DEFAULT_FRAME_COLOR);
        public static Pen framePen = new Pen(Globals.DEFAULT_FRAME_COLOR, Globals.BORDER_THICKNESS);
        public static Pen crosshairsPen = new Pen(Globals.DEFAULT_FRAME_COLOR, Globals.CROSSHAIR_THICKNESS);
        public static Pen povHatPen = new Pen(POV_LINE_COLOR, POV_LINE_THICKNESS);
        #endregion Variables

        #region External Calls
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern System.IntPtr CreateRoundRectRgn
         (int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        [System.Runtime.InteropServices.DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        private static extern bool DeleteObject(System.IntPtr hObject);
        #endregion External Calls

        #region Methods
        #region User Interface and Rendering
        /// <summary>
        /// Draws a set of center and dot-width crosshairs
        /// </summary>
        /// <param name="direction">The Globals.CrosshairDirection to draw: Vertical, Horizontal, or Both</param>
        /// <param name="drawingSurface">A reference to a form's drawing surface</param>
        /// <param name="pen">A reference to the pen to use</param>
        /// <param name="height">The height of the control</param>
        /// <param name="width">The width of the control</param>
        /// <param name="dotSize">For 2D axes, the width of the dot to draw. Ignored for 1D axes.</param>
        /// <param name="drawCenterLine">Whether to draw one line at the exact center</param>
        /// <param name="drawDotWidthLines">Whether to draw a pair of lines on each side of the center range</param>
        public static void DrawCrosshairs(CrosshairDirection direction, Graphics drawingSurface, ref Pen pen, int height, int width, int dotSize, bool drawCenterLine = true, bool drawDotWidthLines = false) {
            if (drawingSurface == null) return;

            switch (direction) {
                case CrosshairDirection.Vertical:
                    if (drawCenterLine) {
                        pen.DashStyle = CenterLineDashStyle;
                        drawingSurface.DrawLine(pen, width / 2, 0, width / 2, height);
                    }

                    // In this case, use the height to determine offset
                    if (drawDotWidthLines) {
                        pen.DashStyle = DotWidthLineDashStyle;
                        drawingSurface.DrawLine(pen, (width - height) / 2, 0, (width - height) / 2, height);
                        drawingSurface.DrawLine(pen, (width + height) / 2, 0, (width + height) / 2, height);
                    }

                    break;
                case CrosshairDirection.Horizontal:
                    if (drawCenterLine) {
                        pen.DashStyle = CenterLineDashStyle;
                        drawingSurface.DrawLine(pen, 0, height / 2, width, height / 2);
                    }

                    // In this case, use the width to determine offset
                    if (drawDotWidthLines) {
                        pen.DashStyle = DotWidthLineDashStyle;
                        drawingSurface.DrawLine(pen, 0, (height - width) / 2, width, (height - width) / 2);
                        drawingSurface.DrawLine(pen, 0, (height + width) / 2, width, (height + width) / 2);
                    }

                    break;
                case CrosshairDirection.Both:
                    if (drawCenterLine) {
                        pen.DashPattern = CenterDashValues;
                        drawingSurface.DrawLine(pen, width / 2, 0, width / 2, height);
                        drawingSurface.DrawLine(pen, 0, height / 2, width, height / 2);
                    }

                    // In this case, use the fixed dot size to determine offset
                    if (drawDotWidthLines) {
                        pen.DashPattern = DotWidthDashValues;
                        drawingSurface.DrawLine(pen, (width - dotSize) / 2, 0, (width - dotSize) / 2, height);
                        drawingSurface.DrawLine(pen, (width + dotSize) / 2, 0, (width + dotSize) / 2, height);
                        drawingSurface.DrawLine(pen, 0, (height - dotSize) / 2, width, (height - dotSize) / 2);
                        drawingSurface.DrawLine(pen, 0, (height + dotSize) / 2, width, (height + dotSize) / 2);
                    }

                    break;
            }
        }
        #endregion User Interface and Rendering

        #region Joystick Management
        /// <summary>
        /// Instantiates Joystick objects given proper GUIDs, sets buffer sizes, and performs Acquire() on the sticks.  Only call after BindJoysticks().
        /// </summary>
        public static bool ActivateJoysticks() {
            if (joystickLFound && !joystickLAcquired) {
                // Instantiate the joystick
                joystickL = new Joystick(directInput, joystickLGuid);
                //Debug.WriteLine($"Found Left Joystick/Gamepad with GUID: '{joystickLGuid}'");

                // Set BufferSize in order to use buffered data
                joystickL.Properties.BufferSize = 1024;

                // Acquire the joystick
                try {
                    joystickL.Acquire();
                    joystickLAcquired = true;
                } catch { }
            }

            if (joystickRFound && !joystickRAcquired) {
                // Instantiate the joystick
                joystickR = new Joystick(directInput, joystickRGuid);
                //Debug.WriteLine($"Found Right Joystick/Gamepad with GUID: '{joystickRGuid}'");

                // Set BufferSize in order to use buffered data
                joystickR.Properties.BufferSize = 1024;

                // Acquire the joystick
                try {
                    joystickR.Acquire();
                    joystickRAcquired = true;
                } catch { }
            }

            return joystickLAcquired || joystickRAcquired;
        }

#if false
        /// <summary>
        /// Iterates through device instances from DirectInput and saves the left/right stick GUIDs and marks them as found
        /// </summary>
        /// <returns>true if at least one joystick was bound successfully</returns>
        public static bool BindJoysticks() {
            foreach (DeviceInstance thisDevice in directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices)) {
                Debug.WriteLine($"Device instance found: '{thisDevice.InstanceName}'");

                // Glom the words together and force lowercase to allow more flexible device selection
                string glommedName = thisDevice.InstanceName.Replace(" ", "").ToLower();

                if (glommedName.StartsWith(GLADIATOR_L_GLOMMED)) {
                    joystickLFound = true;
                    joystickLGuid = thisDevice.InstanceGuid;
                } else if (glommedName.StartsWith(GLADIATOR_R_GLOMMED)) {
                    joystickRFound = true;
                    joystickRGuid = thisDevice.InstanceGuid;
                } else {
                    //Debug.WriteLine("Unplanned extra device found.");
                }
            }

            return (joystickLFound || joystickRFound);
        }
#endif

        /// <summary>
        /// Binds a single joystick to a selected device name
        /// </summary>
        /// <param name="DeviceName">The string of the DeviceInstance.DeviceName to bind to</param>
        /// <param name="StickToBind">A selection of which stick to bind</param>
        /// <returns></returns>
        public static bool BindSingleJoystick(string DeviceName, JoystickSelection StickToBind) {
            foreach (DeviceInstance thisDevice in directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices)) {
                if (thisDevice.ProductName == DeviceName) {
                    if (StickToBind == JoystickSelection.Left) {
                        joystickLFound = true;
                        joystickLGuid = thisDevice.InstanceGuid;
                        return true;
                    } else {
                        joystickRFound = true;
                        joystickRGuid = thisDevice.InstanceGuid;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Calls Poll() on the Joystick object and returns its buffered data
        /// </summary>
        /// <param name="stickToPoll">the Joystick object to poll</param>
        /// <returns>the contents of the data buffer as a JoystickUpdate[]</returns>
        public static JoystickUpdate[] PollJoystick(Joystick stickToPoll) {
            if (stickToPoll == null) return null;

            try {
                stickToPoll.Poll();
                return stickToPoll.GetBufferedData();
            } catch {
                return null;
            }
        }

        public static void UnacquireJoysticks() {
            // Unacquire any active joysticks
            UnacquireSingleJoystick(JoystickSelection.Left);
            UnacquireSingleJoystick(JoystickSelection.Right);
        }

        public static void UnacquireSingleJoystick(JoystickSelection StickToRelease) {
            // Unacquire the selected joystick, if it is active
            if (StickToRelease == JoystickSelection.Left && joystickLAcquired) {
                try {
                    joystickL.Unacquire();
                    joystickLAcquired = false;
                } catch { }
            } else if (StickToRelease == JoystickSelection.Right && joystickRAcquired) {
                try {
                    joystickR.Unacquire();
                    joystickRAcquired = false;
                } catch { }
            }
        }
#endregion Joystick Management

#region Utilities
        public static bool NearlyEquals(double x, double y, double tolerance = 0.01d) {
            var diff = Math.Abs(x - y);
            return diff <= tolerance ||
                   diff <= Math.Max(Math.Abs(x), Math.Abs(y)) * tolerance;
        }

        // For rounded corners, call this function on form Paint
        //private void Form_Paint(object sender, PaintEventArgs e) {
        //    System.IntPtr ptr = CreateRoundRectRgn(0, 0, this.Width, this.Height, CornerRadius, CornerRadius);
        //    this.Region = System.Drawing.Region.FromHrgn(ptr);
        //    DeleteObject(ptr);
        //}
#endregion Utilities
#endregion Methods
    }
}
