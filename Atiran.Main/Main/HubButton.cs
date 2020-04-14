using Atiran.Connections.Enums;
using Atiran.UI.WindowsForms;
using Atiran.UI.WindowsForms.UIBuilder;
using Atiran.UI.WindowsForms.UIElements;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.Main.Main
{
    public class HubButton : System.Windows.Forms.TableLayoutPanel, IDisposable
    {
        PictureBox Icon;
        //   public Label Title;
        public UI.WindowsForms.Controls.RichTextBox Title;
        Hub parent;
        public int SubSystemID { get; set; }
        Definitions.EnvironmentNames env;
        public HubButton(Definitions.EnvironmentNames env_, Hub hub)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                env = env_;
                Padding = System.Windows.Forms.Padding.Empty;
                parent = hub;

                this.ColumnCount = 1;
                this.RowCount = 2;

                Icon = new PictureBox();
                Icon.Anchor = AnchorStyles.None;
                Title = new UI.WindowsForms.Controls.RichTextBox();
                Title.BorderStyle = BorderStyle.None;
                Title.ForeColor = Color.Black;
                Title.BackColor = Color.White;
                Title.RightToLeft = RightToLeft.Yes;
                Title.SelectionAlignment = HorizontalAlignment.Center;
                Title.Dock = DockStyle.Fill;
                Title.ReadOnly = true;
                Title.MouseDown += Title_MouseDown;
                Title.Enter += Title_Enter;
                int _ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                int _ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
                if (_ScreenWidth <= 1280 & _ScreenHeight <= 768)
                {
                    this.Width = 110;
                    this.Height = 130;//150;
                    this.Margin = new Padding(50, 5, 0, 0);
                    Title.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 9, FontStyle.Regular);
                }
                else
                {
                    this.Width = 120;
                    this.Height = 140;//150;
                    this.Margin = new Padding(50, 10, 0, 0);
                    Title.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 11, FontStyle.Regular);
                }
                Icon.MouseEnter += Icon_MouseEnter;
                Title.MouseEnter += Icon_MouseEnter;
                Icon.MouseLeave += Icon_MouseLeave;
                Title.MouseLeave += Icon_MouseLeave;
                switch (env)
                {
                    case Definitions.EnvironmentNames.Sales:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Selling") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("Selling") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemSalesText");
                                Icon.Click += PnlHubItemSales_Click;
                                Title.Click += PnlHubItemSales_Click;
                                SubSystemID = 1;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeSelling") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeSelling") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemSalesText");
                                Icon.Click += PnlHubItemSales_Click;
                                Title.Click += PnlHubItemSales_Click;
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.SalesManagement:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Selling_Management") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("Selling_Management") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemSalesManagementText");
                                Icon.Click += PnlHubItemSalesManagement_Click;
                                Title.Click += PnlHubItemSalesManagement_Click;
                                SubSystemID = 2;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeSelling_Management") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeSelling_Management") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemSalesManagementText");
                                Icon.Click += PnlHubItemSalesManagement_Click;
                                Title.Click += PnlHubItemSalesManagement_Click;
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.KalaGostaran:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("KalaGostaranPic") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("KalaGostaranPic") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemKalaGostaranText");
                                Icon.Click += PnlHubItemKalaGostaran_Click;
                                Title.Click += PnlHubItemKalaGostaran_Click;
                                SubSystemID = 14;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeKalaGostaranPic") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeKalaGostaranPic") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemKalaGostaranText");
                                Icon.Click += PnlHubItemKalaGostaran_Click;
                                Title.Click += PnlHubItemKalaGostaran_Click;
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.Reporting:
                        Icon.Image = ResourceManager.GetResourceManager().GetObject("Reports") as Image;
                        Icon.Height = (ResourceManager.GetResourceManager().GetObject("Reports") as Image).Height;
                        Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemReportingText");
                        Icon.Click += PnlHubItemReporting_Click;
                        Title.Click += PnlHubItemReporting_Click;
                        SubSystemID = 3;
                        break;
                    case Definitions.EnvironmentNames.Warehouse:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Anbaar") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("Anbaar") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemWarehouseText");
                                Icon.Click += PnlHubItemWarehouse_Click;
                                Title.Click += PnlHubItemWarehouse_Click;
                                SubSystemID = 4;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeAnbaar") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeAnbaar") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemWarehouseText");
                                Icon.Click += PnlHubItemWarehouse_Click;
                                Title.Click += PnlHubItemWarehouse_Click;
                            }
                            break;
                        }

                    case Definitions.EnvironmentNames.Accounting:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Hesabdari") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("Hesabdari") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemAccountingText");
                                Icon.Click += PnlHubItemAccounting_Click;
                                Title.Click += PnlHubItemAccounting_Click;
                                SubSystemID = 5;
                            }
                            else
                            {
                                List<Atiran.Connections.AtiranAccModel.UserFormPermission> ListPermission = context.UserFormPermissions.SqlQuery("select * from security.UserFormPermission where FormId  in (select FormID from security.Menu where SubSystemID = 5 and ParentMenuID != 3 and FormID is not null)").ToList();
                                context.UserFormPermissions.RemoveRange(ListPermission);
                                context.SaveChanges();
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Hesabdari") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("Hesabdari") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemAccountingText");
                                Icon.Click += PnlHubItemAccounting_Click;
                                Title.Click += PnlHubItemAccounting_Click;

                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.Rahyab:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Rahyaab") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("Rahyaab") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemRahyabText");
                                Icon.Click += PnlHubItemRahyab_Click;
                                Title.Click += PnlHubItemRahyab_Click;
                                SubSystemID = 6;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeRahyaab") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeRahyaab") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemRahyabText");
                                Icon.Click += PnlHubItemRahyab_Click;
                                Title.Click += PnlHubItemRahyab_Click;
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.EMS:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("EMS") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("EMS") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemEMSText");
                                Icon.Click += PnlHubItemEMS_Click;
                                Title.Click += PnlHubItemEMS_Click;
                                SubSystemID = 10;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeEMS") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeEMS") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemEMSText");
                                Icon.Click += PnlHubItemEMS_Click;
                                Title.Click += PnlHubItemEMS_Click;
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.BackupAndRestore:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Backup") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("Backup") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemBackupAndRestoreText");
                                Icon.Click += PnlHubItemBackupAndRestore_Click;
                                Title.Click += PnlHubItemBackupAndRestore_Click;
                                SubSystemID = 8;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeBackup") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeBackup") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemBackupAndRestoreText");
                                Icon.Click += PnlHubItemBackupAndRestore_Click;
                                Title.Click += PnlHubItemBackupAndRestore_Click;
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.Settings:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Settings") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("Settings") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemSettingsText");
                                Icon.Click += PnlHubItemSettings_Click;
                                Title.Click += PnlHubItemSettings_Click;
                                SubSystemID = 7;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeSettings") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeSettings") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemSettingsText");
                                Icon.Click += PnlHubItemSettings_Click;
                                Title.Click += PnlHubItemSettings_Click;
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.SMS:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("SMS") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("SMS") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblSMSMANAGMENT");
                                Icon.Click += PnlHubItemSMS_Click;
                                Title.Click += PnlHubItemSMS_Click;
                                SubSystemID = 9;
                            }
                            else
                            {
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("DeSMS") as Image;
                                Icon.Height = (ResourceManager.GetResourceManager().GetObject("DeSMS") as Image).Height;
                                Title.Text = ResourceManager.GetResourceManager().GetString("HublblSMSMANAGMENT");
                                Icon.Click += PnlHubItemSMS_Click;
                                Title.Click += PnlHubItemSMS_Click;
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.BasicInformation:
                        {
                            Icon.Image = ResourceManager.GetResourceManager().GetObject("Basic_Information") as Image;
                            Icon.Height = (ResourceManager.GetResourceManager().GetObject("Basic_Information") as Image).Height;
                            Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemBasicInformationText");
                            Icon.Click += PnlHubItemBasicInformation_Click;
                            Title.Click += PnlHubItemBasicInformation_Click;
                            SubSystemID = 11;
                            break;
                        }
                    case Definitions.EnvironmentNames.Treasury:
                        {
                            Icon.Image = ResourceManager.GetResourceManager().GetObject("Treasury") as Image;
                            Icon.Height = (ResourceManager.GetResourceManager().GetObject("Treasury") as Image).Height;
                            Title.Text = ResourceManager.GetResourceManager().GetString("HublblHubItemTreasuryText");
                            Icon.Click += PnlHubItemTreasury_Click;
                            Title.Click += PnlHubItemTreasury_Click;
                            SubSystemID = 12;
                            break;
                        }

                }
                this.Controls.Add(Icon, 0, 0);
                this.Controls.Add(Title, 0, 1);
            }
        }
        private void Title_Enter(object sender, EventArgs e)
        {
            Icon.Focus();
        }
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            Icon.Focus();
        }
        private void Icon_MouseLeave(object sender, EventArgs e)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                switch (env)
                {
                    case Definitions.EnvironmentNames.Accounting:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Hesabdari") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Sales:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Selling") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.SalesManagement:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Selling_Management") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.KalaGostaran:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("KalaGostaranPic") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Reporting:
                        Icon.Image = ResourceManager.GetResourceManager().GetObject("Reports") as Image;
                        break;
                    case Definitions.EnvironmentNames.Warehouse:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Anbaar") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Rahyab:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Rahyaab") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.EMS:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("EMS") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.BackupAndRestore:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Backup") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Settings:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Settings") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.SMS:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("SMS") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.BasicInformation:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Basic_Information") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Treasury:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Treasury") as Image;
                            break;
                        }
                }
            }
        }
        private bool AccessStatus(int SubsytemID)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                Connections.AtiranAccModel.SubSystemPermission instance = context.SubSystemPermissions.Where(i => i.UserID == Connections.Operaions.UserOp.GetCurrentSysUser.Instance.UserID && i.SubSystemID == SubsytemID).FirstOrDefault();
                if (instance != null)
                    return true;
                return false;
            }
        }
        private void Icon_MouseEnter(object sender, EventArgs e)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                switch (env)
                {
                    case Definitions.EnvironmentNames.Accounting:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Hesabdari_H") as Image;
                            //parent.statusBar.Message = "حسابداری";
                            break;
                        }
                    case Definitions.EnvironmentNames.Sales:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Selling_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.SalesManagement:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Selling_Management_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.KalaGostaran:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("KalaGostaranPic_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Reporting:
                        Icon.Image = ResourceManager.GetResourceManager().GetObject("Reports_H") as Image;
                        break;
                    case Definitions.EnvironmentNames.Warehouse:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Anbaar_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Rahyab:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Rahyaab_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.EMS:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("EMS_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.BackupAndRestore:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Backup_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Settings:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Settings_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.SMS:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("SMS_H") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.BasicInformation:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Basic_InformationH") as Image;
                            break;
                        }
                    case Definitions.EnvironmentNames.Treasury:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                                Icon.Image = ResourceManager.GetResourceManager().GetObject("Treasury_H") as Image;
                            break;
                        }
                }
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        public void RunModule(Definitions.EnvironmentNames module, Connections.AtiranAccModel.Menu uc = null, bool callFromShortCut = false, Guid TabGUID = default(Guid))
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                if (module == Definitions.EnvironmentNames.SalesManagement || module == Definitions.EnvironmentNames.KalaGostaran || module == Definitions.EnvironmentNames.Sales || module == Definitions.EnvironmentNames.Accounting || module == Definitions.EnvironmentNames.Rahyab || module == Definitions.EnvironmentNames.Treasury)
                {
                    if (true)
                    {

                    }
                }
                switch (module)
                {
                    case Definitions.EnvironmentNames.BasicInformation:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.SalesManagement:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.KalaGostaran:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.Sales:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.Reporting:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.Accounting:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.Rahyab:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.EMS:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.SMS:
                        {

                            break;
                        }
                    case Definitions.EnvironmentNames.Settings:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                if (AccessStatus(7))
                                {
                                    if (!parent.environments.Contains(Definitions.EnvironmentNames.Settings))
                                    {
                                        Settings.Default defaultForm = new Settings.Default(Definitions.EnvironmentNames.Settings)
                                        {
                                            SubSystemID = 7,
                                            Text = ResourceManager.GetResourceManager().GetString("HublblHubItemSettingsText"),
                                            Icon = (ResourceManager.GetResourceManager().GetObject("Settings_tiny_icon") as Icon)
                                        };
                                        defaultForm.FormClosing += DefaultForm_FormClosing;
                                        defaultForm.SizeChanged += new EventHandler(DefaultForm_SizeChanged);
                                        EnvironmentGenerator.Generate(Definitions.EnvironmentNames.Settings, defaultForm);
                                        parent.environments.Add(Definitions.EnvironmentNames.Settings, defaultForm);
                                        if (callFromShortCut)
                                            defaultForm.AddForm(uc);
                                        defaultForm.Show();
                                    }
                                    else
                                    {
                                        if (callFromShortCut)
                                            ((Atiran.Settings.Default)parent.environments[Definitions.EnvironmentNames.Settings]).AddForm(uc);
                                        ((EnviromentMainForm)parent.environments[Definitions.EnvironmentNames.Settings]).WindowState = System.Windows.Forms.FormWindowState.Maximized;
                                        ((EnviromentMainForm)parent.environments[Definitions.EnvironmentNames.Settings]).Focus();
                                        if (TabGUID != default(Guid))
                                        {
                                            ((Atiran.Settings.Default)parent.environments[Definitions.EnvironmentNames.Settings]).FocuseOnTab(TabGUID);
                                        }
                                        try
                                        {
                                            if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString().ToLower().Contains("windows 10"))
                                            {
                                                this.Refresh();
                                                ((EnviromentMainForm)parent.environments[Definitions.EnvironmentNames.Settings]).Refresh();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                }
                                else
                                {
                                    UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم", "شما مجوز دسترسي به اين زيرسيستم را نداريد");
                                }
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.BackupAndRestore:
                        {
                            if (!Connections.AtiranAccModel.ConnectionInfo.OldSac)
                            {
                                if (AccessStatus(8))
                                {
                                    if (!parent.environments.Contains(Definitions.EnvironmentNames.BackupAndRestore))
                                    {
                                        BackupAndRestore.Default defaultForm = new BackupAndRestore.Default(Definitions.EnvironmentNames.BackupAndRestore)
                                        {
                                            SubSystemID = 8,
                                            Text = ResourceManager.GetResourceManager().GetString("HublblHubItemBackupAndRestoreText"),
                                            Icon = (ResourceManager.GetResourceManager().GetObject("Backup_tiny_icon") as Icon)
                                        };
                                        defaultForm.FormClosing += DefaultForm_FormClosing;
                                        defaultForm.SizeChanged += new EventHandler(DefaultForm_SizeChanged);
                                        EnvironmentGenerator.Generate(Definitions.EnvironmentNames.BackupAndRestore, defaultForm);
                                        parent.environments.Add(Definitions.EnvironmentNames.BackupAndRestore, defaultForm);
                                        if (callFromShortCut)
                                            defaultForm.AddForm(uc);
                                        defaultForm.Show();
                                    }
                                    else
                                    {
                                        if (callFromShortCut)
                                            ((Atiran.BackupAndRestore.Default)parent.environments[Definitions.EnvironmentNames.BackupAndRestore]).AddForm(uc);
                                        ((EnviromentMainForm)parent.environments[Definitions.EnvironmentNames.BackupAndRestore]).WindowState = System.Windows.Forms.FormWindowState.Maximized;
                                        ((EnviromentMainForm)parent.environments[Definitions.EnvironmentNames.BackupAndRestore]).Focus();
                                        if (TabGUID != default(Guid))
                                        {
                                            ((Atiran.BackupAndRestore.Default)parent.environments[Definitions.EnvironmentNames.BackupAndRestore]).FocuseOnTab(TabGUID);
                                        }
                                        try
                                        {
                                            if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString().ToLower().Contains("windows 10"))
                                            {
                                                this.Refresh();
                                                ((EnviromentMainForm)parent.environments[Definitions.EnvironmentNames.BackupAndRestore]).Refresh();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }

                                    }
                                }
                                else
                                {
                                    UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم", "شما مجوز دسترسي به اين زيرسيستم را نداريد");
                                }
                            }
                            break;
                        }
                    case Definitions.EnvironmentNames.Treasury:
                        {

                            break;
                        }
                }
            }
        }
        private void PnlHubItemSettings_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.Settings);
        }
        private void PnlHubItemSMS_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.SMS);
        }
        private void DefaultForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.environments.Remove(((EnviromentMainForm)sender).environment);
        }
        private void PnlHubItemRahyab_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.Rahyab);
        }
        private void PnlHubItemAccounting_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.Accounting);
        }
        private void PnlHubItemWarehouse_Click(object sender, EventArgs e)
        {
            UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("", "در حال ساخت ...");
        }
        private void PnlHubItemReporting_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.Reporting);
        }
        private void PnlHubItemSalesManagement_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.SalesManagement);
        }
        private void PnlHubItemKalaGostaran_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.KalaGostaran);
        }
        private void PnlHubItemEMS_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.EMS);
        }
        private void PnlHubItemBackupAndRestore_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.BackupAndRestore);
        }
        private void PnlHubItemBasicInformation_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.BasicInformation);
        }
        private void PnlHubItemTreasury_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.Treasury);
        }
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private void PnlHubItemSales_Click(object sender, EventArgs e)
        {
            RunModule(Definitions.EnvironmentNames.Sales);
        }
        private void DefaultForm_SizeChanged(object sender, EventArgs e)
        {
            if (((EnviromentMainForm)sender).WindowState == FormWindowState.Minimized)
            {
                if (this.parent.WindowState == FormWindowState.Minimized)
                {
                    this.parent.WindowState = FormWindowState.Maximized;
                }
            }
        }


    }
}
