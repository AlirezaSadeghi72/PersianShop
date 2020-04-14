
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions.UserOp;
using Atiran.Connections.Operaions.UserPersonalizationOp;
using Atiran.UI.WindowsForms.Controls;
using Atiran.UI.WindowsForms.MessageBoxes;
using Label = Atiran.UI.WindowsForms.Controls.Label;
using MenuStrip = Atiran.UI.WindowsForms.Controls.MenuStrip;

namespace Atiran.Settings
{
    public class UserPersonalizationTheme : Atiran.UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.UIElements.Panel pnlTop;
        private UI.WindowsForms.UIElements.Panel pnlMain;
        private UI.WindowsForms.Controls.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageControls;
        private UI.WindowsForms.Controls.GroupBox gboxFooter;
        private UI.WindowsForms.Controls.GroupBox gboxImageBackGround;
        private UI.WindowsForms.Controls.GroupBox gboxMenu;
        private UI.WindowsForms.Controls.GroupBox gboxTitre;
        private UI.WindowsForms.Controls.pictureBox picForColorFooter;
        private UI.WindowsForms.Controls.Label label8;
        private UI.WindowsForms.Controls.pictureBox picBackgroundColorFooter;
        private UI.WindowsForms.Controls.Label label7;
        private UI.WindowsForms.Controls.pictureBox picBackground;
        private UI.WindowsForms.Controls.Buttons.Button btnChoise;
        private UI.WindowsForms.Controls.RadioButton rbtnUserChoise;
        private UI.WindowsForms.Controls.RadioButton rbtnDefault;
        private UI.WindowsForms.Controls.pictureBox picForColorOutMenu;
        private UI.WindowsForms.Controls.pictureBox picForColorInMenu;
        private UI.WindowsForms.Controls.Label label6;
        private UI.WindowsForms.Controls.pictureBox picBackgroundColorOutMenu;
        private UI.WindowsForms.Controls.Label label3;
        private UI.WindowsForms.Controls.Label label5;
        private UI.WindowsForms.Controls.pictureBox picBackgroundColorInMenu;
        private UI.WindowsForms.Controls.Label label4;
        private UI.WindowsForms.Controls.pictureBox picColorFrontTitre;
        private UI.WindowsForms.Controls.pictureBox picBackgroundColorOutTitre;
        private UI.WindowsForms.Controls.Label label2;
        private UI.WindowsForms.Controls.Label label1;
        private UI.WindowsForms.Controls.Label lblFooter;
        private UI.WindowsForms.UIElements.Panel pnlMainButtons;
        private UI.WindowsForms.Controls.pictureBox lblClose;
        private UI.WindowsForms.Controls.Label lblDateTime;
        private UI.WindowsForms.Controls.Label lblSalMali;
        private UI.WindowsForms.Controls.Label btnLine;
        private UI.WindowsForms.Controls.Label lblseperator3;
        private UI.WindowsForms.Controls.Label lblseperator4;
        private UI.WindowsForms.Controls.Label lblseperator2;
        private UI.WindowsForms.Controls.Label lblseperator1;
        private UI.WindowsForms.Controls.Label lblMinimis;
        private UI.WindowsForms.Controls.Label lblMaximis;
        private System.Windows.Forms.MenuStrip msUserActivs;
        private ToolStripMenuItemAtiran miRestartApplication;
        private ToolStripMenuItemAtiran miUserActivs;
        private UI.WindowsForms.UIElements.Panel panel1;
        private UI.WindowsForms.Controls.Timer timerDateTime;
        private MenuStrip msMenu;
        private ColorDialog colorDialog1;
        private UI.WindowsForms.Controls.pictureBox picBackgroundColorInItemTitre;
        private UI.WindowsForms.Controls.Label label10;
        private UI.WindowsForms.UIElements.Panel panel2;
        private UI.WindowsForms.Controls.Buttons.Button btnDefault;
        private UI.WindowsForms.Controls.Buttons.SaveButton saveButton1;
        private UI.WindowsForms.Controls.Buttons.CancelButton cancelButton1;
        private ToolStripMenuItemAtiran ToolStripMenuItem4;
        private ToolStripMenuItemAtiran ToolStripMenuItem7;
        private ToolStripMenuItemAtiran ToolStripMenuItem8;
        private ToolStripMenuItemAtiran ToolStripMenuItem9;
        private ToolStripMenuItemAtiran toolStripMenuItem3;
        private ToolStripMenuItemAtiran ToolStripMenuItem10;
        private ToolStripMenuItemAtiran ToolStripMenuItem11;
        private ToolStripMenuItemAtiran ToolStripMenuItem12;
        private ToolStripMenuItemAtiran ToolStripMenuItem13;
        private ToolStripMenuItemAtiran ToolStripMenuItem5;
        private ToolStripMenuItemAtiran ToolStripMenuItem6;
        private ToolStripMenuItemAtiran ToolStripMenuItem14;
        private ToolStripMenuItemAtiran ToolStripMenuItem15;
        private UI.WindowsForms.Controls.NumericUpDown numberUDMenu;
        private UI.WindowsForms.Controls.Label label11;
        private UI.WindowsForms.Controls.NumericUpDown numberUDFooter;
        private UI.WindowsForms.Controls.Label label12;
        private ToolStripMenuItemAtiran toolStripMenuItem2;
        private ToolStripMenuItemAtiran toolStripMenuItem16;
        private ToolStripMenuItemAtiran toolStripMenuItem17;
        private UI.WindowsForms.UIElements.Panel pnlFooter;

        public UserPersonalizationTheme()
        {
            InitializeComponent();
            timerDateTime.Start();
            MenuTitre = new PropertyToolStripProfessionalRenderer()
            {
                ColorBackGroundHighlight = Color.FromArgb(21, 100, 123)
            };
            MenuMenu = new PropertyToolStripProfessionalRenderer();
            renserMenuTitre =
                new ToolStripProfessionalRendererAtiran(ref MenuTitre);
            renserMenuMenu =
                new ToolStripProfessionalRendererAtiran(ref MenuMenu);

            msMenu.Renderer = renserMenuMenu;
            msUserActivs.Renderer = renserMenuTitre;

            ImageAddres = UserPersonalizationOperaion.ImageBackgroundAddres;

        }

