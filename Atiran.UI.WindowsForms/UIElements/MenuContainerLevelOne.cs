using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class MenuContainerLevelOne : MenuContainer
    {
        public MenuContainerLevelOne(Form parent_):base (parent_)
        {

            this.Width = 200;
            this.Height = this.parent.Height - 69-25;
            this.Left = parent.Width;
            this.Top = 69;
            parent.SizeChanged += Parent_SizeChanged;
            parent.Controls.Add(this);
        }

        private void Parent_SizeChanged(object sender, System.EventArgs e)
        {
            this.Width = 200;
            this.Height = parent.Height - 69-25;
            this.Left = parent.Width;
            this.Top = 69;
        }
       
    }
}
