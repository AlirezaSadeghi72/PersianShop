using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class HelpControl : UI.WindowsForms.Controls.UserControl
    {
        public System.String Texthelp { get; set; }
        private PictureBox userImage;
        private Panel panel1;
        private RichTextBox richTextBox1;
        public HelpControl()
        {
            InitializeComponent();
            this.Width = 32;
            this.Height = 29;
        }
        private void InitializeComponent()
        {
            this.userImage = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).BeginInit();
            this.SuspendLayout();
            // 
            // userImage
            // 
            this.userImage.BackColor = System.Drawing.Color.White;
            this.userImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userImage.Image = global::Atiran.UI.WindowsForms.Resources._376;
            this.userImage.Location = new System.Drawing.Point(0, 0);
            this.userImage.Name = "userImage";
            this.userImage.Size = new System.Drawing.Size(532, 167);
            this.userImage.TabIndex = 0;
            this.userImage.TabStop = false;
            this.userImage.MouseLeave += new System.EventHandler(this.userImage_MouseLeave);
            this.userImage.MouseHover += new System.EventHandler(this.userImage_MouseHover);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.richTextBox1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.richTextBox1.Location = new System.Drawing.Point(29, 28);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(502, 139);
            this.richTextBox1.TabIndex = 16;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(30, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 25);
            this.panel1.TabIndex = 19;
            // 
            // HelpControl
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.userImage);
            this.Name = "HelpControl";
            this.Size = new System.Drawing.Size(532, 167);
            ((System.ComponentModel.ISupportInitialize)(this.userImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void setControls(bool StateVisable = true)
        {
            if (Texthelp == null || Texthelp == string.Empty)
            {
                Texthelp = "در صورت خالي بودن هر كدام از فيلدها همه ي مقادير آن انتخاب خواهد شد";
            }
            richTextBox1.Text = Texthelp;
            if (StateVisable == true)
            {
                richTextBox1.Visible = true;
                richTextBox1.Height = richTextBox1.Text.Length;//(richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length) + (richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length)/5)) ;
                                                               // richTextBox1.Font.Height + richTextBox1.Margin.Vertical;
                                                               //if (richTextBox1.Size.Height > 66)
                richTextBox1.BringToFront();
                this.Size = new Size(450, richTextBox1.Height + 25);

            }
            else
            {
                richTextBox1.Visible = false;
                this.Width = 32;
                this.Height = 29;
            }
        }
        private void userImage_MouseHover(object sender, EventArgs e)
        {
            setControls(true);
            this.BringToFront();
        }

        private void userImage_MouseLeave(object sender, EventArgs e)
        {
            setControls(false);
        }
    }
}
