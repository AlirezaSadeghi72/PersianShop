namespace Atiran.UI.WindowsForms.UIElements
{
    public class HeaderSeperator : Panel
    {
       public Panel top;
       public Panel bottom;
       public System.Windows.Forms.FlowLayoutPanel parent;
        
       
        public HeaderSeperator(System.Windows.Forms.FlowLayoutPanel parent_)
        {
            this.Margin = new System.Windows.Forms.Padding(0);
            parent = parent_;
            this.Width = 1;
            this.Height = parent_.Height;
            
            this.BackColor = System.Drawing.Color.FromArgb(147,166,176);
            this.BringToFront();
           
            top = new Panel();
            bottom = new Panel();

            top.Height = 8;
            top.Dock = System.Windows.Forms.DockStyle.Top;

            bottom.Height = 6;
            bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Controls.Add(bottom);
            this.Controls.Add(top);

            top.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);
            bottom.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);
            
        }
    }
}
