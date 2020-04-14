using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Atiran.UI.WindowsForms.UIElements
{
    public class EnvironmentTitleHeaderButton : HeaderButton
    {
        System.Windows.Forms.Label Title;
       
        public EnvironmentTitleHeaderButton(Header header,string title, Color color): base(header)
        {
            
            this.Width = 200;
            this.BackColor = System.Drawing.Color.FromArgb(120,144,156);
            this.ForeColor = color;
            
            Title = new System.Windows.Forms.Label();
            Title.Text = title;
            Title.TextAlign = ContentAlignment.MiddleLeft;
            Title.Font = FontManager.GetFont("IRANSans", 10, System.Drawing.FontStyle.Bold);
            Title.Padding = new System.Windows.Forms.Padding(0, 10, 5, 0);

            Title.Dock = System.Windows.Forms.DockStyle.Fill;
            Title.TextAlign = ContentAlignment.TopRight;
            this.Controls.Add(Title);

         //   HeaderSeperator seperator = new HeaderSeperator(this);
           // seperator.Dock = System.Windows.Forms.DockStyle.Right;
           // this.Controls.Add(seperator);
        }
    }
}
