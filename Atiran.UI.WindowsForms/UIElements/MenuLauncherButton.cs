using System;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MenuLauncherButton : System.Windows.Forms.Panel
    {
        public EnviromentMainForm AtiranParent;
        public bool MenuIsShow = false;
        ToolTip tlp;
        public MenuLauncherButton(EnviromentMainForm parent_) 
        {
            AtiranParent=parent_;
            this.Top = 39;
            this.Left = AtiranParent.Width - 30;
            this.Width = 30;
            this.Height = 30;
            // this.BackColor = System.Drawing.Color.FromArgb(140,186,2);
            this.BackgroundImage = ResourceManager.GetResourceManager().GetObject("Menu") as Image;
            this.MouseEnter += MenuLauncherButton_MouseEnter;
            this.Click += MenuLauncherButton_Click;
            AtiranParent.Resize += AtiranParent_Resize;
            AtiranParent.Controls.Add(this);
            AtiranParent.slate.Click += Slate_Click;
            this.MouseHover += MenuLauncherButton_MouseHover;
           
        }

        private void MenuLauncherButton_MouseHover(object sender, EventArgs e)
        {
            if (tlp != null)
                tlp.Dispose();
            this.Cursor = Cursors.Hand;
            tlp = new ToolTip();
            tlp.Show("براي مشاهده منو كليك كنيد",this,1500);
        }

        public void DisableMenu()
        {
            if (AtiranParent.menu != null)
            {
                AtiranParent.menu.SendToBack();
                AtiranParent.slate.BringToFront();
                MenuIsShow = false;
            }
        }
        private void MenuLauncherButton_Click(object sender, EventArgs e)
        {
            if (MenuIsShow)
            {
                DisableMenu();
            }
            else
                ShowMenu();
        }

        private void Slate_Click(object sender, EventArgs e)
        {
           DisableMenu();
        }
        public void ShowMenu()
        {
            AtiranParent.menuTimer.Start();
            if (AtiranParent.slate != null)
            {
                AtiranParent.slate.SendToBack();
                AtiranParent.menu.BringToFront();
                MenuIsShow = true;
            }
        }
        private void MenuLauncherButton_MouseEnter(object sender, EventArgs e)
        {
            //AtiranParent.menuTimer.Start();
            //ShowMenu();
        }

        void AtiranParent_Resize(object sender, EventArgs e)
        {
            this.Left = AtiranParent.Width - 30;
        }
    }
}
