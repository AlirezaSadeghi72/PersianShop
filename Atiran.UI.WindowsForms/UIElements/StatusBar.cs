namespace Atiran.UI.WindowsForms.UIElements
{
    public class StatusBar : System.Windows.Forms.Panel
    {
        public Atiran.UI.WindowsForms.UIElements.Form parentForm;
        public string Message {
            get
            {
                return Message;
            }
            set
            {
                lblMessage.Text = value;
            }
        }
        private RTLLabel lblMessage;

        public StatusBar(Atiran.UI.WindowsForms.UIElements.Form _parentForm)
        {
            parentForm = _parentForm;
            this.Height = 25;
            this.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.Width = _parentForm.Width - 25;
            this.Left = 0;
            this.Top = _parentForm.Height - 25;
           

            lblMessage = new RTLLabel();
            lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Controls.Add(lblMessage);
           
            parentForm.SizeChanged += parentForm_SizeChanged;
            parentForm.Controls.Add(this);

        }

        private void parentForm_SizeChanged(object sender, System.EventArgs e)
        {
            this.Height = 25;
            this.Width = parentForm.Width - 25;
            this.Left = 0;
            this.Top = parentForm.Height - 25;
            this.BringToFront();
        }
    }
}
