using Atiran.UI.WindowsForms;
using Atiran.UI.WindowsForms.UIElements;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Windows.Input;
using Atiran.Connections.Enums;
using Atiran.Connections.Operaions.UserFormPermissionOp;
using Atiran.UI.WindowsForms.Shortcuts;

namespace Atiran.Main.Main
{
    public class Hub : Atiran.UI.WindowsForms.UIElements.Form, IDisposable
    {
        #region Properties
        TableLayoutPanel pnlContainer;
        public static List<EnviromentMainForm> Environments;
        System.Windows.Forms.TableLayoutPanel pnlFeed;
        System.Windows.Forms.Panel pnlMainFeed;
        private System.Windows.Forms.Panel newsBox;
        System.Windows.Forms.FlowLayoutPanel pnlSeperator;
        private TableLayoutPanel hubItem;
        private string CurrentUsername;
        public FlowLayoutPanel pnlHubItemContainer;
        private Timer timer;
        #endregion
        public Hashtable environments;
        private Control GetStatusBarControl()
        {
            UI.WindowsForms.Controls.Label shortcutKey = new UI.WindowsForms.Controls.Label
            {
                AutoSize = false,
                Text = "راهنماي نرم افزار : F1",
                Width = statusBar.Width,
                RightToLeft = RightToLeft.Yes,
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleLeft,
                ForeColor = Color.Black
            };
            shortcutKey.Font = new Font(shortcutKey.Font, FontStyle.Regular);
            return shortcutKey;
        }
        public Hub( string username)
        {
            CurrentUsername = username;
            environments = new Hashtable();
            InitializeDesign();
            this.Load += Hub_Load;
            statusBar.Controls.Add(GetStatusBarControl());
            this.Text = "جزيره آتيران";
            this.isHub = true;
            timer = new Timer
            {
                Interval = 500
            };
            timer.Tick += Timer_Tick;
            Application.ApplicationExit += Application_ApplicationExit;
            this.FormClosing += Hub_FormClosing;
        }
        private void Hub_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Application_ApplicationExit(object sender, EventArgs e)
        {

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!Keyboard.IsKeyDown(Key.LeftAlt) | !Keyboard.IsKeyDown(Key.RightAlt))
            {
                List<HubButton> buttons = hubItem.Controls.OfType<HubButton>().ToList();

                buttons.ForEach(i =>
                {
                    if (i.SubSystemID == 8 | i.SubSystemID == 12)
                    {
                        i.Title.Select(1, 1);
                    }
                    else
                    {
                        i.Title.Select(0, 1);
                    }
                    //i.Title.SelectionBackColor = Color.Transparent;
                    i.Title.SelectionColor = Color.Black;
                });
                timer.Stop();
            }

        }
        UserControl usercontrol_;
        bool ChangeSizeFormBySizeOfTheUserControl;
        UI.WindowsForms.UIElements.Form D;
        public void UserControlLoader(UserControl usercontrol, bool ChangeSizeFormBySizeOfTheUserControl_ = false)
        {
            try
            {
                usercontrol_ = usercontrol;
                D = new UI.WindowsForms.UIElements.Form
                {
                    BackColor = Color.Black,
                    Opacity = 0.60f,
                    WindowState = FormWindowState.Maximized
                };
                ChangeSizeFormBySizeOfTheUserControl = ChangeSizeFormBySizeOfTheUserControl_;
                D.Load += D_Load;
                D.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void D_Load(object sender, EventArgs e)
        {
            Atiran.UI.WindowsForms.UIElements.Form frm = new Atiran.UI.WindowsForms.UIElements.Form
            {
                KeyPreview = true,
                StartPosition = FormStartPosition.CenterScreen,
                Width = usercontrol_.Width,
                Height = usercontrol_.Height
            };
            if (ChangeSizeFormBySizeOfTheUserControl)
                frm.MaximumSize = new Size(usercontrol_.Width, usercontrol_.Height);
            usercontrol_.Dock = DockStyle.Fill;
            frm.WindowState = FormWindowState.Normal;
            frm.Controls.Add(usercontrol_);
            frm.ShowDialog();
            D.Close();
        }
        private void Hub_SizeChanged(object sender, EventArgs e)
        {
            HandleResize();
            try
            {
                if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString().ToLower().Contains("windows 10"))
                {
                    Atiran.Connections.Operaions.FixScreenLag.WinApi.SetWinFullScreen(this.Handle);
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        public void GetNews()
        {
            System.Threading.ThreadStart ts = new System.Threading.ThreadStart(GetNewsAsync);
            System.Threading.Thread gn = new System.Threading.Thread(ts);
            gn.Start();
        }
        public void UpdateNewsBar()
        {
        }
        private void GetNewsAsync()
        {

        }
        private void InitializeDesign_()
        {
            //Window
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            HubHeader header = new HubHeader(this);
            this.statusBar = new UI.WindowsForms.UIElements.StatusBar(this);
            this.sizeGrip = new SizeGrip(this);
            this.SizeChanged += Hub_SizeChanged;
            pnlContainer = new TableLayoutPanel();


            pnlContainer.Top = 60;

            pnlContainer.Font = FontManager.GetFont("IRANSans", 14, FontStyle.Regular);

            HandleResize();

            pnlContainer.ColumnCount = 3;
            pnlContainer.RowCount = 1;
            pnlContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 330));
            pnlHubItemContainer = new FlowLayoutPanel();
            pnlHubItemContainer.FlowDirection = FlowDirection.RightToLeft;
            pnlHubItemContainer.WrapContents = true;
            pnlHubItemContainer.Dock = DockStyle.Fill;
            pnlHubItemContainer.Padding = new Padding(0, 0, 50, 0);

            //BasicInformation

            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.BasicInformation, this);
            BlinkLabel l = new BlinkLabel();
            l.Text = "ماژول جديد";
            l.ForeColor = Color.Red;
            basicInformation.Controls.Add(l);
            pnlHubItemContainer.Controls.Add(basicInformation);

            //Sales Management
            HubButton salesManagement = new HubButton(Definitions.EnvironmentNames.SalesManagement, this);
            pnlHubItemContainer.Controls.Add(salesManagement);
            //Kala Gostaran
            HubButton kalaGostaran = new HubButton(Definitions.EnvironmentNames.KalaGostaran, this);
            pnlHubItemContainer.Controls.Add(kalaGostaran);
            //Sales
            HubButton sales = new HubButton(Definitions.EnvironmentNames.Sales, this);
            pnlHubItemContainer.Controls.Add(sales);

            // Treasury
            HubButton treasury = new HubButton(Definitions.EnvironmentNames.Treasury, this);
            pnlHubItemContainer.Controls.Add(treasury);

            //Reporting
            HubButton reporting = new HubButton(Definitions.EnvironmentNames.Reporting, this);
            pnlHubItemContainer.Controls.Add(reporting);

            //Warehouse
            HubButton warehouse = new HubButton(Definitions.EnvironmentNames.Warehouse, this);
            pnlHubItemContainer.Controls.Add(warehouse);

            //Accounting
            HubButton accounting = new HubButton(Definitions.EnvironmentNames.Accounting, this);
            pnlHubItemContainer.Controls.Add(accounting);

            //Rahyab
            HubButton rahyab = new HubButton(Definitions.EnvironmentNames.Rahyab, this);
            pnlHubItemContainer.Controls.Add(rahyab);

            //EMS
            HubButton ems = new HubButton(Definitions.EnvironmentNames.EMS, this);
            pnlHubItemContainer.Controls.Add(ems);
            //BackupAndRestore
            HubButton bak = new HubButton(Definitions.EnvironmentNames.BackupAndRestore, this);
            pnlHubItemContainer.Controls.Add(bak);
            //Settings
            HubButton setting = new HubButton(Definitions.EnvironmentNames.Settings, this);
            pnlHubItemContainer.Controls.Add(setting);
            //SMS
            HubButton sms = new HubButton(Definitions.EnvironmentNames.SMS, this);
            pnlHubItemContainer.Controls.Add(sms);



            pnlContainer.Controls.Add(pnlHubItemContainer, 2, 0);

            pnlSeperator = new FlowLayoutPanel();

            pnlSeperator.BackColor = Color.Transparent;

            pnlSeperator.Dock = DockStyle.Left;
            HubSeperator seperator = new HubSeperator(this.pnlSeperator);
            seperator.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            pnlSeperator.Controls.Add(seperator);
            pnlSeperator.ControlAdded += PnlSeperator_ControlAdded;
            pnlContainer.Controls.Add(pnlSeperator, 1, 0);

            pnlFeed = new TableLayoutPanel();
            pnlFeed.BackColor = Color.FromArgb(238, 238, 238);
            pnlFeed.Width = pnlContainer.Width - pnlHubItemContainer.Width - pnlSeperator.Width;
            pnlFeed.Height = Screen.PrimaryScreen.Bounds.Height;

            pnlFeed.ControlAdded += PnlFeed_ControlAdded;

            pnlContainer.Controls.Add(pnlFeed, 0, 0);

            this.Controls.Add(pnlContainer);
        }
        private void PnlSeperator_ControlAdded(object sender, ControlEventArgs e)
        {
            int height = 0;

            foreach (System.Windows.Forms.Control c in pnlSeperator.Controls)

            {
                height += c.Height;
            }
            pnlSeperator.Height = height;
        }
        private void PnlFeed_ControlAdded(object sender, ControlEventArgs e)
        {

            int height = 0;
            foreach (System.Windows.Forms.Control c in pnlFeed.Controls)

            {
                height += c.Height;
            }
            pnlFeed.Height = height + 5;

        }

        private void HandleResize()
        {
            pnlContainer.Width = Screen.PrimaryScreen.Bounds.Width;// - 100; // this.Width - 100;
            pnlContainer.Height = Screen.PrimaryScreen.Bounds.Height; //this.Height;// - 300;
            Invalidate();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Hub
            // 
            this.ClientSize = new System.Drawing.Size(1127, 628);
            this.Name = "Hub";
            this.Load += new System.EventHandler(this.Hub_Load);
            this.ResumeLayout(false);

        }


        private void Hub_Load(object sender, EventArgs e)
        {
            var AppVersionSplit = Application.ProductVersion.Trim().Split('.');
        }

        public void RunnerFromHub(Definitions.EnvironmentNames name, Connections.AtiranAccModel.Menu m, bool shortCut)
        {
            new HubButton(name, this).RunModule(name, m, shortCut);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Menu | Keys.Alt):
                    {

                        List<HubButton> buttons = hubItem.Controls.OfType<HubButton>().ToList();

                        buttons.ForEach(i =>
                        {
                            if (i.SubSystemID == 8 | i.SubSystemID == 12)
                            {
                                i.Title.Select(1, 1);
                            }
                            else
                            {
                                i.Title.Select(0, 1);
                            }

                            i.Title.SelectionColor = Color.Crimson;
                        });
                        timer.Start();
                        return true;
                    }
                case (Keys.Alt | Keys.H):
                    {
                        HubButton button = new HubButton(Definitions.EnvironmentNames.BasicInformation, this);
                        button.RunModule(Definitions.EnvironmentNames.BasicInformation);
                        button.Dispose();
                        return true;
                    }

                case (Keys.Alt | Keys.J):
                    {
                        HubButton button = new HubButton(Definitions.EnvironmentNames.Settings, this);
                        button.RunModule(Definitions.EnvironmentNames.Settings);
                        button.Dispose();
                        return true;
                    }
                case (Keys.Alt | Keys.A):
                    {
                        HubButton button = new HubButton(Definitions.EnvironmentNames.BackupAndRestore, this);
                        button.RunModule(Definitions.EnvironmentNames.BackupAndRestore);
                        button.Dispose();
                        return true;
                    }
                case ((Keys)Atiran.Connections.Enums.ShortcutKeyEnum.HelpKey):
                    {
                        Help H = new Help();
                        UserControlLoader u = new UserControlLoader(H, true, false, true,false);
                        return true;
                    }
                case (Keys.Alt | Keys.F4):
                    {
                        UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 0;
                        DialogResult close =
                            Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم",
                                "آيا مي خواهيد از سيستم خارج شويد؟", "w");
                        UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 1;
                        if (close == DialogResult.Yes)
                        {
                            if (Connections.Operaions.UserFormPermissionOp.FormPermission.CheckBackupPermission())
                            {
                                DialogResult res =
                                    Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show(
                                        "پيام سيستم", "آيا مي خواهيد از اطلاعات پشتيبان بگيريد؟", "w");
                                if (res == DialogResult.Yes)
                                {
                                    // backup
                                    UI.WindowsForms.Controls.FastBackup c = new UI.WindowsForms.Controls.FastBackup();
                                    UserControlLoader(c);
                                }
                            }

                            Application.Exit();

                        }

                        return true;
                    }
                case (Keys)Atiran.Connections.Enums.ShortcutKeyEnum.SearchFormsKey:
                {
                    try
                    {
                        List<Atiran.Connections.AtiranAccModel.Menu> menu = new List<Connections.AtiranAccModel.Menu>();
                        AtiranSpotlight spotlight = new AtiranSpotlight(menu);
                        new UserControlLoader(spotlight, true, false, true);
                        if (menu.Count > 0)
                        {
                            if (FormPermission.AccessUserForm((int?)menu[0].FormID ?? 0))
                            {
                                RunnerFromHub((Definitions.EnvironmentNames)menu[0].SubSystemID - 1, menu[0], true);
                            }
                            else
                            {
                                UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام", "شما به اين فرم دسترسي نداريد", "i");
                            }
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
                //            List<Atiran.Connections.AtiranAccModel.Menu> menu = new List<Connections.AtiranAccModel.Menu>();
                //            UI.WindowsForms.Shortcuts.AtiranShortcuts ShortCutHere = new UI.WindowsForms.Shortcuts.AtiranShortcuts(menu);
                //            ShortCutHere.pnlLeft.Visible = false;
                //            ShortCutHere.Width = 470;
                //            Atiran.UI.WindowsForms.UIElements.Form frm = new Atiran.UI.WindowsForms.UIElements.Form
                //            {
                //                KeyPreview = true,
                //                StartPosition = System.Windows.Forms.FormStartPosition.Manual,
                //                Width = ShortCutHere.Width,
                //                Height = ShortCutHere.Height,
                //                MaximumSize = new Size(ShortCutHere.Width, ShortCutHere.Height)
                //            };
                //            ShortCutHere.Dock = System.Windows.Forms.DockStyle.Fill;
                //            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                //            frm.Controls.Add(ShortCutHere);
                //            frm.Deactivate += (sender, e) => { ShortCutHere.ParentForm.Close(); };
                //            frm.Location = new Point(750, 39);
                //            frm.ShowDialog();
                //            if (menu.Count > 0)
                //            {
                //                if (Connections.Operaions.UserFormPermissionOp.FormPermission.AccessUserForm((int?)menu[0].FormID ?? 0))
                //                {
                //                    RunnerFromHub((Definitions.EnvironmentNames)menu[0].SubSystemID - 1, menu[0], true);
                //                }
                //                else
                //                {
                //                    UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام", "شما به اين فرم دسترسي نداريد", "i");
                //                }
                //            }
                //        }
                //        catch (Exception ex)
                //        {
                //            MessageBox.Show(ex.ToString());
                //            throw;
                //        }
                //        return true;
                //    }
                case (Keys)Atiran.Connections.Enums.ShortcutKeyEnum.ActivatedFormKey:
                    {
                        try
                        {
                            if (Atiran.UI.WindowsForms.UIElements.TabBar.StaticTabs == null || Atiran.UI.WindowsForms.UIElements.TabBar.StaticTabs.Count == 0)
                            {
                                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام", "هيچ فرمي باز نشده است");
                                return true;
                            }
                            List<Guid> menu = new List<Guid>();
                            AtiranActivatedForms ActiveHere = new AtiranActivatedForms(menu)
                            {
                                Width = 470
                            };
                            Atiran.UI.WindowsForms.UIElements.Form frm = new Atiran.UI.WindowsForms.UIElements.Form
                            {
                                KeyPreview = true,
                                StartPosition = System.Windows.Forms.FormStartPosition.Manual,
                                Width = ActiveHere.Width,
                                Height = ActiveHere.Height,
                                MaximumSize = new Size(ActiveHere.Width, ActiveHere.Height)
                            };
                            ActiveHere.Dock = System.Windows.Forms.DockStyle.Fill;
                            frm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                            frm.Controls.Add(ActiveHere);
                            frm.Deactivate += (sender, e) => { ActiveHere.ParentForm.Close(); };
                            //  frm.Location = new Point(MousePosition.X - 190, MousePosition.Y + 15);
                            frm.Location = new Point(800, 39);
                            // System.Windows.Forms.MessageBox.Show("X = " + MousePosition.X.ToString() + " Y = " + MousePosition.Y.ToString());
                            frm.ShowDialog();
                            if (menu.Count > 0)
                            {
                                foreach (Tab item in Atiran.UI.WindowsForms.UIElements.TabBar.StaticTabs)
                                {
                                    if (item.control.UcGuid == menu.FirstOrDefault())
                                    {
                                        if (item.control.ProjectName == "Atiran.Accounting")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.Accounting, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.Accounting, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.BasicInformation")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.BasicInformation, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.BasicInformation, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.KalaGostaran")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.KalaGostaran, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.KalaGostaran, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.Management")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.SalesManagement, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.SalesManagement, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.Rahyab")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.Rahyab, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.Rahyab, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.Reporting")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.Reporting, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.Reporting, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.Sale")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.Sales, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.Sales, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.Settings")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.Settings, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.Settings, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.SMS")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.SMS, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.SMS, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.TaskManager")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.EMS, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.EMS, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.Treasury")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.Treasury, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.Treasury, TabGUID: item.control.UcGuid);
                                        }
                                        else if (item.control.ProjectName == "Atiran.BackupAndRestore")
                                        {
                                            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.BackupAndRestore, this);
                                            basicInformation.RunModule(Definitions.EnvironmentNames.BackupAndRestore, TabGUID: item.control.UcGuid);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        return true;
                    }
            }

            if (keyData == Keys.Escape)
            {

                // new by sharafzade
                UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 0;
                DialogResult res = Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم", "آيا مي خواهيد آتيران را ترك كنيد؟", "w");
                UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 1;
                if (res == DialogResult.Yes)
                {
                    if (Connections.Operaions.UserFormPermissionOp.FormPermission.CheckBackupPermission())
                    {
                        DialogResult res1 = Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام سيستم", "آيا مي خواهيد از اطلاعات پشتيبان بگيريد؟", "w");
                        if (res1 == DialogResult.Yes)
                        {
                            // backup
                            UI.WindowsForms.Controls.FastBackup c = new UI.WindowsForms.Controls.FastBackup();
                            UserControlLoader(c);

                        }
                    }

                    Application.Exit();
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void InitializeDesign()
        {
            //Window
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            HubHeader header = new HubHeader(this);
            this.statusBar = new UI.WindowsForms.UIElements.StatusBar(this);
            this.sizeGrip = new SizeGrip(this);
            this.SizeChanged += Hub_SizeChanged;
            pnlContainer = new TableLayoutPanel();
            hubItem = new TableLayoutPanel();
            hubItem.ColumnCount = 4;
            hubItem.RowCount = 5;


            pnlContainer.Top = 50;

            pnlContainer.Font = FontManager.GetFont("IRANSans", 14, FontStyle.Regular);

            HandleResize();
            pnlContainer.ColumnCount = 3;
            pnlContainer.RowCount = 1;
            pnlContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 330));
            //BasicInformation
            HubButton basicInformation = new HubButton(Definitions.EnvironmentNames.BasicInformation, this);
            hubItem.Controls.Add(basicInformation, 0, 0);
            //Sales Management
            HubButton KalaGostaran = new HubButton(Definitions.EnvironmentNames.KalaGostaran, this);
            hubItem.Controls.Add(KalaGostaran, 1, 0);
            //Sales Management
            HubButton sales = new HubButton(Definitions.EnvironmentNames.Sales, this);
            hubItem.Controls.Add(sales, 1, 1);

            HubButton salesManagement = new HubButton(Definitions.EnvironmentNames.SalesManagement, this);
            hubItem.Controls.Add(salesManagement, 0, 1);
            //  pnlHubItemContainer.Controls.Add(salesManagement);
            //Sales

                // Treasury
                HubButton treasury = new HubButton(Definitions.EnvironmentNames.Treasury, this);
                hubItem.Controls.Add(treasury, 0, 2);
            //Accounting
            HubButton accounting = new HubButton(Definitions.EnvironmentNames.Accounting, this);
            hubItem.Controls.Add(accounting, 1, 2);

            //Reporting
            HubButton reporting = new HubButton(Definitions.EnvironmentNames.Reporting, this);
            hubItem.Controls.Add(reporting, 0, 3);

            ////Warehouse
            //HubButton warehouse = new HubButton(Definitions.EnvironmentNames.Warehouse, this);
            //pnlHubItemContainer.Controls.Add(warehouse);
            //Rahyab
            HubButton rahyab = new HubButton(Definitions.EnvironmentNames.Rahyab, this);
            hubItem.Controls.Add(rahyab, 1, 3);

            //EMS
            HubButton ems = new HubButton(Definitions.EnvironmentNames.EMS, this);
            hubItem.Controls.Add(ems, 0, 4);
            //SMS
            HubButton sms = new HubButton(Definitions.EnvironmentNames.SMS, this);
            hubItem.Controls.Add(sms, 1, 4);
            //BackupAndRestore
            HubButton bak = new HubButton(Definitions.EnvironmentNames.BackupAndRestore, this);
            hubItem.Controls.Add(bak, 2, 4);
            //Settings
            HubButton setting = new HubButton(Definitions.EnvironmentNames.Settings, this);
            hubItem.Controls.Add(setting, 3, 4);
            
            hubItem.Dock = DockStyle.Fill;
            hubItem.RightToLeft = RightToLeft.Yes;
            pnlContainer.Controls.Add(hubItem, 2, 0);

            pnlSeperator = new FlowLayoutPanel();

            pnlSeperator.BackColor = Color.Transparent;

            pnlSeperator.Dock = DockStyle.Left;
            HubSeperator seperator = new HubSeperator(this.pnlSeperator);
            seperator.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            pnlSeperator.Controls.Add(seperator);
            pnlSeperator.ControlAdded += PnlSeperator_ControlAdded;
            pnlSeperator.Width = seperator.Width;
            pnlContainer.Controls.Add(pnlSeperator, 1, 0);

            pnlFeed = new TableLayoutPanel();
            pnlFeed.ColumnCount = 1;
            pnlFeed.RowCount = 3;
            System.Windows.Forms.Panel pnlTopFeed = new System.Windows.Forms.Panel();
            pnlTopFeed.Dock = DockStyle.Top;
            System.Windows.Forms.Panel pnlFooterFeed = new System.Windows.Forms.Panel();
            pnlFooterFeed.Dock = DockStyle.Bottom;
            pnlMainFeed = new System.Windows.Forms.Panel();
            pnlMainFeed.Dock = DockStyle.Fill;
            pnlFeed.RightToLeft = RightToLeft.Yes;
            pnlFeed.BackColor = Color.FromArgb(238, 238, 238);
            pnlFeed.Width = pnlContainer.Width - hubItem.Width - pnlSeperator.Width;
            pnlFeed.Height = Screen.PrimaryScreen.Bounds.Height;

            LinkLabel lbltxtAtiran = new LinkLabel();
            lbltxtAtiran.AutoSize = true;
            lbltxtAtiran.Parent = pnlFeed;
            lbltxtAtiran.Font = FontManager.GetFont("IRANSans", 11, FontStyle.Regular);
            lbltxtAtiran.Text = $"گروه نرم افزاري آتيران www.Atiran.ir";
            lbltxtAtiran.Dock = DockStyle.Top;
            pnlFooterFeed.Controls.Add(lbltxtAtiran);
            pnlMainFeed.Height = pnlFeed.Height - pnlTopFeed.Height - pnlFooterFeed.Height - 100;
            pnlFeed.Controls.Add(pnlTopFeed, 0, 0);
            pnlFeed.Controls.Add(pnlMainFeed, 0, 1);
            pnlFeed.Controls.Add(pnlFooterFeed, 0, 2);
            pnlFeed.ControlAdded += PnlFeed_ControlAdded;
            newsBox = new System.Windows.Forms.Panel();
            newsBox.Dock = DockStyle.Fill;
            pnlMainFeed.BringToFront();

            pnlContainer.Controls.Add(pnlFeed, 0, 0);

            this.Controls.Add(pnlContainer);

        }
    }
}
