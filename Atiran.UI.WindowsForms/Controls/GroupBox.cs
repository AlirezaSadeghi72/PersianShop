using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{
    public class GroupBox : System.Windows.Forms.GroupBox
    {

        public System.Drawing.Color BackColorOptinal = System.Drawing.Color.Empty;
        public GroupBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);
            this.Enter += GroupBox_Enter;
            this.Leave += GroupBox_Leave;
        }

        private void GroupBox_Leave(object sender, EventArgs e)
        {
            this.BackColor = BackColorOptinal;
        }

        private void GroupBox_Enter(object sender, EventArgs e)
        {
            // this.BackColor = System.Drawing.Color.FromArgb(204, 212, 219);
        }
    }
}
