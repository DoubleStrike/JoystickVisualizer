using SharpDX.DirectInput;
using System;
using System.Drawing;
using System.Windows.Forms;

using JoystickVisualizer.Properties;


namespace JoystickVisualizer {
    public partial class MainWindow : Form {
        #region Private members
        #endregion Private members

        public MainWindow() {
            Globals.LoadSettings();

            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e) {
            //BindAndActivateSticks();
            foreach (DeviceInstance thisDevice in Globals.directInput.GetDevices(DeviceClass.GameControl, DeviceEnumerationFlags.AllDevices)) {
                cboLeftBinding.Items.Add(thisDevice.ProductName);
                cboRightBinding.Items.Add(thisDevice.ProductName);
            }

            ScaleDots();
            SetDarkMode();
            SetWideMode(Settings.Default.Main_WideLayout);

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
    }
}
