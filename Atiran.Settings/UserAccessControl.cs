#region new code
using Atiran.UI.WindowsForms.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.Operaions.SubSystemPermissionOp;
using Atiran.Connections.Operaions.UserOp;

namespace Atiran.Settings
{
    public class UserAccessControl : Atiran.UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.UIElements.Panel panel1;
        private UI.WindowsForms.Controls.TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private UI.WindowsForms.Controls.GroupBox groupBox1;
        private UI.WindowsForms.Controls.ComboBoxes.ComboBox cb_User;
        private UI.WindowsForms.Controls.Label label1;
        private UI.WindowsForms.UIElements.Panel panel3;
        private UI.WindowsForms.Controls.TreeView treeView1;
        private UI.WindowsForms.UIElements.Panel panel4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private UI.WindowsForms.Controls.TreeView treeView2;
        private UI.WindowsForms.UIElements.Panel panel5;
        private Panel panel6;
        private UI.WindowsForms.Controls.TreeView treeView4;
        private UI.WindowsForms.UIElements.Panel panel7;
        private UI.WindowsForms.Controls.TreeView treeView5;
        private UI.WindowsForms.UIElements.Panel panel8;
        private UI.WindowsForms.UIElements.Panel panel9;
        private UI.WindowsForms.UIElements.Panel panel10;
        private UI.WindowsForms.Controls.TreeView treeView6;
        private UI.WindowsForms.Controls.TreeView treeView7;
        private UI.WindowsForms.Controls.TreeView treeView8;
        private UI.WindowsForms.Controls.TreeView treeView3;
        private UI.WindowsForms.UIElements.Panel panel17;
        private UI.WindowsForms.Controls.Buttons.SaveButton btn_Save;
        private UI.WindowsForms.UIElements.Panel panel2;
        List<long> formNodes = new List<long>();
        List<long> fieldNodes = new List<long>();
        List<long> allFormNodes = new List<long>();
        private UI.WindowsForms.Controls.Buttons.CancelButton cancelButton1;
        private TabPage tabPage9;
        private UI.WindowsForms.Controls.Label label3;
        private UI.WindowsForms.Controls.TreeView treeView9;
        List<long> allFieldNodes = new List<long>();
        private TabPage tabPage10;
        private UI.WindowsForms.Controls.TreeView treeView10;
        bool tempAllocation = false;
        bool status = false;
        private TabPage tabPage11;
        private UI.WindowsForms.Controls.TreeView treeView11;
        private TabPage tabPage12;
        private UI.WindowsForms.Controls.TreeView treeView12;
        private TabPage tabPage13;
        private UI.WindowsForms.Controls.TreeView treeView13;
        int userid = 0;
        private TabPage tabPage14;
        private UI.WindowsForms.Controls.TreeView treeView14;
        private UI.WindowsForms.Controls.Label lblProccess;
        List<Atiran.Connections.AtiranAccModel.User> SysUser = new List<Connections.AtiranAccModel.User>();
        public UserAccessControl()
        {
            InitializeComponent();
            FillUsers();
            SubSystemPermissionOperaion.FillMenuList();
            SetVisabilityTab();
            TabControl1_SelectedIndexChanged(null, null);
        }
        public UserAccessControl(bool status_, int userid_)
        {
            InitializeComponent();
            FillUsers();
            SubSystemPermissionOperaion.FillMenuList();
            SetVisabilityTab();
            status = status_;
            userid = userid_;
            cb_User.SelectedValue = userid;
            TabControl1_SelectedIndexChanged(null, null);
        }
        private void InitializeComponent()
        {
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.groupBox1 = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.cb_User = new Atiran.UI.WindowsForms.Controls.ComboBoxes.ComboBox();
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.treeView9 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.panel2 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.tabControl1 = new Atiran.UI.WindowsForms.Controls.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.treeView1 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel4 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.treeView2 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel5 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.treeView3 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.treeView4 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.panel7 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.treeView5 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel8 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.treeView6 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.panel9 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.treeView7 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel10 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.treeView8 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.tabPage10 = new System.Windows.Forms.TabPage();
            this.treeView10 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.treeView11 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.treeView12 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.treeView13 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.treeView14 = new Atiran.UI.WindowsForms.Controls.TreeView();
            this.panel17 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.label3 = new Atiran.UI.WindowsForms.Controls.Label();
            this.cancelButton1 = new Atiran.UI.WindowsForms.Controls.Buttons.CancelButton();
            this.btn_Save = new Atiran.UI.WindowsForms.Controls.Buttons.SaveButton();
            this.lblProccess = new Atiran.UI.WindowsForms.Controls.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.tabPage10.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.panel17.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(1280, 84);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_User);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1280, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "تعیین سطوح دسترسی کاربران";
            // 
            // cb_User
            // 
            this.cb_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_User.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_User.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_User.Font = new System.Drawing.Font("IRANSans", 9.5F);
            this.cb_User.FormattingEnabled = true;
            this.cb_User.Location = new System.Drawing.Point(953, 37);
            this.cb_User.Margin = new System.Windows.Forms.Padding(10);
            this.cb_User.Name = "cb_User";
            this.cb_User.NextControl = null;
            this.cb_User.Size = new System.Drawing.Size(200, 30);
            this.cb_User.TabIndex = 1;
            this.cb_User.SelectionChangeCommitted += new System.EventHandler(this.Cb_User_SelectionChangeCommitted);
            this.cb_User.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cb_User_KeyDown);
            this.cb_User.Leave += new System.EventHandler(this.Cb_User_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.Location = new System.Drawing.Point(1155, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربر:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // treeView9
            // 
            this.treeView9.CheckBoxes = true;
            this.treeView9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView9.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView9.Location = new System.Drawing.Point(0, 0);
            this.treeView9.Name = "treeView9";
            this.treeView9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeView9.RightToLeftLayout = true;
            this.treeView9.Size = new System.Drawing.Size(1272, 423);
            this.treeView9.TabIndex = 0;
            this.treeView9.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView9_AfterCheck);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel2.Size = new System.Drawing.Size(1280, 461);
            this.panel2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Controls.Add(this.tabPage9);
            this.tabControl1.Controls.Add(this.tabPage10);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.Controls.Add(this.tabPage14);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1280, 461);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabNextControll = null;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1272, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "فروش";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1266, 417);
            this.panel3.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.Size = new System.Drawing.Size(1266, 417);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterCheck);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1272, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "مدیریت فروش";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.treeView2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1266, 417);
            this.panel4.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.CheckBoxes = true;
            this.treeView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Name = "treeView2";
            this.treeView2.RightToLeftLayout = true;
            this.treeView2.Size = new System.Drawing.Size(1266, 417);
            this.treeView2.TabIndex = 0;
            this.treeView2.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView2_AfterCheck);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1272, 423);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = " گزارشات";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.treeView3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1272, 423);
            this.panel5.TabIndex = 0;
            // 
            // treeView3
            // 
            this.treeView3.CheckBoxes = true;
            this.treeView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView3.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView3.Location = new System.Drawing.Point(0, 0);
            this.treeView3.Name = "treeView3";
            this.treeView3.RightToLeftLayout = true;
            this.treeView3.Size = new System.Drawing.Size(1272, 423);
            this.treeView3.TabIndex = 0;
            this.treeView3.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView3_AfterCheck);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel6);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1272, 423);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "انبار";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.treeView4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1272, 423);
            this.panel6.TabIndex = 0;
            // 
            // treeView4
            // 
            this.treeView4.CheckBoxes = true;
            this.treeView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView4.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView4.Location = new System.Drawing.Point(0, 0);
            this.treeView4.Name = "treeView4";
            this.treeView4.RightToLeftLayout = true;
            this.treeView4.Size = new System.Drawing.Size(1272, 423);
            this.treeView4.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.panel7);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1272, 423);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "حسابداری";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.treeView5);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1272, 423);
            this.panel7.TabIndex = 0;
            // 
            // treeView5
            // 
            this.treeView5.CheckBoxes = true;
            this.treeView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView5.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView5.Location = new System.Drawing.Point(0, 0);
            this.treeView5.Name = "treeView5";
            this.treeView5.RightToLeftLayout = true;
            this.treeView5.Size = new System.Drawing.Size(1272, 423);
            this.treeView5.TabIndex = 1;
            this.treeView5.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView5_AfterCheck);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel8);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1272, 423);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "رهیاب";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.treeView6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1272, 423);
            this.panel8.TabIndex = 0;
            // 
            // treeView6
            // 
            this.treeView6.CheckBoxes = true;
            this.treeView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView6.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView6.Location = new System.Drawing.Point(0, 0);
            this.treeView6.Name = "treeView6";
            this.treeView6.RightToLeftLayout = true;
            this.treeView6.Size = new System.Drawing.Size(1272, 423);
            this.treeView6.TabIndex = 1;
            this.treeView6.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView6_AfterCheck);
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.panel9);
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(1272, 423);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "تنظیمات";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.treeView7);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1272, 423);
            this.panel9.TabIndex = 0;
            // 
            // treeView7
            // 
            this.treeView7.CheckBoxes = true;
            this.treeView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView7.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView7.Location = new System.Drawing.Point(0, 0);
            this.treeView7.Name = "treeView7";
            this.treeView7.RightToLeftLayout = true;
            this.treeView7.Size = new System.Drawing.Size(1272, 423);
            this.treeView7.TabIndex = 1;
            this.treeView7.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView7_AfterCheck);
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.panel10);
            this.tabPage8.Location = new System.Drawing.Point(4, 34);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(1272, 423);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "پشتیبان گیری";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.treeView8);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1272, 423);
            this.panel10.TabIndex = 0;
            // 
            // treeView8
            // 
            this.treeView8.CheckBoxes = true;
            this.treeView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView8.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView8.Location = new System.Drawing.Point(0, 0);
            this.treeView8.Name = "treeView8";
            this.treeView8.RightToLeftLayout = true;
            this.treeView8.Size = new System.Drawing.Size(1272, 423);
            this.treeView8.TabIndex = 1;
            this.treeView8.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView8_AfterCheck);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.treeView9);
            this.tabPage9.Location = new System.Drawing.Point(4, 34);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(1272, 423);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "پيامك";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // tabPage10
            // 
            this.tabPage10.Controls.Add(this.treeView10);
            this.tabPage10.Location = new System.Drawing.Point(4, 34);
            this.tabPage10.Name = "tabPage10";
            this.tabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage10.Size = new System.Drawing.Size(1272, 423);
            this.tabPage10.TabIndex = 9;
            this.tabPage10.Text = "مديريت وظايف";
            this.tabPage10.UseVisualStyleBackColor = true;
            // 
            // treeView10
            // 
            this.treeView10.CheckBoxes = true;
            this.treeView10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView10.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView10.Location = new System.Drawing.Point(3, 3);
            this.treeView10.Name = "treeView10";
            this.treeView10.RightToLeftLayout = true;
            this.treeView10.Size = new System.Drawing.Size(1266, 417);
            this.treeView10.TabIndex = 2;
            this.treeView10.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView10_AfterCheck);
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.treeView11);
            this.tabPage11.Location = new System.Drawing.Point(4, 34);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(1272, 423);
            this.tabPage11.TabIndex = 10;
            this.tabPage11.Text = "اطلاعات پايه";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // treeView11
            // 
            this.treeView11.CheckBoxes = true;
            this.treeView11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView11.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView11.Location = new System.Drawing.Point(3, 3);
            this.treeView11.Name = "treeView11";
            this.treeView11.RightToLeftLayout = true;
            this.treeView11.Size = new System.Drawing.Size(1266, 417);
            this.treeView11.TabIndex = 2;
            this.treeView11.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView11_AfterCheck);
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.treeView12);
            this.tabPage12.Location = new System.Drawing.Point(4, 34);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Size = new System.Drawing.Size(1272, 423);
            this.tabPage12.TabIndex = 11;
            this.tabPage12.Text = "خزانه داري";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // treeView12
            // 
            this.treeView12.CheckBoxes = true;
            this.treeView12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView12.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView12.Location = new System.Drawing.Point(0, 0);
            this.treeView12.Name = "treeView12";
            this.treeView12.RightToLeftLayout = true;
            this.treeView12.Size = new System.Drawing.Size(1272, 423);
            this.treeView12.TabIndex = 2;
            this.treeView12.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView12_AfterCheck);
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.treeView13);
            this.tabPage13.Location = new System.Drawing.Point(4, 34);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage13.Size = new System.Drawing.Size(1272, 423);
            this.tabPage13.TabIndex = 12;
            this.tabPage13.Text = "كليدهاي ميانبر";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // treeView13
            // 
            this.treeView13.CheckBoxes = true;
            this.treeView13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView13.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView13.Location = new System.Drawing.Point(3, 3);
            this.treeView13.Name = "treeView13";
            this.treeView13.RightToLeftLayout = true;
            this.treeView13.Size = new System.Drawing.Size(1266, 417);
            this.treeView13.TabIndex = 3;
            this.treeView13.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView13_AfterCheck);
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.treeView14);
            this.tabPage14.Location = new System.Drawing.Point(4, 34);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(1272, 423);
            this.tabPage14.TabIndex = 13;
            this.tabPage14.Text = "كالا گستران";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // treeView14
            // 
            this.treeView14.CheckBoxes = true;
            this.treeView14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView14.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.treeView14.Location = new System.Drawing.Point(3, 3);
            this.treeView14.Name = "treeView14";
            this.treeView14.RightToLeftLayout = true;
            this.treeView14.Size = new System.Drawing.Size(1266, 417);
            this.treeView14.TabIndex = 4;
            this.treeView14.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TreeView14_AfterCheck);
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.lblProccess);
            this.panel17.Controls.Add(this.label3);
            this.panel17.Controls.Add(this.cancelButton1);
            this.panel17.Controls.Add(this.btn_Save);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel17.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel17.Location = new System.Drawing.Point(0, 545);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1280, 55);
            this.panel17.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(271, 17);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(487, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "براي اعمال تنظيمات هر برگه بعد از تعيين دسترسي ها در همان برگه دكمه ي ثبت را بفشا" +
    "ريد.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton1
            // 
            this.cancelButton1.BackColor = System.Drawing.Color.White;
            this.cancelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.cancelButton1.ForeColor = System.Drawing.Color.Gray;
            this.cancelButton1.Location = new System.Drawing.Point(7, 11);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.NextControl = null;
            this.cancelButton1.Size = new System.Drawing.Size(81, 34);
            this.cancelButton1.TabIndex = 2;
            this.cancelButton1.Text = "انصراف";
            this.cancelButton1.UseVisualStyleBackColor = false;
            this.cancelButton1.Click += new System.EventHandler(this.CancelButton1_Click);
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
            this.btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // lblProccess
            // 
            this.lblProccess.AutoSize = true;
            this.lblProccess.BackColor = System.Drawing.Color.DarkGreen;
            this.lblProccess.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.lblProccess.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblProccess.Location = new System.Drawing.Point(179, 16);
            this.lblProccess.Name = "lblProccess";
            this.lblProccess.Size = new System.Drawing.Size(87, 22);
            this.lblProccess.TabIndex = 4;
            this.lblProccess.Text = "در حال پردازش";
            this.lblProccess.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProccess.Visible = false;
            // 
            // UserAccessControl
            // 
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel17);
            this.Name = "UserAccessControl";
            this.Size = new System.Drawing.Size(1280, 600);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.tabPage10.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.ResumeLayout(false);

        }
        private void SetVisabilityTab()
        {
            try
            {
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    ((Control)tabControl1.TabPages[i]).Enabled = false;
                }
                var list = SubSystemPermissionOperaion.GetListOfPermissionThisUser(Convert.ToInt32(cb_User.SelectedValue));
                foreach (var item in list)
                {
                    //if (item.SubSystemID != 10)
                    //{
                    ((Control)tabControl1.TabPages[Convert.ToInt32(item.SubSystemID) - 1]).Enabled = true;
                    //}
                    //else
                    //{
                    //    break;
                    //}
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FillUsers()
        {
            SysUser = UserComponent.GetAtiranUsers().ToList();
            cb_User.DisplayMember = "UserName";
            cb_User.ValueMember = "UserID";
            cb_User.DataSource = SysUser;
        }
        private void CheckChildren(TreeNode rootNode, bool isChecked)//انتخاب کردن یا غیر انتخاب کردن  زیر گره های یک تری ویو 
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }
        private void TreeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //foreach (int item in allFieldNodes)
                    //{
                    //    formNodes.Add(item);
                    //}
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //formNodes.Clear();
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int tabIndex = int.Parse(tabControl1.SelectedIndex.ToString());
            if (cb_User.SelectedValue == null)
            {
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("هشدار", "نام كاربر را انتخاب نماييد", "e");
                cb_User.Focus();
                cb_User.DroppedDown = true;
                return;
            }
            if (tabIndex == 0)
            {
                treeView1.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView1, 1, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView1.Nodes[0].EnsureVisible();
                treeView1.Nodes[treeView1.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 1)
            {
                treeView2.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView2, 2, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView2.Nodes[0].EnsureVisible();
                treeView2.Nodes[treeView2.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 2)
            {
                treeView3.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView3, 3, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView3.Nodes[0].EnsureVisible();
                treeView3.Nodes[treeView3.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 3)
            {
                treeView4.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView4, 4, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView4.Nodes[0].EnsureVisible();
                treeView4.Nodes[treeView4.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 4)
            {
                treeView5.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView5, 5, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView5.Nodes[0].EnsureVisible();
                treeView5.Nodes[treeView5.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 5)
            {
                treeView6.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView6, 6, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView6.Nodes[0].EnsureVisible();
                treeView6.Nodes[treeView6.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 6)
            {
                treeView7.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView7, 7, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView7.Nodes[0].EnsureVisible();
                treeView7.Nodes[treeView7.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 7)
            {
                treeView8.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView8, 8, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView8.Nodes[0].EnsureVisible();
                treeView8.Nodes[treeView8.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 8)
            {
                treeView9.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView9, 9, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView9.Nodes[0].EnsureVisible();
                treeView9.Nodes[treeView9.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 9)
            {
                treeView10.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView10, 10, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView10.Nodes[0].EnsureVisible();
                treeView10.Nodes[treeView10.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 10)
            {
                treeView11.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView11, 11, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView11.Nodes[0].EnsureVisible();
                treeView11.Nodes[treeView11.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 11)
            {
                treeView12.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView12, 12, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView12.Nodes[0].EnsureVisible();
                treeView12.Nodes[treeView12.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 12)
            {
                treeView13.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView13, 13, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView13.Nodes[0].EnsureVisible();
                treeView13.Nodes[treeView13.Nodes.Count - 1].EnsureVisible();
            }
            else if (tabIndex == 13)
            {
                treeView14.Nodes.Clear();
                SubSystemPermissionOperaion.GetFormEnvironmentList(treeView14, 14, int.Parse(cb_User.SelectedValue.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes);
                treeView14.Nodes[0].EnsureVisible();
                treeView14.Nodes[treeView14.Nodes.Count - 1].EnsureVisible();
            }
        }
        private void TreeView3_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //foreach (int item in allFieldNodes)
                    //{
                    //    formNodes.Add(item);
                    //}
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //formNodes.Clear();
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void TreeView5_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //formNodes.Clear();
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void TreeView6_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void TreeView7_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //foreach (int item in allFieldNodes)
                    //{
                    //    formNodes.Add(item);
                    //}
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //formNodes.Clear();
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void TreeView8_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //foreach (int item in allFieldNodes)
                    //{
                    //    formNodes.Add(item);
                    //}
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //formNodes.Clear();
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private async void Btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_User.SelectedValue == null)
                {
                    Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("هشدار", "نام كاربر را انتخاب نماييد", "e");
                    cb_User.Focus();
                    cb_User.DroppedDown = true;
                    return;
                }
                cb_User.Focus();
                btn_Save.Enabled = false;
                lblProccess.Visible = true;
                await SubSystemPermissionOperaion.DeleteFormPermission(int.Parse(cb_User.SelectedValue.ToString()), allFormNodes);
                await SubSystemPermissionOperaion.DeleteFieldPermission(int.Parse(cb_User.SelectedValue.ToString()), allFieldNodes);
                await SubSystemPermissionOperaion.insertToFormPermission(int.Parse(cb_User.SelectedValue.ToString()), formNodes);
                await SubSystemPermissionOperaion.insertToFieldPermission(int.Parse(cb_User.SelectedValue.ToString()), fieldNodes);
                TabControl1_SelectedIndexChanged(null, null);
                CustomMessageForm.CustomMessageBox.Show("پیغام", " ثبت با موفقیت انجام گرفت ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                btn_Save.Enabled = true;
                lblProccess.Visible = false;
            }
        }
        private void CancelButton1_Click(object sender, EventArgs e)
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
        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
            SetNodesForColor((TreeView)sender);
        }
        private void TreeView9_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    //foreach (int item in allFieldNodes)
                    //{
                    //    formNodes.Add(item);
                    //}
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void ChildNode(TreeNode node, bool status)
        {
            if (node.Nodes.Count > 0)
            {
                if (status != true)
                {
                    for (int i = 0; i < node.GetNodeCount(false); i++)
                    {
                        if (node.Nodes[i].Checked)
                        {
                            node.Nodes[i].Checked = status;
                        }
                        ChildNode(node.Nodes[i], status);
                    }
                }
                else
                {
                    for (int i = 0; i < node.GetNodeCount(false); i++)
                    {
                        if (!(node.Nodes[i].Checked))
                        {
                            node.Nodes[i].Checked = status;
                        }
                        ChildNode(node.Nodes[i], status);
                    }
                }
            }
        }
        private void SetNodesForColor(TreeView tree)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void TreeView10_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (status)
                {
                    this.ParentForm.Close();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Cb_User_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TabControl1_SelectedIndexChanged(sender, e);
            SetVisabilityTab();
        }
        private void TreeView11_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void TreeView12_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void TreeView13_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
        private void Cb_User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SetValueCmb();
            }
        }
        private void SetValueCmb()
        {
            try
            {
                if (SysUser.Count > 0 && SysUser.Where(i => i.UserName.StartsWith(cb_User.Text)).Count() > 0)
                {
                    string TextTemp = cb_User.Text;
                    cb_User.DataSource = null;
                    cb_User.DisplayMember = "user_name";
                    cb_User.ValueMember = "user_id";
                    cb_User.DataSource = SysUser;
                    cb_User.SelectedValue = SysUser.Where(i => i.UserName.StartsWith(TextTemp)).FirstOrDefault().UserID;
                    cb_User.Text = SysUser.Where(i => i.UserName.StartsWith(TextTemp)).FirstOrDefault().UserName;
                }
                else
                {
                    cb_User.SelectedIndex = 0;
                }
                TabControl1_SelectedIndexChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        private void Cb_User_Leave(object sender, EventArgs e)
        {
            if (cb_User.SelectedValue == null)
            {
                SetValueCmb();
            }
        }
        private void TreeView14_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (tempAllocation)
            {
                tempAllocation = false;
                return;
            }
            int userid = GetCurrentSysUser.Instance.UserID;
            if (e.Node.Checked)
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("MI"))
                {//نود منو انتخاب شده باشد
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FI"))
                {//نود فرم انتخاب شده باشد
                    formNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    if (!fieldNodes.Contains(int.Parse(e.Node.Tag.ToString().Substring(2))))
                    {
                        fieldNodes.Add(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    }
                    ChildNode(e.Node, true);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = false;
                }
            }
            else
            {
                if (e.Node.Tag.ToString().Contains("select"))
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("MI")) //نود منو در حالت انتخاب نشده باشد
                {
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FI")) //نود فرم در حالت انتخاب نشده باشد
                {
                    formNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Contains("FP"))
                {
                    fieldNodes.Remove(int.Parse(e.Node.Tag.ToString().Substring(2)));
                    ChildNode(e.Node, false);
                }
                else if (e.Node.Tag.ToString().Equals("WithoutAccess"))
                {
                    tempAllocation = true;
                    e.Node.Checked = true;
                }
            }
        }
    }
}
#endregion newcode
