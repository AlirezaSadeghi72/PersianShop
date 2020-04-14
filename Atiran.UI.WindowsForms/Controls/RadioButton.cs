using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{
    public class RadioButton : System.Windows.Forms.RadioButton
    {
        public System.Windows.Forms.Control NextControl { get; set; }
        public bool SendTabKey = false;
        Color previousForeColor;
        public Color EnterForColor = Color.FromArgb(225, 174, 0);
        public Color LeaveForColor = Color.Black;
        public RadioButton()
        {
            this.KeyDown += RadioButton_KeyDown;
            this.Enter += RadioButton_Enter;
            this.Leave += RadioButton_Leave;
            previousForeColor = this.ForeColor;
        }
        private void RadioButton_Leave(object sender, EventArgs e)
        {
            this.ForeColor = LeaveForColor;
        }

        private void RadioButton_Enter(object sender, EventArgs e)
        {
            this.ForeColor = EnterForColor;
        }

        private void RadioButton_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (NextControl != null)
                {
                    if (!NextControl.Enabled || SendTabKey)
                    {
                        SetNextControl((RadioButton)sender);
                    }
                    else
                    {
                        NextControl.Focus();
                    }
                }
                else
                {
                    SetNextControl((RadioButton)sender);
                }
            }
            if (e.KeyCode == Keys.Space)
                this.Checked = true;
        }
        private void SetNextControl(RadioButton NextControl)
        {
            SendKeys.Send("{TAB}");
        }
    }
}
