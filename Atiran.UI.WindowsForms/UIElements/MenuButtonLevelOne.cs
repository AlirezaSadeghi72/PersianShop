using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MenuButtonLevelOne : MenuButton
    {

        public MenuButtonLevelOne(List<Connections.AtiranAccModel.Menu> childeren_, Connections.AtiranAccModel.Menu self_,MenuContainer parent_) : base(childeren_,self_, parent_)
        {
            this.Height = 35;
            this.Width = 200;
            this.Font = FontManager.GetFont("IRANSans", 11F, FontStyle.Regular);
            rightSpace.Width = 30;
            title.Width = 200 - 30;
            title.Height = 35;
            this.rightSpace.MouseEnter += MenuButtonLevelOne_MouseEnter;
            this.title.MouseEnter += MenuButtonLevelOne_MouseEnter;
            this.rightSpace.MouseLeave += RightSpace_MouseLeave;
            this.title.MouseLeave+= RightSpace_MouseLeave;
        }

        private void RightSpace_MouseLeave(object sender, System.EventArgs e)
        {
           // this.Font = UI.WindowsForms.FontManager.GetFont("IRANSans", 11.5F, FontStyle.Bold);
        }
       public void ShowMenuChildren()
        {
            int height = 0;
            foreach (MenuButton m in ((MenuContainer)this.Parent).items)
            {
                if (m.children.Count > 0)
                    m.title.Image = ResourceManager.GetResourceManager().GetObject("sort_down_green") as Image;
            }
            if (this.children.Count > 0)
                this.title.Image = ResourceManager.GetResourceManager().GetObject("Actions_arrow_left_icon") as Image;
            //this.Font = UI.WindowsForms.FontManager.GetFont("IRANSans", 11.5F, FontStyle.Bold);
            if ((GetHubForm.GetCurrent).WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                (GetHubForm.GetCurrent).WindowState = System.Windows.Forms.FormWindowState.Maximized;
                (GetHubForm.GetCurrent).SendToBack();
            }
           ((Atiran.UI.WindowsForms.UIElements.Form)this.Parent.Parent).InvisibleSubMenus();
            if (childContainer.Controls.Count > 0)
            {

                childContainer.Visible = true;
                foreach (var item in childContainer.items)
                {
                    height += item.Height;
                }
                 height += 135;
               // height += 65;
                childContainer.Size = new Size(childContainer.Width, height);
                childContainer.Visible = true;
                if (childContainer.Height + childContainer.Location.Y >= Atiran.UI.WindowsForms.GetHubForm.GetCurrent.Height - 35)
                {
                    // childContainer.Height = Atiran.UI.WindowsForms.GetHubForm.GetCurrent.Height - childContainer.Location.Y;
                    childContainer.Location = new Point(childContainer.Location.X, Atiran.UI.WindowsForms.GetHubForm.GetCurrent.Height - (childContainer.Height + 35));
                }
            }
        }
        private void MenuButtonLevelOne_MouseEnter(object sender, System.EventArgs e)
        {
            ShowMenuChildren();
        }
    }
}
