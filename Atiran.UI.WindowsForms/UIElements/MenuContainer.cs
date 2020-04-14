using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MenuContainer : System.Windows.Forms.FlowLayoutPanel 
    {
        public Form parent;
        public List<MenuButton> items;
        public MenuContainer(Form parent_)
        {
            //this.AutoSize = true;
            parent = parent_;
            items = new List<MenuButton>();
            this.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Margin= System.Windows.Forms.Padding.Empty;
            this.BackColor = Color.FromArgb(56,79,99);
            this.BringToFront();
            parent.Controls.Add(this);
            this.ControlAdded += MenuContainer_ControlAdded;
        }

        private void MenuContainer_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            int sum = 0;
           foreach (MenuButton c in this.items)
            {
                sum += 35;
            }
            this.Height =sum;
        }

        public void AddItem(MenuButton item)
        {
            items.Add(item);
            this.Controls.Add(item);
            MenuItemSeperator sep = new MenuItemSeperator();
            this.Controls.Add(sep);
            sep.SetWidth();
        }

       

    }

    
}
