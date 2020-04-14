using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
   public class UserOnline:Controls.Label
    {
        public UserOnline()
        {
            this.Image = Resources.status_online;
            this.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Location = new System.Drawing.Point(41, 51);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(206, 40);
            this.Text = "";
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        }
    }
}
