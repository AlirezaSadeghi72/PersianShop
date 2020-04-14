using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.Controls
{
   public class NumericUpDown : System.Windows.Forms.NumericUpDown
    {
        public System.Windows.Forms.Control NextControl { get; set; }
        
        public NumericUpDown()
        {
            this.KeyPress += NumericUpDown_KeyPress;
        }

        private void NumericUpDown_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (NextControl != null)
                    NextControl.Focus();
            }
        }
    }
}
