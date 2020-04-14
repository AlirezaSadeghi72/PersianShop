using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Atiran.CustomDocking.MessageBox
{
    public class YesNoMessageBox : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label lblCaption;
        private PictureBox pictureBox1;
        private Panel pnlButtons;
        private Button btnNo;
        private Button btnYes;
        private System.Windows.Forms.Panel pnlTop;
        private Button btnNoAll;
        private Button btnYesAll;
        public bool LoadOnYesButton = true;
        private ListBox txtMessage;
        public bool ShowAllButton = true;
        public YesNoMessageBox()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblCaption = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.ListBox();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnNoAll = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYesAll = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTop.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.pnlTop.Controls.Add(this.lblCaption);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(462, 28);
            this.pnlTop.TabIndex = 0;
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCaption.Location = new System.Drawing.Point(294, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblCaption.Size = new System.Drawing.Size(156, 25);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "توضيحات";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMessage
            // 
            this.txtMessage.FormattingEnabled = true;
            this.txtMessage.ItemHeight = 22;
            this.txtMessage.Location = new System.Drawing.Point(23, 47);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(343, 70);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.TabStop = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlButtons.Controls.Add(this.btnNoAll);
            this.pnlButtons.Controls.Add(this.btnNo);
            this.pnlButtons.Controls.Add(this.btnYesAll);
            this.pnlButtons.Controls.Add(this.btnYes);
            this.pnlButtons.Location = new System.Drawing.Point(0, 136);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(382, 47);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnNoAll
            // 
            this.btnNoAll.BackColor = System.Drawing.Color.White;
            this.btnNoAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNoAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNoAll.ForeColor = System.Drawing.Color.Gray;
            this.btnNoAll.Location = new System.Drawing.Point(200, 2);
            this.btnNoAll.Name = "btnNoAll";
            this.btnNoAll.Size = new System.Drawing.Size(81, 34);
            this.btnNoAll.TabIndex = 0;
            this.btnNoAll.Text = "انصراف";
            this.btnNoAll.UseVisualStyleBackColor = false;
            this.btnNoAll.Enter += new System.EventHandler(this.Button_Enter);
            this.btnNoAll.Leave += new System.EventHandler(this.Button_Leave);
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.Color.White;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNo.ForeColor = System.Drawing.Color.Gray;
            this.btnNo.Location = new System.Drawing.Point(23, 2);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(81, 34);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "خير";
            this.btnNo.UseVisualStyleBackColor = false;
            this.btnNo.Enter += new System.EventHandler(this.Button_Enter);
            this.btnNo.Leave += new System.EventHandler(this.Button_Leave);
            // 
            // btnYesAll
            // 
            this.btnYesAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(92)))), ((int)(((byte)(114)))));
            this.btnYesAll.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnYesAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesAll.ForeColor = System.Drawing.Color.White;
            this.btnYesAll.Location = new System.Drawing.Point(285, 2);
            this.btnYesAll.Name = "btnYesAll";
            this.btnYesAll.Size = new System.Drawing.Size(81, 34);
            this.btnYesAll.TabIndex = 1;
            this.btnYesAll.Text = "بلي(همه)";
            this.btnYesAll.UseVisualStyleBackColor = false;
            this.btnYesAll.Enter += new System.EventHandler(this.Button_Enter);
            this.btnYesAll.Leave += new System.EventHandler(this.Button_Leave);
            // 
            // btnYes
            // 
            this.btnYes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(142)))), ((int)(((byte)(174)))));
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYes.ForeColor = System.Drawing.Color.White;
            this.btnYes.Location = new System.Drawing.Point(108, 2);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(81, 34);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "بلي";
            this.btnYes.UseVisualStyleBackColor = false;
            this.btnYes.Enter += new System.EventHandler(this.Button_Enter);
            this.btnYes.Leave += new System.EventHandler(this.Button_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Atiran.CustomDocking.MessageBox.Resources.Alarm;
            this.pictureBox1.Location = new System.Drawing.Point(388, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // YesNoMessageBox
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(462, 186);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("IRANSans(FaNum)", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "YesNoMessageBox";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.ConfirmMessageBox_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        //private void ClosePictureBox_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        //}
        public string Caption
        {
            set { lblCaption.Text = value; }
        }
        public string SetMessage
        {
            set
            {
                txtMessage.Items.AddRange(value.Split('\n'));
                if (ShowAllButton)
                {
                    txtMessage.SelectedIndex = 0;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape || keyData == (Keys.Alt | Keys.F4))
            {
                if (btnNoAll.Visible)
                    this.DialogResult = DialogResult.Cancel;
                else
                    this.DialogResult = DialogResult.No;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        //private void ClosePictureBox_MouseEnter(object sender, EventArgs e)
        //{
        //    ClosePictureBox.BackColor = Color.DarkRed;
        //}
        //private void ClosePictureBox_MouseLeave(object sender, EventArgs e)
        //{
        //    ClosePictureBox.BackColor = Color.Transparent;
        //}
        private void Button_Leave(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.BorderColor = Color.Black;
            ((Button)sender).FlatAppearance.BorderSize = 1;
        }
        private void Button_Enter(object sender, EventArgs e)
        {
            ((Button)sender).FlatAppearance.BorderColor = Color.DarkOrange;
            ((Button)sender).FlatAppearance.BorderSize = 1;
        }
        private System.Threading.Thread threadLoad;
        private System.Threading.ThreadStart threadStartLoad;
        //================================================================
        /// <summary>
        ///  Load User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmMessageBox_Load(object sender, EventArgs e)
        {
            try
            {
                MTF_UserControl();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Starting Thread
        /// </summary>
        private void MTF_UserControl()
        {
            try
            {
                threadStartLoad = new System.Threading.ThreadStart(MTF_UserControlLoad_Load);
                threadLoad = new System.Threading.Thread(threadStartLoad)
                {
                    Priority = System.Threading.ThreadPriority.AboveNormal,
                    IsBackground = true //<— Set the thread to work in background
                };
                //
                threadLoad.Start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// Act Thread
        /// </summary>
        /// 
        private void MTF_UserControlLoad_Load()
        {
            Invoke(new System.Windows.Forms.MethodInvoker(delegate ()
            {
                if (!ShowAllButton)
                {
                    btnNoAll.Visible = false;
                    btnYesAll.Visible = false;
                }
                if (LoadOnYesButton)
                {
                    btnYes.Focus();
                }
                else
                {
                    btnNo.Focus();
                }
            }));
        }

    }
}
