using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.Controls.TextBoxes
{
    public class LargeTextBox : Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox
    {
        public LargeTextBox()
        {
            InitializeUI();
            this.Enter += LargeTextBox_Enter;
            this.KeyDown += LargeTextBox_KeyDown;
        }

        private void LargeTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (this.HavingStar && e.KeyCode == System.Windows.Forms.Keys.Multiply)
            {
                this.Text += "00";
            }
        }

        private void LargeTextBox_Enter(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void InitializeUI()
        {
            this.Font = FontManager.GetDefaultTextFont();
            this.Width = 230;
        }
    }
}
