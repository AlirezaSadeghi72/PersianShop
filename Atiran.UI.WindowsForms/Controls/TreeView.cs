using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.Controls
{
    public class TreeView : System.Windows.Forms.TreeView
    {
        public TreeView()
        {
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.Font = FontManager.GetDefaultTextFont();


        }
    }
}