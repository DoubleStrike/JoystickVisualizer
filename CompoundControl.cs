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
    public partial class CompoundControl : Form {
        public CompoundControl() {
            InitializeComponent();
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

        private void CompoundControl_Load(object sender, EventArgs e) {
            KeepGridSquare();
        }
    }
}
