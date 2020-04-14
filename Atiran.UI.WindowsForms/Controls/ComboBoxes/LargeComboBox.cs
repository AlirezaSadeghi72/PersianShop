using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.ComboBoxes
{
    public class LargeComboBox : System.Windows.Forms.ComboBox
    {
        public LargeComboBox()
        {
            InitializeUI();
            this.KeyDown += LargeComboBox_KeyDown;
            this.Enter += LargeComboBox_Enter;
            this.LostFocus += LargeComboBox_LostFocus;
        }

        private void LargeComboBox_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void LargeComboBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(225, 174, 0);
        }

        private void LargeComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void InitializeUI()
        {
            this.AutoSize = true;
            this.Font = FontManager.GetFont("B Nazanin", 12, System.Drawing.FontStyle.Regular);
            this.Width = 200;
            this.Height = 34;
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
        }
    }
}
