using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.Controls
{
   public class TabControl:System.Windows.Forms.TabControl
    {
        public TabControl TabNextControll { get; set; }
        public TabControl()
        {
            this.Font = FontManager.GetDefaultTextFont();
            this.KeyDown += TabControl_KeyDown;
        }

        private void TabControl_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            
        }
    }
}
