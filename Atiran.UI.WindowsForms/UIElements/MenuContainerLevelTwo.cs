using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MenuContainerLevelTwo : MenuContainer
    {
        MenuContainer hLevelContainer;
        MenuButton hLevelButton;
        public MenuContainerLevelTwo(Form parent_, MenuContainer hLevelContainer_, MenuButton hLevelButton_) : base(parent_)
        {
            hLevelContainer = hLevelContainer_;
            hLevelButton = hLevelButton_;
            this.VisibleChanged += MenuContainerLevelTwo_VisibleChanged;
            this.ControlAdded += MenuContainerLevelTwo_ControlAdded;
            this.MouseEnter += MenuContainerLevelTwo_MouseEnter;
            this.Paint += MenuContainerLevelTwo_Paint;
            this.Width = 300;
            this.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.WrapContents = false;
         //   this.AutoScroll = true;
        }

        private void MenuContainerLevelTwo_Paint(object sender, PaintEventArgs e)
        {
        }

        private void MenuContainerLevelTwo_MouseEnter(object sender, System.EventArgs e)
        {
            this.Focus();
        }

        private void MenuContainerLevelTwo_ControlAdded(object sender, ControlEventArgs e)
        {
            int height = 0;
            foreach (System.Windows.Forms.Control c in this.Controls)
            {
                height += c.Height;
                this.Height = height+30;
            }
        }
   
        private void MenuContainerLevelTwo_VisibleChanged(object sender, System.EventArgs e)
        {
            this.Top = hLevelContainer.Top + hLevelButton.Top;
            this.Left = hLevelContainer.Left - 300;
        }
    }
}
