using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class LoginCloseHeaderButton : HeaderButton
    {
        public LoginCloseHeaderButton(Header parent_) : base(parent_)
        {
            this.Width = 36;
            this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Close_36px") as Bitmap;

            
            this.MouseLeave += LoginCloseHeaderButton_MouseLeave;
            this.MouseEnter += LoginCloseHeaderButton_MouseEnter;
        }

        private void LoginCloseHeaderButton_MouseEnter(object sender, EventArgs e)
        {
            this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Close_36px_hover") as Bitmap;
        }

        private void LoginCloseHeaderButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Login_Close_36px") as Bitmap;

        }

     
    }
}
