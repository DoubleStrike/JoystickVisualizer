﻿using SharpDX.DirectInput;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class MainWindow : Form {
        #region Private members
        #endregion Private members

        public MainWindow() {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e) {
            // Try to bind the joysticks, else throw an error and exit
            if (!Globals.BindJoysticks()) {
                MessageBox.Show("No joystick/Gamepad found.", "No devices", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            if (Globals.ActivateJoysticks()) {
                if (Globals.joystickRAcquired) {
                    RightStick.SetJoystickToUse(JoystickSelection.Right);
                    RightStick.StartPolling();
                    RightStick.SetDarkMode();
                } else {
                    RightStick.Enabled = false;
                }

                if (Globals.joystickLAcquired) {
                    LeftStick.SetJoystickToUse(JoystickSelection.Left);
                    LeftStick.StartPolling();
                    LeftStick.SetDarkMode();
                } else {
                    LeftStick.Enabled = false;
                }
            }

            LeftStick.SetDotSize(LeftStick.Width / 7);
            RightStick.SetDotSize(RightStick.Width / 7);
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            // Unacquire any active joysticks
            Globals.UnacquireJoysticks();
        }

        private void MainWindow_Resize(object sender, EventArgs e) {
            LeftStick.SetDotSize(LeftStick.Width / 7);
            RightStick.SetDotSize(RightStick.Width / 7);
        }

        private void chkKeepOnTop_CheckedChanged(object sender, EventArgs e) {
            this.TopMost = chkKeepOnTop.Checked;
            this.Focus();
        }

        private void btnSet_Click(object sender, EventArgs e) {
            try {
                int parsedInput = int.Parse(txtPollingTime.Text);

                LeftStick.UpdatePollingInterval(parsedInput);
                RightStick.UpdatePollingInterval(parsedInput);
            } catch (Exception) {
                MessageBox.Show("Enter a valid numeric value in milliseconds");
            }
        }
    }
}
