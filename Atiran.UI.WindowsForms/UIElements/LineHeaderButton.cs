using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.UI.WindowsForms.Controls;
using System.Windows.Forms;
using System.Drawing;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class LineHeaderButton : HeaderButton
    {
        public Controls.Label lblUserFullName;
        ToolTip tlp;
        public LineHeaderButton(Header parent_, string fullName) : base(parent_)
        {
            this.Width = 250;
            this.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);
            this.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);

            lblUserFullName = new Controls.Label();

            lblUserFullName.Text = fullName;
            lblUserFullName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            lblUserFullName.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            lblUserFullName.Dock = DockStyle.Fill;
            lblUserFullName.Font = FontManager.GetFont("IRANSans", 10, FontStyle.Regular);
            this.Controls.Add(lblUserFullName);
            this.lblUserFullName.MouseHover += LineHeaderButton_MouseHover;
            lblUserFullName.MouseLeave += LblUserFullName_MouseLeave;
            //PictureBox userImage = new PictureBox();
            //userImage.Image = Resources._376;
            //userImage.Width = Resources._376.Width;
            //userImage.Dock = DockStyle.Right;
            //this.Controls.Add(userImage);

            // HeaderSeperator seperator = new HeaderSeperator(this);
            // seperator.Dock = System.Windows.Forms.DockStyle.Right;
            // this.Controls.Add(seperator);
        }

        private void LblUserFullName_MouseLeave(object sender, EventArgs e)
        {
            this.lblUserFullName.BackColor = Color.Transparent;
            lblUserFullName.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
        }

        private void LineHeaderButton_MouseHover(object sender, EventArgs e)
        {
            this.lblUserFullName.BackColor = Color.Khaki;
            this.lblUserFullName.ForeColor = Color.Black;
            if (tlp != null)
                tlp.Dispose();
            tlp = new ToolTip();
            tlp.Show("براي تغيير لاين كليك كنيد", lblUserFullName, 2000);
            this.lblUserFullName.Cursor = Cursors.Hand;
        }
    }
}
