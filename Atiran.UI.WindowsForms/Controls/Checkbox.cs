using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Atiran.UI.WindowsForms.UIElements
{
   public class Checkbox:CheckBox
    {
        Color previousForeColor;
        public bool SendTabKey = false;
        public Color EnterForColor = Color.FromArgb(225, 174, 0);
        public Color LeaveForColor = Color.Black;
        public System.Windows.Forms.Control NextControl { get; set; }
        public Checkbox()
        {
            this.Enter += Checkbox_Enter;
            this.Leave += Checkbox_Leave;
            previousForeColor = this.ForeColor;
            this.KeyDown += Checkbox_KeyDown;
            this.KeyPress += Checkbox_KeyPress;
            this.Font = UI.WindowsForms.FontManager.GetDefaultTextFont();
        }

        private void Checkbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (NextControl != null)
                {
                    if (!NextControl.Enabled || SendTabKey)
                    {
                        SetNextControl((CheckBox)sender);
                    }
                    else
                    {
                        NextControl.Focus();
                    }
                }
            }
        }
        private void SetNextControl(CheckBox NextControl)
        {
            SendKeys.Send("{TAB}");
        }
        private void Checkbox_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void Checkbox_Leave(object sender, EventArgs e)
        {
            this.ForeColor = LeaveForColor;
        }
        private void Checkbox_Enter(object sender, EventArgs e)
        {
            this.ForeColor = EnterForColor;
        }
    }
}
