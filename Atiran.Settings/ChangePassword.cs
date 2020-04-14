using Atiran.UI.WindowsForms.MessageBoxes;
using System;
using System.Windows.Forms;
using Atiran.Connections.Operaions.UserOp;

namespace Atiran.Settings
{
   public class ChangePassword:Atiran.UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.Controls.Buttons.CancelButton btn_Cancel;
        private UI.WindowsForms.Controls.Buttons.SaveButton btn_Save;
        private UI.WindowsForms.Controls.Label label4;
        private UI.WindowsForms.Controls.Label label3;
        private UI.WindowsForms.Controls.Label label2;
        private UI.WindowsForms.Controls.Label label1;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_ConfirmNewPassword;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_NewPassword;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_CurrentPassword;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_Username;
        private UI.WindowsForms.UIElements.Panel panel1;
        private UI.WindowsForms.Controls.GroupBox groupBox1;
        public ChangePassword()
        {
            InitializeComponent();
            txt_Username.Text  = Atiran.Connections.Operaions.UserOp.GetCurrentSysUser.Instance.UserName.ToString();
        }
        private void InitializeComponent()
        {
            this.groupBox1 = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.btn_Cancel = new Atiran.UI.WindowsForms.Controls.Buttons.CancelButton();
            this.btn_Save = new Atiran.UI.WindowsForms.Controls.Buttons.SaveButton();
            this.txt_ConfirmNewPassword = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.txt_NewPassword = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.txt_CurrentPassword = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.txt_Username = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.label4 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label3 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label2 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.txt_ConfirmNewPassword);
            this.groupBox1.Controls.Add(this.txt_NewPassword);
            this.groupBox1.Controls.Add(this.txt_CurrentPassword);
            this.groupBox1.Controls.Add(this.txt_Username);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1280, 650);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تغییر کلمه عبور";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(941, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 41);
            this.panel1.TabIndex = 4;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.Gray;
            this.btn_Cancel.Location = new System.Drawing.Point(5, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.NextControl = null;
            this.btn_Cancel.Size = new System.Drawing.Size(81, 34);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "انصراف";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(88, 3);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.NextControl = null;
            this.btn_Save.Size = new System.Drawing.Size(81, 34);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "ثبت";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_ConfirmNewPassword
            // 
            this.txt_ConfirmNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ConfirmNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ConfirmNewPassword.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_ConfirmNewPassword.Location = new System.Drawing.Point(946, 145);
            this.txt_ConfirmNewPassword.Margin = new System.Windows.Forms.Padding(10);
            this.txt_ConfirmNewPassword.Name = "txt_ConfirmNewPassword";
            this.txt_ConfirmNewPassword.NextControl = this.btn_Save;
            this.txt_ConfirmNewPassword.PasswordChar = '*';
            this.txt_ConfirmNewPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_ConfirmNewPassword.Size = new System.Drawing.Size(200, 29);
            this.txt_ConfirmNewPassword.TabIndex = 3;
            this.txt_ConfirmNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_NewPassword
            // 
            this.txt_NewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_NewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_NewPassword.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_NewPassword.Location = new System.Drawing.Point(946, 110);
            this.txt_NewPassword.Margin = new System.Windows.Forms.Padding(10);
            this.txt_NewPassword.Name = "txt_NewPassword";
            this.txt_NewPassword.NextControl = this.txt_ConfirmNewPassword;
            this.txt_NewPassword.PasswordChar = '*';
            this.txt_NewPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_NewPassword.Size = new System.Drawing.Size(200, 29);
            this.txt_NewPassword.TabIndex = 2;
            this.txt_NewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_NewPassword.TextChanged += new System.EventHandler(this.txt_NewPassword_TextChanged);
            // 
            // txt_CurrentPassword
            // 
            this.txt_CurrentPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CurrentPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_CurrentPassword.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_CurrentPassword.Location = new System.Drawing.Point(946, 75);
            this.txt_CurrentPassword.Margin = new System.Windows.Forms.Padding(10);
            this.txt_CurrentPassword.Name = "txt_CurrentPassword";
            this.txt_CurrentPassword.NextControl = this.txt_NewPassword;
            this.txt_CurrentPassword.PasswordChar = '*';
            this.txt_CurrentPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_CurrentPassword.Size = new System.Drawing.Size(200, 29);
            this.txt_CurrentPassword.TabIndex = 1;
            this.txt_CurrentPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_CurrentPassword.TextChanged += new System.EventHandler(this.txt_CurrentPassword_TextChanged);
            // 
            // txt_Username
            // 
            this.txt_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Username.Enabled = false;
            this.txt_Username.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_Username.Location = new System.Drawing.Point(946, 40);
            this.txt_Username.Margin = new System.Windows.Forms.Padding(10);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.NextControl = this.txt_CurrentPassword;
            this.txt_Username.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Username.Size = new System.Drawing.Size(200, 29);
            this.txt_Username.TabIndex = 0;
            this.txt_Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Username.TextChanged += new System.EventHandler(this.txt_Username_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label4.Location = new System.Drawing.Point(1150, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "تکرار کلمه عبور جدید:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label3.Location = new System.Drawing.Point(1150, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "کلمه عبور جدید:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label2.Location = new System.Drawing.Point(1150, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "کلمه عبور  فعلی:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.Location = new System.Drawing.Point(1150, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربری:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChangePassword
            // 
            this.Controls.Add(this.groupBox1);
            this.Name = "ChangePassword";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1280, 650);
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Atiran.UI.WindowsForms.CloseFormService.CloseUserControll(this);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_CurrentPassword.Text.Trim()!="" && txt_NewPassword.Text.Trim()!="" && txt_ConfirmNewPassword.Text.Trim()!="")
            {
                if (txt_CurrentPassword.Text == System.Text.Encoding.UTF8.GetString(Atiran.Connections.Operaions.UserOp.GetCurrentSysUser.Instance.UserPassWord))
                {
                    if (txt_NewPassword.Text == txt_ConfirmNewPassword.Text)
                    {
                        if (UserComponent.ChangePassword(GetCurrentSysUser.Instance.UserID, txt_Username.Text, txt_NewPassword.Text))
                        {
                            CustomMessageForm.CustomMessageBox.Show("پیغام", "رمز عبور با موفقيت تغيير كرد");
                            Application.Restart();
                        }
                        
                    }
                    else
                    {
                        CustomMessageForm.CustomMessageBox.Show("پیغام", "کلمه عبور جدید و تکرار آن مشابه نمی باشند");
                    }
                }
                else
                {
                    CustomMessageForm.CustomMessageBox.Show("پیغام", "کلمه عبور فعلی اشتباه می باشد");
                }
            }
            else
            {
                CustomMessageForm.CustomMessageBox.Show("پیغام", "پر کردن کلمه عبور جاری، کلمه عبور جدید و تایید کلمه عبور جدید الزامی می باشد");
            }
        }

        private void txt_NewPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_CurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txt_CurrentPassword.Focus();
        }
    }
}
