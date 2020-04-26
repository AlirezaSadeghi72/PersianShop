using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.UI.WindowsForms;

namespace Atiran.Main
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Atiran.UI.WindowsForms.FontManager.InstallFontForProgram();
                //frmLogin l = new frmLogin(Connections.Enums.Definitions.EnvironmentNames.Login);
                Login l = new Login();
                Application.Run(CreateForm(l));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static Form CreateForm(UserControl usercontrol)
        {
            var D = new UI.WindowsForms.UIElements.Form();
            D.Name = "BackForm";
            D.BackColor = Color.Black;
            D.Opacity = 0.60f;
            D.Width = usercontrol.Width;
            D.Height = usercontrol.Height;
            D.WindowState = FormWindowState.Maximized;
            D.Load += (s, e) =>
            {
                Atiran.UI.WindowsForms.UIElements.Form frm = new Atiran.UI.WindowsForms.UIElements.Form();

                frm.KeyPreview = true;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.TransparencyKey = Color.Snow;
                frm.BackColor = Color.Snow;
                frm.Width = usercontrol.Width;
                frm.Height = usercontrol.Height;
                frm.MaximumSize = new Size(usercontrol.Width, usercontrol.Height);
                usercontrol.Location = new Point(0, 0);
                frm.WindowState = FormWindowState.Normal;
                frm.Controls.Add(usercontrol);
                frm.ShowDialog();
                D.Hide();

            };
            D.openAsShortcut = true;
            return D;
        }
    }
}
