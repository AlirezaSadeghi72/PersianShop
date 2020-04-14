using Atiran.UI.WindowsForms.UIElements;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Atiran.Connections.Services;

namespace Atiran.UI.WindowsForms.Controls
{

    public class UserControl : System.Windows.Forms.UserControl
    {
        //public Atiran.UI.WindowsForms.ResourceManager ResourceManagerInstance;
        public string AtiranTitle { get; set; }
        public Guid UcGuid { get; set; }
        public string ProjectName { get; set; }
        public UserControl()
        {
            // ResourceManagerInstance = new ResourceManager("fa-Ir");
            //  this.Font = FontManager.GetFont("IRNazanin", 14, FontStyle.Bold);
            this.Font = UI.WindowsForms.FontManager.GetDefaultTextFont();
            this.BackColor = Color.FromArgb(250, 250, 250);
            this.KeyPress += UserControl_KeyPress;
            UcGuid = Guid.NewGuid();
            ProjectName = this.CompanyName;
            new System.Threading.Thread(() =>
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }).Start();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (this.ParentForm is Atiran.CustomDocking.Docking.Desk.DeskTab)
                {
                    if (((Atiran.CustomDocking.Docking.Desk.DeskTab) this.ParentForm).DockAreas ==
                        ((Atiran.CustomDocking.Docking.DockAreas) ((Atiran.CustomDocking.Docking.DockAreas.DockLeft |
                                                                    Atiran.CustomDocking.Docking.DockAreas.DockRight))))
                    {
                        return true;
                    }

                    if (((Atiran.CustomDocking.Docking.Desk.DeskTab)this.ParentForm).Kind == 1)
                    {
                        Atiran.UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 0;
                        DialogResult CloseAnsewr =
                            Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام",
                                "براي خروج از فرم اطمينان داريد؟", "w");
                        if (CloseAnsewr == DialogResult.Yes)
                        {
                            this.ParentForm.Close();
                        }

                        Atiran.UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 1;
                    }
                    else
                    {
                        this.ParentForm.Close();
                    }
                }
                else
                {
                    if (((UIElements.Form)this.ParentForm) != null &&
                        ((UIElements.Form)this.ParentForm).menuLuancherButton != null &&
                        ((UIElements.Form)this.ParentForm).menuLuancherButton.MenuIsShow)
                    {
                        ((UIElements.Form)this.ParentForm).menuLuancherButton.DisableMenu();
                        return true;
                    }

                    if (((UIElements.Form)this.ParentForm) != null &&
                        ((UIElements.Form)this.ParentForm).tabBar != null)
                    {
                        if (((UIElements.Form)this.ParentForm).tabBar.CurrentTab.Kind == 1)
                        {
                            Atiran.UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 0;
                            DialogResult CloseAnsewr =
                                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام",
                                    "براي خروج از فرم اطمينان داريد؟", "w");
                            if (CloseAnsewr == DialogResult.Yes)
                            {
                                ((UIElements.Form)this.ParentForm).tabBar.RemoveTab(this.UcGuid);
                            }

                            Atiran.UI.WindowsForms.MessageBoxes.MessageBoxWarning.state = 1;
                        }
                        else
                        {
                            ((UIElements.Form)this.ParentForm).tabBar.RemoveTab(this.UcGuid);
                        }
                    }
                    else if (this.ParentForm != null)
                    {
                        this.ParentForm.Close();
                    }
                }

                return true;
            }
            else if (keyData == Keys.Home)
            {
                if (this.ParentForm is Atiran.CustomDocking.Docking.Desk.DeskTab)
                {
                    var MyMnSt =
                        (System.Windows.Forms.MenuStrip) this.ParentForm.TopLevelControl.Controls.Find("MyMnSt", true)?[
                            0];
                    ShowDropDown(MyMnSt,
                        this.ParentForm.ActiveControl.ToString(), true);
                    return true;
                }
                else
                {
                    if ((UIElements.Form)this.ParentForm != null & ((UIElements.Form)this.ParentForm).menuLuancherButton != null)
                        ((UIElements.Form)this.ParentForm).menuLuancherButton?.ShowMenu();
                }
            }
            else if (keyData == (Keys.Alt | Keys.Home))
            {
                if (this.ParentForm is Atiran.CustomDocking.Docking.Desk.DeskTab)
                {
                    var MyMnSt =
                        (System.Windows.Forms.MenuStrip) this.ParentForm.TopLevelControl.Controls.Find("MyMnSt", true)?[
                            0];
                    ShowDropDown(MyMnSt,
                        this.ParentForm.ActiveControl.ToString(), false /*, this.ParentForm.ActiveControl.Name*/);
                }
                else
                {
                    if ((UIElements.Form)this.ParentForm != null)
                        ((UIElements.EnvironmentHeader)((UIElements.Form)this.ParentForm).header)?.home.BackToHome();
                }

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected void ShowDropDown(System.Windows.Forms.MenuStrip Menu, string TypeName, bool ShowRoot/*, string Name = null*/)
        {
            foreach (ToolStripMenuItem item in Menu.Items)
            {
                if (CheckMenuItem(item, TypeName, ShowRoot))
                {
                    item.ShowDropDown();

                    break;
                }
            }
        }

        private bool CheckMenuItem(ToolStripMenuItem MenuItem, string TypeName, bool ShowRoot)
        {
            if (((MyTag)MenuItem.Tag).NameSpase + "." + ((MyTag)MenuItem.Tag).Class == TypeName)
            {
                MenuItem.Select();
                return true;
            }

            foreach (ToolStripMenuItem item in MenuItem.DropDown.Items)
            {
                if (CheckMenuItem(item, TypeName, ShowRoot))
                {
                    if (!ShowRoot)
                    {
                        MenuItem.ShowDropDown();
                    }
                    return true;
                }
            }

            //i = null;
            return false;
        }
        private void UserControl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (this.ParentForm != null)
                    if (this.ParentForm.TopLevelControl == null)
                        this.ParentForm.Close();
            }

        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControl
            // 
            this.Name = "UserControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ResumeLayout(false);
        }
    }
}
