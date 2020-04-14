using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.MessageBoxes
{
    public class MessageBoxError : System.Windows.Forms.Form
    {
        public Controls.Label label2;
        private RichTextBox richTextBox1;
        private UIElements.Panel panel1;
        private UIElements.Panel panel2;
        private Controls.Buttons.OkButton okButton1;
        private PictureBox pictureBox1;
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.label2 = new Atiran.UI.WindowsForms.Controls.Label();
            this.panel2 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.okButton1 = new Atiran.UI.WindowsForms.Controls.Buttons.OkButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(383, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 53);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("IRANSans(FaNum)", 10.75F);
            this.richTextBox1.Location = new System.Drawing.Point(27, 66);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(337, 66);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            this.richTextBox1.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBox1_ContentsResized);
            this.richTextBox1.Enter += new System.EventHandler(this.richTextBox1_Enter);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(44)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 28);
            this.panel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("IRANSans(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(212, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(238, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "خطا";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.okButton1);
            this.panel2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel2.Location = new System.Drawing.Point(12, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 47);
            this.panel2.TabIndex = 18;
            // 
            // okButton1
            // 
            this.okButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(142)))), ((int)(((byte)(174)))));
            this.okButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okButton1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.okButton1.ForeColor = System.Drawing.Color.White;
            this.okButton1.Location = new System.Drawing.Point(15, 1);
            this.okButton1.Name = "okButton1";
            this.okButton1.NextControl = null;
            this.okButton1.Size = new System.Drawing.Size(81, 34);
            this.okButton1.TabIndex = 19;
            this.okButton1.Text = "تاييد";
            this.okButton1.UseVisualStyleBackColor = false;
            this.okButton1.Click += new System.EventHandler(this.okButton1_Click);
            this.okButton1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // MessageBoxError
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 186);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxError";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CustomMessageForm_Load);
            this.Shown += new System.EventHandler(this.CustomMessageForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
            public MessageBoxError(string description,string title)
            {
                InitializeComponent();
                this.richTextBox1.Text = description;
                this.label2.Text = title;
            }

        public static class CustomMessageBox
        {

            public static void Show(string title, string description)
            {
                using (var form = new MessageBoxError(description, title))
                {
                    form.ShowDialog();
                }
            }
        }

        private void okButton1_Click(object sender, EventArgs e)
        {

          this.Close();

        }

        private void CustomMessageForm_Shown(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.error;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //if (label2.Location.X+label2.Size.Width>this.Size.Width)
            //{
            //    int loc = label2.Location.X- this.Location.X+120;
            //    label2.Location = new System.Drawing.Point(label2.Location.X + loc, label2.Location.Y);
            //}
        }

        private void CustomMessageForm_Load(object sender, EventArgs e)
        {
               okButton1.Focus();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            okButton1.Focus();
        }

        private void richTextBox1_ContentsResized(object sender, ContentsResizedEventArgs e)
        {
            richTextBox1.Height = (richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length) + 2) *
                  richTextBox1.Font.Height + richTextBox1.Margin.Vertical;
                 if (richTextBox1.Size.Height> 66)
                this.Size = new Size(this.Width, richTextBox1.Height+120);
            
        }
    }
}
