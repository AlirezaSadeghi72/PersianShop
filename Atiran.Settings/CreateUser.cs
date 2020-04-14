using Atiran.UI.WindowsForms.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.Operaions.UserOp;
using Atiran.UI.WindowsForms;

namespace Atiran.Settings
{
   public class CreateUser:Atiran.UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.Controls.Buttons.SaveButton btn_Save;
        private UI.WindowsForms.UIElements.Panel panel2;
        private UI.WindowsForms.Controls.Buttons.CancelButton btn_Cancell;
        private UI.WindowsForms.Controls.Label label8;
        private UI.WindowsForms.Controls.DataGridView dataGridView1;
        private UI.WindowsForms.UIElements.Panel panel3;
        private UI.WindowsForms.Controls.Label label9;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_Password;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_UserName;
        private UI.WindowsForms.Controls.GroupBox groupBox1;
        private UI.WindowsForms.Controls.GroupBox groupBox2;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_EditPassword;
        private UI.WindowsForms.UIElements.Panel panel5;
        private UI.WindowsForms.Controls.Buttons.EditButton btn_Edit;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_EditUserName;
        private UI.WindowsForms.Controls.Label label6;
        private UI.WindowsForms.Controls.Label label15;
        private UI.WindowsForms.UIElements.Panel panel1;
        int USERID;

        string user="";
        private UI.WindowsForms.Controls.TextBoxes.TextBox txt_ConfPassword;
        private UI.WindowsForms.Controls.Label label20;

