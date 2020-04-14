using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class LoginMaximizeHeaderButton : HeaderButton
    {
        public LoginMaximizeHeaderButton(Header parent_)
            : base(parent_)
        {
            this.Width = 36;
            if (this.parent.parent.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Max_33px") as Bitmap;
            }
            else
            {
                this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Max_33px") as Bitmap;
            }

            this.Click += MaximizeHeaderButton_Click;
            this.MouseHover += MaximizeHeaderButton_MouseHover;
            this.MouseLeave += MaximizeHeaderButton_MouseLeave;
        }

        private void MaximizeHeaderButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.parent.parent.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Max_33px") as Bitmap;
            }
            else
            {
                this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Max_33px") as Bitmap;
            }
        }

        private void MaximizeHeaderButton_MouseHover(object sender, EventArgs e)
        {
            if (this.parent.parent.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Max_33px_hover") as Bitmap;
            }
            else
            {
                this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Max_33px_hover") as Bitmap;
            }
        }
        void MaximizeHeaderButton_Click(object sender, EventArgs e)
        {
            if (this.parent.parent.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.parent.parent.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
            else
            {
                this.parent.parent.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }
    }
}
    
