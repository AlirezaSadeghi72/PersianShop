using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
  public class HubSeperator : HeaderSeperator
    {
        public HubSeperator(System.Windows.Forms.FlowLayoutPanel parent_) : base(parent_)
        {
            this.BackColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.Width = 6;
        }
    }
}
