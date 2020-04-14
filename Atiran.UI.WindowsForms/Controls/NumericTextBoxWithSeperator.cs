using System;

namespace Atiran.UI.WindowsForms.Controls
{
    public class NumericTextBoxWithSeperator : NumericTextBox
    {
        public NumericTextBoxWithSeperator()
        {
            this.TextChanged += NumberTextbox_TextChanged;
        }
        void NumberTextbox_TextChanged(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(this.Text, out number))
            {
                this.Text = string.Format("{0:N0}", number);
                this.SelectionStart = this.Text.Length;
            }
        }
    }
}
