using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.MessageBoxes
{
    public class CustomMessageForm : System.Windows.Forms.Form
    {
       
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomMessageForm
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1280, 769);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomMessageForm";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CustomMessageForm_Load);
            this.ResumeLayout(false);

        }
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public CustomMessageForm(string description,string title,string BoxName="i")
        {
            InitializeComponent();
        
        }
        public static string Desc_;
        public static string Title_;
        public static string BoxNum_;
        public static Task<object> Task_;
        public static class CustomMessageBox
        {
            public static DialogResult Show(string title, string description, string BoxName = "i")
            {
                using (var form = new CustomMessageForm(description,title, BoxName))
                {
                    Desc_ = description;
                    Title_ = title;
                    BoxNum_ = BoxName;
                    form.ShowDialog();
                }
                return dialog;
            }
            public static async Task<object> Show(string title, string description, Task<object> t)
            {
                using (var form = new CustomMessageForm(description, title, "l"))
                {
                    Desc_ = description;
                    Title_ = title;
                    BoxNum_ = "l";
                    Task_ = t;
                    form.ShowDialog();
                }
                return await t;
            }
        }

        public static DialogResult dialog;
      private static MessageBoxes.MessageBoxLoading LoadingBox;

        public static void CloseLoading()
        {
            MessageBoxes.MessageBoxLoading.CustomMessageBox.Close();
        }
        private void CustomMessageForm_Load(object sender, EventArgs e)
        {
            if (BoxNum_ == "i")
            {
                MessageBoxes.MessageBoxInfo.CustomMessageBox.Show(Title_, Desc_);
                this.Close();
            }
            if(BoxNum_=="e")
            {
                MessageBoxes.MessageBoxError.CustomMessageBox.Show(Title_,Desc_);
                this.Close();
            }
            if (BoxNum_ == "w")
            {
                MessageBoxes.MessageBoxWarning.CustomMessageBox.Show(Title_, Desc_,ref dialog);
                this.Close();
            }
            if (BoxNum_ == "l")
            {
                MessageBoxes.MessageBoxLoading.CustomMessageBox.Show(Title_, Desc_, Task_, this);
            }
        }
    }
}
