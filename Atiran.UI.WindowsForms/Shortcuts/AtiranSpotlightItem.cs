using Atiran.UI.WindowsForms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.Shortcuts
{
    public class AtiranSpotlightItem : UserControl
    {
        private Controls.Label lblShortcut;
        private Controls.Label lblName;
        private Controls.pictureBox pictureBoxIcon;
        public bool onFocused;
        public Atiran.Connections.AtiranAccModel.Menu menu_;
        public AtiranSpotlightItem(System.Drawing.Image image, Atiran.Connections.AtiranAccModel.Menu menu)
        {
            InitializeComponent();
            pictureBoxIcon.Image = image;
            menu_ = menu;
            lblName.Text = menu_.Titel;
            lblShortcut.Text = menu_.Shortcut;
            onFocused = false;
        }
        private void InitializeComponent()
        {
            this.pictureBoxIcon = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.lblShortcut = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblName = new Atiran.UI.WindowsForms.Controls.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxIcon.Location = new System.Drawing.Point(394, 0);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            // 
            // lblShortcut
            // 
            this.lblShortcut.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblShortcut.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.lblShortcut.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.lblShortcut.Location = new System.Drawing.Point(0, 0);
            this.lblShortcut.Name = "lblShortcut";
            this.lblShortcut.Size = new System.Drawing.Size(48, 35);
            this.lblShortcut.TabIndex = 1;
            this.lblShortcut.Text = "Shift + Key";
            this.lblShortcut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.lblName.Location = new System.Drawing.Point(48, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(346, 35);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label2";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AtiranSpotlightItem
            // 
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblShortcut);
            this.Controls.Add(this.pictureBoxIcon);
            this.Name = "AtiranSpotlightItem";
            this.Size = new System.Drawing.Size(429, 35);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
