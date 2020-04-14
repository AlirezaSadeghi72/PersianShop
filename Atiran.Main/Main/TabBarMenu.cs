using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Main.Properties;
using Atiran.UI.WindowsForms.UIElements;
using StatusBar = Atiran.UI.WindowsForms.UIElements.StatusBar;
using Atiran.CustomDocking.Docking.Desk;
using Atiran.CustomDocking.MessageBox;
using Form = Atiran.Connections.AtiranAccModel.Form;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions.UserPersonalizationOp;
using Atiran.Connections.Services;
using Atiran.CustomDocking.Docking;
using Atiran.UI.WindowsForms;
using Atiran.UI.WindowsForms.Controls;
//using ContextMenuStrip = Atiran.UI.WindowsForms.Controls.ContextMenuStrip;
using Label = Atiran.UI.WindowsForms.Controls.Label;
using MenuStrip = Atiran.UI.WindowsForms.Controls.MenuStrip;

namespace Atiran.Main
{
    public class TabBarMenu : Atiran.UI.WindowsForms.UIElements.Form, IDisposable
    {
        private List<Atiran.Connections.AtiranAccModel.Menu> menus = new List<Connections.AtiranAccModel.Menu>();
        private Label lblFooter;
        private List<Atiran.Connections.AtiranAccModel.SubSystem> subSystems =
            new List<Connections.AtiranAccModel.SubSystem>();
        // براي تم استفاده مي شود.
        private static PropertyToolStripProfessionalRenderer PropertyRendererTitre = new PropertyToolStripProfessionalRenderer()
        {
            ColorBackGroundHighlight = Color.FromArgb(21, 100, 123)
        };
        private static PropertyToolStripProfessionalRenderer PropertyRendererMenu = new PropertyToolStripProfessionalRenderer();
        private Atiran.UI.WindowsForms.Controls.ToolStripProfessionalRendererAtiran ToolStripProfessionalRendererTitre = new Atiran.UI.WindowsForms.Controls.ToolStripProfessionalRendererAtiran(ref PropertyRendererTitre);
        private Atiran.UI.WindowsForms.Controls.ToolStripProfessionalRendererAtiran ToolStripProfessionalRendererMenu = new Atiran.UI.WindowsForms.Controls.ToolStripProfessionalRendererAtiran(ref PropertyRendererMenu);
        private Color MenuColor = PropertyRendererMenu.ColorBackGroundHighlight;
        private Color TitreEnterItemColor;
        public TabBarMenu(string username)
        {
            InitializeComponent();

            Application.ApplicationExit += Application_ApplicationExit;
            this.FormClosing += TabBarMenu_FormClosing;

            this.menus = Atiran.Connections.Operaions.MenuOp.MenuOperaion.ResultAllMenuTabBar;
            this.subSystems = Atiran.Connections.Operaions.SubSystemOp.SubSystemOperaion.ResultAllSubSystemTabBar.OrderBy(o => o.ShowOrder).ToList();
            FirstTurn();
            this.KeyPreview = true;
            this.KeyDown += TabBarMenu_KeyDown;
        }

