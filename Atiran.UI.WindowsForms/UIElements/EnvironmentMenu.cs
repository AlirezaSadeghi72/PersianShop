using System;
using System.Collections.Generic;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class EnvironmentMenu
    {
        public string Title { get; set; }
        public string RuntimeClass { get; set; }
        public long Code { get; set; }
       
        public List<EnvironmentMenu> EnvironmnetSubMenus;
        public EnvironmentMenu()
        {
            RuntimeClass = String.Empty;
            EnvironmnetSubMenus = new List<EnvironmentMenu>();
        }

        public bool IsItExecutable()
        {
            if (RuntimeClass == String.Empty)
                return false;
            else if (RuntimeClass != String.Empty && EnvironmnetSubMenus.Count == 0)
                return true;
            else
                return false;

        }
    }
}
