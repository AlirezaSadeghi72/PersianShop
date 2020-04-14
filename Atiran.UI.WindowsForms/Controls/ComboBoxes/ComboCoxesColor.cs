using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls.ComboBoxes
{
    class ComboCoxesColor: ComboBox
    {
        public ComboCoxesColor():base()
        {
            if (!this.DesignMode)
            {
                Type colorType = typeof(System.Drawing.Color);
                PropertyInfo[] propInfoList = colorType.GetProperties();
                this.Items.AddRange(propInfoList.Where(w => w.PropertyType == typeof(System.Drawing.Color))
                    .Select(s => s.Name).ToArray());
            }

            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ComboBoxColor_DrawItem);
        }
        private void ComboBoxColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((System.Windows.Forms.ComboBox)sender).Items[e.Index].ToString();
                Font f = new System.Drawing.Font("AtiranFont", 9.5F);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5,
                    rect.Width - 10, rect.Height - 10);
            }
        }
        public void SelectedIndexComboBoxColorOfNameColor(string NameColor)
        {
            if (this.Items.IndexOf(NameColor) != -1)
            {
                this.SelectedIndex = this.Items.IndexOf(NameColor);
            }
            else
            {
                this.Text = "";
            }
        }
    }
}
