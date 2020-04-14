using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.Controls.Buttons
{
    public class Button : System.Windows.Forms.Button
    {
        public System.Windows.Forms.Control NextControl { get; set; }

        public Button()
        {
            InitializeUI();
            this.Enter += Button_Enter;
            this.Leave += Button_Leave;
            this.KeyDown += Button_KeyDown;
        }

        private void Button_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Down)
            {
                if (NextControl != null)
                    NextControl.Focus();
            }
        }

        private void Button_Leave(object sender, EventArgs e)
        {
            this.FlatAppearance.BorderColor = Color.Black;
            this.FlatAppearance.BorderSize = 1;
        }

        private void Button_Enter(object sender, EventArgs e)
        {

            this.FlatAppearance.BorderColor = Color.DarkOrange;
            this.FlatAppearance.BorderSize = 1;
        }

        private void InitializeUI()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = FontManager.GetDefaultTextFont();
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Width = 81;
            this.Height = 34;


        }

    }
}
