using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
   public static class CloseEnviroment
    {
        public static void CloseAllOpenedFormInSpesificSubsystem(int subsystemId)
        {
            List<UI.WindowsForms.UIElements.EnviromentMainForm> forms = Application.OpenForms.OfType<UI.WindowsForms.UIElements.EnviromentMainForm>().ToList();
            EnviromentMainForm env = forms.FirstOrDefault(i => i.SubSystemID == subsystemId);
            CloseAllOpenedTabInEnviroment(env);
        }
        public static void CloseAllOpenedFormInUseLine()
        {
            List<UI.WindowsForms.UIElements.EnviromentMainForm> forms = Application.OpenForms.OfType<UI.WindowsForms.UIElements.EnviromentMainForm>().ToList();
            forms = forms.Where(i => i.SubSystemID == 1 | i.SubSystemID == 2 | i.SubSystemID == 3 | i.SubSystemID == 6 | i.SubSystemID == 10 | i.SubSystemID == 11 | i.SubSystemID == 12).ToList();
            forms.ForEach(i => CloseAllOpenedTabInEnviroment(i));
        }
        public static void CloseAllOpenedTabInEnviroment(EnviromentMainForm enviroment)
        {
            List<Tab> tabs = null;
            try
            {
                 tabs = enviroment.tabBar.Tabs;
            }
            catch (NullReferenceException)
            {
                return;
            }
            finally
            {
                tabs.Clear();
                enviroment.tabBar.Controls.Clear();
                enviroment.slate.Controls.Clear();
            }

        }
        public static void CloseEnviroment_(int subsystemId)
        {
            CloseAllOpenedFormInSpesificSubsystem(subsystemId);
        }
    }
}
