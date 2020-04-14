using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions.UserOp;
using Atiran.Connections.Operaions.UserPersonalizationOp;
using Atiran.Connections.Security;
using Atiran.Main.Main;
using Atiran.UI.WindowsForms;
using Atiran.UI.WindowsForms.Controls.TextBoxes;
using Atiran.UI.WindowsForms.UIElements;

namespace Atiran.Main
{
    public class frmLogin : UI.WindowsForms.UIElements.EnviromentMainForm, IDisposable
    {
        LoginCloseHeaderButton close;
        LoginMaximizeHeaderButton max;
        LoginMinimizeHeaderButton min;

        UI.WindowsForms.UIElements.Panel pnlLoginContainer;
        Atiran.UI.WindowsForms.UIElements.Panel pnlLoginControls;
        List<Atiran.UI.WindowsForms.UIElements.Panel> ps;
        int betweenPsMargin;
        public LargeTextBox tbxUsername;
        public LargeTextBox tbxPassword;
        Atiran.UI.WindowsForms.Controls.Buttons.Button btnSignIn;
        UI.WindowsForms.Controls.Label lblMessage;
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public void AutoLogin()
        {
            if (Connections.AtiranAccModel.ConnectionInfo.AdminUser != null && Connections.AtiranAccModel.ConnectionInfo.AdminPass != null)
            {
                tbxUsername.Text = Connections.AtiranAccModel.ConnectionInfo.AdminUser;
                tbxPassword.Text = Connections.AtiranAccModel.ConnectionInfo.AdminPass;
                BtnSignIn_Click(null, null);
            }
        }
        public frmLogin(Connections.Enums.Definitions.EnvironmentNames env_) : base(env_)
        {
            if (!InitializeDesign()) this.Dispose();
        }
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            try
            {

                if (FormIsValid())
                {
                    SecurityResult result = Authentication.Authenticate(tbxUsername.Text.Trim(), tbxPassword.Text.Trim());

                    if (result.IsAuthenticated)
                    {

                        GetCurrentSysUser.SetCurrentUserByFiscalUserName(tbxUsername.Text.Trim());
                        UserService.UserLogined(GetCurrentSysUser.Instance.UserID);
                        UserPersonalizationOperaion.SetUserPersonalization();

                        this.Hide();
                        #region  جزيره اي
                        //if (ResultOveral.Any(a => a.id == 267 && a.value == 0))
                        //{
                        //var hub = new Hub(tbxUsername.Text.Trim());
                        //hub.Show();
                        //}
                        #endregion
                        #region تب بار
                        //else if (ResultOveral.Any(a => a.id == 267 && a.value == 1))
                        //{
                        var HubTabBar = new TabBarMenu(tbxUsername.Text.Trim());
                        HubTabBar.Show();
                        //}
                        #endregion
                    }
                    else
                    {
                        lblMessage.Text = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString(result.Exceptions[0].ErrorCode);
                        lblMessage.Visible = true;
                        lblMessage.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("", ex.Message, "e");
            }
        }
        private void LoginForm_SizeChanged(object sender, System.EventArgs e)
        {
            LocatepnlLoginContainer();
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this.paintFlag)
            {
                Bitmap image = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Back_Login") as Bitmap;
                var newImage = new Bitmap(this.Width, this.Height);
                var graphics = Graphics.FromImage(newImage);
                graphics.DrawImage(image, 0, 0, this.Width, this.Height);
                e.Graphics.DrawImage(newImage, BackStartingPoint(newImage));
            }
        }
        private bool InitializeDesign()
        {

            //Window
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            EnvironmentHeader header = new EnvironmentHeader(this);
            close = new LoginCloseHeaderButton(header);
            max = new LoginMaximizeHeaderButton(header);
            min = new LoginMinimizeHeaderButton(header);



            close.Click += Close_Click;
            header.rightPanel.Controls.Add(close);
            header.rightPanel.Controls.Add(max);
            header.rightPanel.Controls.Add(min);
            header.BackColor = Color.Transparent;
            SizeGrip sizeGripObj = new SizeGrip(this);
            this.Controls.Add(sizeGripObj);
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.SizeChanged += LoginForm_SizeChanged;
            pnlLoginContainer = new UI.WindowsForms.UIElements.Panel()
            {
                Width = 505,
                Height = 404,
                BackColor = Color.Transparent
            };
            this.Controls.Add(pnlLoginContainer);
            LocatepnlLoginContainer();

            pnlLoginContainer.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("AtiranLogo_large") as Bitmap;
            pnlLoginContainer.BackgroundImageLayout = ImageLayout.None;

            pnlLoginControls = new Atiran.UI.WindowsForms.UIElements.Panel()
            {
                Width = 338,
                Height = 204,
                BackColor = Color.Transparent,
                Top = 200,
                Left = 120
            };
            pnlLoginContainer.Controls.Add(pnlLoginControls);
            pnlLoginControls.BringToFront();

            betweenPsMargin = 12;

            if (!AddPs(0)) return false;
            if (!AddPs(1)) return false;
            if (!AddPs(3)) return false;
            if (!AddPs(4)) return false;

            lblMessage.ForeColor = Color.Red;
            lblMessage.Font = FontManager.GetFont("IRANSans", 10, FontStyle.Regular);
            this.Load += (e, s) =>
            {
                Atiran.Connections.AtiranAccModel.ConnectionInfo.ReadData();
                AutoLogin();
            };
            return true;

        }
        private bool AddPs(int index)
        {
            if (ps == null)
                ps = new List<UI.WindowsForms.UIElements.Panel>();
            Atiran.UI.WindowsForms.UIElements.Panel p = new UI.WindowsForms.UIElements.Panel();
            ps.Add(p);
            p.Left = 0;
            p.Top = pnlLoginControls.Controls.Count * (32 + betweenPsMargin);
            p.Width = pnlLoginControls.Width;
            p.Height = 32;
            p.BackColor = Color.Transparent;
            pnlLoginControls.Controls.Add(p);
            Atiran.UI.WindowsForms.UIElements.Panel ptext = new UI.WindowsForms.UIElements.Panel()
            {
                Width = 250,
                Padding = new Padding(0),
                Height = p.Height
            };
            Atiran.UI.WindowsForms.UIElements.Panel plabel = new UI.WindowsForms.UIElements.Panel()
            {
                Width = p.Width - 250,
                Left = 250,
                Top = 0,
                Padding = new Padding(0),
                Height = p.Height,
                BackColor = Color.Transparent
            };
            switch (index)
            {
                case 0:
                    tbxUsername = new LargeTextBox()
                    {
                        Margin = new Padding(0),
                        Dock = DockStyle.Fill,

                        Font = new System.Drawing.Font("IRANSans(FaNum)", 12.5F)//FontManager.GetFont("IRANSans", 16, FontStyle.Regular);
                    };
                    ptext.Controls.Add(tbxUsername);
                    p.Controls.Add(ptext);

                    Label title = new Label()
                    {
                        Text = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString("LoginForm_lblUsername_Text"),
                        Dock = DockStyle.Fill,
                        Font = FontManager.GetFont("IRANSans", 11, FontStyle.Regular),
                        ForeColor = Color.FromArgb(255, 255, 255),
                        BackColor = Color.Transparent,
                        Padding = new Padding(0)
                    };
                    plabel.Controls.Add(title);
                    p.Controls.Add(plabel);
                    return true;

                case 1:
                    tbxPassword = new LargeTextBox();
                    tbxUsername.NextControl = tbxPassword;
                    tbxPassword.Margin = new Padding(0);
                    tbxPassword.Dock = DockStyle.Fill;
                    tbxPassword.Font = new System.Drawing.Font("IRANSans(FaNum)", 14.5F);//FontManager.GetFont("IRANSans", 16, FontStyle.Regular);
                    tbxPassword.PasswordChar = '•';
                    ptext.Controls.Add(tbxPassword);
                    p.Controls.Add(ptext);

                    Label pwd = new Label()
                    {
                        Text = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString("LoginForm_lblPassword_Text"),
                        Dock = DockStyle.Fill,
                        Font = FontManager.GetFont("IRANSans", 11, FontStyle.Regular),
                        ForeColor = Color.FromArgb(255, 255, 255),
                        BackColor = Color.Transparent,
                        Padding = new Padding(0)
                    };
                    plabel.Controls.Add(pwd);
                    p.Controls.Add(plabel);

                    return true;

                case 3:
                    btnSignIn = new UI.WindowsForms.Controls.Buttons.Button()
                    {
                        Text = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString("LoginForm_btnSignIn_Text"),
                        Dock = DockStyle.Fill,
                        BackColor = Color.FromArgb(140, 186, 2),
                        ForeColor = Color.FromArgb(255, 255, 255),
                        Padding = new Padding(0),
                        Font = FontManager.GetFont("IRANSans", 11, FontStyle.Regular)
                    };
                    btnSignIn.Click += BtnSignIn_Click;
                    ptext.Controls.Add(btnSignIn);
                    p.Controls.Add(ptext);
                    return true;

                case 4:
                    lblMessage = new UI.WindowsForms.Controls.Label()
                    {
                        TextAlign = ContentAlignment.MiddleRight,
                        Dock = DockStyle.Fill,
                        Font = FontManager.GetFont("IRANSans", 14, FontStyle.Regular)
                    };
                    ptext.Controls.Add(lblMessage);
                    p.Controls.Add(ptext);
                    return true;
                default:
                    return true;

            }

        }
        private bool FormIsValid()
        {
            bool isValid = true;
            try
            {
                //Username and Passwprd
                if (string.IsNullOrEmpty(tbxUsername.Text.Trim()) && string.IsNullOrEmpty(tbxPassword.Text.Trim()))
                {
                    string Value = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString("ERR_UandP_IS_EMPTY");

                    lblMessage.Text = Value;
                    isValid = false;
                }
                //Username
                else if (string.IsNullOrEmpty(tbxUsername.Text.Trim()))
                {
                    string Value = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString("ERR_USERNAME_IS_EMPTY");
                    lblMessage.Text = Value;
                    isValid = false;
                }

                //Password
                else if (string.IsNullOrEmpty(tbxPassword.Text.Trim()))
                {
                    lblMessage.Text = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString("ERR_PASSWORD_IS_EMPTY");
                    isValid = false;
                }

            }
            catch (Exception ex)
            {
                UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("", ex.Message, "e");
            }
            return isValid;
        }
        public Point BackStartingPoint(Bitmap image)
        {
            Point result = new Point()
            {
                X = 0,
                Y = 0
            };
            return result;
        }
        private void LocatepnlLoginContainer()
        {
            pnlLoginContainer.Top = (this.Height - pnlLoginContainer.Height) / 2;
            pnlLoginContainer.Left = (this.Width - pnlLoginContainer.Width) / 2;
        }
    }
}





