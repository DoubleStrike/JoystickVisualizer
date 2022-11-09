using SharpDX.DirectInput;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        #region Variables
        // Access object for DirectInput
        public static readonly DirectInput directInput = new DirectInput();

        // VKB's device names - complete with weird extra spaces
        public const string GLADIATOR_LEFT_NAME = " VKBsim Gladiator EVO  L  ";
        public const string GLADIATOR_RIGHT_NAME = " VKBsim Gladiator EVO  R  ";
        public const string GLADIATOR_RIGHT_SEM_NAME = " VKBsim Gladiator EVO  R SEM ";

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

        // Polling timeout
        public const int POLLING_INTERVAL_MS = 50;

        // Axis values
        public const int DEFAULT_AXIS_VALUE = 32768;
        public const int MAX_AXIS_VALUE = 65535;

        // Visual style
        public const int BORDER_THICKNESS = 4;
        public const int CROSSHAIR_THICKNESS = 1;
        public const int DOT_SIZE = 20;
        public readonly static Color DEFAULT_DOT_COLOR = SystemColors.HotTrack;
        public readonly static Color DEFAULT_FRAME_COLOR = SystemColors.Info;
        public readonly static DashStyle CenterLineDashStyle = DashStyle.DashDot;
        public readonly static DashStyle DotWidthLineDashStyle = DashStyle.Dot;
        public readonly static float[] CenterDashValues = { 5, 10 };
        public readonly static float[] DotWidthDashValues = { 1, 2 };
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
                        drawingSurface.DrawLine(pen, (width - DOT_SIZE) / 2, 0, (width - DOT_SIZE) / 2, height);
                        drawingSurface.DrawLine(pen, (width + DOT_SIZE) / 2, 0, (width + DOT_SIZE) / 2, height);
                        drawingSurface.DrawLine(pen, 0, (height - DOT_SIZE) / 2, width, (height - DOT_SIZE) / 2);
                        drawingSurface.DrawLine(pen, 0, (height + DOT_SIZE) / 2, width, (height + DOT_SIZE) / 2);
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
            if (joystickLFound) {
                // Instantiate the joystick
                joystickL = new Joystick(directInput, joystickLGuid);
                //Debug.WriteLine($"Found Left Joystick/Gamepad with GUID: '{joystickLGuid}'");

                // Set BufferSize in order to use buffered data
                joystickL.Properties.BufferSize = 128;

                // Acquire the joystick
                joystickL.Acquire();
                joystickLAcquired = true;
            }

            if (joystickRFound) {
                // Instantiate the joystick
                joystickR = new Joystick(directInput, joystickRGuid);
                //Debug.WriteLine($"Found Right Joystick/Gamepad with GUID: '{joystickRGuid}'");

                // Set BufferSize in order to use buffered data
                joystickR.Properties.BufferSize = 128;

                // Acquire the joystick
                joystickR.Acquire();
                joystickRAcquired = true;
            }

            return joystickLAcquired || joystickRAcquired;
        }

        /// <summary>
        /// Iterates through device instances from DirectInput and saves the left/right stick GUIDs and marks them as found
        /// </summary>
        /// <returns>true if at least one joystick was bound successfully</returns>
        public static bool BindJoysticks() {
            foreach (DeviceInstance thisDevice in directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices)) {
                Debug.WriteLine($"Device instance found: '{thisDevice.InstanceName}'");

                if (thisDevice.InstanceName == GLADIATOR_LEFT_NAME) {
                    joystickLFound = true;
                    joystickLGuid = thisDevice.InstanceGuid;
                } else if (thisDevice.InstanceName == GLADIATOR_RIGHT_NAME) {
                    joystickRFound = true;
                    joystickRGuid = thisDevice.InstanceGuid;
                } else if (thisDevice.InstanceName == GLADIATOR_RIGHT_SEM_NAME) {
                    joystickRFound = true;
                    joystickRGuid = thisDevice.InstanceGuid;
                } else {
                    Debug.WriteLine("Unplanned extra device found.");
                }
            }

            return (joystickLFound || joystickRFound);
        }

        /// <summary>
        /// Calls Poll() on the Joystick object and returns its buffered data
        /// </summary>
        /// <param name="stickToPoll">the Joystick object to poll</param>
        /// <returns>the contents of the data buffer as a JoystickUpdate[]</returns>
        public static JoystickUpdate[] PollJoystick(Joystick stickToPoll) {
            if (stickToPoll == null) return null;

            stickToPoll.Poll();
            return stickToPoll.GetBufferedData();
        }

        public static void UnacquireJoysticks() {
            // Unacquire any active joysticks
            if (joystickLAcquired) joystickL.Unacquire();
            if (joystickRAcquired) joystickR.Unacquire();
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
