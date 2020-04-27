using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.Operaions.UserOp;
using Atiran.Connections.Operaions.UserPersonalizationOp;
using Atiran.Connections.Security;
using Atiran.Main.Main;
using Atiran.UI.WindowsForms.Controls;
using Label = Atiran.UI.WindowsForms.Controls.Label;
using UserControl = Atiran.UI.WindowsForms.Controls.UserControl;

namespace Atiran.Main
{
    public class Login : UserControl, IDisposable
    {
        private UI.WindowsForms.UIElements.Panel panel1;
        private UI.WindowsForms.UIElements.Panel panel12;
        private UI.WindowsForms.Controls.Buttons.RefreshButton btnEnter;
        private UI.WindowsForms.Controls.Buttons.ExitButton btnExit;
        private UI.WindowsForms.UIElements.Panel panel3;
        private UI.WindowsForms.UIElements.Panel panel4;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txtPass;
        private UI.WindowsForms.UIElements.Panel panel9;
        private pictureBox picPass;
        private UI.WindowsForms.UIElements.Panel panel10;
        private UI.WindowsForms.UIElements.Panel pnlDownPass;
        private UI.WindowsForms.UIElements.Panel panel2;
        private UI.WindowsForms.UIElements.Panel panel8;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txtUser;
        private UI.WindowsForms.UIElements.Panel panel6;
        private pictureBox picUser;
        private UI.WindowsForms.UIElements.Panel panel7;
        private UI.WindowsForms.UIElements.Panel pnlDownUser;
        private UI.WindowsForms.Controls.Timer timer1;
        private pictureBox picFacebook;
        private pictureBox picInstagram;
        private pictureBox picTwitter;
        private Label lblMessage;
        private System.ComponentModel.IContainer components = null;


