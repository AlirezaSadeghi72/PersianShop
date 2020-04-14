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
    public class ModuleAccessControl : Atiran.UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.Controls.GroupBox groupBox1;
        private UI.WindowsForms.Controls.ComboBoxes.ComboBox cb_User;
        private UI.WindowsForms.UIElements.Panel panel17;
        private UI.WindowsForms.Controls.Buttons.CancelButton btn_Cancel;
        private UI.WindowsForms.Controls.Buttons.SaveButton btn_Save;
        private UI.WindowsForms.Controls.FlowLayoutPanel flowLayoutPanel1;
        private UI.WindowsForms.Controls.Label label1;
        List<int> ModuleNodes = new List<int>();
        List<int> ModuleNodesOrginal = new List<int>();
        bool status = false;int userid = 0;
        public ModuleAccessControl()
        {
            InitializeComponent();
            //Atiran.Connections.GetCurrentSysUser.Instance.user_id
            CreateModuleList();
            fillUsers();
        }
        public ModuleAccessControl(bool Status_,int userid_)
        {
            InitializeComponent();
            //Atiran.Connections.GetCurrentSysUser.Instance.user_id
            CreateModuleList();
            fillUsers();
            status = Status_;
            userid = userid_;
            cb_User.SelectedValue = userid;
        }
        private void InitializeComponent()
        {
            this.groupBox1 = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.cb_User = new Atiran.UI.WindowsForms.Controls.ComboBoxes.ComboBox();
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.panel17 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.btn_Cancel = new Atiran.UI.WindowsForms.Controls.Buttons.CancelButton();
            this.btn_Save = new Atiran.UI.WindowsForms.Controls.Buttons.SaveButton();
            this.flowLayoutPanel1 = new Atiran.UI.WindowsForms.Controls.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_User);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1280, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعیین سطوح دسترسی به ماژول  های هاب";
            // 
            // cb_User
            // 
            this.cb_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_User.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_User.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_User.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.cb_User.FormattingEnabled = true;
            this.cb_User.Location = new System.Drawing.Point(950, 47);
            this.cb_User.Margin = new System.Windows.Forms.Padding(10);
            this.cb_User.Name = "cb_User";
            this.cb_User.NextControl = null;
            this.cb_User.Size = new System.Drawing.Size(200, 30);
            this.cb_User.TabIndex = 1;
            this.cb_User.SelectedValueChanged += new System.EventHandler(this.cb_User_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.Location = new System.Drawing.Point(1151, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربر:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.btn_Cancel);
            this.panel17.Controls.Add(this.btn_Save);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel17.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel17.Location = new System.Drawing.Point(0, 595);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1280, 55);
            this.panel17.TabIndex = 3;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.White;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.btn_Cancel.ForeColor = System.Drawing.Color.Gray;
            this.btn_Cancel.Location = new System.Drawing.Point(7, 11);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.NextControl = null;
            this.btn_Cancel.Size = new System.Drawing.Size(81, 34);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "انصراف";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
            this.btn_Save.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(91, 11);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.NextControl = null;
            this.btn_Save.Size = new System.Drawing.Size(81, 34);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "ثبت";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 131);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1280, 464);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // ModuleAccessControl
            // 
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModuleAccessControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1280, 650);
            this.Load += new System.EventHandler(this.ModuleAccessControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private void fillUsers()
        {
            cb_User.DisplayMember = "UserName";
            cb_User.ValueMember = "UserID";
            cb_User.DataSource = UserComponent.GetAtiranUsers().ToList();
        }
        private void CreateModuleList()
        {
            Atiran.UI.WindowsForms.UIElements.Checkbox chk1 = new Atiran.UI.WindowsForms.UIElements.Checkbox();
            chk1.Tag = "selectAll";
            chk1.Name= "selectAll";
            chk1.Text = " انتخاب همه موارد ... ";
            chk1.AutoSize = true;
            chk1.CheckedChanged += Chk_CheckedChanged;
            chk1.ForeColor = System.Drawing.Color.Orange;
            //chk1.BackColor = System.Drawing.Color.DarkOrange;
            flowLayoutPanel1.Controls.Add(chk1);
            List<Atiran.Connections.AtiranAccModel.SubSystem> module = Connections.Operaions.SubSystemOp.SubSystemOperaion.ResultAllSubSystem;
            foreach (var item in module)
            {
                Atiran.UI.WindowsForms.UIElements.Checkbox chk = new Atiran.UI.WindowsForms.UIElements.Checkbox();
                chk.Tag = item.SubSystemId;
                chk.Text = item.Name;
                chk.AutoSize = true;
                chk.CheckedChanged += Chk_CheckedChanged;
                flowLayoutPanel1.Controls.Add(chk);
            }
        }
        private void Chk_CheckedChanged(object sender, EventArgs e)
        {
            if (((Atiran.UI.WindowsForms.UIElements.Checkbox)sender).Tag.ToString() != "selectAll")
            {
                if (((Atiran.UI.WindowsForms.UIElements.Checkbox)sender).Checked == false)
                {
                    int modulID = int.Parse(((CheckBox)sender).Tag.ToString());
                    ModuleNodes.Remove(modulID);
                }
                else
                {
                    int modulID = int.Parse(((CheckBox)sender).Tag.ToString());
                    ModuleNodes.Add(modulID);
                }
            }
            else
            {
                if (((Atiran.UI.WindowsForms.UIElements.Checkbox)sender).Checked == false)
                {
                    foreach (System.Windows.Forms.Control c1 in flowLayoutPanel1.Controls)
                    {
                        if (((Atiran.UI.WindowsForms.UIElements.Checkbox)c1).Tag.ToString() != "selectAll")
                        {
                            if (((Atiran.UI.WindowsForms.UIElements.Checkbox)c1).Checked != false)
                                ((Atiran.UI.WindowsForms.UIElements.Checkbox)c1).Checked = false;
                            //else
                            //    ((Atiran.UI.WindowsForms.UIElements.Checkbox)c1).Checked = true;
                        }
                    }
                }
                else
                {
                    foreach (System.Windows.Forms.Control c1 in flowLayoutPanel1.Controls)
                    {
                        // CheckBox chk=(CheckBox)c1;
                        if (((Atiran.UI.WindowsForms.UIElements.Checkbox)c1).Tag.ToString() != "selectAll")
                        { 
                            if (((Atiran.UI.WindowsForms.UIElements.Checkbox)c1).Checked != true)
                                ((Atiran.UI.WindowsForms.UIElements.Checkbox)c1).Checked = true;
                            //else
                            //    ((Atiran.UI.WindowsForms.UIElements.Checkbox)c1).Checked = false;
                        }
                    }
                }
            }
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (status)
            {
                this.ParentForm.Close();
            }
            else
            {
                Atiran.UI.WindowsForms.CloseFormService.CloseUserControll(this);
            }
        }
        private void cb_User_SelectedValueChanged(object sender, EventArgs e)
        {
            ModuleNodes.Clear();
            ModuleNodesOrginal.Clear();
            Atiran.UI.WindowsForms.UIElements.Checkbox chk2 = flowLayoutPanel1.Controls.Find("selectAll", true).FirstOrDefault() as Atiran.UI.WindowsForms.UIElements.Checkbox;
            chk2.Checked = false;
            foreach (System.Windows.Forms.Control c1 in flowLayoutPanel1.Controls)
            {
                Atiran.UI.WindowsForms.UIElements.Checkbox chk = (Atiran.UI.WindowsForms.UIElements.Checkbox)c1;
                if (cb_User.SelectedValue != null)
                {
                    if (chk.Tag.ToString() != "selectAll")
                    {
                        Atiran.Connections.AtiranAccModel.SubSystemPermission mod = Atiran.Connections.Operaions.SubSystemPermissionOp.SubSystemPermissionOperaion.GetUserModulePermissionStatus(Convert.ToInt32(cb_User.SelectedValue), int.Parse(chk.Tag.ToString()));
                        ModuleNodesOrginal.Add(int.Parse(chk.Tag.ToString()));
                        if(mod != null)
                        {
                            chk.Checked = true;
                            int oo = ModuleNodes.IndexOf(int.Parse(chk.Tag.ToString()));
                            if (oo==-1)
                                ModuleNodes.Add(int.Parse(chk.Tag.ToString()));
                        }
                        else
                        {
                            chk.Checked = false;
                            int oo = ModuleNodes.IndexOf(int.Parse(chk.Tag.ToString()));
                            if (oo ==-1)
                                ModuleNodes.Remove(int.Parse(chk.Tag.ToString()));
                        }
                    }
                }
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (cb_User.SelectedValue == null)
            {
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("هشدار", "نام كاربر را انتخاب نماييد", "e");
                cb_User.Focus();
                cb_User.DroppedDown = true;
                return;
            }
            Atiran.Connections.Operaions.SubSystemPermissionOp.SubSystemPermissionOperaion.DeleteModulePermission(int.Parse(cb_User.SelectedValue.ToString()));
            Atiran.Connections.Operaions.SubSystemPermissionOp.SubSystemPermissionOperaion.insertToModulePermission(int.Parse(cb_User.SelectedValue.ToString()), ModuleNodes.Distinct().ToList(),ModuleNodesOrginal.Distinct().ToList());
            CustomMessageForm.CustomMessageBox.Show("پیغام"," ثبت با موفقیت انجام گرفت ");
            DialogResult x = Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام", "آيا ميخواهيد براي كاربر تعريف شده، تعيين سطوح دسترسي زير سيستم‌ها را مشخص كنيد؟", "w");
            if (x == DialogResult.Yes)
            {
                UserAccessControl UAC = new UserAccessControl(true,int.Parse(cb_User.SelectedValue.ToString()));
                UserControlLoader loader = new UserControlLoader(UAC);
            }
            if (status)
            {
                this.ParentForm.Close();
            }
        }
        private void cb_User_Format(object sender, ListControlConvertEventArgs e)
        {
            //string lastname = ((Atiran.Connections.AtiranAccModel.user)e.ListItem).UserFname;
            //string firstname = ((Atiran.Connections.AtiranAccModel.user)e.ListItem).UserLname;
            //e.Value = lastname + " " + firstname;
        }
        private void ModuleAccessControl_Load(object sender, EventArgs e)
        {
            cb_User.Focus();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData==Keys.Escape)
            {
                if (status)
                {
                    this.ParentForm.Close();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
