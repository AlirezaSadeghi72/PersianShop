using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms
{
    public class UserControlLoader
    {
        UI.WindowsForms.UIElements.Form D;
        bool ChangeSizeFormBySizeOfTheUserControl;
        bool AllSize;
        bool Pad;
        private void D_Load(object sender, EventArgs e)
        {
            using (Atiran.UI.WindowsForms.UIElements.Form frm = new Atiran.UI.WindowsForms.UIElements.Form())
            // ;
            {
                if (AllSize)
                {
                    if (showMaximizeSate_)
                    {
                        frm.KeyPreview = true;
                        usercontrol_.Dock = DockStyle.Fill;
                        frm.WindowState = FormWindowState.Maximized;
                        frm.Controls.Add(usercontrol_);
                        frm.ShowDialog();
                        if (Pad) frm.BackColor = Color.LightSeaGreen;
                        if (Pad) frm.Padding = new Padding(10, 10, 10, 10);
                        D.Close();
                    }
                    else
                    {
                        frm.KeyPreview = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Width = usercontrol_.Width;
                        frm.Height = usercontrol_.Height;
                        if (ChangeSizeFormBySizeOfTheUserControl)
                            frm.MaximumSize = new Size(usercontrol_.Width, usercontrol_.Height);
                        usercontrol_.Dock = DockStyle.Fill;
                        frm.WindowState = FormWindowState.Normal;
                        if (Pad) frm.BackColor = Color.LightSeaGreen;
                        if (Pad) frm.Padding = new Padding(10, 10, 10, 10);
                        frm.Controls.Add(usercontrol_);
                        frm.ShowDialog();
                        D.Close();
                    }
                }
                else
                {
                    frm.KeyPreview = true;
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    usercontrol_.Width = Screen.PrimaryScreen.Bounds.Width - 30;
                    usercontrol_.Height = Screen.PrimaryScreen.Bounds.Height - 30;
                    frm.Width = usercontrol_.Width;
                    frm.Height = usercontrol_.Height;
                    frm.MaximumSize = new Size(usercontrol_.Width, usercontrol_.Height);
                    usercontrol_.Dock = DockStyle.Fill;
                    frm.WindowState = FormWindowState.Normal;
                    if (Pad) frm.BackColor = Color.LightSeaGreen;
                    if (Pad) frm.Padding = new Padding(10, 10, 10, 10);
                    frm.Controls.Add(usercontrol_);
                    frm.ShowDialog();
                    D.Close();
                }

            }
        }
        bool showMaximizeSate_;
        UserControl usercontrol_;
        public UserControlLoader(UserControl usercontrol, bool ChangeSizeFormBySizeOfTheUserControl_ = false, bool showMaximizeSate = false, bool AllSize_ = false, bool Pad_ = true)
        {
            try
            {
                usercontrol_ = usercontrol;
                using (D = new UI.WindowsForms.UIElements.Form())//;
                {
                    D.BackColor = Color.Black;
                    D.Opacity = 0.60f;
                    D.Width = usercontrol.Width;
                    D.Height = usercontrol.Height;
                    D.WindowState = FormWindowState.Maximized;
                    showMaximizeSate_ = showMaximizeSate;
                    Pad = Pad_;
                    AllSize = AllSize_;
                    ChangeSizeFormBySizeOfTheUserControl = ChangeSizeFormBySizeOfTheUserControl_;
                    D.Load += D_Load;
                    D.openAsShortcut = true;
                    D.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
