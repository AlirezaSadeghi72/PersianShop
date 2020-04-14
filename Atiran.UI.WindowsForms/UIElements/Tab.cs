using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class Tab : System.Windows.Forms.FlowLayoutPanel
    {
        public System.Windows.Forms.Panel Close;
        public System.Windows.Forms.Label Title;
        public Atiran.UI.WindowsForms.Controls.UserControl control;
        public Control controlClicked;
        public string ID;
        public int Kind;
        public Panel slate;
        public TabBar parent;
        public int flagGrip;
        int x = 0, y = 0;
        public ToolTip tt;
        public Tab()
        {

        }
        public Tab(TabBar parent_, string title_, Atiran.UI.WindowsForms.Controls.UserControl control_, Panel slate_)
        {
            try
            {
                var AskedList = new System.Collections.Generic.List<string> { "Invoice", "FactorKharid", "Daryaft", "Pardakht", "ShopFactor", "PishFactorForosh", "PishFactorKharid" };
                tt = new ToolTip();
                this.Font = UI.WindowsForms.FontManager.GetFont("IRANSans", 9.5f, FontStyle.Regular);
                this.AllowDrop = true;
                flagGrip = 0;
                ID = System.Guid.NewGuid().ToString("N");
                Kind = (AskedList.Contains(control_.Name)) ? 1 : 0;
                control = control_;
                slate = slate_;
                parent = parent_;
                this.Margin = System.Windows.Forms.Padding.Empty;
                this.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
                Close = new System.Windows.Forms.Panel();
                Title = new System.Windows.Forms.Label();

                Close.BackColor = slate.BackColor;
                Close.Width = 35;
                Close.Height = 30;
                Close.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Close_Tab_Active") as Bitmap;

                Close.Margin = System.Windows.Forms.Padding.Empty;
                Title.Height = 30;
                Title.Width = 169;
                Title.Top = 60;
                Title.TextAlign = ContentAlignment.MiddleLeft;
                Title.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
                Title.Text = replaceByDot(title_);
                tt.SetToolTip(Title, title_);
                Title.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Tab_23_Active") as Bitmap;

                Title.Margin = System.Windows.Forms.Padding.Empty;
                Title.Click += Title_Click;
                Close.Click += Close_Click;
                Title.DoubleClick += Title_DoubleClick1;

                Title.DoubleClick += Title_DoubleClick;
                Title.MouseDown += Title_MouseDown;
                Title.MouseUp += Title_MouseUp;
                Title.MouseMove += Title_MouseMove;
                this.ControlAdded += Tab_ControlAdded;
                this.Controls.Add(Close);
                this.Controls.Add(Title);
                controlClicked = control.GetContainerControl().ActiveControl;
                slate.Click += Slate_Click;
                if (controlClicked != null)
                {
                    controlClicked = controlClicked.Parent;
                    controlClicked.Click += ControlClicked_Click;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "/n" + ex.InnerException);
            }

        }
        private void Title_DoubleClick1(object sender, EventArgs e)
        {
            parent.RemoveTab(this);
            FloatingForm f = new FloatingForm();
            f.slate.Controls.Add(this.control);
            f.Show();
            parent.ArrangeTabs();
            flagGrip = 0;
        }
        private void Slate_Click(object sender, EventArgs e)
        {
            DisableMenu();
        }
        private void ControlClicked_Click(object sender, EventArgs e)
        {
            DisableMenu();
        }
        private string replaceByDot(string input)
        {

            int length = input.Length;
            StringBuilder sb = new StringBuilder(input);


            if (length > 25)
            {
                for (int i = 22; i < 25; i++)
                    sb[i] = '.';
                return sb.ToString().Substring(0, 25);

            }
            else
                return input;
        }
        private void Title_MouseMove(object sender, MouseEventArgs e)
        {
            if (flagGrip == 1)
            {
                if ((y + 5) == MousePosition.Y || (y - 5) == MousePosition.Y)
                {
                    //Create Floating Window
                    parent.RemoveTab(this);
                    FloatingForm f = new FloatingForm();
                    f.slate.Controls.Add(this.control);
                    f.Show();
                    parent.ArrangeTabs();
                    flagGrip = 0;
                }

            }
        }
        private void Title_MouseUp(object sender, MouseEventArgs e)
        {
            flagGrip = 0;
        }
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            flagGrip = 1;
            x = MousePosition.X;
            y = MousePosition.Y;
        }
        private void Title_DoubleClick(object sender, System.EventArgs e)
        {

        }
        private void Close_Click(object sender, System.EventArgs e)
        {
            if (this.slate.Controls.Find("TraceOnline", false).Length > 0)
            {
                Control crt = this.slate.Controls.Find("TraceOnline", false)[0];
                crt.Dispose();
            }
            parent.RemoveTab(this);
        }
        private void DisableMenu()
        {
            if (parent.AtiranParent.menu != null)
            {
                parent.AtiranParent.menu.SendToBack();
                parent.AtiranParent.slate.BringToFront();
            }
        }
        private void Title_Click(object sender, System.EventArgs e)
        {
            Display();
            DisableMenu();
        }
        void Tab_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            int sumLength = 0;
            foreach (System.Windows.Forms.Control con in this.Controls)
            {
                sumLength += con.Width;
            }

            this.Width = sumLength;
        }
        public void Display()
        {
            try
            {
                this.control.Dock = System.Windows.Forms.DockStyle.Fill;
                this.slate.Controls.Clear();
                this.slate.Controls.Add(control);
                parent.InActiveLookForAll();
                ActiveLook();
                control.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ActiveLook()
        {
            Close.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Close_Tab_Active") as Bitmap;
            Title.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Tab_23_Active") as Bitmap;
        }
        public void InActiveLook()
        {
            Close.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Close_Tab") as Bitmap;
            Title.BackgroundImage = Atiran.UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("Tab_23") as Bitmap;
        }
    }
}
