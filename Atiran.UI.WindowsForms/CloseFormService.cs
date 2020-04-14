using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Atiran.UI.WindowsForms
{
    public class CloseFormService
    {
        public static void CloseUserControll(UI.WindowsForms.Controls.UserControl uc)
        {
            if (uc.ParentForm is Atiran.CustomDocking.Docking.Desk.DeskTab)
            {
                if (uc.ParentForm != null)
                {
                    uc.ParentForm.Dispose();
                    uc.Dispose();
                }
            }
            else
            {
                if (((UI.WindowsForms.UIElements.Form)uc.ParentForm) != null && ((UI.WindowsForms.UIElements.Form)uc.ParentForm).tabBar != null)
                    ((UI.WindowsForms.UIElements.Form)uc.ParentForm).tabBar.RemoveTab(uc.UcGuid);
            }


        }
        public static void ChangeTabName(UI.WindowsForms.Controls.UserControl uc, string Text)
        {
            if (uc.ParentForm is Atiran.CustomDocking.Docking.Desk.DeskTab)
            {
                if (uc.ParentForm != null)
                    uc.ParentForm.Text = Text;
            }
            else
            {
                if (((UI.WindowsForms.UIElements.Form)uc.ParentForm) != null && ((UI.WindowsForms.UIElements.Form)uc.ParentForm).tabBar != null)
                    ((UI.WindowsForms.UIElements.Form)uc.ParentForm).tabBar.ChangeTabName(uc.UcGuid, Text);
            }
        }
        public static void FixTabName(UI.WindowsForms.Controls.UserControl uc, string Text)
        {
            if (uc.ParentForm is Atiran.CustomDocking.Docking.Desk.DeskTab)
            {
                if (uc.ParentForm != null)
                    uc.ParentForm.Text = Text;
            }
            else
            {
                if (((UI.WindowsForms.UIElements.Form)uc.ParentForm) != null && ((UI.WindowsForms.UIElements.Form)uc.ParentForm).tabBar != null)
                    ((UI.WindowsForms.UIElements.Form)uc.ParentForm).tabBar.FixTabName(uc.UcGuid, Text);
            }


        }
    }
}
