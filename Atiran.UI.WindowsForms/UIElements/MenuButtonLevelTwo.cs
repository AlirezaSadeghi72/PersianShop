using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MenuButtonLevelTwo : MenuButton
    {
        Panel indicator;

        public MenuButtonLevelTwo(List<Connections.AtiranAccModel.Menu> childeren_, Connections.AtiranAccModel.Menu self_, MenuContainer parent_) : base(childeren_, self_, parent_)
        {

            this.Width = 300;
            this.Font = UI.WindowsForms.FontManager.GetFont("IRANSans", 9.5F, FontStyle.Regular);
            indicator = new Panel()
            {
                Dock = System.Windows.Forms.DockStyle.Right,
                BackColor = Color.Transparent,
                Width = 5
            };
            rightSpace.Controls.Add(indicator);
            rightSpace.Width = 20;
            title.Width = 300 - 20;
            title.Height = 23;
            this.Height = 23;
            this.title.MouseEnter += MenuButtonLevelTwo_MouseEnter;
            this.rightSpace.MouseEnter += MenuButtonLevelTwo_MouseEnter;
            this.title.MouseLeave += Title_MouseLeave;
            this.rightSpace.MouseLeave += Title_MouseLeave;
            focusedLevelTwo = true;
        }
        private void Title_MouseLeave(object sender, System.EventArgs e)
        {
            indicator.BackColor = Color.Transparent;
            focusedLevelTwo = false;
        }
        public void ShowChildren()
        {
            indicator.BackColor = Color.Yellow;
            int height = 0;
            foreach (MenuButton m in ((MenuContainer)this.Parent).items)
            {
                m.childContainer.Visible = false;
                if (m.children.Count > 0)
                    m.title.Image = ResourceManager.GetResourceManager().GetObject("sort_down_green") as Image;
            }
            if (this.children.Count > 0)
                this.title.Image = ResourceManager.GetResourceManager().GetObject("Actions_arrow_left_icon") as Image;
            if (childContainer.Controls.Count > 0)
            {
                foreach (var item in childContainer.items)
                {
                    height += item.Height;
                }
                height += 70;
                //  MessageBox.Show(childContainer.Location.X.ToString() + childContainer.Location.Y.ToString());
                childContainer.Size = new Size(childContainer.Width, height);
                childContainer.Visible = true;
                if (childContainer.Height + childContainer.Location.Y >= Atiran.UI.WindowsForms.GetHubForm.GetCurrent.Height - 35)
                {
                    childContainer.Height = Atiran.UI.WindowsForms.GetHubForm.GetCurrent.Height - childContainer.Location.Y;
                }
            }
            focusedLevelTwo = true;
        }
        public void HideChildren()
        {
            indicator.BackColor = Color.Transparent;
            int height = 0;
            foreach (MenuButton m in ((MenuContainer)this.Parent).items)
            {
                m.childContainer.Visible = false;
                if (m.children.Count > 0)
                    m.title.Image = ResourceManager.GetResourceManager().GetObject("sort_down_green") as Image;
            }
            if (this.children.Count > 0)
                this.title.Image = ResourceManager.GetResourceManager().GetObject("Actions_arrow_left_icon") as Image;
            if (childContainer.Controls.Count > 0)
            {
                foreach (var item in childContainer.items)
                {
                    height += item.Height;
                }
                height += 70;
                //  MessageBox.Show(childContainer.Location.X.ToString() + childContainer.Location.Y.ToString());
                childContainer.Size = new Size(childContainer.Width, height);
                childContainer.Visible = false;
                if (childContainer.Height + childContainer.Location.Y >= Atiran.UI.WindowsForms.GetHubForm.GetCurrent.Height - 35)
                {
                    childContainer.Height = Atiran.UI.WindowsForms.GetHubForm.GetCurrent.Height - childContainer.Location.Y;
                }
            }
            focusedLevelTwo = false;
        }
        private void MenuButtonLevelTwo_MouseEnter(object sender, System.EventArgs e)
        {
            ShowChildren();
        }
    }
}
