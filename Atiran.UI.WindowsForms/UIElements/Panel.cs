using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class Panel : System.Windows.Forms.Panel
    {
        public Panel()
        {
            this.Font = FontManager.GetDefaultTextFont();
        }
    }
}
