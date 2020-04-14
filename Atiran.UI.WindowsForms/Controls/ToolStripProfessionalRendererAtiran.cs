using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.Services;

namespace Atiran.UI.WindowsForms.Controls
{
    public class ToolStripProfessionalRendererAtiran : ToolStripProfessionalRenderer
    {
        public ToolStripProfessionalRendererAtiran(ref PropertyToolStripProfessionalRenderer propertyToolStripProfessionalRenderer) : base(new MyColors(ref propertyToolStripProfessionalRenderer))
        {
            pro = propertyToolStripProfessionalRenderer;
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowRectangle = Rectangle.Empty;
            if (e.Item.Selected)
            {
                e.Graphics.DrawImage(new Bitmap(Atiran.UI.WindowsForms.Resources.expandleft, new Size(16, 16)), new Point(5, 5));
            }
            else
            {
                e.Graphics.DrawImage(new Bitmap(Atiran.UI.WindowsForms.Resources.expandDown, new Size(16, 16)), new Point(5, 5));
            }
            //base.OnRenderArrow(e);
        }
        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemImage(e);
            if (e.Item.Tag is MyTag && ((MyTag)e.Item.Tag).ParentId > -1)
            {
                if (!e.Item.Selected)
                {
                    e.Graphics.DrawImage(new Bitmap(Atiran.UI.WindowsForms.Resources.LemonChiffon, new Size(16, 16)),
                        new Point(e.Item.ContentRectangle.Right - 19, e.Item.ContentRectangle.Top + 6));
                }
                else
                {
                    e.Graphics.DrawImage(new Bitmap(Atiran.UI.WindowsForms.Resources.Yellow, new Size(16, 16)),
                        new Point(e.Item.ContentRectangle.Right - 19, e.Item.ContentRectangle.Top + 6));
                }
            }
        }
        /// <include file='doc\ToolStripProfessionalRenderer.uex' path='docs/doc[@for="ToolStripProfessionalRenderer.OnRenderItemText"]/*' />
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.Selected)
                e.TextColor = pro.ForColorInHighlight;
            else
                e.TextColor = pro.ForColorOutHighlight;

            e.Item.BackColor = pro.ColorBackGroundHighlight;
            base.OnRenderItemText(e);
        }

        public PropertyToolStripProfessionalRenderer pro;
    }
    public class PropertyToolStripProfessionalRenderer
    {
        public Color ColorBackGroundHighlight { get; set; } = Color.FromArgb(20, 130, 150);
        public Color ColorSelectedHighlight { get; set; } = Color.Teal;
        public Color ForColorInHighlight { get; set; } = Color.White;
        public Color ForColorOutHighlight { get; set; } = Color.White;
        public float FontSize { get; set; } = 10;
    }

    class MyColors : ProfessionalColorTable
    {
        public MyColors(ref PropertyToolStripProfessionalRenderer pro )
        {
            this.pro = pro;
        }
        public PropertyToolStripProfessionalRenderer pro;
        public Color CustomColer => pro.ColorBackGroundHighlight;

        public override Color MenuItemSelected
        {
            get { return CustomColer; }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get { return CustomColer; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return CustomColer; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return CustomColer; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return CustomColer; }
        }
        public override Color ImageMarginGradientBegin
        {
            get { return CustomColer; }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return CustomColer; }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return CustomColer;
            }
        }
        public override Color MenuItemBorder
        {
            get { return Color.Transparent; }
        }
        public override Color ButtonSelectedHighlight => pro.ColorSelectedHighlight; //زماني كه موس روي زير منوها ميرود
        public override Color ButtonCheckedGradientBegin => CustomColer;
        public override Color ButtonCheckedGradientEnd => CustomColer;
        public override Color ButtonCheckedGradientMiddle => CustomColer;
        public override Color ButtonCheckedHighlight => CustomColer;
        public override Color ButtonCheckedHighlightBorder => CustomColer;
        public override Color ButtonPressedBorder => Color.Red;
        public override Color ButtonPressedGradientBegin => Color.Red;
        public override Color ButtonPressedGradientEnd => Color.Red;
        public override Color ButtonPressedGradientMiddle => Color.Red;
        public override Color ButtonPressedHighlight => Color.Red;
        public override Color ButtonPressedHighlightBorder => Color.Red;
        public override Color ButtonSelectedBorder => Color.Red;
        public override Color ToolStripPanelGradientEnd => Color.Red;
        public override Color ToolStripPanelGradientBegin => Color.Red;
        public override Color ToolStripDropDownBackground => CustomColer; // رنگ دور زير منوها
    }
}
