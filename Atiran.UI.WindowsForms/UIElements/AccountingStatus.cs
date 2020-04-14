using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
   public class AccountingStatus : HeaderButton
    {
        public UI.WindowsForms.Controls.Label lblCurrentPath;
        public AccountingStatus(Header parent_, string status)
           : base(parent_)
        {
            this.Width = 140;
            this.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);

            this.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);

            lblCurrentPath = new Controls.Label();
            lblCurrentPath.Text = "وضعيت : " + status.Trim();

            lblCurrentPath.Dock = System.Windows.Forms.DockStyle.Fill;
            lblCurrentPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lblCurrentPath.Padding = new System.Windows.Forms.Padding(0, 8, 1, 0);
            lblCurrentPath.Font = FontManager.GetFont("IRANSans", 10,  System.Drawing.FontStyle.Regular);
            this.Controls.Add(lblCurrentPath);

            // HeaderSeperator seperator = new HeaderSeperator(this);
            //seperator.Dock = System.Windows.Forms.DockStyle.Right;
            //this.Controls.Add(seperator);
        }
    
    }
}
