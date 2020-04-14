using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using Atiran.Connections.Operaions.UserOp;

namespace Atiran.UI.WindowsForms.UIElements
{
    public  class CloseHeaderButton: HeaderButton
    {
       public CloseHeaderButton(Header parent_): base(parent_)
       {
            this.Width = 36;
            this.BackgroundImage = Resources.Close_36px;
            this.Click += CloseHeaderButton_Click;
            this.MouseHover += CloseHeaderButton_MouseHover;
            this.MouseLeave += CloseHeaderButton_MouseLeave;
       }

        private void CloseHeaderButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Close_36px;
        }

        private void CloseHeaderButton_MouseHover(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Close_36px_hover;
        }
        UI.WindowsForms.UIElements.Form D;
        bool ChangeSizeFormBySizeOfTheUserControl;
        private void D_Load(object sender, EventArgs e)
        {
            Atiran.UI.WindowsForms.UIElements.Form frm = new Atiran.UI.WindowsForms.UIElements.Form();
            frm.KeyPreview = true;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Width = usercontrol_.Width;
            frm.Height = usercontrol_.Height;
            if (ChangeSizeFormBySizeOfTheUserControl)
                frm.MaximumSize = new Size(usercontrol_.Width, usercontrol_.Height);
            usercontrol_.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Normal;
            frm.Controls.Add(usercontrol_);
            frm.ShowDialog();
            D.Close();
        }
        UserControl usercontrol_;
        
        public void  UserControlLoader(UserControl usercontrol, bool ChangeSizeFormBySizeOfTheUserControl_ = false)
        {
            try
            {
                usercontrol_ = usercontrol;
                D = new UI.WindowsForms.UIElements.Form();
                D.BackColor = Color.Black;
                D.Opacity = 0.60f;
                D.WindowState = FormWindowState.Maximized;
                ChangeSizeFormBySizeOfTheUserControl = ChangeSizeFormBySizeOfTheUserControl_;
                D.Load += D_Load;
                D.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void CloseHeaderButton_Click(object sender, EventArgs e)
        {
            MessageBoxes.MessageBoxWarning.state = 0;
            DialogResult close = Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم", "آيا مي خواهيد از سيستم خارج شويد؟", "w");
            MessageBoxes.MessageBoxWarning.state = 1;
            if (close == DialogResult.Yes)
            {
                if (CheckBackupPermission.HavePermission())
                {
                    DialogResult res = Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم", "آيا مي خواهيد از اطلاعات پشتيبان بگيريد؟", "w");
                    if (res == DialogResult.Yes)
                    {
                        // backup
                        UI.WindowsForms.Controls.FastBackup c = new WindowsForms.Controls.FastBackup();
                        UserControlLoader(c);

                    }

                }
               
                Application.Exit();
            }
        }
    }
}
