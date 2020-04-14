using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = Atiran.UI.WindowsForms.Controls.Label;

namespace Atiran.UI.WindowsForms.MessageBoxes
{
    public class MessageBoxLoading : System.Windows.Forms.Form
    {
        private Label richTextBox1;
        private UIElements.Panel panel1;
        public Controls.Label label2;
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
            this.richTextBox1 = new Label();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.label2 = new Atiran.UI.WindowsForms.Controls.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(383, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 49);
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
            this.richTextBox1.Location = new System.Drawing.Point(28, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox1.Size = new System.Drawing.Size(333, 57);
            this.richTextBox1.TabIndex = 15;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 28);
            this.panel1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("IRANSans(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(316, 1);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(143, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "کمی صبر کنید ...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageBoxLoading
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 186);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBoxLoading";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.CustomMessageForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        public MessageBoxLoading(string description, string title)
        {
            InitializeComponent();
            this.richTextBox1.Text = description;
            if (string.IsNullOrEmpty(title))
                title = "کمی صبر کنید ...";
            this.label2.Text = title;
            
        }

        public static class CustomMessageBox
        {
            private static Form form;
            private static Form parrent;
            public static async Task<object> Show(string title, string description, Task<object> t, Form parrent)
            {
                CustomMessageBox.parrent = parrent;
                form = new MessageBoxLoading(description, title);
                {
                    if (t != null)
                    {
                        if (!t.IsCompleted)
                        {
                            t.GetAwaiter().OnCompleted(Close);
                            form.ShowDialog();
                        }
                        else
                        {
                            parrent?.Close();
                            parrent = null;
                        }
                    }
                }
                return await t;
            }
            public static void Show(string title, string description)
            {
                using (Form form = new MessageBoxInfo(description, title))
                {
                    form.ShowDialog();
                }
            }

            public static void Close()
            {
                form?.Close();
                parrent?.Close();
            }
        }
        private void CustomMessageForm_Shown(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.Information;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Image img = UI.WindowsForms.ResourceManager.GetResourceManager().GetObject("loader") as Bitmap;
//            pictureBox1.Width = img.Width;
//            pictureBox1.Height = img.Height;
            pictureBox1.Image = img;
            //if (label2.Location.X+label2.Size.Width>this.Size.Width)
            //{
            //    int loc = label2.Location.X- this.Location.X+120;
            //    label2.Location = new System.Drawing.Point(label2.Location.X + loc, label2.Location.Y);
            //}
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        
        
    }
}
