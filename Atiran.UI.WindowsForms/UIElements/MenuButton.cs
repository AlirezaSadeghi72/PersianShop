using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MenuButton : System.Windows.Forms.FlowLayoutPanel
    {
        public List<Connections.AtiranAccModel.Menu> menuData;
        public Connections.AtiranAccModel.Menu self;
        public List<Connections.AtiranAccModel.Menu> children;
        public MenuContainerLevelTwo childContainer;
        MenuContainer parent;
        public Panel rightSpace;
        public Label title;
        ToolTip tlp;
        public bool FocusON = false;
        public bool focusedLevelTwo = false;
        public MenuButton(List<Connections.AtiranAccModel.Menu> menuData_, Connections.AtiranAccModel.Menu self_, MenuContainer parent_)
        {
            this.Margin = new Padding(0);
            menuData = menuData_;
            self = self_;
            children = menuData.Where(md => md.ParentMenuID == self.MenuID).OrderBy(i => i.order).ToList();
            parent = parent_;
            parent.AddItem(this);
            tlp = new ToolTip();
            tlp.OwnerDraw = true;
            tlp.Draw += Tlp_Draw;
            tlp.Popup += Tlp_Popup;
            this.FlowDirection = FlowDirection.RightToLeft;

            rightSpace = new Panel();

            rightSpace.Height = this.Height;
            rightSpace.Margin = new Padding(0);
            this.Controls.Add(rightSpace);

            title = new Label();
            if (children.Count > 0)
            {
                title.Image = ResourceManager.GetResourceManager().GetObject("sort_down_green") as Image;
                title.ImageAlign = ContentAlignment.MiddleLeft;
                title.Padding = new Padding(5, 0, 0, 0);
            }
            title.TextAlign = ContentAlignment.MiddleRight;
            title.Text = (self_.Titel.Length > title.Width) ? " ... " + self_.Titel.Remove(self_.Titel.LastIndexOf(' ')).ToString() : self_.Titel;
            title.Tag = self_.MenuID;
            title.Height = this.Height;
            title.Margin = new Padding(0);

            this.Controls.Add(title);

            this.ControlAdded += MenuButton_ControlAdded;
            this.Enter += MenuButton_Enter;
            childContainer = new MenuContainerLevelTwo((Atiran.UI.WindowsForms.UIElements.Form)this.Parent.Parent, (MenuContainer)this.parent, this);
            ((Atiran.UI.WindowsForms.UIElements.Form)this.Parent.Parent).AddToSubMenus(childContainer);
            childContainer.Visible = false;

            if (children != null && children.Count > 0)
            {
                foreach (Connections.AtiranAccModel.Menu c in children)
                {
                    MenuButtonLevelTwo mb = new MenuButtonLevelTwo(menuData, c, childContainer);
                }
            }
            childContainer.Top = this.Top + 69;

            //childContainer.Left = this.parent.Left - 200;
            this.BackColor = Color.FromArgb(56, 79, 99);
            this.ForeColor = Color.FromArgb(255, 255, 255);
            this.title.MouseMove += MenuButtonMouseMove;
            this.title.MouseLeave += MenuButton_MouseLeave;
            this.title.MouseEnter += MenuButton_MouseEnter;
            this.title.Click += MenuButton_Click;
            this.rightSpace.MouseMove += MenuButtonMouseMove;
            this.rightSpace.MouseLeave += MenuButton_MouseLeave;
            this.rightSpace.MouseEnter += MenuButton_MouseEnter;
            this.rightSpace.Click += MenuButton_Click;
            this.MouseHover += MenuButton_MouseHover;
        }

        private void MenuButton_Enter(object sender, EventArgs e)
        {
            MenuFocused();
        }

        string tlptext = "";
        private void Tlp_Popup(object sender, PopupEventArgs e)
        {
            e.ToolTipSize = TextRenderer.MeasureText(tlptext, FontManager.GetFont("IRANSans", 9.5f, System.Drawing.FontStyle.Regular));
        }

        private void Tlp_Draw(object sender, DrawToolTipEventArgs e)
        {
            tlp.UseAnimation = true;
            DrawToolTipEventArgs newArgs = new DrawToolTipEventArgs(e.Graphics,
                e.AssociatedWindow, e.AssociatedControl, e.Bounds, e.ToolTipText,
                this.BackColor, Color.Yellow, FontManager.GetFont("IRANSans", 9.5f, System.Drawing.FontStyle.Regular) /*Font("IRANSans(FaNum)_Medium", 10f,FontStyle.Regular)*/);
            newArgs.DrawBackground();
            newArgs.DrawBorder();
            newArgs.DrawText(TextFormatFlags.TextBoxControl);
        }

        private void MenuButton_MouseHover(object sender, EventArgs e)
        {

        }

        private void MenuButton_ControlAdded(object sender, ControlEventArgs e)
        {
            int width = 0;
            foreach (System.Windows.Forms.Control c in this.Controls)
                width += c.Width;
            this.Width = width;
        }

        private void MenuButton_Click(object sender, System.EventArgs e)
        {

        }
        public void MenuFocused()
        {
            this.rightSpace.BackColor = this.title.BackColor = Color.FromArgb(80, 104, 125);
            this.title.ForeColor = Color.FromArgb(255, 255, 255);
            if (this.children.Count > 0)
            {
                this.title.Image = ResourceManager.GetResourceManager().GetObject("Actions_arrow_left_icon") as Image;
            }
            FocusON = true;
        }
        private void MenuButton_MouseEnter(object sender, System.EventArgs e)
        {

            MenuFocused();

            //if (sender is Label)
            //    if (((Label)sender).Tag != null /*&& ((Label)sender).Text.Contains("...")*/)
            //    {

            //        int x = Convert.ToInt32(((Label)sender).Tag.ToString());
            //        if (menuData.Where(i => i.MenuID == x).Count() > 0)
            //        {
            //            tlptext = menuData.Where(i => i.MenuID == x).FirstOrDefault().Text;
            //            tlp.SetToolTip((Label)sender, tlptext);
            //        }
            //    }
        }
        public void FocuseLeaved()
        {

            this.rightSpace.BackColor = this.title.BackColor = Color.FromArgb(56, 79, 99);
            this.title.ForeColor = Color.FromArgb(255, 255, 255);
            FocusON = false;
        }
        private void MenuButton_MouseLeave(object sender, System.EventArgs e)
        {

            FocuseLeaved();
            //if (this.children.Count > 0)
            //{
            //    title.Image = ResourceManager.GetResourceManager().GetObject("sort_down_green") as Image;
            //}
        }

        private void MenuButtonMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {


        }

    }
}
