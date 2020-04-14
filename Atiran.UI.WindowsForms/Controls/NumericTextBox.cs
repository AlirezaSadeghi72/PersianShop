using System;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{
    public class NumericTextBox : UI.WindowsForms.Controls.TextBoxes.TextBox
    {
        private double value;
        public double Value
        {
            set
            {

            }
            get
            {
                value = double.Parse(this.Text.Replace(",", ""));
                return value;
            }

        }
        private void InitializeUI()
        {
            this.AutoSize = true;
            this.Margin = new Padding(10);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("IRANSans(FaNum)", 9.5f, FontStyle.Regular);
            this.Text = "0";
            this.HavingStar = true;

        }
        public NumericTextBox()
        {
            InitializeUI();
            this.KeyPress += NumberTextbox_KeyPress;
            this.Enter += NumericTextBox_Enter;
            this.Leave += NumericTextBox_Leave;
            this.KeyDown += NumericTextBox_KeyDown;
            this.TextChanged += NumericTextBox_TextChanged;
            this.PreviewKeyDown += NumericTextBox_PreviewKeyDown;
        }

        private void NumericTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            //decimal number;
            //if (decimal.TryParse(this.Text, out number))
            //{
            //    this.Text = string.Format("{0:N0}", number);
            //    this.SelectionStart = this.Text.Length;
            //}
            if (this.Text == string.Empty)
            {
                this.Text = "0";
                this.SelectAll();
            }

        }

        private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //    SendKeys.Send("{TAB}");

        }

        private void NumericTextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = this.LeaveBackColor;
            this.ForeColor = this.LeaveForColor;
            if (this.Text.Trim() == String.Empty)
                this.Text = "0";
        }

        void NumericTextBox_Enter(object sender, EventArgs e)
        {

            this.SelectionStart = 0;
            this.BackColor = this.EnterBackColor;
            this.ForeColor = this.EnterForColor;
            this.SelectionLength = this.Text.Length;

        }

        void NumberTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrWhiteSpace(this.Text))
                    this.Text = "0";

            }
            if (e.KeyChar == 46)
            {
                e.Handled = true;
            }
            else
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete))
            {

                e.Handled = true;
            }
        }
    }
}
