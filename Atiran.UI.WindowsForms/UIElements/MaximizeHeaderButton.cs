using System;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MaximizeHeaderButton: HeaderButton
    {
       
        public MaximizeHeaderButton(Header parent_)
            : base(parent_)
        {
            this.Width = 36;

            if (this.parent.parent.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.BackgroundImage = Resources.Restore_33px;
            }
            else
            {
                this.BackgroundImage = Resources.Max_33px;
            }

            this.Click += MaximizeHeaderButton_Click;
            this.MouseHover += MaximizeHeaderButton_MouseHover;
            this.MouseLeave += MaximizeHeaderButton_MouseLeave;
        }
       
        private void MaximizeHeaderButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.parent.parent.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.BackgroundImage = Resources.Restore_33px;
            }
            else
            {
                this.BackgroundImage = Resources.Max_33px;
            }
        }

        private void MaximizeHeaderButton_MouseHover(object sender, EventArgs e)
        {
            if (this.parent.parent.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.BackgroundImage = Resources.Restore_33px_hover;
            }
            else
            {
                this.BackgroundImage = Resources.Max_33px_hover;
            }
        }     

        void MaximizeHeaderButton_Click(object sender, EventArgs e)
        {
            if (this.parent.parent.WindowState == System.Windows.Forms.FormWindowState.Maximized)
            {
                this.parent.parent.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
            else
            {
                this.parent.parent.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }
    }
}
