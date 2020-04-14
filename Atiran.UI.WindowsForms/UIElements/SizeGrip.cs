using System;
using System.Drawing;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class SizeGrip : System.Windows.Forms.Label
    {
        public bool ReadyToMove { get; set; }
        public int PreviousX { get; set; }
        public int PreviousY { get; set; }

        Atiran.UI.WindowsForms.UIElements.Form parentForm;

        public SizeGrip(Atiran.UI.WindowsForms.UIElements.Form _parentForm)
        {
            this.Width = 20;
            this.Height = 20;
            //this.BackColor = System.Drawing.Color.Green;
            this.Image = Resources.Size_Grip_20px;
            this.BackColor = Color.Transparent;

            parentForm = _parentForm;
            this.Location = new Point(parentForm.Width - 25, parentForm.Height - 25);
            parentForm.SizeChanged += ParentForm_SizeChanged;

            this.MouseDown += SizeGrip_MouseDown;
            this.MouseMove += SizeGrip_MouseMove;
            this.MouseUp += SizeGrip_MouseUp;
            _parentForm.Controls.Add(this);
        }

        private void ParentForm_SizeChanged(object sender, EventArgs e)
        {
            this.Location = new Point(parentForm.Width - 25, parentForm.Height - 25);
            this.BringToFront();
        }

        private void SizeGrip_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ReadyToMove = false;
            PreviousY = 0;
            PreviousX = 0;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeNWSE;

            this.parentForm.paintFlag = true;
            this.parentForm.Invalidate();
        }

        private void SizeGrip_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(ReadyToMove)
            {
                this.parentForm.Height = this.parentForm.Height + (e.Y - PreviousY);
                this.parentForm.Width = this.parentForm.Width + (e.X - PreviousX);

                this.Refresh();
            }
        }

        private void SizeGrip_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.SizeNWSE;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.parentForm.paintFlag = false;
                this.parentForm.BackgroundImage = null;
                this.parentForm.Refresh();

                this.parentForm.WindowState = System.Windows.Forms.FormWindowState.Normal;
                ReadyToMove = true;
                PreviousX = e.X;
                PreviousY = e.Y;
            }
        }
    }
}