        private void TabBarMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TabBarMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Application_ApplicationExit(object sender, EventArgs e)
        {


        }
        //private void Next_Click(object sender, EventArgs e)
        //{
        //    ToolStripItem[] tsc = new ToolStripItem[MyMnSt.Items.Count];
        //    MyMnSt.Items.CopyTo(tsc, 0);
        //    MyMnSt.Items.Clear();
        //    for (int i = 0; i < tsc.Length; i++)
        //    {
        //        if (i == 0)
        //            MyMnSt.Items.Add(tsc[0]);
        //        else
        //        {
        //            if (i == 1)
        //                MyMnSt.Items.Add(tsc[tsc.Length - 1]);
        //            else
        //                MyMnSt.Items.Add(tsc[i - 1]);
        //        }
        //    }
        //}
        private void InitializeComponent()
        {
            this.mainDockPanel = new Atiran.CustomDocking.Docking.DockPanel();
            this.vS2017LightTheme1 = new Atiran.CustomDocking.Docking.Theme.ThemeVS2017.VS2017LightTheme();
            this.pnlFooter = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.lblFooter = new Atiran.UI.WindowsForms.Controls.Label();
            this.MyMnSt = new Atiran.UI.WindowsForms.Controls.MenuStrip();
            this.pnlMainButtons = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.lblseperator6 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblClose = new System.Windows.Forms.PictureBox();
            this.lblDateTime = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator5 = new Atiran.UI.WindowsForms.Controls.Label();
            this.btnMessenger = new Atiran.UI.WindowsForms.Controls.Label();
            this.btnShortcutDesk = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator3 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator4 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator2 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblseperator1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblMinimis = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblMaximis = new Atiran.UI.WindowsForms.Controls.Label();
            this.msUserActivs = new Atiran.UI.WindowsForms.Controls.MenuStrip();
            this.miRestartApplication = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.miUserActivs = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
            this.timerDateTime = new Atiran.UI.WindowsForms.Controls.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.mainDockPanel)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.pnlMainButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblClose)).BeginInit();
            this.msUserActivs.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainDockPanel
            // 
            this.mainDockPanel.AllowDrop = true;
            this.mainDockPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(242)))));
            this.mainDockPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainDockPanel.DockBackColor = System.Drawing.Color.Transparent;
            this.mainDockPanel.DockLeftPortion = 0.15D;
            this.mainDockPanel.DockRightPortion = 0.15D;
            this.mainDockPanel.Font = new System.Drawing.Font("IRANSans(FaNum)", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.mainDockPanel.Location = new System.Drawing.Point(0, 41);
            this.mainDockPanel.Name = "mainDockPanel";
            this.mainDockPanel.Padding = new System.Windows.Forms.Padding(6);
            this.mainDockPanel.RightToLeftLayout = true;
            this.mainDockPanel.ShowAutoHideContentOnHover = false;
            this.mainDockPanel.ShowDocumentIcon = true;
            this.mainDockPanel.Size = new System.Drawing.Size(1200, 567);
            this.mainDockPanel.TabIndex = 7;
            this.mainDockPanel.TabStop = true;
            this.mainDockPanel.Theme = this.vS2017LightTheme1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.lblFooter);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlFooter.Location = new System.Drawing.Point(0, 608);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1200, 20);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFooter.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F);
            this.lblFooter.Location = new System.Drawing.Point(0, 0);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(1200, 20);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "راهنماي نرم افزار : F1";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MyMnSt
            // 
            this.MyMnSt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.MyMnSt.Font = new System.Drawing.Font("IRANSans(FaNum)", 9F);
            this.MyMnSt.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.MyMnSt.Location = new System.Drawing.Point(0, 37);
            this.MyMnSt.Name = "MyMnSt";
            this.MyMnSt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MyMnSt.Size = new System.Drawing.Size(1200, 4);
            this.MyMnSt.TabIndex = 1;
            // 
            // pnlMainButtons
            // 
            this.pnlMainButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(100)))), ((int)(((byte)(123)))));
            this.pnlMainButtons.Controls.Add(this.lblseperator6);
            this.pnlMainButtons.Controls.Add(this.lblClose);
            this.pnlMainButtons.Controls.Add(this.lblDateTime);
            this.pnlMainButtons.Controls.Add(this.lblseperator5);
            this.pnlMainButtons.Controls.Add(this.btnMessenger);
            this.pnlMainButtons.Controls.Add(this.btnShortcutDesk);
            this.pnlMainButtons.Controls.Add(this.lblseperator3);
            this.pnlMainButtons.Controls.Add(this.lblseperator4);
            this.pnlMainButtons.Controls.Add(this.lblseperator2);
            this.pnlMainButtons.Controls.Add(this.lblseperator1);
            this.pnlMainButtons.Controls.Add(this.lblMinimis);
            this.pnlMainButtons.Controls.Add(this.lblMaximis);
            this.pnlMainButtons.Controls.Add(this.msUserActivs);
            this.pnlMainButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainButtons.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlMainButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlMainButtons.Name = "pnlMainButtons";
            this.pnlMainButtons.Size = new System.Drawing.Size(1200, 37);
            this.pnlMainButtons.TabIndex = 0;
            this.pnlMainButtons.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pnlMainButtons_MouseDoubleClick);
            this.pnlMainButtons.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlMainButtons_MouseDown);
            // 
            // lblseperator6
            // 
            this.lblseperator6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.lblseperator6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblseperator6.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblseperator6.Location = new System.Drawing.Point(1032, -1);
            this.lblseperator6.Name = "lblseperator6";
            this.lblseperator6.Size = new System.Drawing.Size(3, 38);
            this.lblseperator6.TabIndex = 26;
            this.lblseperator6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblseperator6.Visible = false;
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lblClose.Image = global::Atiran.Main.Properties.Resources.Exit_1;
            this.lblClose.Location = new System.Drawing.Point(1163, 1);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(34, 38);
            this.lblClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.lblClose.TabIndex = 25;
            this.lblClose.TabStop = false;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
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
            this.lblDateTime.MouseEnter += new System.EventHandler(this.lblDateTime_MouseEnter);
            // 
            // lblseperator5
            // 
            this.lblseperator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(81)))), ((int)(((byte)(100)))));
            this.lblseperator5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblseperator5.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblseperator5.Location = new System.Drawing.Point(876, -1);
            this.lblseperator5.Name = "lblseperator5";
            this.lblseperator5.Size = new System.Drawing.Size(3, 38);
            this.lblseperator5.TabIndex = 20;
            this.lblseperator5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblseperator5.Visible = false;
            // 
            // btnMessenger
            // 
            this.btnMessenger.BackColor = System.Drawing.Color.Transparent;
            this.btnMessenger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMessenger.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessenger.ForeColor = System.Drawing.Color.White;
            this.btnMessenger.Location = new System.Drawing.Point(881, -1);
            this.btnMessenger.Name = "btnMessenger";
            this.btnMessenger.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMessenger.Size = new System.Drawing.Size(150, 36);
            this.btnMessenger.TabIndex = 18;
            this.btnMessenger.Text = "پيام ها";
            this.btnMessenger.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMessenger.Visible = false;
            this.btnMessenger.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.btnMessenger.MouseLeave += new System.EventHandler(this.label_MouseLeave);
            // 
            // btnShortcutDesk
            // 
            this.btnShortcutDesk.BackColor = System.Drawing.Color.Transparent;
            this.btnShortcutDesk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShortcutDesk.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShortcutDesk.ForeColor = System.Drawing.Color.White;
            this.btnShortcutDesk.Location = new System.Drawing.Point(725, 0);
            this.btnShortcutDesk.Name = "btnShortcutDesk";
            this.btnShortcutDesk.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnShortcutDesk.Size = new System.Drawing.Size(150, 36);
            this.btnShortcutDesk.TabIndex = 19;
            this.btnShortcutDesk.Text = "ميزكار";
            this.btnShortcutDesk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnShortcutDesk.Visible = false;
            this.btnShortcutDesk.Click += new System.EventHandler(this.btnShortcutDesk_Click);
            this.btnShortcutDesk.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.btnShortcutDesk.MouseLeave += new System.EventHandler(this.label_MouseLeave);
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
            this.lblMinimis.Image = global::Atiran.Main.Properties.Resources.Minimis_1;
            this.lblMinimis.Location = new System.Drawing.Point(1099, 1);
            this.lblMinimis.Name = "lblMinimis";
            this.lblMinimis.Size = new System.Drawing.Size(32, 38);
            this.lblMinimis.TabIndex = 13;
            this.lblMinimis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMinimis.Click += new System.EventHandler(this.lblMinimis_Click);
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
            this.lblMaximis.Image = global::Atiran.Main.Properties.Resources.Maximis_2;
            this.lblMaximis.Location = new System.Drawing.Point(1131, 1);
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
            this.miRestartApplication.Image = global::Atiran.Main.Properties.Resources.user;
            this.miRestartApplication.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.miRestartApplication.Name = "miRestartApplication";
            this.miRestartApplication.Size = new System.Drawing.Size(42, 37);
            this.miRestartApplication.Text = " ";
            this.miRestartApplication.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.miRestartApplication.Click += new System.EventHandler(this.miRestartApplication_Click);
            this.miRestartApplication.MouseEnter += new System.EventHandler(this.miRestartApplication_MouseEnter);
            this.miRestartApplication.MouseLeave += new System.EventHandler(this.miRestartApplication_MouseLeave);
            // 
            // miUserActivs
            // 
            this.miUserActivs.AutoSize = false;
            this.miUserActivs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miUserActivs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.miUserActivs.ForeColor = System.Drawing.Color.White;
            this.miUserActivs.Name = "miUserActivs";
            this.miUserActivs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.miUserActivs.Size = new System.Drawing.Size(120, 37);
            this.miUserActivs.Text = "كاربر";
            this.miUserActivs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.miUserActivs.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // timerDateTime
            // 
            this.timerDateTime.Enabled = true;
            this.timerDateTime.Interval = 1000;
            this.timerDateTime.Tick += new System.EventHandler(this.timerDateTime_Tick);
            // 
            // TabBarMenu
            // 
            this.ClientSize = new System.Drawing.Size(1200, 628);
            this.Controls.Add(this.mainDockPanel);
            this.Controls.Add(this.MyMnSt);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlMainButtons);
            this.Font = new System.Drawing.Font("IRANSans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.IsMdiContainer = true;
            this.Name = "TabBarMenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MyMenuItem_Load);
            this.SizeChanged += new System.EventHandler(this.TabBarMenu_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.mainDockPanel)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlMainButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblClose)).EndInit();
            this.msUserActivs.ResumeLayout(false);
            this.msUserActivs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void MyMenuItem_Load(object sender, EventArgs e)
        {
            miUserActivs.Text = Connections.Operaions.UserOp.GetCurrentSysUser.Instance.UserName;

            //Elina 21/9/98
            loadSettingTheme();

        }
        private void loadSettingTheme()
        {
            if (UserPersonalizationOperaion.ImageBackgroundAddres == string.Empty || UserPersonalizationOperaion.ImageBackgroundAddres == null)
            {
                mainDockPanel.BackgroundImage = null;
            }
            else
            {
                try
                {
                    mainDockPanel.BackgroundImage = Bitmap.FromFile(UserPersonalizationOperaion.ImageBackgroundAddres);
                }
                catch (Exception)
                {
                    mainDockPanel.BackgroundImage = null;
                }
            }

            TitreEnterItemColor = UserPersonalizationOperaion.BackgroundColorInItemTitre;
            PropertyRendererTitre.ColorSelectedHighlight = UserPersonalizationOperaion.BackgroundColorInItemTitre;
            PropertyRendererTitre.ColorBackGroundHighlight = UserPersonalizationOperaion.BackgroundColorOutTitre;
            PropertyRendererTitre.ForColorInHighlight = UserPersonalizationOperaion.ColorFrontTitre;
            PropertyRendererTitre.ForColorOutHighlight = UserPersonalizationOperaion.ColorFrontTitre;
            msUserActivs.Renderer = ToolStripProfessionalRendererTitre;
            pnlMainButtons.BackColor = UserPersonalizationOperaion.BackgroundColorOutTitre;
            lblDateTime.ForeColor = UserPersonalizationOperaion.ColorFrontTitre;

            //------------------------------------------------------------------------------------------

            PropertyRendererMenu.ForColorInHighlight = UserPersonalizationOperaion.ForColorInMenu;
            PropertyRendererMenu.ForColorOutHighlight = UserPersonalizationOperaion.ForColorOutMenu;
            PropertyRendererMenu.ColorSelectedHighlight = UserPersonalizationOperaion.BackgroundColorInMenu;
            PropertyRendererMenu.ColorBackGroundHighlight = UserPersonalizationOperaion.BackgroundColorOutMenu;
            MyMnSt.Renderer = ToolStripProfessionalRendererMenu;
            MyMnSt.BackColor = UserPersonalizationOperaion.BackgroundColorOutMenu;
            MyMnSt.Font = new Font("IRANSans(FaNum)", UserPersonalizationOperaion.FontSizeMenu);

            //------------------------------------------------------------------------------------------

            lblFooter.BackColor = UserPersonalizationOperaion.BackgroundColorFooter;
            lblFooter.ForeColor = UserPersonalizationOperaion.ForColorFooter;
            lblFooter.Font = new Font("IRANSans(FaNum)", UserPersonalizationOperaion.FontSizeFooter);

            //------------------------------------------------------------------------------------------

            this.Refresh();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                case (Keys.Alt | Keys.F4):
                    {
                        CloseProgramm();
                        return true;
                    }
                case Keys.Home:
                    {
                        ((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)MyMnSt.Items[0]).ShowDropDown();
                        return true;
                    }
                case Keys.Scroll:
                    {
                        try
                        {
                            mainDockPanel.NextTabFocus();
                        }
                        catch (Exception)
                        {
                            break;
                        }

                        return true;
                    }
                #region Copy as Hub
                case ((Keys)Atiran.Connections.Enums.ShortcutKeyEnum.HelpKey):
                    {
                        Help H = new Help();
                        UserControlLoader u = new UserControlLoader(H, true, false, true,false);
                        return true;
                    }
                case (Keys)Atiran.Connections.Enums.ShortcutKeyEnum.SearchFormsKey:
                    {
                        try
                        {
                            List<Atiran.Connections.AtiranAccModel.Menu> menu =
                                new List<Connections.AtiranAccModel.Menu>();
                            UI.WindowsForms.Shortcuts.AtiranSpotlight spotlight =
                                new UI.WindowsForms.Shortcuts.AtiranSpotlight(menu);
                            new UserControlLoader(spotlight, true, false, true);
                            if (menu.Count > 0)
                            {
                                var result = menus.FirstOrDefault(f => f.FormID == menu[0].FormID);
                                AddTab(result.Titel, result.Form.NameSpace, result.Form.Class, result.SubSystemID ?? 0,
                                    result.FormID ?? 0);
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        return true;
                    }
                //case (Keys.Alt | Keys.F7):
                //    {
                //        try
                //        {
                //            RefreshShortcutItemMenu();
                //            ShortcutTab.Show(mainDockPanel);

                //            MyMnSt.Items.Cast<Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran>()
                //                .FirstOrDefault(f => f.Name == "ShortCutItemMenu")?.ShowDropDown();

                //            return true;
                //        }
                //        catch (Exception ex)
                //        {
                //            MessageBox.Show(ex.ToString());
                //        }

                //        return true;
                //    }
                case (Keys)Atiran.Connections.Enums.ShortcutKeyEnum.ActivatedFormKey:
                    {
                        try
                        {
                            mainDockPanel.ActiveDocumentPane?.TabStripControl.StripMenuShowDropDown();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        return true;
                    }

               #endregion
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private bool AccessStatus(int SubsytemID)
        {
            if (subSystems.Any(f => f.SubSystemId == SubsytemID))
                return true;
            return false;
        }
        #region Panl Main Button
        private UI.WindowsForms.UIElements.Panel pnlMainButtons;
        private Label lblseperator6;
        private Label lblseperator5;
        private Label lblseperator4;
        private Label lblseperator3;
        private Label lblseperator2;
        private Label lblseperator1;
        private PictureBox lblClose;
        private Label lblMaximis;
        private Label lblMinimis;
        private Label btnMessenger;
        private Label btnShortcutDesk;
        private Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran miRestartApplication;
        private MenuStrip msUserActivs;
        private Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran miUserActivs;
        private Label lblDateTime;

        #region private

        private List<Atiran.Connections.AtiranAccModel.Menu> menu;
        private List<System.Windows.Forms.Form> deskTabs;
        private bool isCanselCLoseAll = false;
        private UI.WindowsForms.Controls.Timer timerDateTime;
        private bool isCLoseAll = false;
        private PersianCalendar pc = new PersianCalendar();

        #endregion

        #region Event Controls

        private void pnlMainButtons_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            CloseProgramm();
        }

        private void lblClose_MouseDown(object sender, MouseEventArgs e)
        {
            lblClose.BackColor = Color.DarkRed;
        }

        private void lblMaximis_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                lblMaximis.Image = Resources.Maximis_2;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                lblMaximis.Image = Resources.Maximis_1;
            }
        }

        private void lblMinimis_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            ((Label)sender).BackColor = Color.DeepSkyBlue;
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = TitreEnterItemColor;//Color.Teal; //Color.Wheat;
            ((Control)sender).Focus();
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Transparent;
            //((Control)sender).ForeColor = Color.White;
        }

        private void btnShortcutDesk_Click(object sender, EventArgs e)
        {
            //RefreshShortcutItemMenu();
            //ShortcutTab.Show(mainDockPanel);
        }

        private void miRestartApplication_MouseLeave(object sender, EventArgs e)
        {
            miRestartApplication.Image = Resources.user;
        }

        private void miRestartApplication_MouseEnter(object sender, EventArgs e)
        {
            miRestartApplication.Image = Resources.user_hover;
        }

        private void miRestartApplication_Click(object sender, EventArgs e)
        {
            CloseProgramm(true);
        }

        private void timerDateTime_Tick(object sender, EventArgs e)
        {
            DateTime td = DateTime.Now;
            lblDateTime.Text = String.Format("{0}/{1}/{2}   {3}", pc.GetYear(td).ToString("0000"), pc.GetMonth(td).ToString("00"), pc.GetDayOfMonth(td).ToString("00"), td.ToString("HH:mm:ss"));
        }
        #endregion

        #region Method

        private void TryCloseTab(Atiran.CustomDocking.Docking.Desk.DeskTab form, System.Windows.Forms.Form[] forms)
        {
            if (form.Kind == 1)
            {
                if (!isCLoseAll)
                {
                    string TextTabs = form.Text;
                    foreach (System.Windows.Forms.Form tab in forms)
                    {
                        TextTabs += "\n" + tab.Text;
                    }
                    var result = ShowPersianMessageBox.ShowMessge("آيا تب ها بسته شوند؟", TextTabs,
                        MessageBoxButtons.YesNo, false);
                    if (result == DialogResult.Yes)
                    {
                        form.Close();
                    }
                    else if (result == DialogResult.OK)
                    {
                        isCLoseAll = true;
                        form.Close();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        isCanselCLoseAll = true;
                    }
                }
                else
                {
                    form.Close();
                }
            }
            else
            {
                form.Close();
            }

            deskTabs.Remove(form);

        }
        
        #endregion

        #region moving form by mouse down in pnlMainButtons

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void pnlMainButtons_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x00A1, 0x2, 0);
            }
        }

        #endregion

        #endregion
        #region Main
        private MenuStrip MyMnSt;
        private CustomDocking.Docking.DockPanel mainDockPanel;
        private CustomDocking.Docking.Theme.ThemeVS2017.VS2017LightTheme vS2017LightTheme1;

        private System.Collections.Generic.List<string> AskedList = new System.Collections.Generic.List<string>
        {
            "Invoice", "FactorKharid", "Daryaft", "Pardakht", "ShopFactor", "PishFactorForosh", "PishFactorKharid"
        };

        private Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran ShorCutToolStripMenuItem;


        #region Event Controls

        private void MakeYellow(object sender, EventArgs e)
        {
            ((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)sender).Image = Properties.Resources.Yellow;
        }

        private void MakeBack(object sender, EventArgs e)
        {
            ((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)sender).Image = Properties.Resources.LemonChiffon;
        }

        private void ItemMenuStrip_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            var DropDownItems = ((ToolStripDropDownMenu)sender).Items.Cast<Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran>().ToList();
            if (DropDownItems.Any(a => a.Selected && a.DropDown.Items.Count == 0) && e.KeyCode == Keys.Left)
            {
                var RootItems = MyMnSt.Items.Cast<Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran>().ToList();
                var RootPressItem = RootItems
                    .Where(t => t.Pressed && t.DropDown.Visible).ToList();
                if (RootPressItem.Count() > 0)
                {
                    var index = RootItems.IndexOf(RootPressItem[0]);

                    if (RootItems[(index + 1) % RootItems.Count].DropDownItems.Count > 0)
                    {
                        RootItems[(index + 1) % RootItems.Count].DropDown.Show();
                        RootItems[(index + 1) % RootItems.Count].DropDown.Focus();
                    }
                    else
                    {
                        var index1 = MyMnSt.Items.Cast<Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran>().ToList()
                            .IndexOf(RootItems[(index + 1) % RootItems.Count]);
                        MyMnSt.Focus();
                        MyMnSt.Items[index1].Select();
                    }

                }
            }
        }

        private void Form_Click(object sender, EventArgs e)
        {
            var ItemTag = ((Atiran.Connections.Services.MyTag)((ToolStripItem)sender).Tag);
            AddTab(((ToolStripItem)sender).Text, ItemTag.NameSpase, ItemTag.Class, ItemTag.SubSysteID, ItemTag.FormId);

        }

        #endregion

        #region Metohod
        private void FirstTurn()
        {
            //ToolStripItem next = MyMnSt.Items.Add(Properties.Resources.next);
            //next.Click += Next_Click;
            Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran tmp = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran()
            {
                Tag = new Atiran.Connections.Services.MyTag() { MenuId = 0, FormId = 0, ParentId = -2 }
            };
            CreateMenus(tmp);
        }

        public void CreateMenus(Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran TStrip)
        {
            MyTag tag = ((MyTag)TStrip.Tag);
            Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran tmp;
            if (tag.ParentId == -2)
            {
                foreach (SubSystem sub in subSystems)
                {
                    tmp = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
                    {
                        tmp.Text = sub.Name;
                        tmp.Tag = new MyTag()
                        { MenuId = sub.SubSystemId, FormId = 0, ParentId = -1 };
                        tmp.ForeColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.BackColor = MenuColor;
                        tmp.Image = GetImageEnviroment(sub.SubSystemId);
                        tmp.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                        tmp.TextImageRelation = TextImageRelation.ImageBeforeText;
                        tmp.Height = MyMnSt.Height;
                    }

                    MyMnSt.Items.Add(tmp);
                    CreateMenus(tmp);
                }
            }
            else
            {
                IEnumerable<Atiran.Connections.AtiranAccModel.Menu> items;
                if (tag.ParentId == -1)
                    items = menus.Where(a => (a.ParentMenuID ?? 0) == 0 && (a.SubSystemID == tag.MenuId)).OrderBy(s => s.MenuID).OrderBy(s => s.order);
                else
                    items = menus.Where(a => (a.ParentMenuID ?? 0) == tag.MenuId).OrderBy(s => s.MenuID).OrderBy(s => s.order);
                foreach (var item in items)
                {
                    tmp = new Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran();
                    {
                        tmp.Name = item.FormID != null ? item.Form.Class : "";
                        tmp.Text = item.Titel;
                        tmp.TextAlign = ContentAlignment.BottomLeft;
                        tmp.Tag = new MyTag()
                        { MenuId = item.MenuID, SubSysteID = item.SubSystemID ?? 0, FormId = item.FormID ?? 0, ParentId = item.ParentMenuID ?? 0, NameSpase = item.FormID != null ? item.Form.NameSpace : null, Class = item.FormID != null ? item.Form.Class : null };
                        tmp.ForeColor = System.Drawing.SystemColors.ButtonFace;
                        tmp.BackColor = System.Drawing.Color.FromArgb(40, 130, 150);
                        tmp.Image = Properties.Resources.LemonChiffon;
                        tmp.ImageAlign = ContentAlignment.MiddleCenter;
                        tmp.ImageScaling = ToolStripItemImageScaling.None;
                        tmp.Height = MyMnSt.Height;
                        tmp.ShortcutKeyDisplayString = item.Shortcut;
                    }
                    ((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)TStrip).DropDownItems.Add(tmp);
                    if ((item.FormID ?? 0) > 0)
                        tmp.Click += Form_Click;
                    CreateMenus(tmp);
                }

                if (((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)TStrip).DropDownItems.Count > 0)
                {
                    if (tag.ParentId != -1)
                    {
                        ((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)TStrip).Image = null;
                        ((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)TStrip).DropDown.PreviewKeyDown += ItemMenuStrip_PreviewKeyDown;
                    }
                }
                else if (tag.ParentId != -1)
                {
                    ((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)TStrip).MouseEnter += MakeYellow;
                    ((Atiran.UI.WindowsForms.Controls.ToolStripMenuItemAtiran)TStrip).MouseLeave += MakeBack;
                }
            }
        }

        private System.Drawing.Bitmap GetImageEnviroment(int subsystemId)
        {
            switch (subsystemId)
            {
                case 1:
                    return Resources.Selling_Tiny;
                case 2:
                    return Resources.Selling_Management_Tiny;
                case 3:
                    return Resources.Reports_Tiny;
                case 4:
                    return Resources.Anbaar_Tiny;
                case 5:
                    return Resources.Hesabdari_Tiny;
                case 6:
                    return Resources.Rahyaab_Tiny;
                case 7:
                    return Resources.Settings_Tiny;
                case 8:
                    return Resources.Backup_Tiny;
                case 9:
                    return Resources.SMS_Tiny;
                case 10:
                    return Resources.EMS_Tiny;
                case 11:
                    return Resources.Basic_Information_Tiny;
                case 12:
                    return Resources.Treasury_Tiny;
                default:
                    return new Bitmap(8, 8);

            }
        }
        private void AddTab(string text, string NameSpase, string ClassName, int subSystemID, int FormID)
        {
                if (AccessStatus(subSystemID) && Connections.Operaions.UserFormPermissionOp.FormPermission.AccessUserForm(FormID))
                {
                    var control = (Control)GetObjectFromString(NameSpase + "." + ClassName);
                    control.Dock = DockStyle.Fill;

                    Atiran.CustomDocking.Docking.Desk.DeskTab tab = new Atiran.CustomDocking.Docking.Desk.DeskTab();
                    tab.Text = text;
                    tab.TextName = text;
                    tab.Icon = Icon.FromHandle(GetImageEnviroment(subSystemID).GetHicon());
                    tab.Controls.Add(control);
                    tab.Kind = (AskedList.Contains(ClassName)) ? 1 : 0;
                    tab.Show(mainDockPanel);
                }
                else
                {
                    UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام", "شما به اين فرم دسترسي نداريد", "i");
                }
        }

        private object GetObjectFromString(string str)
        {
            return AppDomain.CurrentDomain.GetAssemblies().Select(a => a.CreateInstance(str)).FirstOrDefault(f => f != null) ?? new Control();

            //var arrStr = str.Split('.');
            //var ali = arrStr[0] + "." + arrStr[1];
            //ali = (ali == "Atiran.UI") ? "Atiran.UI.WindowsForms" : ali;
            //Assembly assembly = Assembly.GetAssembly(GetType());

            //Assembly assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.CreateInstance(str) != null);
            //if (assembly != null)
            //{
            //    return assembly.CreateInstance(str);
            //}
            //return new Control();
        }

        private void CloseProgramm(bool IsRestart = false)
        {
            UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 0;
            DialogResult close =
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم",
                    "آيا مي خواهيد از سيستم خارج شويد؟", "w");
            UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 1;
            if (close == DialogResult.Yes)
            {
                //try Close all tabs
                deskTabs = ((System.Windows.Forms.Form)TopLevelControl).MdiChildren.ToList();

                foreach (DeskTab form in this.MdiChildren)
                {
                    if (!isCanselCLoseAll)
                        TryCloseTab(form, deskTabs.Where(f => f != form).ToArray());
                }

                isCLoseAll = false;
                isCanselCLoseAll = false;

                if (this.MdiChildren.Length < 1)
                {

                    if (Connections.Operaions.UserFormPermissionOp.FormPermission.CheckBackupPermission())
                    {
                        DialogResult res =
                            Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم",
                                "آيا مي خواهيد از اطلاعات پشتيبان بگيريد؟", "w");
                        if (res == DialogResult.Yes)
                        {
                            // backup
                            UI.WindowsForms.Controls.FastBackup c = new UI.WindowsForms.Controls.FastBackup();
                            new UI.WindowsForms.UserControlLoader(c);
                        }
                    }

                    if (IsRestart)
                    {
                        Application.Restart();
                    }

                    Application.Exit();
                }
            }
        }


        #endregion

        #endregion
        #region Footer
        private UI.WindowsForms.UIElements.Panel pnlFooter;

        #endregion
        private void lblDateTime_MouseEnter(object sender, EventArgs e)
        {
            loadSettingTheme();
        }
        //Fixes when there was a problem loading the form
        private void TabBarMenu_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString().ToLower().Contains("windows 10"))
                {
                    Invalidate();
                    //Atiran.Connections.FixScreenLag.WinApi.SetWinFullScreen(this.Handle);
                    //this.FormBorderStyle = FormBorderStyle.None;
                    pnlMainButtons.Refresh();
                    Refresh();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
