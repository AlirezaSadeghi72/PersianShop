using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Atiran.UI.WindowsForms
{
    public class ResourceManager : System.Resources.ResourceManager
    {
        public static string cultureInfo;
        public ResourceManager(string cultureInfo_ = null)
        {
            cultureInfo = cultureInfo_;
            if (cultureInfo == null)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");

            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo);
        }

        public static System.Resources.ResourceManager GetResourceManager()
        {
            if (cultureInfo == null)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");

            else
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo);
            return new System.Resources.ResourceManager("Atiran.UI.WindowsForms.Resources", Assembly.GetExecutingAssembly());
        }
    }
}
