using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class CompoundControl : UserControl {
        #region Private members
        // Initialize DirectInput
        private readonly DirectInput directInput;

        // Joystick GUIDs
        private Guid joystickLGuid = Guid.Empty;
        private Guid joystickRGuid = Guid.Empty;

        // Joystick state
        private bool joystickLFound = false;
        private bool joystickRFound = false;

        // Joystick objects
        private Joystick joystickL;
        private Joystick joystickR;

        // Joystick data buffers
        private JoystickUpdate[] dataLeftStick;
        private JoystickUpdate[] dataRightStick;
        #endregion Private members

        public CompoundControl() {
            InitializeComponent();

            directInput = new DirectInput();
        }

        private void CompoundControl_Load(object sender, EventArgs e) {
            KeepGridSquare();
        }

        private void CompoundControl_Resize(object sender, EventArgs e) {
            KeepGridSquare();
        }

        private void KeepGridSquare() {
            // Size of the Axis2D control
            int tableWidth = squareTableLayout.Width;
            int tableHeight = squareTableLayout.Height;

            // Size of the control
            int interiorWidth = this.ClientSize.Width;
            int interiorHeight = this.ClientSize.Height;

            //Debug.Print($"TableGrid before ('{tableWidth}', '{tableHeight}')");
            if (interiorHeight > interiorWidth) {
                tableHeight = tableWidth = interiorWidth;
            } else if (interiorWidth > interiorHeight) {
                tableHeight = tableWidth = interiorHeight;
            }

            squareTableLayout.Size = new Size(tableWidth, tableHeight);
            //Debug.Print($"TableGrid after ('{tableWidth}', '{tableHeight}')");
        }
    }
}
