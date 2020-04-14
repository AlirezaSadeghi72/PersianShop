using System;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class Header : System.Windows.Forms.Panel
    {
        public bool ReadyToMove { get; set; }
        public int PreviousX { get; set; }
        public int PreviousY { get; set; }
        public bool MovedOut { get; set; }

        public Form parent;
        public System.Windows.Forms.FlowLayoutPanel rightPanel;
        public System.Windows.Forms.FlowLayoutPanel leftPanel;
        public System.Windows.Forms.Panel bottomPanel;
        public System.Windows.Forms.Panel TopPanel;

        public Header(Form parent_)
        {
            parent = parent_;
            this.Top = 0;
            this.Left = 0;
            this.Width = parent.Width;

            parent.Resize += Parent_Resize;
            this.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.Height = 46;

            this.TopPanel = new Panel();
            this.TopPanel.Height = 39;
            this.TopPanel.Dock = DockStyle.Top;
          
            this.Controls.Add(TopPanel);


            this.bottomPanel = new Panel();
            this.bottomPanel.Height = 7;
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.BackColor = System.Drawing.Color.FromArgb(255,204,0);
            this.Controls.Add(bottomPanel); 


            leftPanel = new System.Windows.Forms.FlowLayoutPanel();
            leftPanel.Margin = System.Windows.Forms.Padding.Empty;
            leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            leftPanel.ControlAdded += LayoutPanel_ControlAdded;
            leftPanel.Width = 0;
            leftPanel.BackColor = System.Drawing.Color.Pink;
            leftPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;


            TopPanel.Controls.Add(leftPanel);
            
            rightPanel = new System.Windows.Forms.FlowLayoutPanel();
            rightPanel.Margin = System.Windows.Forms.Padding.Empty;
            rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            rightPanel.ControlAdded += LayoutPanel_ControlAdded;
            rightPanel.Width = 0;
            rightPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            TopPanel.Controls.Add(rightPanel);

            this.DoubleClick += Header_DoubleClick;

            //Draging
            this.TopPanel.MouseDown += Header_MouseDown;
            this.TopPanel.MouseUp += Header_MouseUp;
            this.TopPanel.MouseMove += Header_MouseMove;
        }

        private void Header_DoubleClick(object sender, EventArgs e)
        {
            if (this.parent.WindowState == FormWindowState.Normal)
                this.parent.WindowState = FormWindowState.Maximized;

            else if (this.parent.WindowState == FormWindowState.Minimized)
                this.parent.WindowState = FormWindowState.Normal;
        }

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            ReadyToMove = true;
            PreviousX = e.X;
            PreviousY = e.Y;

            this.parent.paintFlag = false;
            this.parent.BackgroundImage = null;
            this.parent.Refresh();
        }

        private void Header_MouseUp(object sender, MouseEventArgs e)
        {
            ReadyToMove = false;
            PreviousY = 0;
            PreviousX = 0;

            this.parent.paintFlag = true;
            this.parent.Invalidate();
        }

        private void Header_MouseMove(object sender, MouseEventArgs e)
        {
            if (ReadyToMove)
            {
                this.parent.WindowState = System.Windows.Forms.FormWindowState.Normal;

                if (this.parent != null)
                {
                    this.parent.Top = this.parent.Top + (e.Y - PreviousY);
                    this.parent.Left = this.parent.Left + (e.X - PreviousX);
                }
            }
        }

        private void LayoutPanel_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            int width = 0;
            foreach (System.Windows.Forms.Control con in ((System.Windows.Forms.FlowLayoutPanel)sender).Controls)
            {
                width += con.Width;
            }
            ((System.Windows.Forms.FlowLayoutPanel)sender).Width = width;
        }

        void Parent_Resize(object sender, EventArgs e)
        {
            if (this.Parent != null)
                this.Width = this.Parent.Width;
        }
    }
}
