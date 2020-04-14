namespace Atiran.UI.WindowsForms.UIElements
{
    public class HomeHeaderButton : HeaderButton
    {
        public HomeHeaderButton(Header parent_): base(parent_)
        {
            this.Width = 36;
            this.BackgroundImage = Resources.Home_36px;

            this.Click += HomeHeaderButton_Click;
            this.MouseHover += HomeHeaderButton_MouseHover;
            this.MouseLeave += HomeHeaderButton_MouseLeave;
        }

        private void HomeHeaderButton_MouseLeave(object sender, System.EventArgs e)
        {
            this.BackgroundImage = Resources.Home_36px;
        }

        private void HomeHeaderButton_MouseHover(object sender, System.EventArgs e)
        {
            this.BackgroundImage = Resources.Home_36px_hover;
        }
        public void BackToHome()
        {
            this.parent.parent.WindowState = System.Windows.Forms.FormWindowState.Minimized;
        }
        private void HomeHeaderButton_Click(object sender, System.EventArgs e)
        {
            BackToHome();
        }
    }
}
