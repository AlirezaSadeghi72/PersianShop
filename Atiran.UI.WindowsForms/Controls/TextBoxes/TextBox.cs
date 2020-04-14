using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.TextBoxes
{
    public class TextBox : System.Windows.Forms.TextBox
    {
        public System.Windows.Forms.Control NextControl { get; set; }
        public bool HavingStar = false;
        public bool SendTabKey = false;
        public Color EnterBackColor = Color.FromArgb(225, 174, 0);
        public Color LeaveBackColor = Color.White;
        public Color EnterForColor = Color.Black;
        public Color LeaveForColor = Color.Black;
        public TextBox()
        {
            InitializeUI();
            this.KeyPress += TextBox_KeyPress;
            this.Enter += TextBox_Enter;
            this.Leave += TextBox_Leave;
            this.KeyDown += TextBox_KeyDown;
            this.TextChanged += TextBox_TextChanged;

        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (HavingStar && (this.Text.Contains("*") | this.Text.Contains("/")))
            {
                this.Text = this.Text.Replace("*", "");
                this.Text = this.Text.Replace("/", "");
                this.SelectionStart = this.Text.Length;
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                this.SelectAll();
            }
            if (HavingStar)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Multiply)
                {
                    this.Text += "00";
                    this.SelectionStart = this.Text.Length;
                }
                if (e.KeyCode == System.Windows.Forms.Keys.Divide)
                {
                    this.Text += "000";
                    this.SelectionStart = this.Text.Length;
                }
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = LeaveBackColor;
            this.ForeColor = LeaveForColor;
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            this.BackColor = EnterBackColor;
            this.ForeColor = EnterForColor;
        }
        private void InitializeUI()
        {
            this.AutoSize = true;
            this.Margin = new Padding(10);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Width = 200;
            this.Height = 34;
            this.TextAlign = HorizontalAlignment.Right;
            this.Font = FontManager.GetDefaultTextFont();
            this.BackColor = LeaveBackColor;
            this.ForeColor = LeaveForColor;
        }

        void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar==(char)13)
            //SendKeys.Send("{TAB}");
            if (e.KeyChar == (char)13)
            {
                if (NextControl != null)
                {
                    if (!NextControl.Enabled || SendTabKey)
                    {
                        SetNextControl((TextBox)sender);
                    }
                    else
                    {
                        NextControl.Focus();
                    }
                }
            }

        }
        private void SetNextControl(TextBox NextControl)
        {
            SendKeys.Send("{TAB}");
        }

    }
}
