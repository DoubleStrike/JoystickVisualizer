using SharpDX.DirectInput;
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

            if (Globals.ActivateJoysticks() || Globals.joystickRAcquired) {
                compoundControl1.SetJoystickToUse(JoystickSelection.Right);
                compoundControl1.StartPolling();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
            // Unacquire any active joysticks
            Globals.UnacquireJoysticks();
        }
    }
}
