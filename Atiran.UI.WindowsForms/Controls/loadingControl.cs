using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.Controls
{
   public class loadingControl:UI.WindowsForms.Controls.UserControl
    {
        private UIElements.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Label label1;

        public loadingControl(string TextLoading)
        {
            InitializeComponent();
            label1.Text = TextLoading;
        }
        public loadingControl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 22);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 22);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Atiran.UI.WindowsForms.Resources._376;
            this.pictureBox1.Location = new System.Drawing.Point(84, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 58);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // loadingControl
            // 
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "loadingControl";
            this.Size = new System.Drawing.Size(254, 86);
            this.Load += new System.EventHandler(this.loadingControl_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void loadingControl_Load(object sender, EventArgs e)
        {
         
           
        }
    }
}
