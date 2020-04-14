using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class Form : System.Windows.Forms.Form,IDisposable
    {
        public EnvironmentHeader environmentHeader;
        public System.Windows.Forms.Timer menuTimer;
        public bool paintFlag;
        public bool openAsShortcut;
        public Atiran.UI.WindowsForms.ResourceManager ResourceManagerInstance;
        public Header header;
        public MenuLauncherButton menuLuancherButton;
        public TabBar tabBar;
        public StatusBar statusBar;
        public SizeGrip sizeGrip;
        public MenuContainerLevelOne menu;
        public List<MenuContainerLevelTwo> subMenus;
        public Panel slate;
        private List<MenuButton> menuButtons;
        public bool menuLevelTwoIsActive;
        public bool isHub = false;
        public Form()
        {
            ResourceManagerInstance = new ResourceManager("fa-Ir");
            slate = new Panel();
            slate.Click += Slate_Click;
            menuTimer = new Timer
            {
                Interval = 1
            };
            menuTimer.Tick += MenuTimer_Tick;
            menuTimer.Stop();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.White;
            this.paintFlag = true;
            this.Font = FontManager.GetDefaultTextFont();
            subMenus = new List<MenuContainerLevelTwo>();
            // this.Size = new System.Drawing.Size(1127, 628);
            this.MinimumSize = new System.Drawing.Size(1127, 628);
            this.Shown += Form_Shown;
            menuLevelTwoIsActive = false;
            new System.Threading.Thread(() =>
            {
                GC.Collect();
            }).Start();
        }
        private void MenuTimer_Tick(object sender, System.EventArgs e)
        {

            if (menu.Left > this.Width - 200)
                menu.Left -= 100;
            if (menu.Left == this.Width - 200)
                menuTimer.Stop();
        }
        private void Form_Shown(object sender, EventArgs e)
        {
            var CO = this.Controls.OfType<Atiran.UI.WindowsForms.Controls.UserControl>().ToList();
        }
        private void Slate_Click(object sender, EventArgs e)
        {
            if (menu != null)
                //  menu.Left = this.Width;
                subMenus.ForEach(i => i.Visible = false);
        }
        //GDI+ performance trick
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        public void AddToSubMenus(MenuContainerLevelTwo subMenu)
        {
            subMenus.Add(subMenu);
        }
        public void InvisibleSubMenus()
        {
            if (subMenus != null && subMenus.Count > 0)
            {
                foreach (MenuContainerLevelTwo subMenu in subMenus)
                {
                    subMenu.Visible = false;
                    subMenu.BringToFront();
                }
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Form";
            this.ResumeLayout(false);

        }
        public void BindMenuItemsToForms()
        {
            int i = 0;
            try
            {
                foreach (Atiran.UI.WindowsForms.UIElements.MenuButton mb in this.menu.items)
                {
                    i++;
                    if (mb.self.Form != null)
                    {
                        mb.title.Click += Mb_Click;
                        mb.rightSpace.Click += Mb_Click;
                    }
                }

                foreach (Atiran.UI.WindowsForms.UIElements.MenuContainer mc in this.subMenus)
                {
                    foreach (Atiran.UI.WindowsForms.UIElements.MenuButton mb in mc.items)
                    {
                        if (mb.self.Form != null)
                        {
                            mb.title.Click += Mb_Click;
                            mb.rightSpace.Click += Mb_Click;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        private void CheckAccessPermission(Atiran.UI.WindowsForms.UIElements.MenuButton mb, string typeName)
        {
            if (Connections.Operaions.UserFormPermissionOp.FormPermission.AccessUserForm(mb.self.FormID.Value))
            {
                var control = this.GetType().Assembly.CreateInstance(typeName);
                Tab tab = new Tab(tabBar, mb.self.Form.Title, (Atiran.UI.WindowsForms.Controls.UserControl)control, slate);
                this.tabBar.AddTab(tab);
                InvisibleSubMenus();
                menu.Left = this.Width;
            }
            else
            {
                UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيام", "شما به اين فرم دسترسي نداريد", "i");
            }
        }
        private void RunnerForm(MenuButton mb)
        {
            string typeName = mb.self.Form.NameSpace + "." + mb.self.Form.Class;
            CheckAccessPermission(mb, typeName);
        }
        private void Mb_Click(object sender, EventArgs e)
        {
            Atiran.UI.WindowsForms.UIElements.MenuButton mb = (Atiran.UI.WindowsForms.UIElements.MenuButton)((System.Windows.Forms.Control)sender).Parent;
            RunnerForm(mb);
            menuLuancherButton.MenuIsShow = false;
        }
    }
}
