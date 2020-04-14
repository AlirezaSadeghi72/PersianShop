using System.Drawing;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class HeaderButton : System.Windows.Forms.Panel
    {
        public Header parent;
        public HeaderButton(Header parent_)
        {
            parent = parent_;
            this.Font = Atiran.UI.WindowsForms.FontManager.GetFont("IRANSans", 11, FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(0);
            if (this.Parent!=null)
            this.Height=this.Parent.Height;
           
        }

      
    }
}
