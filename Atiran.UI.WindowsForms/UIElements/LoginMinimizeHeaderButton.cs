using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class LoginMinimizeHeaderButton : HeaderButton
    {

        public LoginMinimizeHeaderButton(Header parent_)
            : base(parent_)
        {
            this.Width = 36;
            //this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Min_39px") as Bitmap;
            this.Click += MinimizeHeaderButton_Click;
            this.MouseHover += MinimizeHeaderButton_MouseHover;
            this.MouseLeave += MinimizeHeaderButton_MouseLeave;
        }

        private void MinimizeHeaderButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Min_39px") as Bitmap;
        }

        private void MinimizeHeaderButton_MouseHover(object sender, EventArgs e)
        {
            this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Min_39px_hover") as Bitmap;
        }

        void MinimizeHeaderButton_Click(object sender, EventArgs e)
        {
            this.parent.parent.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
    }
}
