using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                frmLogin l = new frmLogin(Connections.Enums.Definitions.EnvironmentNames.Login);
                if (l.IsDisposed) return;
                Application.Run(l);
                //Application.Run(new KabiriTest());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
