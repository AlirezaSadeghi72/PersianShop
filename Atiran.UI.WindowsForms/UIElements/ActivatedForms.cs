using Atiran.UI.WindowsForms.Controls;
using System.Drawing;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class ActivatedForms : HeaderButton
    {
        public ActivatedForms(Header parent_, string ActivatedFormName)
            : base(parent_)
        {
            this.Width = 130;
            this.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);

            this.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);

            Label lblActivatedForms = new Label
            {
                Text = ActivatedFormName,

                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.TopCenter,
                Padding = new System.Windows.Forms.Padding(5, 10, 0, 0),
                Font = FontManager.GetFont("IRANSans", 10F, FontStyle.Regular),
            };
            lblActivatedForms.MouseHover += (sender, e) =>
            {
                lblActivatedForms.BackColor = Color.Khaki;
                lblActivatedForms.ForeColor = Color.Black;
                lblActivatedForms.Cursor = System.Windows.Forms.Cursors.Hand;
            };
            lblActivatedForms.MouseLeave += (sender, e) =>
            {
                lblActivatedForms.BackColor = Color.Transparent;
                lblActivatedForms.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            };
            lblActivatedForms.MouseClick += (sender, e) =>
            {
                System.Threading.Thread.Sleep(20);
                System.Windows.Forms.SendKeys.Send("%{F6}");
            };
            this.Controls.Add(lblActivatedForms);
        }
    }
}
