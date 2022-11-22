using SharpDX.DirectInput;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using JoystickVisualizer.Properties;
using System.Reflection;

namespace JoystickVisualizer {
    public partial class MainWindow : Form {
        #region Private members
        #endregion Private members

        public MainWindow() {
            Globals.LoadSettings();

            InitializeComponent();
        }

        #region Event Handlers
        private void MainWindow_Load(object sender, EventArgs e) {
            foreach (DeviceInstance thisDevice in Globals.directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices)) {
                cboLeftBinding.Items.Add(thisDevice.ProductName);
                cboRightBinding.Items.Add(thisDevice.ProductName);
            }

            ScaleDots();
            SetDarkMode();
            SetWideMode(Settings.Default.Main_WideLayout);

            this.Text = this.Text + " v" + Application.ProductVersion;
            chkKeepOnTop.Checked = Settings.Default.Main_KeepOnTop;
            chkWide.Checked = Settings.Default.Main_WideLayout;
            txtPollingTime.Text = Settings.Default.Timer_PollingIntervalMs.ToString();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            // Unacquire any active joysticks
            Globals.UnacquireJoysticks();

            // Save default settings on exit
            Globals.SaveDefaultSettings();
        }

        private void MainWindow_Resize(object sender, EventArgs e) {

            this.Text = lblTitle.Text;
            ScaleDots();
        }

        private void KeepOnTop_CheckedChanged(object sender, EventArgs e) {
            this.TopMost = chkKeepOnTop.Checked;
            this.Focus();
        }

        private void Set_Click(object sender, EventArgs e) {
            try {
                int parsedInput = int.Parse(txtPollingTime.Text);

                LeftStick.UpdatePollingInterval(parsedInput);
                RightStick.UpdatePollingInterval(parsedInput);
            } catch (Exception) {
                MessageBox.Show("Enter a valid numeric value in milliseconds");
            }
        }

        private void LeftBinding_SelectedIndexChanged(object sender, EventArgs e) {
            // Unacquire the stick if it is active
            Globals.UnacquireSingleJoystick(JoystickSelection.Left);

            // Bind the selected stick
            Globals.BindSingleJoystick(cboLeftBinding.SelectedItem.ToString(), JoystickSelection.Left);

            // Activate the stick and the related control
            if (Globals.ActivateJoysticks()) {
                if (Globals.joystickLAcquired) {
                    LeftStick.SetJoystickToUse(JoystickSelection.Left);
                    LeftStick.StartPolling();
                } else {
                    LeftStick.Enabled = false;
                }
            }

            txtPollingTime.Focus();
        }

        private void RightBinding_SelectedIndexChanged(object sender, EventArgs e) {
            // Unacquire the stick if it is active
            Globals.UnacquireSingleJoystick(JoystickSelection.Right);

            // Bind the selected stick
            Globals.BindSingleJoystick(cboRightBinding.SelectedItem.ToString(), JoystickSelection.Right);

            // Activate the stick and the related control
            if (Globals.ActivateJoysticks()) {
                if (Globals.joystickRAcquired) {
                    RightStick.SetJoystickToUse(JoystickSelection.Right);
                    RightStick.StartPolling();
                } else {
                    RightStick.Enabled = false;
                }
            }

            txtPollingTime.Focus();
        }

        private void Wide_CheckedChanged(object sender, EventArgs e) {
            SetWideMode(chkWide.Checked);
        }
        #endregion Event Handlers

        #region Private Methods
        private void ScaleDots() {
            int smallerDimension = LeftStick.Width < LeftStick.Height ? LeftStick.Width : LeftStick.Height;
            LeftStick.SetDotSize(smallerDimension / 7);
            RightStick.SetDotSize(smallerDimension / 7);
        }

        private void SetDarkMode() {
            if (Globals.GetSystemDarkMode()) {
                // Darken UI elements as needed
                this.BackColor = Settings.Default.UI_DarkModeBackground;

                lblTitle.ForeColor = SystemColors.Info;
                chkKeepOnTop.ForeColor = SystemColors.Info;
                chkWide.ForeColor = SystemColors.Info;
                lblPollingTime.ForeColor = SystemColors.Info;

                LeftStick.SetDarkMode(true);
                RightStick.SetDarkMode(true);
            } else {
                // Lighten UI elements as needed
                Globals.dotBrush.Color = SystemColors.ControlDarkDark;
                Globals.frameBrush.Color = SystemColors.ControlDarkDark;

                Globals.crosshairsPen.Color = SystemColors.ControlText;
                Globals.framePen.Color = SystemColors.ControlText;
            }
        }

        private void SetWideMode(bool wideModeOn) {
            if (wideModeOn) {
                // HACK: This is sloppy as hell and needs a better solution
                RightStick.squareTableLayout.Dock = DockStyle.Right;
                LeftStick.squareTableLayout.Dock = DockStyle.Left;
            } else {
                // HACK: This is sloppy as hell and needs a better solution
                RightStick.squareTableLayout.Dock = DockStyle.Fill;
                LeftStick.squareTableLayout.Dock = DockStyle.Fill;
            }
        }

        private void Form_MouseEnter(object sender, EventArgs e) {
            if (!mouseHasEnteredForm) {
                FlowPanelCenter.Visible = true;
                mouseHasEnteredForm = true;
            }
        }

        private void Form_MouseLeave(object sender, EventArgs e) {
            if (MouseIsOverOtherWindow()) {
                FlowPanelCenter.Visible = false;
                mouseHasEnteredForm = false;
            }
        }
        #endregion Private Methods

        #region MouseOver stuff
        /*
         * Credit to Calle Mellergardh for this one.  This uses WndProc subclassing from the Win32 API to grab raw mouse events.
         * Grabbed from https://social.msdn.microsoft.com/Forums/windows/en-US/3b143c44-a523-4e60-a76f-f010058750b9/event-bubbling-mousehover-event-for-child-controls
         */

        private bool trackingNonClientArea;
        private bool mouseHasEnteredForm;

        private const int WM_NCMOUSEMOVE = 0x0a0;
        private const int WM_NCMOUSELEAVE = 0x02a2;
        private const int WM_MOUSELEAVE = 0x02a3;

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(POINTSTRUCT lpPoint);

        [DllImport("user32.dll", EntryPoint = "IsChild")]
        private static extern bool IsChildWindow(IntPtr hWndParent, IntPtr hwnd);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINTSTRUCT {
            public int x;
            public int y;

            public POINTSTRUCT(Point fromPoint) {
                this.x = fromPoint.X;
                this.y = fromPoint.Y;
            }
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == WM_NCMOUSEMOVE) {
                if (!this.trackingNonClientArea) {
                    this.TrackNonClientMouse();
                    this.Form_MouseEnter(this, EventArgs.Empty);
                }
            } else if (m.Msg == WM_NCMOUSELEAVE || m.Msg == WM_MOUSELEAVE) {
                this.trackingNonClientArea = false;
                this.Form_MouseLeave(this, EventArgs.Empty);
            }

            base.WndProc(ref m);
        }

        private void TrackNonClientMouse() {
            this.trackingNonClientArea = true;
        }

        private bool MouseIsOverOtherWindow() {
            IntPtr hWnd = WindowFromPoint(new POINTSTRUCT(Cursor.Position));
            return ((this.Handle != hWnd) && !IsChildWindow(this.Handle, hWnd));
        }
        #endregion MouseOver stuff
    }
}
