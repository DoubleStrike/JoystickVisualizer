using Microsoft.Win32;
using SharpDX.DirectInput;
using System;
using System.Drawing;

using JoystickVisualizer.Properties;


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

        // Visual style
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
        public static SolidBrush dotBrush;
        public static SolidBrush frameBrush;
        public static Pen framePen;
        public static Pen crosshairsPen;
        public static Pen povHatPen;
        #endregion Variables

        #region External Calls
        #endregion External Calls

        #region Methods
        /// <summary>
        /// Static constructor - currently only used for setting load
        /// </summary>
        static Globals() {
            System.Diagnostics.Debug.Print("Loading settings...");
            LoadSettings();
            System.Diagnostics.Debug.Print("...settings loaded.");
        }

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
                        pen.DashPattern = CenterDashValues;
                        drawingSurface.DrawLine(pen, width / 2, 0, width / 2, height);
                    }

                    // In this case, use the height to determine offset
                    if (drawDotWidthLines) {
                        pen.DashPattern = DotWidthDashValues;
                        drawingSurface.DrawLine(pen, (width - height) / 2, 0, (width - height) / 2, height);
                        drawingSurface.DrawLine(pen, (width + height) / 2, 0, (width + height) / 2, height);
                    }

                    break;
                case CrosshairDirection.Horizontal:
                    if (drawCenterLine) {
                        pen.DashPattern = CenterDashValues;
                        drawingSurface.DrawLine(pen, 0, height / 2, width, height / 2);
                    }

                    // In this case, use the width to determine offset
                    if (drawDotWidthLines) {
                        pen.DashPattern = DotWidthDashValues;
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

        public static bool GetSystemDarkMode() {
            // Check for dark mode
            int AppsUseLightTheme = 1;
            try {
                RegistryKey WinPersonalizeSettings = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", false);
                AppsUseLightTheme = int.Parse(WinPersonalizeSettings.GetValue("AppsUseLightTheme").ToString());
            } catch { }

            return AppsUseLightTheme == 0;
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
        public static void LoadSettings() {
            if (Settings.Default.Timer_PollingIntervalMs > 0) {
                if (dotBrush == null)
                    dotBrush = new SolidBrush(Settings.Default.UI_DefaultDotColor);
                if (frameBrush == null)
                    frameBrush = new SolidBrush(Settings.Default.UI_DefaultFrameColor);
                if (framePen == null)
                    framePen = new Pen(Settings.Default.UI_DefaultFrameColor, Settings.Default.UI_BorderThickness);
                if (crosshairsPen == null)
                    crosshairsPen = new Pen(Settings.Default.UI_DefaultFrameColor, Settings.Default.UI_CrosshairThickness);
                if (povHatPen == null)
                    povHatPen = new Pen(Settings.Default.UI_PovLineColor, Settings.Default.UI_PovLineThickness);
            }
        }

        public static void SaveDefaultSettings() {
            Settings.Default.Save();
        }

        /// <summary>
        /// Returns true if two doubles are within 0.001 of each other
        /// </summary>
        public static Func<double, double, bool> NearlyEquals = (x, y) =>
            Math.Abs(x - y) <= 0.001d || Math.Abs(x - y) <= Math.Max(Math.Abs(x), Math.Abs(y)) * 0.001d;

        #endregion Utilities
        #endregion Methods
    }
}
