using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{
    public class QuestionMarkControl : Atiran.UI.WindowsForms.Controls.UserControl
    {
        private pictureBox pictureBox1;

        public string MyTextHover { get; set; }
        public int HoverTime { get; set; } = 10000;
        private ToolTip tt = new ToolTip();
        public QuestionMarkControl()
        {
            InitializeComponent();
            }
        private void InitializeComponent()
        {
            this.pictureBox1 = new Atiran.UI.WindowsForms.Controls.pictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Atiran.UI.WindowsForms.Resources.question;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.PictureBox1_MouseHover);
            // 
            // QuestionMarkControl
            // 
            this.Controls.Add(this.pictureBox1);
            this.Name = "QuestionMarkControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(29, 33);
            this.Load += new System.EventHandler(this.QuestionMarkControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            tt.RemoveAll();
        }

        private void PictureBox1_MouseHover(object sender, EventArgs e)
        {
            tt.Show(MyTextHover, pictureBox1, 0, 30, HoverTime);
        }

        private void QuestionMarkControl_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.ParentForm.Closing += (s1, e1) =>
                {
                    tt.RemoveAll();
                    tt.Dispose();
                };
            }
        }
    }
}
