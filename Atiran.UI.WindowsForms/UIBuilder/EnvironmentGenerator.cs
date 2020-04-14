using Atiran.UI.WindowsForms.UIElements;
using System.Globalization;
using System.Threading;
using System;
using System.Drawing;
using Atiran.Connections.Enums;

namespace Atiran.UI.WindowsForms.UIBuilder
{
    public class EnvironmentGenerator
    {
        public static  Definitions.EnvironmentNames Ename;
        public static Atiran.UI.WindowsForms.ResourceManager ResourceManagerInstance;

        public static void  Generate(Connections.Enums.Definitions.EnvironmentNames ename, EnviromentMainForm form)
        {
            GenerateEnvironment(form, ename);
        }

        private static void GenerateEnvironment(EnviromentMainForm form,Connections.Enums.Definitions.EnvironmentNames env)
        {
            form.environment = env;
            form.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            if (env == Connections.Enums.Definitions.EnvironmentNames.Accounting)
            {
                form.header = new AccountingEnviromentHeader(form);
                
            }
            else
                form.header = new EnvironmentHeader(form);
            form.menuLuancherButton = new MenuLauncherButton(form);
            form.tabBar = new TabBar(form);
            form.menu = new MenuContainerLevelOne(form);
            form.LoadMenu();
            form.BindMenuItemsToForms();
            form.statusBar = new UI.WindowsForms.UIElements.StatusBar(form);
            form.sizeGrip = new SizeGrip(form);
         
        }


      
    }
}
