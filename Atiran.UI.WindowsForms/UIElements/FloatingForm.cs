using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements 
{
    public class FloatingForm : Form 
    {
        public FloatingForm()
        {
            this.ControlAdded += FloatingForm_ControlAdded;
            this.MinimumSize = new System.Drawing.Size(1024, 680);
            this.header = new Header(this);
            this.header.Height = 39;
            this.header.Left = 0;
            this.header.Top = 0;
            this.Controls.Add(this.header);
            this.slate = new Panel();
            slate.Top = 39;
            slate.Left = 0;
            slate.Width = this.Width;
            slate.Height = this.Height - 25 - 39;
            this.SizeChanged += FloatingForm_SizeChanged;
            this.Controls.Add(slate);
            slate.ControlAdded += Slate_ControlAdded;
            this.sizeGrip = new SizeGrip(this);
            this.sizeGrip.BringToFront();
        }

        private void Slate_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            FixHeight();
        }

        private void FloatingForm_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            FixHeight();
        }

        public void FixHeight()
        {
            int height = 0;
            foreach (System.Windows.Forms.Control c in slate.Controls)
            {
                height += c.Height;
            }
            slate.Height = height;
            height = 0;
            foreach (System.Windows.Forms.Control c in this.Controls)
            {
                height += c.Height;
            }
            this.Height = height;
        }
        protected override void OnClick(EventArgs e)
        {
            ((Form)this.ParentForm).subMenus.ForEach(i => i.Visible = false);
            base.OnClick(e);
        }
        private void FloatingForm_SizeChanged(object sender, EventArgs e)
        {
            slate.Top = 39;
            slate.Left = 0;
            slate.Width = this.Width;
            slate.Height = this.Height - 25 - 39;
        }
    }
}
