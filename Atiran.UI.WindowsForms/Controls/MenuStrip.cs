using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.Controls
{
   public class MenuStrip:System.Windows.Forms.MenuStrip
    {
        public MenuStrip()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.Font = FontManager.GetDefaultTextFont();
        }
    }
}
