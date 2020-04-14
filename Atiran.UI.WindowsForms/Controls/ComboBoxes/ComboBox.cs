using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.ComboBoxes
{
    public class ComboBox : System.Windows.Forms.ComboBox
    {
        public System.Windows.Forms.Control NextControl { get; set; }
        public ComboBox()
        {
            InitializeUI();
      
            this.KeyDown += ComboBox_KeyDown;

            this.LostFocus += ComboBox_LostFocus;
            this.GotFocus += ComboBox_GotFocus;
            this.KeyPress += ComboBox_KeyPress;
          
          
            
        }

        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void ComboBox_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(225, 174, 0);
        }

        private void ComboBox_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }



        private void ComboBox_KeyDown(object sender, KeyEventArgs e)
    {
            //if (e.KeyCode == Keys.Enter)
            //    SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.Enter)
            {
                if (NextControl != null)
                {
                    if (!NextControl.Enabled)
                    {
                        SetNextControl((ComboBox)sender);
                    }
                    else
                    {
                        NextControl.Focus();
                    }
                }
            }
        }
        private void SetNextControl(ComboBox NextControl)
        {
            SendKeys.Send("{TAB}");
        }


        private void InitializeUI()
        {
            this.AutoSize = true;
           this.Margin = new Padding(10);
            this.FormattingEnabled = true;

            // this.Font = FontManager.GetFont("B Nazanin", 12, System.Drawing.FontStyle.Bold);
            this.Width = 200;
            this.Height = 34;
            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            
        }
    }
}
