using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using Atiran.Connections.Operaions.MenuOp;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class EnviromentMainForm : Atiran.UI.WindowsForms.UIElements.Form, IDisposable
    {
        public Connections.Enums.Definitions.EnvironmentNames environment;
        public List<Connections.AtiranAccModel.Menu> menuData;
        public int SubSystemID { get; set; }
        public EnviromentMainForm()
        {
        }
        public EnviromentMainForm(Connections.Enums.Definitions.EnvironmentNames env_) : base()
        {
            environment = env_;
            slate.BackgroundImageLayout = ImageLayout.Stretch;
            switch (environment)
            {
                case Connections.Enums.Definitions.EnvironmentNames.Accounting:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Accounting") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Rahyab:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Rahyaab") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.SalesManagement:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Selling_Mng") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.KalaGostaran:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_KalaGostaran_Mng") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Warehouse:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Inventory") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Settings:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Settings") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Reporting:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Reports") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.EMS:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_EMS") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.BackupAndRestore:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Backup") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.SMS:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_SMS") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.BasicInformation:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_BasicInformation") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Treasury:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Treasury") as Bitmap;
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Sales:
                    slate.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Background_Selling") as Bitmap;
                    break;
            }

            menuData = new List<Connections.AtiranAccModel.Menu>();

            if (environment != Connections.Enums.Definitions.EnvironmentNames.Login)
            {
                slate.Top = 69;
                slate.SendToBack();
                slate.Width = this.Width;
                slate.Left = 0;
                slate.Height = this.Height - 69 - 25;
                slate.BackColor = Color.FromArgb(238, 238, 238);

                this.Controls.Add(slate);
                this.SizeChanged += EnviromentMainForm_SizeChanged;


            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
             if (keyData == (Keys.Alt | Keys.Home))
            {
                ((EnvironmentHeader)(this.header)).home.BackToHome();
                return true;
            }
            else if (keyData == Keys.Home)
            {
                ((Form)this).menuLuancherButton.ShowMenu();
                return true;
            }
            else if (keyData == Keys.Escape )
            {
                if (((UIElements.Form)this).menuLuancherButton.MenuIsShow)
                    ((UIElements.Form)this).menuLuancherButton.DisableMenu();
                this.ActiveControl = slate;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void EnviromentMainForm_SizeChanged(object sender, EventArgs e)
        {
            slate.Top = 69;
            slate.Width = this.Width;
            slate.Left = 0;
            slate.Height = this.Height - 69 - 25;
            InvisibleSubMenus();
        }
        public void LoadMenu()
        {
            switch (environment)
            {
                case Connections.Enums.Definitions.EnvironmentNames.Accounting:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 5).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Rahyab:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 6).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.SalesManagement:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 2).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.KalaGostaran:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 14).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Warehouse:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 4).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Settings:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 7).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Reporting:
                    {
                        menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 3).ToList();
                        AddMenuButtonsToMenu();
                        break;
                    }
                case Connections.Enums.Definitions.EnvironmentNames.EMS:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 10).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.BackupAndRestore:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 8).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.SMS:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 9).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.BasicInformation:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 11).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Treasury:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 12).ToList();
                    AddMenuButtonsToMenu();
                    break;
                case Connections.Enums.Definitions.EnvironmentNames.Sales:
                    menuData = MenuOperaion.ResultAllMenu.Where(m => m.SubSystemID == 1).ToList();
                    AddMenuButtonsToMenu();
                    break;
            }
        }
        public void AddMenuButtonsToMenu()
        {
            if (menuData != null && menuData.Count > 0)
            {
                List<Connections.AtiranAccModel.Menu> roots = menuData.Where(m => m.ParentMenuID == 0).OrderBy(i => i.order).ToList();
                roots.ForEach(m => new MenuButtonLevelOne(menuData, m, menu));
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EnviromentMainForm
            // 
            this.ClientSize = new System.Drawing.Size(1127, 628);
            this.Name = "EnviromentMainForm";
            this.ResumeLayout(false);
        }
    }
}
