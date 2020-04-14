using Atiran.UI.WindowsForms.Controls;
using System.Collections.Generic;
using System.Drawing;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class ShortcutHeaderButton : HeaderButton
    {
        public Header header;
        public ShortcutHeaderButton(Header parent_, string ShortcutName)
            : base(parent_)
        {
            this.Width = 130;
            this.BackColor = System.Drawing.Color.FromArgb(120, 144, 156);

            this.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);

            Label lblShortcut = new Label
            {
                Text = ShortcutName,

                Dock = System.Windows.Forms.DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.TopCenter,
                Padding = new System.Windows.Forms.Padding(5, 10, 0, 0),
                Font = FontManager.GetFont("IRANSans", 10F, FontStyle.Regular),
            };
            lblShortcut.MouseHover += (sender, e) =>
            {
                lblShortcut.BackColor = Color.Khaki;
                lblShortcut.ForeColor = Color.Black;
                lblShortcut.Cursor = System.Windows.Forms.Cursors.Hand;
            };
            lblShortcut.MouseLeave += (sender, e) =>
            {
                lblShortcut.BackColor = Color.Transparent;
                lblShortcut.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            };
            lblShortcut.MouseClick += (sender, e) =>
            {
                try
                {
                    System.Threading.Thread.Sleep(20);
                    System.Windows.Forms.SendKeys.Send("%{Home}");
                    System.Windows.Forms.SendKeys.Send("%{F7}");
                }
                catch (System.Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            };
            this.Controls.Add(lblShortcut);
        }
    }
}
