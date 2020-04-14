using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class TabBar : System.Windows.Forms.FlowLayoutPanel
    {
        public EnviromentMainForm AtiranParent;
        public List<Tab> Tabs;
        public static List<Tab> StaticTabs;
        public Tab CurrentTab;
        public TabBar(EnviromentMainForm parent_)
        {
            AtiranParent = parent_;
            Tabs = new List<Tab>();

            this.Left = 0;
            this.Top = 39;
            this.Height = 30;
            this.Width = AtiranParent.Width - 30;

            this.Margin = System.Windows.Forms.Padding.Empty;
            this.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            AtiranParent.SizeChanged += AtiranParent_SizeChanged;
            this.BackColor = System.Drawing.Color.FromArgb(204, 212, 219);
            //this.Controls.Add(new Atiran.UI.WindowsForms.Controls.Buttons.RefreshButton() { AutoSize = true,Name="btnNext", Dock=DockStyle.Left, BackColor = Color.Blue, Text = "قبلي" });
            //this.Controls.Add(new Atiran.UI.WindowsForms.Controls.Buttons.RefreshButton() { AutoSize = true,Name="btnNext1", Dock=DockStyle.Right, BackColor = Color.Blue, Text = "قبلي" });
            //this.Controls.Add(new Atiran.UI.WindowsForms.Controls.Buttons.RefreshButton() { AutoSize = true,Name="btnNext2", Dock=DockStyle.Top, BackColor = Color.Blue, Text = "قبلي" });
            //this.Controls.Add(new Atiran.UI.WindowsForms.Controls.Buttons.RefreshButton() { AutoSize = true,Name="btnNext3", Dock=DockStyle.Bottom, BackColor = Color.Blue, Text = "قبلي" });
            //this.Controls.Add(new Atiran.UI.WindowsForms.Controls.Buttons.RefreshButton() { AutoSize = true,Name="btnNext4", Dock=DockStyle.Fill, BackColor = Color.Blue, Text = "قبلي" });
            AtiranParent.Controls.Add(this);
        }
        public TabBar()
        {

        }
        public bool AddTab(Tab tab)
        {
            if (StaticTabs == null)
            {
                StaticTabs = new List<Tab>();
            }
            Tabs.Add(tab);
            StaticTabs.Add(tab);
            ArrangeTabs();
            tab.Display();
            return true;
        }

        public void InActiveLookForAll()
        {
            foreach (Tab t in Tabs)
            {
                this.Controls.Add(t);
                t.InActiveLook();
            }
        }
        public bool ArrangeTabs()
        {
            this.Controls.Clear();
            //this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            //MessageBox.Show(Tabs.Count.ToString());
            foreach (Tab t in Tabs)
            {
                this.Controls.Add(t);
                t.InActiveLook();
            }
            if (Tabs.Count > 0)
            {
                //Tabs[Tabs.Count - 1].slate.Controls.Clear();
                Tabs[Tabs.Count - 1].Display();
                CurrentTab = Tabs[Tabs.Count - 1];
                Tabs[Tabs.Count - 1].ActiveLook();
                CurrentTab.control.Focus();

            }
            else
            {
                ((Atiran.UI.WindowsForms.UIElements.EnviromentMainForm)this.Parent).slate.Controls.Clear();
                ((Atiran.UI.WindowsForms.UIElements.EnviromentMainForm)this.Parent).slate.Focus();
            }
            return true;
        }
        public bool RemoveTab(Tab tab)
        {
            Tabs.Remove(tab);
            StaticTabs.Remove(tab);
            ArrangeTabs();
            //DoMouseClick();
            return true;
        }
        public void FocuseTab(Guid TabGUID)
        {
            foreach (Tab item in Tabs)
            {
                if (item.control.UcGuid == TabGUID)
                {
                    Tabs[Tabs.FindIndex(a => a.control.UcGuid == TabGUID)].Display();
                    CurrentTab = Tabs[Tabs.FindIndex(a => a.control.UcGuid == TabGUID)];
                    Tabs[Tabs.FindIndex(a => a.control.UcGuid == TabGUID)].ActiveLook();
                    CurrentTab.control.Focus();
                }
            }
        }
        /// <summary>
        ///  به اين دليل اضافه شد كه هميشه اخرين تب بسته ميشد و يك جي يو اي دي در هنگام لود يوزر كنترل ساخته ميشود
        /// </summary>
        /// <param name="TabGuid"></param>
        /// <returns></returns>
        public bool RemoveTab(Guid TabGuid)
        {
            try
            {
                foreach (Tab item in Tabs)
                {
                    if (item.control.UcGuid == TabGuid)
                    {
                        Tabs.Remove(item);
                        StaticTabs.Remove(item);
                        ArrangeTabs();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

            //DoMouseClick();
            return true;
        }
        public bool ChangeTabName(Guid TabGuid, string Message)
        {
            try
            {
                foreach (Tab item in Tabs)
                {
                    if (item.control.UcGuid == TabGuid)
                    {
                        item.Title.Text = Message;
                        item.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 8F, System.Drawing.FontStyle.Regular);
                        return true;
                    }
                }
                foreach (Tab item in StaticTabs)
                {
                    if (item.control.UcGuid == TabGuid)
                    {
                        item.Title.Text = Message;
                        item.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 8F, System.Drawing.FontStyle.Regular);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return true;
        }
        public bool FixTabName(Guid TabGuid, string Message)
        {
            try
            {
                foreach (Tab item in Tabs)
                {
                    if (item.control.UcGuid == TabGuid)
                    {
                        item.Title.Text = Message;
                        item.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 10F, System.Drawing.FontStyle.Regular);
                        return true;
                    }
                }
                foreach (Tab item in StaticTabs)
                {
                    if (item.control.UcGuid == TabGuid)
                    {
                        item.Title.Text = Message;
                        item.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 10F, System.Drawing.FontStyle.Regular);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            return true;
        }
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)900;
            uint Y = (uint)600;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 10, 20);
        }

        void AtiranParent_SizeChanged(object sender, EventArgs e)
        {
            this.Width = AtiranParent.Width - 30;
            /* int sumLength = 0;
             foreach (System.Windows.Forms.Control con in this.Controls)
             {
                 sumLength += con.Width;
             }

             this.Width = sumLength;
             this.Left = AtiranParent.Width - 30 - sumLength;*/
        }


    }
}