        public Login()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.picFacebook = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.picInstagram = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.picTwitter = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.panel12 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.btnEnter = new Atiran.UI.WindowsForms.Controls.Buttons.RefreshButton();
            this.btnExit = new Atiran.UI.WindowsForms.Controls.Buttons.ExitButton();
            this.panel3 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.panel4 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.txtPass = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.panel9 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.picPass = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.panel10 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.pnlDownPass = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.panel2 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.panel8 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.txtUser = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.panel6 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.picUser = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.panel7 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.pnlDownUser = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.timer1 = new Atiran.UI.WindowsForms.Controls.Timer();
            this.lblMessage = new Atiran.UI.WindowsForms.Controls.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFacebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInstagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).BeginInit();
            this.panel12.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPass)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblMessage);
            this.panel1.Controls.Add(this.picFacebook);
            this.panel1.Controls.Add(this.picInstagram);
            this.panel1.Controls.Add(this.picTwitter);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel1.Location = new System.Drawing.Point(46, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 197);
            this.panel1.TabIndex = 0;
            // 
            // picFacebook
            // 
            this.picFacebook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFacebook.Image = global::Atiran.Main.Properties.Resources.facebook1;
            this.picFacebook.Location = new System.Drawing.Point(181, 162);
            this.picFacebook.Name = "picFacebook";
            this.picFacebook.Size = new System.Drawing.Size(32, 32);
            this.picFacebook.TabIndex = 4;
            this.picFacebook.TabStop = false;
            this.picFacebook.Click += new System.EventHandler(this.picFacebook_Click);
            this.picFacebook.MouseEnter += new System.EventHandler(this.picFacebook_MouseEnter);
            this.picFacebook.MouseLeave += new System.EventHandler(this.picFacebook_MouseLeave);
            // 
            // picInstagram
            // 
            this.picInstagram.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picInstagram.Image = global::Atiran.Main.Properties.Resources.instagram1;
            this.picInstagram.Location = new System.Drawing.Point(113, 162);
            this.picInstagram.Name = "picInstagram";
            this.picInstagram.Size = new System.Drawing.Size(32, 32);
            this.picInstagram.TabIndex = 4;
            this.picInstagram.TabStop = false;
            this.picInstagram.Click += new System.EventHandler(this.picInstagram_Click);
            this.picInstagram.MouseEnter += new System.EventHandler(this.picInstagram_MouseEnter);
            this.picInstagram.MouseLeave += new System.EventHandler(this.picInstagram_MouseLeave);
            // 
            // picTwitter
            // 
            this.picTwitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTwitter.Image = global::Atiran.Main.Properties.Resources.twitter1;
            this.picTwitter.Location = new System.Drawing.Point(44, 162);
            this.picTwitter.Name = "picTwitter";
            this.picTwitter.Size = new System.Drawing.Size(32, 32);
            this.picTwitter.TabIndex = 4;
            this.picTwitter.TabStop = false;
            this.picTwitter.Click += new System.EventHandler(this.picTwitter_Click);
            this.picTwitter.MouseEnter += new System.EventHandler(this.picTwitter_MouseEnter);
            this.picTwitter.MouseLeave += new System.EventHandler(this.picTwitter_MouseLeave);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btnEnter);
            this.panel12.Controls.Add(this.btnExit);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel12.Location = new System.Drawing.Point(0, 80);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(253, 56);
            this.panel12.TabIndex = 2;
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.btnEnter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(83)))));
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnter.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.btnEnter.ForeColor = System.Drawing.Color.White;
            this.btnEnter.Location = new System.Drawing.Point(132, 14);
            this.btnEnter.Margin = new System.Windows.Forms.Padding(10);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.NextControl = null;
            this.btnEnter.Size = new System.Drawing.Size(81, 34);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.Text = "ورود";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(44, 14);
            this.btnExit.Margin = new System.Windows.Forms.Padding(10);
            this.btnExit.Name = "btnExit";
            this.btnExit.NextControl = null;
            this.btnExit.Size = new System.Drawing.Size(81, 34);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "خروج";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(253, 40);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtPass);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel4.Location = new System.Drawing.Point(0, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(226, 32);
            this.panel4.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.White;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPass.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.txtPass.ForeColor = System.Drawing.Color.Black;
            this.txtPass.Location = new System.Drawing.Point(0, 0);
            this.txtPass.Margin = new System.Windows.Forms.Padding(10);
            this.txtPass.Name = "txtPass";
            this.txtPass.NextControl = this.btnEnter;
            this.txtPass.Size = new System.Drawing.Size(226, 29);
            this.txtPass.TabIndex = 0;
            this.txtPass.Text = "کلمه عبور";
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPass.Enter += new System.EventHandler(this.txtPass_Enter);
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.picPass);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel9.Location = new System.Drawing.Point(226, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(27, 37);
            this.panel9.TabIndex = 0;
            // 
            // picPass
            // 
            this.picPass.Image = global::Atiran.Main.Properties.Resources.lock1;
            this.picPass.Location = new System.Drawing.Point(3, 8);
            this.picPass.Name = "picPass";
            this.picPass.Size = new System.Drawing.Size(24, 24);
            this.picPass.TabIndex = 0;
            this.picPass.TabStop = false;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.pnlDownPass);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel10.Location = new System.Drawing.Point(0, 37);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(253, 3);
            this.panel10.TabIndex = 1;
            // 
            // pnlDownPass
            // 
            this.pnlDownPass.BackColor = System.Drawing.Color.White;
            this.pnlDownPass.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDownPass.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.pnlDownPass.Location = new System.Drawing.Point(0, 0);
            this.pnlDownPass.Name = "pnlDownPass";
            this.pnlDownPass.Size = new System.Drawing.Size(253, 1);
            this.pnlDownPass.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 40);
            this.panel2.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtUser);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel8.Location = new System.Drawing.Point(0, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(226, 32);
            this.panel8.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.White;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtUser.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.Location = new System.Drawing.Point(0, 0);
            this.txtUser.Margin = new System.Windows.Forms.Padding(10);
            this.txtUser.Name = "txtUser";
            this.txtUser.NextControl = this.txtPass;
            this.txtUser.Size = new System.Drawing.Size(226, 29);
            this.txtUser.TabIndex = 0;
            this.txtUser.Text = "نام کاربری";
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUser.Enter += new System.EventHandler(this.txtUser_Enter);
            this.txtUser.Leave += new System.EventHandler(this.txtUser_Leave);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.picUser);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel6.Location = new System.Drawing.Point(226, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(27, 37);
            this.panel6.TabIndex = 0;
            // 
            // picUser
            // 
            this.picUser.Image = global::Atiran.Main.Properties.Resources.user1;
            this.picUser.Location = new System.Drawing.Point(3, 8);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(24, 24);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picUser.TabIndex = 0;
            this.picUser.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.pnlDownUser);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.panel7.Location = new System.Drawing.Point(0, 37);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(253, 3);
            this.panel7.TabIndex = 1;
            // 
            // pnlDownUser
            // 
            this.pnlDownUser.BackColor = System.Drawing.Color.White;
            this.pnlDownUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDownUser.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.pnlDownUser.Location = new System.Drawing.Point(0, 0);
            this.pnlDownUser.Name = "pnlDownUser";
            this.pnlDownUser.Size = new System.Drawing.Size(253, 1);
            this.pnlDownUser.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMessage.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(0, 136);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(253, 22);
            this.lblMessage.TabIndex = 5;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.BackgroundImage = global::Atiran.Main.Properties.Resources.AtiranLogo_large;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Login";
            this.Size = new System.Drawing.Size(800, 500);
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFacebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInstagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTwitter)).EndInit();
            this.panel12.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPass)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "نام کاربری")
                txtUser.Text = string.Empty;
            picUser.Image = Properties.Resources.user2;
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            txtPass.Text = string.Empty;
            picPass.Image = Properties.Resources.lock2;
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == string.Empty)
                txtUser.Text = "نام کاربری";
            txtPass.UseSystemPasswordChar = true;
            picUser.Image = Properties.Resources.user1;
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == string.Empty)
            {
                txtPass.Text = "کلمه عبور";
                txtPass.UseSystemPasswordChar = false;
            }
            picPass.Image = Properties.Resources.lock1;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {

                if (FormIsValid())
                {
                    SecurityResult result = Authentication.Authenticate(txtUser.Text.Trim(), txtPass.Text.Trim());

                    if (result.IsAuthenticated)
                    {

                        GetCurrentSysUser.SetCurrentUserByFiscalUserName(txtUser.Text.Trim());
                        UserService.UserLogined(GetCurrentSysUser.Instance.UserID);
                        UserPersonalizationOperaion.SetUserPersonalization();

                        this.ParentForm.Close();
                        #region  جزيره اي
                        //if (ResultOveral.Any(a => a.id == 267 && a.value == 0))
                        //{
                        //var hub = new Hub(txtUser.Text.Trim());
                        //hub.Show();
                        //}
                        #endregion
                        #region تب بار
                        //else if (ResultOveral.Any(a => a.id == 267 && a.value == 1))
                        //{
                        var HubTabBar = new TabBarMenu(txtUser.Text.Trim());
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void AutoLogin()
        {
            if (Connections.AtiranAccModel.ConnectionInfo.AdminUser != null && Connections.AtiranAccModel.ConnectionInfo.AdminPass != null)
            {
                txtUser.Text = Connections.AtiranAccModel.ConnectionInfo.AdminUser;
                txtPass.UseSystemPasswordChar = true;
                txtPass.Text = Connections.AtiranAccModel.ConnectionInfo.AdminPass;
                //btnEnter_Click(null, null);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                this.Size = new Size(0,0);
                timer1.Start();
                Atiran.Connections.AtiranAccModel.ConnectionInfo.ReadData();
                AutoLogin();
            }
            catch (Exception exception)
            {
                Application.Exit();
            }
        }

        private bool FormIsValid()
        {
            bool isValid = true;
            try
            {
                //Username and Passwprd
                if (string.IsNullOrEmpty(txtUser.Text.Trim()) && string.IsNullOrEmpty(txtPass.Text.Trim()))
                {
                    string Value = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString("ERR_UandP_IS_EMPTY");

                    lblMessage.Text = Value;
                    isValid = false;
                }
                //Username
                else if (string.IsNullOrEmpty(txtUser.Text.Trim()))
                {
                    string Value = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetString("ERR_USERNAME_IS_EMPTY");
                    lblMessage.Text = Value;
                    isValid = false;
                }

                //Password
                else if (string.IsNullOrEmpty(txtPass.Text.Trim()))
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Width < 800)
            {
                this.Width += 40;
            }

            if (this.Height < 500)
            {
                this.Height += 25;
            }

            if (this.Width >= 792 && this.Height >= 495)
                timer1.Stop();

        }

        private void picTwitter_MouseEnter(object sender, EventArgs e)
        {
            picTwitter.Image = Properties.Resources.twitter2;
        }

        private void picTwitter_Click(object sender, EventArgs e)
        {
            OpenURL("https://twitter.com/ASharafzade");
        }

        private void picTwitter_MouseLeave(object sender, EventArgs e)
        {
            picTwitter.Image = Properties.Resources.twitter1;
        }

        private void picInstagram_MouseEnter(object sender, EventArgs e)
        {
            picInstagram.Image = Properties.Resources.instagram2;
        }

        private void picInstagram_Click(object sender, EventArgs e)
        {
            OpenURL("https://www.instagram.com/AlirezaSadeghi_1993/");
        }

        private void picInstagram_MouseLeave(object sender, EventArgs e)
        {
            picInstagram.Image = Properties.Resources.instagram1;
        }

        private void picFacebook_MouseEnter(object sender, EventArgs e)
        {
            picFacebook.Image = Properties.Resources.facebook2;
        }

        private void picFacebook_Click(object sender, EventArgs e)
        {
            OpenURL("https://www.facebook.com/ali.sh.33671748");
        }

        private void picFacebook_MouseLeave(object sender, EventArgs e)
        {
            picFacebook.Image = Properties.Resources.facebook1;
        }

        private void OpenURL(string URL)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(URL);
            Process.Start(sInfo);
        }
    }
}
