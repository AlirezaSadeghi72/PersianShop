using Atiran.UI.WindowsForms.UIElements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.Enums;
using Atiran.Connections.Operaions;
using Atiran.Connections.Operaions.FormOp;

namespace Atiran.BackupAndRestore
{
    public partial class Default : EnviromentMainForm
    {
        private FormWindowState mLastState;
        public Default(Definitions.EnvironmentNames env_) : base(env_)
        {
            InitializeComponent();
            mLastState = this.WindowState;
            this.SizeChanged += Default_SizeChanged;
        }
        private void Default_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString().ToLower().Contains("windows 10"))
                {
                    FixScreenLag.WinApi.SetWinFullScreen(this.Handle);
                    this.FormBorderStyle = FormBorderStyle.None;
                    this.Refresh();
                }
            }
            catch (Exception)
            {
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (this.WindowState != mLastState)
            {
                base.OnClientSizeChanged(e);
            }
        }
        public void AddForm(Connections.AtiranAccModel.Menu menu_)
        {
            var form = GetHubForm.GetNameSpaceForm(menu_.FormID.Value);
            string typeName = form.NameSpace + "." + form.Class;
            string title = form.Title;
            var control = this.GetType().Assembly.CreateInstance(typeName);
            Tab tab = new Tab(tabBar, title, (Atiran.UI.WindowsForms.Controls.UserControl)control, slate);
            this.tabBar.AddTab(tab);
            InvisibleSubMenus();
            menu.Left = this.Width;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        public Point BackStartingPoint(Bitmap image)
        {
            Point result = new Point();
            result.X = 0; // this.Width - image.Width;
            result.Y = 0; // this.Height - image.Height;
            return result;
        }

        public void FocuseOnTab(Guid tabGUID)
        {
            this.tabBar.FocuseTab(TabGUID: tabGUID);
        }
    }
}
