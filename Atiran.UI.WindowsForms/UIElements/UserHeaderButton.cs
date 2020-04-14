using Atiran.UI.WindowsForms.Controls;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class UserHeaderButton : HeaderButton
    {
        PictureBox userImage;
        Controls.Label lblUserFullName;
        public UserHeaderButton(Header parent_, string fullName): base(parent_)
        {
            this.Width = 206;
            this.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);
            this.ForeColor = System.Drawing.Color.FromArgb(255,255,255);
            userImage = new PictureBox();
            lblUserFullName = new Controls.Label();
            lblUserFullName.Text = fullName;
            lblUserFullName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            lblUserFullName.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            lblUserFullName.Dock = DockStyle.Fill;
            lblUserFullName.Font = FontManager.GetFont("IRANSans", 10, FontStyle.Bold);
            this.Controls.Add(lblUserFullName);
            lblUserFullName.MouseHover += LblUserFullName_MouseHover;
            userImage.Image = Resources.user;
            userImage.Width = Resources.user.Width;
            userImage.Dock = DockStyle.Right;
            userImage.Padding = new Padding(0, 4, 0, 0);
            this.Controls.Add(userImage);
            userImage.Click += UserHeaderButton_Click;
            userImage.MouseHover += UserImage_MouseHover;
            userImage.MouseLeave += UserImage_MouseLeave;
           // HeaderSeperator seperator = new HeaderSeperator(this);
           // seperator.Dock = System.Windows.Forms.DockStyle.Right;
           // this.Controls.Add(seperator);
        }

        

        private void LblUserFullName_MouseHover(object sender, System.EventArgs e)
        {
            lblUserFullName.Cursor = Cursors.Hand;
           
        }

       
        private void UserImage_MouseLeave(object sender, System.EventArgs e)
        {
           
            userImage.Image = Resources.user;
           
        }

        private void UserImage_MouseHover(object sender, System.EventArgs e)
        {
            userImage.Cursor = Cursors.Hand;
            userImage.Image = Resources.user_hover;
            
        }

        private void UserHeaderButton_Click(object sender, System.EventArgs e)
        {
            string startupPath = Path.GetDirectoryName(Application.ExecutablePath);
            bool isRunning = System.Diagnostics.Process.GetProcessesByName("final2")
                               .FirstOrDefault(p => p.MainModule.FileName.StartsWith(startupPath)) != default(System.Diagnostics.Process);
            if (isRunning)
            {
                Process[] proc = Process.GetProcessesByName("final2");
                proc[0].CloseMainWindow();
            }
            Application.Restart();
        }
    }
}
