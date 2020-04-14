using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{
    public class FloatTextBox : Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox
    {
        public bool Percent = false;
        public bool PercentBetween0And1 = false;
        Regex regex = new Regex("^[0-9]+$");
        Regex Float = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
        private void InitializeUI()
        {
            this.AutoSize = true;
            this.Margin = new Padding(10);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Font = new Font("IRANSans(FaNum)", 9.5f, FontStyle.Regular);
            this.Text = "0";
            this.HavingStar = true;
        }
        public FloatTextBox()
        {
            InitializeUI();
            this.Enter += NumericTextBox_Enter;
            this.Leave += NumericTextBox_Leave;
            this.KeyDown += NumericTextBox_KeyDown;
            this.TextChanged += NumericTextBox_TextChanged;
        }
        private void NumericTextBox_TextChanged(object sender, EventArgs e)
        {
            SetRegularExpressionFloat((TextBox)sender);
            if (((TextBox)sender).Text.EndsWith("."))
            {
                return;
            }
            if (((TextBox)sender).Text == "")
            {
                ((TextBox)sender).Text = "0";
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            }
            SetPer((TextBox)sender);
        }
        private void SetRegularExpressionFloat(TextBox txt)
        {
            if (!Float.IsMatch(txt.Text))
            {
                if (txt.Text.Length <= 1)
                {
                    txt.Text = "0"; return;
                }
                txt.Text = txt.Text.Remove(txt.Text.Length - 1);
                txt.SelectionStart = txt.Text.Length;
            }
        }
        private void SetPer(TextBox txt)
        {
            if (float.Parse(txt.Text) > 100 && Percent)
            {
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام", "دقت كنيد كه درصد بيشتر از 100 نمي‌تواند باشد\n مبلغ به 100 تغيير پيدا كرد", "e");
                txt.Text = "100";
                txt.SelectionStart = txt.Text.Length;
            }
            else if (float.Parse(txt.Text) > 1 && PercentBetween0And1)
            {
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام", "دقت كنيد كه مقدار بيشتر از 1 وارد شده است");
            }
        }
        private void NumericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.NextControl == null)
                SendKeys.Send("{TAB}");

        }
        private void NumericTextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = this.LeaveBackColor;
            this.ForeColor = this.LeaveForColor;
            if (this.Text.Trim() == String.Empty)
                this.Text = "0";
            if (((TextBox)sender).Text.EndsWith("."))
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text + "0";
            }
            if (((TextBox)sender).Text.StartsWith("."))
            {
                ((TextBox)sender).Text = "0" + ((TextBox)sender).Text;
            }
        }
        void NumericTextBox_Enter(object sender, EventArgs e)
        {

            this.SelectionStart = 0;
            this.BackColor = this.EnterBackColor;
            this.ForeColor = this.EnterForColor;
            this.SelectionLength = this.Text.Length;
            this.SelectAll();
        }
    }
}
