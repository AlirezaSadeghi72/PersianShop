using Atiran.UI.WindowsForms.Controls;
using System.Drawing;

namespace Atiran.UI.WindowsForms.UIElements
{
    public  class PathHeaderButton : HeaderButton
    {
       public PathHeaderButton(Header parent_, string fiscalYearTitle)
           : base(parent_)
        {
            this.Width = 130;
            this.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);

            this.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);

            Label lblFiscalYear = new Label
            {
                Text = fiscalYearTitle.Trim(),

                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.TopCenter,
                Padding = new System.Windows.Forms.Padding(5, 10, 0, 0),
                Font = FontManager.GetFont("IRANSans", 10F, FontStyle.Regular)
            };
            this.Controls.Add(lblFiscalYear);
        }
    }
}
