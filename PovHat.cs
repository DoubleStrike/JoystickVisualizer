using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoystickVisualizer {
    public partial class PovHat : UserControl {
        private ToolTip toolTip = new System.Windows.Forms.ToolTip();
        private int m_Value = Globals.DEFAULT_AXIS_VALUE;

        #region Public Properties
        public string ToolTip {
            get {
                return toolTip.GetToolTip(this);
            }
            set {
                toolTip.SetToolTip(this, value);
            }
        }

        [Description("Sets the current value"),
                Category("Control Defaults"),
                Browsable(true)]
        public int Value {
            get { return m_Value; }
            set {
                m_Value = value;
                this.Invalidate();
                this.Update();
            }
        }
        #endregion Public Properties

        #region Public functions
        #endregion Public functions


        public PovHat() {
            InitializeComponent();
        }
    }
}
