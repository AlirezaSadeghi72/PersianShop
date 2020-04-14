using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{
    public class TimeControl : Atiran.UI.WindowsForms.Controls.UserControl
    {
        private Label label2;
        private NumericTextBox txtminutestart;
        private NumericTextBox txthourstart;
        private TextBoxes.TextBox txtstarttime;
        Regex regexInt = new Regex("^[0-9]+$");
        public TimeControl()
        {
            InitializeComponent();
            txtminutestart.SendTabKey = true;
        }
        private void InitializeComponent()
        {
            this.label2 = new Atiran.UI.WindowsForms.Controls.Label();
            this.txtminutestart = new Atiran.UI.WindowsForms.Controls.NumericTextBox();
            this.txthourstart = new Atiran.UI.WindowsForms.Controls.NumericTextBox();
            this.txtstarttime = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("IRANSans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = " : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtminutestart
            // 
            this.txtminutestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtminutestart.BackColor = System.Drawing.Color.White;
            this.txtminutestart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtminutestart.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txtminutestart.ForeColor = System.Drawing.Color.Black;
            this.txtminutestart.Location = new System.Drawing.Point(74, 4);
            this.txtminutestart.Margin = new System.Windows.Forms.Padding(10);
            this.txtminutestart.MaxLength = 2;
            this.txtminutestart.Name = "txtminutestart";
            this.txtminutestart.NextControl = this.label2;
            this.txtminutestart.Size = new System.Drawing.Size(38, 22);
            this.txtminutestart.TabIndex = 37;
            this.txtminutestart.Text = "00";
            this.txtminutestart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtminutestart.Value = 0D;
            this.txtminutestart.TextChanged += new System.EventHandler(this.Txtminutestart_TextChanged);
            this.txtminutestart.Leave += new System.EventHandler(this.Txtminutestart_Leave);
            // 
            // txthourstart
            // 
            this.txthourstart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txthourstart.BackColor = System.Drawing.Color.White;
            this.txthourstart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txthourstart.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txthourstart.ForeColor = System.Drawing.Color.Black;
            this.txthourstart.Location = new System.Drawing.Point(8, 4);
            this.txthourstart.Margin = new System.Windows.Forms.Padding(10);
            this.txthourstart.MaxLength = 2;
            this.txthourstart.Name = "txthourstart";
            this.txthourstart.NextControl = this.txtminutestart;
            this.txthourstart.Size = new System.Drawing.Size(38, 22);
            this.txthourstart.TabIndex = 36;
            this.txthourstart.Text = "00";
            this.txthourstart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txthourstart.Value = 0D;
            this.txthourstart.TextChanged += new System.EventHandler(this.Txthourstart_TextChanged);
            this.txthourstart.Leave += new System.EventHandler(this.Txthourstart_Leave);
            // 
            // txtstarttime
            // 
            this.txtstarttime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtstarttime.BackColor = System.Drawing.Color.White;
            this.txtstarttime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtstarttime.Enabled = false;
            this.txtstarttime.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txtstarttime.ForeColor = System.Drawing.Color.Black;
            this.txtstarttime.Location = new System.Drawing.Point(3, 1);
            this.txtstarttime.Margin = new System.Windows.Forms.Padding(10);
            this.txtstarttime.Name = "txtstarttime";
            this.txtstarttime.NextControl = null;
            this.txtstarttime.ReadOnly = true;
            this.txtstarttime.Size = new System.Drawing.Size(115, 29);
            this.txtstarttime.TabIndex = 38;
            this.txtstarttime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtstarttime.Enter += new System.EventHandler(this.Txtstarttime_Enter);
            // 
            // TimeControl
            // 
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtminutestart);
            this.Controls.Add(this.txthourstart);
            this.Controls.Add(this.txtstarttime);
            this.Name = "TimeControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(121, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void Txtstarttime_Enter(object sender, EventArgs e)
        {
            txthourstart.Focus();
        }
        private void Txthourstart_TextChanged(object sender, EventArgs e)
        {
            SetRegularExpressionInt((TextBox)sender);
            if (int.Parse(this.txthourstart.Text) > 24)
            {
                txthourstart.Text = "24";
            }
            if (txthourstart.Text.Length == 2)
            {
                txtminutestart.Focus();
            }
        }
        private void SetRegularExpressionInt(TextBox txt)
        {
            if (!regexInt.IsMatch(txt.Text))
            {
                if (txt.Text.Length <= 1)
                {
                    txt.Text = "0"; return;
                }
                txt.Text = txt.Text.Remove(txt.Text.Length - 1);
                txt.SelectionStart = txt.Text.Length;
            }
        }
        private void Txtminutestart_TextChanged(object sender, EventArgs e)
        {
            SetRegularExpressionInt((TextBox)sender);
            if (int.Parse(this.txtminutestart.Text) > 59)
            {
                txtminutestart.Text = "59";
            }
        }
        private void Txthourstart_Leave(object sender, EventArgs e)
        {
            if (txthourstart.Text.Length < 2)
            {
                txthourstart.Text = "0" + txthourstart.Text;
            }
        }
        private void Txtminutestart_Leave(object sender, EventArgs e)
        {
            if (txtminutestart.Text.Length < 2)
            {
                txtminutestart.Text = "0" + txtminutestart.Text;
            }
        }
        public string TimeValue()
        {
            return $"{txthourstart.Text}:{txtminutestart.Text}:00";
        }
        public void SetTime(string TimeVal)
        {
            txthourstart.Text = TimeVal.Substring(0, 2);
            txtminutestart.Text = TimeVal.Substring(3, 2);
        }
    }
}
