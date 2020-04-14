using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MenuItemSeperator : System.Windows.Forms.Panel
    {
        public MenuItemSeperator()
        {
            this.Height = 1;
            
            this.BackColor = System.Drawing.Color.FromArgb(43,65,85);
        }

        public void SetWidth()
        {
            if (this.Parent != null)
            {
                this.Width = this.Parent.Width - 20;
            }
        }
    }
}
