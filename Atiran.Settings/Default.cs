using Atiran.UI.WindowsForms.UIElements;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Atiran.Connections.Enums;
using Atiran.Connections.Operaions;
using Atiran.Connections.Operaions.FormOp;
using Atiran.Connections.Operaions.UserFormPermissionOp;

namespace Atiran.Settings
{
    public partial class Default : EnviromentMainForm
    {
        public Default(Definitions.EnvironmentNames env_) : base(env_)
        {
            InitializeComponent();
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

         /*   if (this.paintFlag)
            {
                Bitmap image = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Back_Settings") as Bitmap;
                float scale = image.Width / image.Height;

                int maxWidth = this.Width;
                int maxHeight = this.Height;
                var ratioX = (double)maxWidth / image.Width;
                var ratioY = (double)maxHeight / image.Height;
                var ratio = Math.Min(ratioX, ratioY);
                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);
                var newImage = new Bitmap(newWidth, newHeight);
                var graphics = Graphics.FromImage(newImage);
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                e.Graphics.DrawImage(newImage, BackStartingPoint(newImage));
            }*/
        }

        public Point BackStartingPoint(Bitmap image)
        {
            Point result = new Point();
            result.X = 0; // this.Width - image.Width;
            result.Y = 0; // this.Height - image.Height;
            return result;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void FocuseOnTab(Guid tabGUID)
        {
            this.tabBar.FocuseTab(TabGUID: tabGUID);
        }
    }
}