        private void InitializeComponent()
        {
            this.pnlTop = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.pnlMain = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.tabControl = new Atiran.UI.WindowsForms.Controls.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.panel2 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.btnDefault = new Atiran.UI.WindowsForms.Controls.Buttons.Button();
            this.saveButton1 = new Atiran.UI.WindowsForms.Controls.Buttons.SaveButton();
            this.cancelButton1 = new Atiran.UI.WindowsForms.Controls.Buttons.CancelButton();
            this.gboxFooter = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.numberUDFooter = new Atiran.UI.WindowsForms.Controls.NumericUpDown();
            this.lblFooter = new Atiran.UI.WindowsForms.Controls.Label();
            this.label12 = new Atiran.UI.WindowsForms.Controls.Label();
            this.picForColorFooter = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.label8 = new Atiran.UI.WindowsForms.Controls.Label();
            this.picBackgroundColorFooter = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.label7 = new Atiran.UI.WindowsForms.Controls.Label();
            this.gboxMenu = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.numberUDMenu = new Atiran.UI.WindowsForms.Controls.NumericUpDown();
            this.label11 = new Atiran.UI.WindowsForms.Controls.Label();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.msMenu = new Atiran.UI.WindowsForms.Controls.MenuStrip();
            this.ToolStripMenuItem4 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem7 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem8 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem9 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.toolStripMenuItem3 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem10 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem11 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem12 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem13 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem5 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem14 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem15 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.ToolStripMenuItem6 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.picForColorOutMenu = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.picForColorInMenu = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.label6 = new Atiran.UI.WindowsForms.Controls.Label();
            this.picBackgroundColorOutMenu = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.label3 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label5 = new Atiran.UI.WindowsForms.Controls.Label();
            this.picBackgroundColorInMenu = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.label4 = new Atiran.UI.WindowsForms.Controls.Label();
            this.gboxTitre = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.picBackgroundColorInItemTitre = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.label10 = new Atiran.UI.WindowsForms.Controls.Label();
            this.pnlMainButtons = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.lblClose = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.lblDateTime = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblSalMali = new Atiran.UI.WindowsForms.Controls.Label();
            this.btnLine = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator3 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator4 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator2 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblMinimis = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblMaximis = new Atiran.UI.WindowsForms.Controls.Label();
            this.msUserActivs = new System.Windows.Forms.MenuStrip();
            this.miRestartApplication = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.miUserActivs = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.toolStripMenuItem2 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.toolStripMenuItem16 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.toolStripMenuItem17 = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.picColorFrontTitre = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.picBackgroundColorOutTitre = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.label2 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.gboxImageBackGround = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.picBackground = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.btnChoise = new Atiran.UI.WindowsForms.Controls.Buttons.Button();
            this.rbtnUserChoise = new Atiran.UI.WindowsForms.Controls.RadioButton();
            this.rbtnDefault = new Atiran.UI.WindowsForms.Controls.RadioButton();
            this.tabPageControls = new System.Windows.Forms.TabPage();
            this.pnlFooter = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.timerDateTime = new Atiran.UI.WindowsForms.Controls.Timer();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnlMain.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gboxFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberUDFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForColorFooter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorFooter)).BeginInit();
            this.gboxMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberUDMenu)).BeginInit();
            this.panel1.SuspendLayout();
            this.msMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picForColorOutMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForColorInMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorOutMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorInMenu)).BeginInit();
            this.gboxTitre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorInItemTitre)).BeginInit();
            this.pnlMainButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblClose)).BeginInit();
            this.msUserActivs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColorFrontTitre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorOutTitre)).BeginInit();
            this.gboxImageBackGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 34);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabControl);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlMain.Location = new System.Drawing.Point(0, 34);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1200, 641);
            this.pnlMain.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Controls.Add(this.tabPageControls);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 641);
            this.tabControl.TabIndex = 1;
            this.tabControl.TabNextControll = null;
            // 
            // tabPageMain
            // 
            this.tabPageMain.AutoScroll = true;
            this.tabPageMain.Controls.Add(this.panel2);
            this.tabPageMain.Controls.Add(this.gboxFooter);
            this.tabPageMain.Controls.Add(this.gboxMenu);
            this.tabPageMain.Controls.Add(this.gboxTitre);
            this.tabPageMain.Controls.Add(this.gboxImageBackGround);
            this.tabPageMain.Location = new System.Drawing.Point(4, 31);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(1192, 606);
            this.tabPageMain.TabIndex = 2;
            this.tabPageMain.Text = "زمينه";
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDefault);
            this.panel2.Controls.Add(this.saveButton1);
            this.panel2.Controls.Add(this.cancelButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel2.Location = new System.Drawing.Point(3, 565);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 38);
            this.panel2.TabIndex = 4;
            // 
            // btnDefault
            // 
            this.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefault.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.btnDefault.Location = new System.Drawing.Point(170, 1);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.NextControl = null;
            this.btnDefault.Size = new System.Drawing.Size(81, 34);
            this.btnDefault.TabIndex = 9;
            this.btnDefault.Text = "پيشفرض";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // saveButton1
            // 
            this.saveButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
            this.saveButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
            this.saveButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.saveButton1.ForeColor = System.Drawing.Color.White;
            this.saveButton1.Location = new System.Drawing.Point(89, 1);
            this.saveButton1.Margin = new System.Windows.Forms.Padding(10);
            this.saveButton1.Name = "saveButton1";
            this.saveButton1.NextControl = null;
            this.saveButton1.Size = new System.Drawing.Size(81, 34);
            this.saveButton1.TabIndex = 8;
            this.saveButton1.Text = "ذخيره";
            this.saveButton1.UseVisualStyleBackColor = false;
            this.saveButton1.Click += new System.EventHandler(this.saveButton1_Click);
            // 
            // cancelButton1
            // 
            this.cancelButton1.BackColor = System.Drawing.Color.White;
            this.cancelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.cancelButton1.ForeColor = System.Drawing.Color.Gray;
            this.cancelButton1.Location = new System.Drawing.Point(8, 1);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.NextControl = null;
            this.cancelButton1.Size = new System.Drawing.Size(81, 34);
            this.cancelButton1.TabIndex = 7;
            this.cancelButton1.Text = "انصراف";
            this.cancelButton1.UseVisualStyleBackColor = false;
            this.cancelButton1.Click += new System.EventHandler(this.cancelButton1_Click);
            // 
            // gboxFooter
            // 
            this.gboxFooter.Controls.Add(this.numberUDFooter);
            this.gboxFooter.Controls.Add(this.lblFooter);
            this.gboxFooter.Controls.Add(this.label12);
            this.gboxFooter.Controls.Add(this.picForColorFooter);
            this.gboxFooter.Controls.Add(this.label8);
            this.gboxFooter.Controls.Add(this.picBackgroundColorFooter);
            this.gboxFooter.Controls.Add(this.label7);
            this.gboxFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxFooter.Location = new System.Drawing.Point(3, 448);
            this.gboxFooter.Name = "gboxFooter";
            this.gboxFooter.Size = new System.Drawing.Size(1186, 100);
            this.gboxFooter.TabIndex = 3;
            this.gboxFooter.TabStop = false;
            this.gboxFooter.Text = "پاصفحه";
            // 
            // numberUDFooter
            // 
            this.numberUDFooter.Location = new System.Drawing.Point(891, 38);
            this.numberUDFooter.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numberUDFooter.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numberUDFooter.Name = "numberUDFooter";
            this.numberUDFooter.NextControl = null;
            this.numberUDFooter.Size = new System.Drawing.Size(51, 29);
            this.numberUDFooter.TabIndex = 7;
            this.numberUDFooter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberUDFooter.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numberUDFooter.ValueChanged += new System.EventHandler(this.numberUDFooter_ValueChanged);
            // 
            // lblFooter
            // 
            this.lblFooter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFooter.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.lblFooter.Location = new System.Drawing.Point(6, 45);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(797, 20);
            this.lblFooter.TabIndex = 8;
            this.lblFooter.Text = "راهنماي نرم افزار : F1";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label12.Location = new System.Drawing.Point(948, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 22);
            this.label12.TabIndex = 5;
            this.label12.Text = "سايز متن";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picForColorFooter
            // 
            this.picForColorFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picForColorFooter.BackColor = System.Drawing.Color.Black;
            this.picForColorFooter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picForColorFooter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picForColorFooter.Location = new System.Drawing.Point(1057, 60);
            this.picForColorFooter.Name = "picForColorFooter";
            this.picForColorFooter.Size = new System.Drawing.Size(22, 22);
            this.picForColorFooter.TabIndex = 6;
            this.picForColorFooter.TabStop = false;
            this.picForColorFooter.BackColorChanged += new System.EventHandler(this.picForColorFooter_BackColorChanged);
            this.picForColorFooter.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label8.Location = new System.Drawing.Point(1112, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 22);
            this.label8.TabIndex = 4;
            this.label8.Text = "رنگ زمينه";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBackgroundColorFooter
            // 
            this.picBackgroundColorFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBackgroundColorFooter.BackColor = System.Drawing.Color.White;
            this.picBackgroundColorFooter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackgroundColorFooter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackgroundColorFooter.Location = new System.Drawing.Point(1057, 25);
            this.picBackgroundColorFooter.Name = "picBackgroundColorFooter";
            this.picBackgroundColorFooter.Size = new System.Drawing.Size(22, 22);
            this.picBackgroundColorFooter.TabIndex = 7;
            this.picBackgroundColorFooter.TabStop = false;
            this.picBackgroundColorFooter.BackColorChanged += new System.EventHandler(this.picBackgroundColorFooter_BackColorChanged);
            this.picBackgroundColorFooter.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label7.Location = new System.Drawing.Point(1112, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 22);
            this.label7.TabIndex = 5;
            this.label7.Text = "رنگ متن";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gboxMenu
            // 
            this.gboxMenu.Controls.Add(this.numberUDMenu);
            this.gboxMenu.Controls.Add(this.label11);
            this.gboxMenu.Controls.Add(this.panel1);
            this.gboxMenu.Controls.Add(this.picForColorOutMenu);
            this.gboxMenu.Controls.Add(this.picForColorInMenu);
            this.gboxMenu.Controls.Add(this.label6);
            this.gboxMenu.Controls.Add(this.picBackgroundColorOutMenu);
            this.gboxMenu.Controls.Add(this.label3);
            this.gboxMenu.Controls.Add(this.label5);
            this.gboxMenu.Controls.Add(this.picBackgroundColorInMenu);
            this.gboxMenu.Controls.Add(this.label4);
            this.gboxMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxMenu.Location = new System.Drawing.Point(3, 348);
            this.gboxMenu.Name = "gboxMenu";
            this.gboxMenu.Size = new System.Drawing.Size(1186, 100);
            this.gboxMenu.TabIndex = 1;
            this.gboxMenu.TabStop = false;
            this.gboxMenu.Text = "منو";
            // 
            // numberUDMenu
            // 
            this.numberUDMenu.Location = new System.Drawing.Point(676, 39);
            this.numberUDMenu.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numberUDMenu.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numberUDMenu.Name = "numberUDMenu";
            this.numberUDMenu.NextControl = null;
            this.numberUDMenu.Size = new System.Drawing.Size(51, 29);
            this.numberUDMenu.TabIndex = 7;
            this.numberUDMenu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberUDMenu.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
            this.numberUDMenu.ValueChanged += new System.EventHandler(this.numberUDMenu_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label11.Location = new System.Drawing.Point(733, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 22);
            this.label11.TabIndex = 5;
            this.label11.Text = "سايز متن";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.msMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(3, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 72);
            this.panel1.TabIndex = 4;
            // 
            // msMenu
            // 
            this.msMenu.AllowItemReorder = true;
            this.msMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.msMenu.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem4,
            this.ToolStripMenuItem5,
            this.ToolStripMenuItem6});
            this.msMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(556, 32);
            this.msMenu.TabIndex = 24;
            this.msMenu.Text = "menuStrip1";
            // 
            // ToolStripMenuItem4
            // 
            this.ToolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem7,
            this.ToolStripMenuItem10,
            this.ToolStripMenuItem13});
            this.ToolStripMenuItem4.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem4.Image = global::Atiran.Settings.Properties.Resources.basic_information_tiny;
            this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
            this.ToolStripMenuItem4.Size = new System.Drawing.Size(108, 28);
            this.ToolStripMenuItem4.Text = "اطلاعات پايه";
            // 
            // ToolStripMenuItem7
            // 
            this.ToolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem8,
            this.ToolStripMenuItem9,
            this.toolStripMenuItem3});
            this.ToolStripMenuItem7.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
            this.ToolStripMenuItem7.Size = new System.Drawing.Size(150, 28);
            this.ToolStripMenuItem7.Text = "حوزه فعاليت";
            // 
            // ToolStripMenuItem8
            // 
            this.ToolStripMenuItem8.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
            this.ToolStripMenuItem8.Size = new System.Drawing.Size(112, 28);
            this.ToolStripMenuItem8.Text = "استان";
            // 
            // ToolStripMenuItem9
            // 
            this.ToolStripMenuItem9.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
            this.ToolStripMenuItem9.Size = new System.Drawing.Size(112, 28);
            this.ToolStripMenuItem9.Text = "شهر";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(112, 28);
            this.toolStripMenuItem3.Text = "....";
            // 
            // ToolStripMenuItem10
            // 
            this.ToolStripMenuItem10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem11,
            this.ToolStripMenuItem12});
            this.ToolStripMenuItem10.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem10.Name = "ToolStripMenuItem10";
            this.ToolStripMenuItem10.Size = new System.Drawing.Size(150, 28);
            this.ToolStripMenuItem10.Text = "بانك";
            // 
            // ToolStripMenuItem11
            // 
            this.ToolStripMenuItem11.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem11.Name = "ToolStripMenuItem11";
            this.ToolStripMenuItem11.Size = new System.Drawing.Size(231, 28);
            this.ToolStripMenuItem11.Text = "معرفي بانك و شماره حساب";
            // 
            // ToolStripMenuItem12
            // 
            this.ToolStripMenuItem12.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem12.Name = "ToolStripMenuItem12";
            this.ToolStripMenuItem12.Size = new System.Drawing.Size(231, 28);
            this.ToolStripMenuItem12.Text = "معرفي دسته چك جديد";
            // 
            // ToolStripMenuItem13
            // 
            this.ToolStripMenuItem13.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem13.Name = "ToolStripMenuItem13";
            this.ToolStripMenuItem13.Size = new System.Drawing.Size(150, 28);
            this.ToolStripMenuItem13.Text = "...";
            // 
            // ToolStripMenuItem5
            // 
            this.ToolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem14,
            this.ToolStripMenuItem15});
            this.ToolStripMenuItem5.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem5.Image = global::Atiran.Settings.Properties.Resources.selling_management_tiny;
            this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
            this.ToolStripMenuItem5.Size = new System.Drawing.Size(120, 28);
            this.ToolStripMenuItem5.Text = "مديريت فروش";
            // 
            // ToolStripMenuItem14
            // 
            this.ToolStripMenuItem14.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem14.Name = "ToolStripMenuItem14";
            this.ToolStripMenuItem14.Size = new System.Drawing.Size(170, 28);
            this.ToolStripMenuItem14.Text = "لاين هاي فروش";
            // 
            // ToolStripMenuItem15
            // 
            this.ToolStripMenuItem15.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem15.Name = "ToolStripMenuItem15";
            this.ToolStripMenuItem15.Size = new System.Drawing.Size(170, 28);
            this.ToolStripMenuItem15.Text = "تيم هاي فروش";
            // 
            // ToolStripMenuItem6
            // 
            this.ToolStripMenuItem6.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
            this.ToolStripMenuItem6.Size = new System.Drawing.Size(38, 28);
            this.ToolStripMenuItem6.Text = "....";
            // 
            // picForColorOutMenu
            // 
            this.picForColorOutMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picForColorOutMenu.BackColor = System.Drawing.Color.White;
            this.picForColorOutMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picForColorOutMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picForColorOutMenu.Location = new System.Drawing.Point(836, 60);
            this.picForColorOutMenu.Name = "picForColorOutMenu";
            this.picForColorOutMenu.Size = new System.Drawing.Size(22, 22);
            this.picForColorOutMenu.TabIndex = 2;
            this.picForColorOutMenu.TabStop = false;
            this.picForColorOutMenu.BackColorChanged += new System.EventHandler(this.picForColorOutMenu_BackColorChanged);
            this.picForColorOutMenu.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // picForColorInMenu
            // 
            this.picForColorInMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picForColorInMenu.BackColor = System.Drawing.Color.White;
            this.picForColorInMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picForColorInMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picForColorInMenu.Location = new System.Drawing.Point(1014, 60);
            this.picForColorInMenu.Name = "picForColorInMenu";
            this.picForColorInMenu.Size = new System.Drawing.Size(22, 22);
            this.picForColorInMenu.TabIndex = 2;
            this.picForColorInMenu.TabStop = false;
            this.picForColorInMenu.BackColorChanged += new System.EventHandler(this.picForColorInMenu_BackColorChanged);
            this.picForColorInMenu.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label6.Location = new System.Drawing.Point(873, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "رنگ زمينه هنگام خروج";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBackgroundColorOutMenu
            // 
            this.picBackgroundColorOutMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBackgroundColorOutMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.picBackgroundColorOutMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackgroundColorOutMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackgroundColorOutMenu.Location = new System.Drawing.Point(836, 25);
            this.picBackgroundColorOutMenu.Name = "picBackgroundColorOutMenu";
            this.picBackgroundColorOutMenu.Size = new System.Drawing.Size(22, 22);
            this.picBackgroundColorOutMenu.TabIndex = 2;
            this.picBackgroundColorOutMenu.TabStop = false;
            this.picBackgroundColorOutMenu.BackColorChanged += new System.EventHandler(this.picBackgroundColorOutMenu_BackColorChanged);
            this.picBackgroundColorOutMenu.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label3.Location = new System.Drawing.Point(1051, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "رنگ زمينه هنگام ورود";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label5.Location = new System.Drawing.Point(873, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "رنگ متن هنگام خروج";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picBackgroundColorInMenu
            // 
            this.picBackgroundColorInMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBackgroundColorInMenu.BackColor = System.Drawing.Color.Teal;
            this.picBackgroundColorInMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackgroundColorInMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackgroundColorInMenu.Location = new System.Drawing.Point(1014, 25);
            this.picBackgroundColorInMenu.Name = "picBackgroundColorInMenu";
            this.picBackgroundColorInMenu.Size = new System.Drawing.Size(22, 22);
            this.picBackgroundColorInMenu.TabIndex = 2;
            this.picBackgroundColorInMenu.TabStop = false;
            this.picBackgroundColorInMenu.BackColorChanged += new System.EventHandler(this.picBackgroundColorInMenu_BackColorChanged);
            this.picBackgroundColorInMenu.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label4.Location = new System.Drawing.Point(1055, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 22);
            this.label4.TabIndex = 1;
            this.label4.Text = "رنگ متن هنگام ورود";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gboxTitre
            // 
            this.gboxTitre.Controls.Add(this.picBackgroundColorInItemTitre);
            this.gboxTitre.Controls.Add(this.label10);
            this.gboxTitre.Controls.Add(this.pnlMainButtons);
            this.gboxTitre.Controls.Add(this.picColorFrontTitre);
            this.gboxTitre.Controls.Add(this.picBackgroundColorOutTitre);
            this.gboxTitre.Controls.Add(this.label2);
            this.gboxTitre.Controls.Add(this.label1);
            this.gboxTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxTitre.Location = new System.Drawing.Point(3, 215);
            this.gboxTitre.Name = "gboxTitre";
            this.gboxTitre.Size = new System.Drawing.Size(1186, 133);
            this.gboxTitre.TabIndex = 0;
            this.gboxTitre.TabStop = false;
            this.gboxTitre.Text = "سربرگ";
            // 
            // picBackgroundColorInItemTitre
            // 
            this.picBackgroundColorInItemTitre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBackgroundColorInItemTitre.BackColor = System.Drawing.Color.Teal;
            this.picBackgroundColorInItemTitre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackgroundColorInItemTitre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackgroundColorInItemTitre.Location = new System.Drawing.Point(1031, 62);
            this.picBackgroundColorInItemTitre.Name = "picBackgroundColorInItemTitre";
            this.picBackgroundColorInItemTitre.Size = new System.Drawing.Size(22, 22);
            this.picBackgroundColorInItemTitre.TabIndex = 5;
            this.picBackgroundColorInItemTitre.TabStop = false;
            this.picBackgroundColorInItemTitre.BackColorChanged += new System.EventHandler(this.picBackgroundColorInItemTitre_BackColorChanged);
            this.picBackgroundColorInItemTitre.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label10.Location = new System.Drawing.Point(1068, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 50);
            this.label10.TabIndex = 4;
            this.label10.Text = "رنگ زمينه ايتم ها هنگام ورود";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMainButtons
            // 
            this.pnlMainButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(100)))), ((int)(((byte)(123)))));
            this.pnlMainButtons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMainButtons.Controls.Add(this.lblClose);
            this.pnlMainButtons.Controls.Add(this.lblDateTime);
            this.pnlMainButtons.Controls.Add(this.lblSalMali);
            this.pnlMainButtons.Controls.Add(this.btnLine);
            this.pnlMainButtons.Controls.Add(this.lblseperator3);
            this.pnlMainButtons.Controls.Add(this.lblseperator4);
            this.pnlMainButtons.Controls.Add(this.lblseperator2);
            this.pnlMainButtons.Controls.Add(this.lblseperator1);
            this.pnlMainButtons.Controls.Add(this.lblMinimis);
            this.pnlMainButtons.Controls.Add(this.lblMaximis);
            this.pnlMainButtons.Controls.Add(this.msUserActivs);
            this.pnlMainButtons.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlMainButtons.Location = new System.Drawing.Point(3, 32);
            this.pnlMainButtons.Name = "pnlMainButtons";
            this.pnlMainButtons.Size = new System.Drawing.Size(875, 40);
            this.pnlMainButtons.TabIndex = 3;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lblClose.Image = global::Atiran.Settings.Properties.Resources.Exit_1;
            this.lblClose.Location = new System.Drawing.Point(834, 1);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(34, 38);
            this.lblClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblClose.TabIndex = 25;
            this.lblClose.TabStop = false;
            this.lblClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblClose_MouseDown);
            this.lblClose.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // lblDateTime
            // 
            this.lblDateTime.BackColor = System.Drawing.Color.Transparent;
            this.lblDateTime.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblDateTime.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTime.ForeColor = System.Drawing.Color.White;
            this.lblDateTime.Location = new System.Drawing.Point(4, 4);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDateTime.Size = new System.Drawing.Size(160, 31);
            this.lblDateTime.TabIndex = 14;
            this.lblDateTime.Text = "1398/08/08   12/12/12";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSalMali
            // 
            this.lblSalMali.BackColor = System.Drawing.Color.Transparent;
            this.lblSalMali.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblSalMali.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalMali.ForeColor = System.Drawing.Color.White;
            this.lblSalMali.Location = new System.Drawing.Point(168, 4);
            this.lblSalMali.Name = "lblSalMali";
            this.lblSalMali.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSalMali.Size = new System.Drawing.Size(120, 31);
            this.lblSalMali.TabIndex = 16;
            this.lblSalMali.Text = "سال جاري";
            this.lblSalMali.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLine
            // 
            this.btnLine.BackColor = System.Drawing.Color.Transparent;
            this.btnLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLine.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLine.ForeColor = System.Drawing.Color.White;
            this.btnLine.Location = new System.Drawing.Point(293, 0);
            this.btnLine.Name = "btnLine";
            this.btnLine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLine.Size = new System.Drawing.Size(265, 36);
            this.btnLine.TabIndex = 17;
            this.btnLine.Text = "لاين فروش انتخاب نشده";
            this.btnLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLine.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.btnLine.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // lblseperator3
            // 
            this.lblseperator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.lblseperator3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblseperator3.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblseperator3.Location = new System.Drawing.Point(559, 0);
            this.lblseperator3.Name = "lblseperator3";
            this.lblseperator3.Size = new System.Drawing.Size(3, 38);
            this.lblseperator3.TabIndex = 21;
            this.lblseperator3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblseperator4
            // 
            this.lblseperator4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.lblseperator4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblseperator4.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblseperator4.Location = new System.Drawing.Point(721, -1);
            this.lblseperator4.Name = "lblseperator4";
            this.lblseperator4.Size = new System.Drawing.Size(3, 38);
            this.lblseperator4.TabIndex = 22;
            this.lblseperator4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblseperator2
            // 
            this.lblseperator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.lblseperator2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblseperator2.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblseperator2.Location = new System.Drawing.Point(288, 0);
            this.lblseperator2.Name = "lblseperator2";
            this.lblseperator2.Size = new System.Drawing.Size(3, 38);
            this.lblseperator2.TabIndex = 23;
            this.lblseperator2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblseperator1
            // 
            this.lblseperator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.lblseperator1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblseperator1.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblseperator1.Location = new System.Drawing.Point(165, 1);
            this.lblseperator1.Name = "lblseperator1";
            this.lblseperator1.Size = new System.Drawing.Size(3, 38);
            this.lblseperator1.TabIndex = 15;
            this.lblseperator1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinimis
            // 
            this.lblMinimis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinimis.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimis.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMinimis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMinimis.ForeColor = System.Drawing.Color.Transparent;
            this.lblMinimis.Image = global::Atiran.Settings.Properties.Resources.Minimis_1;
            this.lblMinimis.Location = new System.Drawing.Point(770, 1);
            this.lblMinimis.Name = "lblMinimis";
            this.lblMinimis.Size = new System.Drawing.Size(32, 38);
            this.lblMinimis.TabIndex = 13;
            this.lblMinimis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinimis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.lblMinimis.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lblMinimis.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // lblMaximis
            // 
            this.lblMaximis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaximis.BackColor = System.Drawing.Color.Transparent;
            this.lblMaximis.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblMaximis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblMaximis.ForeColor = System.Drawing.Color.Transparent;
            this.lblMaximis.Image = global::Atiran.Settings.Properties.Resources.Maximis_1;
            this.lblMaximis.Location = new System.Drawing.Point(802, 1);
            this.lblMaximis.Name = "lblMaximis";
            this.lblMaximis.Size = new System.Drawing.Size(32, 38);
            this.lblMaximis.TabIndex = 12;
            this.lblMaximis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMaximis.Click += new System.EventHandler(this.lblMaximis_Click);
            this.lblMaximis.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.lblMaximis.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.lblMaximis.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // msUserActivs
            // 
            this.msUserActivs.AutoSize = false;
            this.msUserActivs.BackColor = System.Drawing.Color.Transparent;
            this.msUserActivs.Dock = System.Windows.Forms.DockStyle.None;
            this.msUserActivs.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msUserActivs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRestartApplication,
            this.miUserActivs});
            this.msUserActivs.Location = new System.Drawing.Point(542, 0);
            this.msUserActivs.Name = "msUserActivs";
            this.msUserActivs.Size = new System.Drawing.Size(180, 36);
            this.msUserActivs.TabIndex = 24;
            this.msUserActivs.Text = "menuStrip1";
            // 
            // miRestartApplication
            // 
            this.miRestartApplication.AutoSize = false;
            this.miRestartApplication.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.miRestartApplication.Image = global::Atiran.Settings.Properties.Resources.user;
            this.miRestartApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miRestartApplication.Name = "miRestartApplication";
            this.miRestartApplication.Size = new System.Drawing.Size(42, 37);
            this.miRestartApplication.Text = " ";
            this.miRestartApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.miRestartApplication.MouseEnter += new System.EventHandler(this.miRestartApplication_MouseEnter);
            this.miRestartApplication.MouseLeave += new System.EventHandler(this.miRestartApplication_MouseLeave);
            // 
            // miUserActivs
            // 
            this.miUserActivs.AutoSize = false;
            this.miUserActivs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miUserActivs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem16,
            this.toolStripMenuItem17});
            this.miUserActivs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.miUserActivs.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.miUserActivs.Name = "miUserActivs";
            this.miUserActivs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.miUserActivs.Size = new System.Drawing.Size(122, 37);
            this.miUserActivs.Text = "كاربر";
            this.miUserActivs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miUserActivs.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Atiran.Settings.Properties.Resources.status_online;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(114, 24);
            this.toolStripMenuItem2.Text = "كاربر1";
            // 
            // toolStripMenuItem16
            // 
            this.toolStripMenuItem16.Image = global::Atiran.Settings.Properties.Resources.status_online;
            this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            this.toolStripMenuItem16.Size = new System.Drawing.Size(114, 24);
            this.toolStripMenuItem16.Text = "كاربر2";
            // 
            // toolStripMenuItem17
            // 
            this.toolStripMenuItem17.Image = global::Atiran.Settings.Properties.Resources.status_online;
            this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            this.toolStripMenuItem17.Size = new System.Drawing.Size(114, 24);
            this.toolStripMenuItem17.Text = "كاربر3";
            // 
            // picColorFrontTitre
            // 
            this.picColorFrontTitre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picColorFrontTitre.BackColor = System.Drawing.Color.White;
            this.picColorFrontTitre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picColorFrontTitre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picColorFrontTitre.Location = new System.Drawing.Point(1031, 102);
            this.picColorFrontTitre.Name = "picColorFrontTitre";
            this.picColorFrontTitre.Size = new System.Drawing.Size(22, 22);
            this.picColorFrontTitre.TabIndex = 2;
            this.picColorFrontTitre.TabStop = false;
            this.picColorFrontTitre.BackColorChanged += new System.EventHandler(this.picColorFrontTitre_BackColorChanged);
            this.picColorFrontTitre.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // picBackgroundColorOutTitre
            // 
            this.picBackgroundColorOutTitre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picBackgroundColorOutTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(100)))), ((int)(((byte)(123)))));
            this.picBackgroundColorOutTitre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackgroundColorOutTitre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picBackgroundColorOutTitre.Location = new System.Drawing.Point(1031, 25);
            this.picBackgroundColorOutTitre.Name = "picBackgroundColorOutTitre";
            this.picBackgroundColorOutTitre.Size = new System.Drawing.Size(22, 22);
            this.picBackgroundColorOutTitre.TabIndex = 2;
            this.picBackgroundColorOutTitre.TabStop = false;
            this.picBackgroundColorOutTitre.BackColorChanged += new System.EventHandler(this.picBackgroundColorOutTitre_BackColorChanged);
            this.picBackgroundColorOutTitre.Click += new System.EventHandler(this.OpenColorDialog_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label2.Location = new System.Drawing.Point(1086, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "رنگ متن";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.Location = new System.Drawing.Point(1086, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "رنگ زمينه";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gboxImageBackGround
            // 
            this.gboxImageBackGround.Controls.Add(this.picBackground);
            this.gboxImageBackGround.Controls.Add(this.btnChoise);
            this.gboxImageBackGround.Controls.Add(this.rbtnUserChoise);
            this.gboxImageBackGround.Controls.Add(this.rbtnDefault);
            this.gboxImageBackGround.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxImageBackGround.Location = new System.Drawing.Point(3, 3);
            this.gboxImageBackGround.Name = "gboxImageBackGround";
            this.gboxImageBackGround.Size = new System.Drawing.Size(1186, 212);
            this.gboxImageBackGround.TabIndex = 2;
            this.gboxImageBackGround.TabStop = false;
            this.gboxImageBackGround.Text = "عكس زمينه";
            // 
            // picBackground
            // 
            this.picBackground.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBackground.Location = new System.Drawing.Point(8, 21);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(391, 185);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 3;
            this.picBackground.TabStop = false;
            // 
            // btnChoise
            // 
            this.btnChoise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoise.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.btnChoise.Location = new System.Drawing.Point(1023, 60);
            this.btnChoise.Name = "btnChoise";
            this.btnChoise.NextControl = null;
            this.btnChoise.Size = new System.Drawing.Size(43, 26);
            this.btnChoise.TabIndex = 2;
            this.btnChoise.Text = "...";
            this.btnChoise.UseVisualStyleBackColor = true;
            this.btnChoise.Visible = false;
            this.btnChoise.Click += new System.EventHandler(this.btnChoise_Click);
            // 
            // rbtnUserChoise
            // 
            this.rbtnUserChoise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnUserChoise.AutoSize = true;
            this.rbtnUserChoise.Location = new System.Drawing.Point(1072, 60);
            this.rbtnUserChoise.Name = "rbtnUserChoise";
            this.rbtnUserChoise.NextControl = null;
            this.rbtnUserChoise.Size = new System.Drawing.Size(97, 26);
            this.rbtnUserChoise.TabIndex = 1;
            this.rbtnUserChoise.Text = "انتخاب عكس";
            this.rbtnUserChoise.UseVisualStyleBackColor = true;
            this.rbtnUserChoise.CheckedChanged += new System.EventHandler(this.rbtnUserChoise_CheckedChanged);
            // 
            // rbtnDefault
            // 
            this.rbtnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtnDefault.AutoSize = true;
            this.rbtnDefault.Checked = true;
            this.rbtnDefault.Location = new System.Drawing.Point(1044, 28);
            this.rbtnDefault.Name = "rbtnDefault";
            this.rbtnDefault.NextControl = null;
            this.rbtnDefault.Size = new System.Drawing.Size(125, 26);
            this.rbtnDefault.TabIndex = 1;
            this.rbtnDefault.TabStop = true;
            this.rbtnDefault.Text = "پيش فرض سيستم";
            this.rbtnDefault.UseVisualStyleBackColor = true;
            this.rbtnDefault.CheckedChanged += new System.EventHandler(this.rbtnDefault_CheckedChanged);
            // 
            // tabPageControls
            // 
            this.tabPageControls.Location = new System.Drawing.Point(4, 31);
            this.tabPageControls.Name = "tabPageControls";
            this.tabPageControls.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageControls.Size = new System.Drawing.Size(1192, 606);
            this.tabPageControls.TabIndex = 3;
            this.tabPageControls.Text = "كنترل ها ";
            this.tabPageControls.UseVisualStyleBackColor = true;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlFooter.Location = new System.Drawing.Point(0, 675);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1200, 25);
            this.pnlFooter.TabIndex = 3;
            this.pnlFooter.Visible = false;
            // 
            // timerDateTime
            // 
            this.timerDateTime.Interval = 500;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // UserPersonalizationTheme
            // 
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTop);
            this.Name = "UserPersonalizationTheme";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1200, 700);
            this.Load += new System.EventHandler(this.UserPersonalizationTheme_Load);
            this.pnlMain.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gboxFooter.ResumeLayout(false);
            this.gboxFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberUDFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForColorFooter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorFooter)).EndInit();
            this.gboxMenu.ResumeLayout(false);
            this.gboxMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numberUDMenu)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picForColorOutMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picForColorInMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorOutMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorInMenu)).EndInit();
            this.gboxTitre.ResumeLayout(false);
            this.gboxTitre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorInItemTitre)).EndInit();
            this.pnlMainButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblClose)).EndInit();
            this.msUserActivs.ResumeLayout(false);
            this.msUserActivs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picColorFrontTitre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackgroundColorOutTitre)).EndInit();
            this.gboxImageBackGround.ResumeLayout(false);
            this.gboxImageBackGround.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.ResumeLayout(false);

        }

        private void UserPersonalizationTheme_Load(object sender, EventArgs e)
        {
            SetDefultValues();
            loadSetting();
             colorDialog1.CustomColors = new int[] { 8086549, 8421376, 16777215, 8421376, 9863700, 16777215, 16777215, 16777215, 0, 16777215, 16777215, 16777215, 16777215, 16777215, 16777215, 16777215 };
        }

        private void loadSetting()
        {
            if (ImageAddres == string.Empty || ImageAddres == null)
            {
                rbtnDefault.Checked = true;
            }
            else
            {
                try
                {
                    rbtnUserChoise.Checked = true;
                    picBackground.Image = Bitmap.FromFile(ImageAddres);
                }
                catch (Exception)
                {
                    rbtnDefault.Checked = true;
                }
            }


            this.picBackgroundColorInItemTitre.BackColor = UserPersonalizationOperaion.BackgroundColorInItemTitre;

            this.picColorFrontTitre.BackColor = UserPersonalizationOperaion.ColorFrontTitre;

            this.picBackgroundColorOutTitre.BackColor = UserPersonalizationOperaion.BackgroundColorOutTitre;
            //------------------------------------------------------------------------------------------

            this.picForColorOutMenu.BackColor = UserPersonalizationOperaion.ForColorOutMenu;

            this.picForColorInMenu.BackColor = UserPersonalizationOperaion.ForColorInMenu;

            this.picBackgroundColorOutMenu.BackColor = UserPersonalizationOperaion.BackgroundColorOutMenu;

            this.picBackgroundColorInMenu.BackColor = UserPersonalizationOperaion.BackgroundColorInMenu;

            this.numberUDMenu.Value = UserPersonalizationOperaion.FontSizeMenu;

            //------------------------------------------------------------------------------------------

            this.picBackgroundColorFooter.BackColor = UserPersonalizationOperaion.BackgroundColorFooter;

            this.picForColorFooter.BackColor = UserPersonalizationOperaion.ForColorFooter;

            this.numberUDFooter.Value = UserPersonalizationOperaion.FontSizeFooter;

            _userPersonalizationForColor.Clear();
            _userPersonalizationForFont.Clear();
        }

        private List<Atiran.Connections.AtiranAccModel.UserPersonalizationForColor> ColorForDatabase;
        private List<Atiran.Connections.AtiranAccModel.UserPersonalizationForFont> FontForDatabase;
        private string ImageAddres;

        private List<Atiran.Connections.AtiranAccModel.UserPersonalizationForColor> _userPersonalizationForColor = new List<UserPersonalizationForColor>();
        private List<Atiran.Connections.AtiranAccModel.UserPersonalizationForFont> _userPersonalizationForFont = new List<UserPersonalizationForFont>();
        private bool _isDefaulte = false;

        #region Panl Main Button TabBarMenu

        private PersianCalendar pc = new PersianCalendar();
        #region Event Controls

        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.DarkRed;
        }

        private void lblMaximis_Click(object sender, EventArgs e)
        {
            lblMaximis.Image = (lblMaximis.Image == Atiran.Settings.Properties.Resources.Maximis_1) ? Atiran.Settings.Properties.Resources.Maximis_2 : Atiran.Settings.Properties.Resources.Maximis_1;
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).BackColor = Color.DeepSkyBlue;
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = picBackgroundColorInItemTitre.BackColor; //Color.Wheat;
            ((Control)sender).Focus();
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Transparent;
        }


        private void miRestartApplication_MouseLeave(object sender, EventArgs e)
        {
            miRestartApplication.Image = Atiran.Settings.Properties.Resources.user;
        }

        private void miRestartApplication_MouseEnter(object sender, EventArgs e)
        {
            miRestartApplication.Image = Atiran.Settings.Properties.Resources.user_hover;
        }

        #endregion

        #endregion

        #region property

        private static PropertyToolStripProfessionalRenderer MenuTitre;
        private static PropertyToolStripProfessionalRenderer MenuMenu;
        private ToolStripProfessionalRendererAtiran renserMenuTitre;
        private ToolStripProfessionalRendererAtiran renserMenuMenu;

        #endregion

        #region Event

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime td = DateTime.Now;
            lblDateTime.Text = String.Format("{0}/{1}/{2}   {3}", pc.GetYear(td).ToString("0000"), pc.GetMonth(td).ToString("00"), pc.GetDayOfMonth(td).ToString("00"), td.ToString("HH:mm:ss"));
        }

        private void OpenColorDialog_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = ((PictureBox)sender).BackColor;
            
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ((PictureBox)sender).BackColor = colorDialog1.Color;
            }
        }

        private void btnChoise_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opfLoadFile = new OpenFileDialog();
                opfLoadFile.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);


                opfLoadFile.Title = "Please select an image file to Inputed.";
                opfLoadFile.Multiselect = false;

                opfLoadFile.Filter = "Image Files (*.jpeg; *.png; *.jpg)|*.jpeg; *.png; *.jpg";
                opfLoadFile.ShowDialog();
                if (opfLoadFile.SafeFileName != null && opfLoadFile.SafeFileName != "")
                {
                    string customPicturePath = opfLoadFile.FileName;
                    try
                    {
                        picBackground.Image = new Bitmap(opfLoadFile.FileName);
                        ImageAddres = opfLoadFile.FileName;
                        //picBackground.Tag = customPicturePath;
                        //if (picBackground.Image.Height > 800 || picBackground.Image.Width > 1200)
                        //{
                        //    picBackground.Image = null;
                        //    Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("خطا", Properties.Resources.AddImage_Error, "e");
                        //    Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام", Properties.Resources.AddImage_Resize, "i");
                        //    picBackground.Image = new Bitmap(opfLoadFile.FileName);
                        //    picBackground.Tag = customPicturePath;
                        //    picBackground.Image = new Bitmap(picBackground.Image, new Size(400, 400));
                        //}
                    }
                    catch
                    {
                        picBackground.Image = null;
                    }
                }
            }
            catch
            {
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("خطا", Properties.Resources.ErrorSelectImage, "e");
            }
        }

        private void rbtnUserChoise_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUserChoise.Checked)
            {
                btnChoise.Visible = true;
                try
                {
                    picBackground.Image = Bitmap.FromFile(ImageAddres);
                }
                catch (Exception)
                {
                    picBackground.Image = new Bitmap(1000,700);

                }
            }
            else
            {
                btnChoise.Visible = false;
            }
        }

        private void rbtnDefault_CheckedChanged(object sender, EventArgs e)
        {
            //loade Default image
            picBackground.Image = new Bitmap(1000,500);
        }


        #region MainButton

        private void picBackgroundColorOutTitre_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorOut, (int)Atiran.Connections.Enums.ControlNamesEnum.Titre, (pictureBox)sender);

            pnlMainButtons.BackColor = ((PictureBox)sender).BackColor;
            MenuTitre.ColorBackGroundHighlight = ((PictureBox)sender).BackColor;
            msUserActivs.Renderer = renserMenuTitre;
            msUserActivs.Refresh();
        }

        private void picBackgroundColorInItemTitre_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorIn, (int)Atiran.Connections.Enums.ControlNamesEnum.Titre, (pictureBox)sender);
            //داخل ايوند موس هندل شده
            MenuTitre.ColorSelectedHighlight = ((PictureBox)sender).BackColor;
            msUserActivs.Renderer = renserMenuTitre;
            msUserActivs.Refresh();

        }

        private void picColorFrontTitre_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.ForColorOut, (int)Atiran.Connections.Enums.ControlNamesEnum.Titre, (pictureBox)sender);
            //------------------------------
            lblDateTime.ForeColor = ((PictureBox)sender).BackColor;
            lblSalMali.ForeColor = ((PictureBox)sender).BackColor;
            btnLine.ForeColor = ((PictureBox)sender).BackColor;
            MenuTitre.ForColorInHighlight = ((PictureBox)sender).BackColor;
            MenuTitre.ForColorOutHighlight = ((PictureBox)sender).BackColor;
            msUserActivs.Renderer = renserMenuTitre;
            msUserActivs.Refresh();
        }


        #endregion

        #region Menu

        private void picBackgroundColorInMenu_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorIn, (int)Atiran.Connections.Enums.ControlNamesEnum.Menu, (pictureBox)sender);
            //---------------------
            MenuMenu.ColorSelectedHighlight = ((PictureBox)sender).BackColor;
            msMenu.Renderer = renserMenuMenu;
            msMenu.Refresh();
        }

        private void picBackgroundColorOutMenu_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorOut, (int)Atiran.Connections.Enums.ControlNamesEnum.Menu, (pictureBox)sender);
            //----------------

            MenuMenu.ColorBackGroundHighlight = ((PictureBox)sender).BackColor;
            msMenu.Renderer = renserMenuMenu;
            msMenu.BackColor = ((PictureBox)sender).BackColor;
            msMenu.Refresh();
        }

        private void picForColorInMenu_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.ForColorIn, (int)Atiran.Connections.Enums.ControlNamesEnum.Menu, (pictureBox)sender);
            //-----------------
            MenuMenu.ForColorInHighlight = ((PictureBox)sender).BackColor;
            msMenu.Renderer = renserMenuMenu;
            msMenu.Refresh();
        }

        private void picForColorOutMenu_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.ForColorOut, (int)Atiran.Connections.Enums.ControlNamesEnum.Menu, (pictureBox)sender);
            //-----------------
            MenuMenu.ForColorOutHighlight = ((PictureBox)sender).BackColor;
            msMenu.Renderer = renserMenuMenu;
            msMenu.Refresh();
        }

        private void numberUDMenu_ValueChanged(object sender, EventArgs e)
        {
            AddSizeFont((int)Atiran.Connections.Enums.ControlNamesEnum.Menu, (int)((UI.WindowsForms.Controls.NumericUpDown)sender).Value);
            //----------
            msMenu.Font = new Font("IRANSans(FaNum)", (int)((UI.WindowsForms.Controls.NumericUpDown)sender).Value);
            msMenu.Refresh();
        }

        #endregion

        #region Footer

        private void picBackgroundColorFooter_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorOut, (int)Atiran.Connections.Enums.ControlNamesEnum.Footer, (pictureBox)sender);
            //--------------
            lblFooter.BackColor = ((PictureBox)sender).BackColor;
        }

        private void picForColorFooter_BackColorChanged(object sender, EventArgs e)
        {
            AddColor((int)Atiran.Connections.Enums.ControlColorsEnum.ForColorOut, (int)Atiran.Connections.Enums.ControlNamesEnum.Footer, (pictureBox)sender);
            //--------------
            lblFooter.ForeColor = ((PictureBox)sender).BackColor;
        }

        private void numberUDFooter_ValueChanged(object sender, EventArgs e)
        {
            AddSizeFont((int)Atiran.Connections.Enums.ControlNamesEnum.Footer, (int)((UI.WindowsForms.Controls.NumericUpDown)sender).Value);
            //----------------
            lblFooter.Font = new Font("IRANSans(FaNum)", (int)((UI.WindowsForms.Controls.NumericUpDown)sender).Value);
        }

        #endregion

        private void cancelButton1_Click(object sender, EventArgs e)
        {
            Atiran.UI.WindowsForms.CloseFormService.CloseUserControll(this);
        }

        private void saveButton1_Click(object sender, EventArgs e)
        {
            if (UserPersonalizationOperaion.InsertIntoUserPersonalization(_userPersonalizationForColor,
                _userPersonalizationForFont, (rbtnDefault.Checked)?"":ImageAddres, _isDefaulte))
            {
                _userPersonalizationForColor.Clear();
                _userPersonalizationForFont.Clear();
                CustomMessageForm.CustomMessageBox.Show("پیغام", " ثبت با موفقیت انجام گرفت ");
                CustomMessageForm.CustomMessageBox.Show("پیغام", " براي اعمال تغييرات برنامه را بسته و مجدد اجرا كنيد. ");
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            SetDefultValues();
            _userPersonalizationForColor.Clear();
            _userPersonalizationForFont.Clear();
            _isDefaulte = true;
        }


        #endregion

        private void AddColor(int ControlColorID, int ControlNameID, PictureBox sender)
        {
            var PersonalizationForColor = new UserPersonalizationForColor()
            {
                ControlColorID = ControlColorID,
                ControlNameID = ControlNameID,
                UserID = GetCurrentSysUser.Instance.UserID,
                R = (int)sender.BackColor.R,
                G = (int)sender.BackColor.G,
                B = (int)sender.BackColor.B,
            };
            var result = _userPersonalizationForColor.FirstOrDefault(a =>
                a.ControlColorID == PersonalizationForColor.ControlColorID && a.ControlNameID == PersonalizationForColor.ControlNameID);
            if (result != null)
                _userPersonalizationForColor.Remove(result);

            _userPersonalizationForColor.Add(PersonalizationForColor);

            _isDefaulte = false;
        }
        private void AddSizeFont(int ControlNameID, int FontSize)
        {
            var PersonalizationForFont = new UserPersonalizationForFont()
            {
                ControlNameID = ControlNameID,
                UserID = GetCurrentSysUser.Instance.UserID,
                FontSize = FontSize
            };
            var result = _userPersonalizationForFont.FirstOrDefault(a => a.ControlNameID == PersonalizationForFont.ControlNameID);
            if (result != null)
                _userPersonalizationForFont.Remove(result);

            _userPersonalizationForFont.Add(PersonalizationForFont);

            _isDefaulte = false;

        }
        private void SetDefultValues()
        {
            rbtnDefault.Checked = true;


            this.picBackgroundColorInItemTitre.BackColor = System.Drawing.Color.Teal;
            this.picColorFrontTitre.BackColor = System.Drawing.Color.White;
            this.picBackgroundColorOutTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(100)))), ((int)(((byte)(123)))));


            this.picForColorOutMenu.BackColor = System.Drawing.Color.White;
            this.picForColorInMenu.BackColor = System.Drawing.Color.White;
            this.picBackgroundColorOutMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.picBackgroundColorInMenu.BackColor = System.Drawing.Color.Teal;
            this.numberUDMenu.Value = 11;


            this.picBackgroundColorFooter.BackColor = System.Drawing.Color.White;
            this.picForColorFooter.BackColor = System.Drawing.Color.Black;
            this.numberUDFooter.Value = 10;
        }

    }
}
