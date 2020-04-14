using System;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MinimizeHeaderButton : HeaderButton
    {
        public MinimizeHeaderButton(Header parent_)
            : base(parent_)
        {
            this.Width = 36;
            //this.BackColor = System.Drawing.Color.Blue;
            this.BackgroundImage = Resources.Mix_39px;
            this.Click += MinimizeHeaderButton_Click;
            this.MouseHover += MinimizeHeaderButton_MouseHover;
            this.MouseLeave += MinimizeHeaderButton_MouseLeave;
        }
        private void MinimizeHeaderButton_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Mix_39px;
        }

        private void MinimizeHeaderButton_MouseHover(object sender, EventArgs e)
        {
            this.BackgroundImage = Resources.Mix_39px_hover;
        }

        void MinimizeHeaderButton_Click(object sender, EventArgs e)
        {
            this.parent.parent.WindowState = System.Windows.Forms.FormWindowState.Minimized;
           
        }
    }
}