        public CreateUser()
        {
            InitializeComponent();
            dataGridView1.DataSource = UserComponent.GetUsers();
            setgridview();
          
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_UserName = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.txt_Password = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.txt_ConfPassword = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.btn_Save = new Atiran.UI.WindowsForms.Controls.Buttons.SaveButton();
            this.btn_Cancell = new Atiran.UI.WindowsForms.Controls.Buttons.CancelButton();
            this.panel2 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.label8 = new Atiran.UI.WindowsForms.Controls.Label();
            this.dataGridView1 = new Atiran.UI.WindowsForms.Controls.DataGridView();
            this.panel3 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.groupBox2 = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.txt_EditPassword = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.txt_EditUserName = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.label6 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label15 = new Atiran.UI.WindowsForms.Controls.Label();
            this.panel5 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.btn_Edit = new Atiran.UI.WindowsForms.Controls.Buttons.EditButton();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.groupBox1 = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.label20 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label9 = new Atiran.UI.WindowsForms.Controls.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_UserName
            // 
            this.txt_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_UserName.BackColor = System.Drawing.Color.White;
            this.txt_UserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_UserName.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_UserName.ForeColor = System.Drawing.Color.Black;
            this.txt_UserName.Location = new System.Drawing.Point(985, 28);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(10);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.NextControl = this.txt_Password;
            this.txt_UserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_UserName.Size = new System.Drawing.Size(200, 29);
            this.txt_UserName.TabIndex = 7;
            this.txt_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Password
            // 
            this.txt_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Password.BackColor = System.Drawing.Color.White;
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_Password.ForeColor = System.Drawing.Color.Black;
            this.txt_Password.Location = new System.Drawing.Point(689, 28);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(10);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.NextControl = this.txt_ConfPassword;
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_Password.Size = new System.Drawing.Size(200, 29);
            this.txt_Password.TabIndex = 8;
            this.txt_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_ConfPassword
            // 
            this.txt_ConfPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ConfPassword.BackColor = System.Drawing.Color.White;
            this.txt_ConfPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ConfPassword.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_ConfPassword.ForeColor = System.Drawing.Color.Black;
            this.txt_ConfPassword.Location = new System.Drawing.Point(375, 28);
            this.txt_ConfPassword.Margin = new System.Windows.Forms.Padding(10);
            this.txt_ConfPassword.Name = "txt_ConfPassword";
            this.txt_ConfPassword.NextControl = this.btn_Save;
            this.txt_ConfPassword.PasswordChar = '*';
            this.txt_ConfPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_ConfPassword.Size = new System.Drawing.Size(200, 29);
            this.txt_ConfPassword.TabIndex = 9;
            this.txt_ConfPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.btn_Save.NextControl = this.btn_Cancell;
            this.btn_Save.Size = new System.Drawing.Size(81, 34);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "ثبت";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Cancell
            // 
            this.btn_Cancell.BackColor = System.Drawing.Color.White;
            this.btn_Cancell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancell.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.btn_Cancell.ForeColor = System.Drawing.Color.Gray;
            this.btn_Cancell.Location = new System.Drawing.Point(3, 3);
            this.btn_Cancell.Name = "btn_Cancell";
            this.btn_Cancell.NextControl = null;
            this.btn_Cancell.Size = new System.Drawing.Size(81, 34);
            this.btn_Cancell.TabIndex = 1;
            this.btn_Cancell.Text = "انصراف";
            this.btn_Cancell.UseVisualStyleBackColor = false;
            this.btn_Cancell.Click += new System.EventHandler(this.btn_Cancell_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_Cancell);
            this.panel2.Controls.Add(this.btn_Save);
            this.panel2.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.panel2.Location = new System.Drawing.Point(142, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(173, 40);
            this.panel2.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.label8.Location = new System.Drawing.Point(1198, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "نام کاربری:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("IRANSans", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.dataGridView1.Location = new System.Drawing.Point(0, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1280, 542);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel3.Location = new System.Drawing.Point(0, 617);
            this.panel3.Name = "panel3";
            this.panel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel3.Size = new System.Drawing.Size(1280, 78);
            this.panel3.TabIndex = 4;
            this.panel3.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_EditPassword);
            this.groupBox2.Controls.Add(this.txt_EditUserName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.panel5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1280, 78);
            this.groupBox2.TabIndex = 43;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ویرایش کاربر";
            // 
            // txt_EditPassword
            // 
            this.txt_EditPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_EditPassword.BackColor = System.Drawing.Color.White;
            this.txt_EditPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_EditPassword.Enabled = false;
            this.txt_EditPassword.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_EditPassword.ForeColor = System.Drawing.Color.Black;
            this.txt_EditPassword.Location = new System.Drawing.Point(723, 35);
            this.txt_EditPassword.Margin = new System.Windows.Forms.Padding(10);
            this.txt_EditPassword.Name = "txt_EditPassword";
            this.txt_EditPassword.NextControl = null;
            this.txt_EditPassword.PasswordChar = '*';
            this.txt_EditPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_EditPassword.Size = new System.Drawing.Size(200, 29);
            this.txt_EditPassword.TabIndex = 8;
            this.txt_EditPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_EditUserName
            // 
            this.txt_EditUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_EditUserName.BackColor = System.Drawing.Color.White;
            this.txt_EditUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_EditUserName.Enabled = false;
            this.txt_EditUserName.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txt_EditUserName.ForeColor = System.Drawing.Color.Black;
            this.txt_EditUserName.Location = new System.Drawing.Point(1000, 35);
            this.txt_EditUserName.Margin = new System.Windows.Forms.Padding(10);
            this.txt_EditUserName.Name = "txt_EditUserName";
            this.txt_EditUserName.NextControl = this.txt_EditPassword;
            this.txt_EditUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_EditUserName.Size = new System.Drawing.Size(200, 29);
            this.txt_EditUserName.TabIndex = 7;
            this.txt_EditUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.label6.Location = new System.Drawing.Point(925, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 22);
            this.label6.TabIndex = 26;
            this.label6.Text = "کلمه عبور:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.label15.Location = new System.Drawing.Point(1202, 38);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(66, 22);
            this.label15.TabIndex = 7;
            this.label15.Text = "نام کاربری:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btn_Edit);
            this.panel5.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.panel5.Location = new System.Drawing.Point(50, 27);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(180, 42);
            this.panel5.TabIndex = 42;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.Green;
            this.btn_Edit.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.btn_Edit.ForeColor = System.Drawing.Color.White;
            this.btn_Edit.Location = new System.Drawing.Point(89, 5);
            this.btn_Edit.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.NextControl = null;
            this.btn_Edit.Size = new System.Drawing.Size(81, 34);
            this.btn_Edit.TabIndex = 0;
            this.btn_Edit.Text = "ويرايش";
            this.btn_Edit.UseVisualStyleBackColor = false;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(1280, 75);
            this.panel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_ConfPassword);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txt_Password);
            this.groupBox1.Controls.Add(this.txt_UserName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1280, 75);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعریف کاربر جدید";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.label20.Location = new System.Drawing.Point(588, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 22);
            this.label20.TabIndex = 29;
            this.label20.Text = "تكرار كلمه عبور:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.label9.Location = new System.Drawing.Point(902, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 22);
            this.label9.TabIndex = 26;
            this.label9.Text = "کلمه عبور:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CreateUser
            // 
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "CreateUser";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1280, 695);
            this.Load += new System.EventHandler(this.CreateUser_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if ( txt_UserName.Text != "" && txt_Password.Text != "" )
                {
                    if (UserComponent.checkAtiranUserName(txt_UserName.Text) == 0)
                    {
                        if (txt_Password.Text.Trim().Equals(txt_ConfPassword.Text.Trim()))
                        {
                            int result = 0;
                            result = UserComponent.InserToUser(txt_UserName.Text, txt_Password.Text);
                            if (result > 0)
                            {
                                txt_UserName.Text = "";
                                txt_Password.Text = "";
                                txt_ConfPassword.Clear();
                                CustomMessageForm.CustomMessageBox.Show("پیغام", "ثبت اطلاعات با موفقیت انجام شد");
                                dataGridView1.DataSource = UserComponent.GetUsers();
                                setgridview();
                                // new by sharafzade
                                DialogResult x = Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام", "آيا ميخواهيد براي كاربر تعريف شده، زير سيستم اختصاص دهيد؟", "w");
                                if (x==DialogResult.Yes)
                                {
                                    ModuleAccessControl UAC = new ModuleAccessControl(true,result);
                                    UserControlLoader loader = new UserControlLoader(UAC);
                                }
                            }
                            else
                            {
                                CustomMessageForm.CustomMessageBox.Show("پیغام", "خطا در ثبت اطلاعات");
                            }
                        }
                        else
                        {
                            CustomMessageForm.CustomMessageBox.Show("پیغام", "كلمه هاي عبور وارد شده مطابقت ندارد","e");
                            txt_Password.Clear();
                            txt_ConfPassword.Clear();
                            txt_Password.Focus();
                        }
                    }
                    else
                    {
                        CustomMessageForm.CustomMessageBox.Show("پیغام", "نام کاربری تکراری می باشد، لطفا نام کاربری دیگری انتخاب نمایید.");
                    }
                }
                else
                {
                    CustomMessageForm.CustomMessageBox.Show("پیغام", "نام، نام خانوادگی، نام کاربری و کلمه عبور نمی تواند خالی باشد");
                }
            }
            catch (Exception ex)
            {
                CustomMessageForm.CustomMessageBox.Show("پیغام", "خطا در ثبت اطلاعات");
            }
        }
        private void setgridview()
        {
            try
            {
                foreach (DataGridViewColumn item in dataGridView1.Columns)
                {
                    item.Visible = false;
                }
                dataGridView1.Columns["UserName"].Visible = true;
                dataGridView1.Columns["UserName"].HeaderText = "نام كاربري";
                dataGridView1.Columns["UserName"].AutoSizeMode =  System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                panel3.Visible = true;
                USERID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var find = UserComponent.GetUserInformation(USERID);
                foreach (var item in find)
                {
                    txt_EditPassword.Text = System.Text.Encoding.UTF8.GetString(item.UserPassWord);
                    user=txt_EditUserName.Text = item.UserName;
                }
                panel3.Visible = true;
                txt_EditUserName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_EditUserName.Text != "" && txt_EditPassword.Text != "")
                {
                    if (user != txt_EditUserName.Text)
                    {
                        if (UserComponent.checkAtiranUserName(txt_EditUserName.Text.ToString()) == 0)
                        {
                            bool result;
                            result = UserComponent.EditUser(USERID, txt_EditUserName.Text, txt_EditPassword.Text);
                            if (result == true)
                            {
                                panel3.Visible = false;
                                CustomMessageForm.CustomMessageBox.Show("پیغام", "ویرایش اطلاعات با موفقیت انجام شد");
                                dataGridView1.DataSource = UserComponent.GetUsers();
                                setgridview();
                            }
                            else
                            {
                                CustomMessageForm.CustomMessageBox.Show("پیغام", "خطا در ویرایش اطلاعات");
                            }
                        }
                        else
                        {
                            CustomMessageForm.CustomMessageBox.Show("پیغام", "نام کاربری تکراری می باشد، لطفا نام کاربری دیگری انتخاب نمایید.");
                        }
                    }
                    else
                    {
                        bool result;
                        result = UserComponent.EditUser(USERID,txt_EditUserName.Text, txt_EditPassword.Text);
                        if (result == true)
                        {
                            panel3.Visible = false;
                            CustomMessageForm.CustomMessageBox.Show("پیغام", "ویرایش اطلاعات با موفقیت انجام شد");
                            dataGridView1.DataSource = UserComponent.GetUsers();
                            setgridview();
                        }
                        else
                        {
                            CustomMessageForm.CustomMessageBox.Show("پیغام", "خطا در ویرایش اطلاعات");
                        }
                    }
                }
                else
                {
                    CustomMessageForm.CustomMessageBox.Show("پیغام", "نام کاربری تکراری می باشد، لطفا نام کاربری دیگری انتخاب نمایید.");
                }
            }
            catch (Exception)
            {
                CustomMessageForm.CustomMessageBox.Show("پیغام", "خطا در ویرایش اطلاعات");
            }

        }
       
        private void TextBoxNumericValidation(object sender, EventArgs e)
        {
            TextBox txtbox = new TextBox();
            txtbox = (TextBox)sender;
            if (txtbox.TextLength > 11)
            {
                txtbox.Text = txtbox.Text.Remove(txtbox.TextLength - 1);
                CustomMessageForm.CustomMessageBox.Show("پیغام", "حداکثر طول 11 کاراکتر می باشد.");
                txtbox.SelectionStart = txtbox.Text.Length;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(txtbox.Text, "[^0-9]"))
            {
                var currentPosition = txtbox.SelectionStart;
                txtbox.SelectionStart = currentPosition > 0 ? currentPosition - 1 : currentPosition;
                txtbox.Text = txtbox.Text.Remove(txtbox.SelectionStart, 1);
                CustomMessageForm.CustomMessageBox.Show("پیغام", "لطفا فقط عدد وارد کنید.");
                txtbox.SelectionStart = txtbox.Text.Length;
            }
        }
        private void emailTxt_Validating(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            txt = (TextBox)sender;
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (txt.TextLength > 50)
            {
                txt.Text = txt.Text.Remove(txt.TextLength - 1);
                MessageBox.Show("حداکثر طول 50 کارکتر می باشد.");
                txt.SelectionStart = txt.Text.Length;
            }
            if (txt.Text.Length > 0 && txt.Text.Trim().Length != 0)
            {
                if (!rEmail.IsMatch(txt.Text.Trim()))
                {
                    MessageBox.Show("لطفا ایمیل خود را درست وارد نمایید.");
                    txt.SelectAll();
                    txt.Focus();
                    txt.SelectionStart = txt.Text.Length;
                }
            }
        }
        private void btn_Cancell_Click(object sender, EventArgs e)
        {
            Atiran.UI.WindowsForms.CloseFormService.CloseUserControll(this);
        }
        private void CreateUser_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txt_UserName;
            txt_UserName.Focus();
            txt_UserName.Select();
        }
    }
}
