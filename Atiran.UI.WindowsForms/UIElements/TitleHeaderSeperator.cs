using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class TitleHeaderSeperator : HeaderSeperator
    {
        public TitleHeaderSeperator(System.Windows.Forms.FlowLayoutPanel parent_) : base(parent_)
        {
            this.BackColor = System.Drawing.Color.FromArgb(254,200,4);
            this.Width = 3;
        }
    }
}
