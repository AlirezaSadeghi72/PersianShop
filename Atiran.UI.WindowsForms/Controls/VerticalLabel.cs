using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{

    public class VerticalLabel : System.Windows.Forms.Control
    {
        private string labelText;
        private DrawMode _dm = DrawMode.BottomUp;
        private bool _transparentBG = false;
        System.Drawing.Text.TextRenderingHint _renderMode = System.Drawing.Text.TextRenderingHint.SystemDefault;
        public enum DrawMode
        {
            BottomUp = 1,
            TopBottom
        }

        private System.ComponentModel.Container components = new System.ComponentModel.Container();

        public VerticalLabel()
        {
            base.CreateControl();
            InitializeComponent();
            SetStyle(System.Windows.Forms.ControlStyles.Opaque, true);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!((components == null)))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.Size = new System.Drawing.Size(24, 100);
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            float vlblControlWidth;
            float vlblControlHeight;
            float vlblTransformX;
            float vlblTransformY;

            Color controlBackColor = BackColor;
            Pen labelBorderPen;
            SolidBrush labelBackColorBrush;

            if (_transparentBG)
            {
                labelBorderPen = new Pen(Color.Empty, 0);
                labelBackColorBrush = new SolidBrush(Color.Empty);
            }
            else
            {
                labelBorderPen = new Pen(controlBackColor, 0);
                labelBackColorBrush = new SolidBrush(controlBackColor);
            }

            SolidBrush labelForeColorBrush = new SolidBrush(base.ForeColor);
            base.OnPaint(e);
            vlblControlWidth = this.Size.Width;
            vlblControlHeight = this.Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.TextRenderingHint = this._renderMode;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (this.TextDrawMode == DrawMode.BottomUp)
            {
                vlblTransformX = 0;
                vlblTransformY = vlblControlHeight;
                e.Graphics.TranslateTransform(vlblTransformX, vlblTransformY);
                e.Graphics.RotateTransform(270);
                e.Graphics.DrawString(labelText, Font, labelForeColorBrush, 0, 0);
            }
            else
            {
                vlblTransformX = vlblControlWidth;
                vlblTransformY = vlblControlHeight;
                e.Graphics.TranslateTransform(vlblControlWidth, 0);
                e.Graphics.RotateTransform(90);
                e.Graphics.DrawString(labelText, Font, labelForeColorBrush, 0, 0, StringFormat.GenericTypographic);
            }
        }

        protected override CreateParams CreateParams//v1.10 
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;  // Turn on WS_EX_TRANSPARENT
                return cp;
            }
        }

        private void VerticalTextBox_Resize(object sender, System.EventArgs e)
        {
            Invalidate();
        }

        [Category("Properties"), Description("Rendering mode.")]
        public System.Drawing.Text.TextRenderingHint RenderingMode
        {
            get { return _renderMode; }
            set { _renderMode = value; }
        }

        [Category("VerticalLabel"), Description("Text is displayed vertically in container.")]
        public override string Text
        {
            get
            {
                return labelText;
            }
            set
            {
                labelText = value;
                Invalidate();
            }
        }

        [Category("Properties"), Description("Whether the text will be drawn from Bottom or from Top.")]
        public DrawMode TextDrawMode
        {
            get { return _dm; }
            set { _dm = value; }
        }

        [Category("Properties"), Description("Whether the text will be drawn with transparent background or not.")]
        public bool TransparentBackground
        {
            get { return _transparentBG; }
            set { _transparentBG = value; }
        }
    }
}
