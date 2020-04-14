using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{
    public class Label : System.Windows.Forms.Label
    {
        public Label()
        {
            InitializeUI();
            
        }

        private void InitializeUI()
        {
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Font = FontManager.GetDefaultTextFont();
        }
    }
}
