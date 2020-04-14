using Atiran.UI.WindowsForms.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.Settings
{
    class FieldPermission: Atiran.UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.UIElements.Panel panel1;

        public FieldPermission()
        {

        }

        private void InitializeComponent()
        {
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 121);
            this.panel1.TabIndex = 0;
            // 
            // FieldPermission
            // 
            this.Controls.Add(this.panel1);
            this.Name = "FieldPermission";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1280, 768);
            this.ResumeLayout(false);

        }
    }
}
