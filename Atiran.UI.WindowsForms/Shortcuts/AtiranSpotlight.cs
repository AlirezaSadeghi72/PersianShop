using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.Operaions.MenuOp;

namespace Atiran.UI.WindowsForms.Shortcuts
{
    public class AtiranSpotlight : UI.WindowsForms.Controls.UserControl
    {
        private Controls.pictureBox pictureBox1;
        private Controls.Label label1;
        private UIElements.Panel pnlBack;
        private UIElements.Panel panel2;
        private Controls.pictureBox pictureBox2;
        private Controls.FlowLayoutPanel pnlResult;
        private UIElements.Panel panel4;
        private UIElements.Panel panel3;
        private UIElements.Panel pnlTextbox;
        private Controls.TextBoxes.TextBox txtSerach;
        private UIElements.Panel panel1;
        private List<AtiranSpotlightItem> uiItems;
        private List<Atiran.Connections.AtiranAccModel.Menu> menu;
        public AtiranSpotlight(List<Atiran.Connections.AtiranAccModel.Menu> menu_)
        {
            InitializeComponent();
            uiItems = new List<AtiranSpotlightItem>();
            menu = menu_;
        }
        private void InitializeComponent()
        {
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.pictureBox1 = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.pnlBack = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.panel2 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.pnlResult = new Atiran.UI.WindowsForms.Controls.FlowLayoutPanel();
            this.panel4 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.panel3 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.pnlTextbox = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.txtSerach = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.pictureBox2 = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlBack.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTextbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 35);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(33, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Atiran Spotlight";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::Atiran.UI.WindowsForms.Resources.Atiran_Spotlight_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlBack
            // 
            this.pnlBack.Controls.Add(this.panel2);
            this.pnlBack.Controls.Add(this.pictureBox2);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlBack.Location = new System.Drawing.Point(0, 35);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(674, 333);
            this.pnlBack.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlResult);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.pnlTextbox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel2.Location = new System.Drawing.Point(0, 166);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(674, 167);
            this.panel2.TabIndex = 1;
            // 
            // pnlResult
            // 
            this.pnlResult.AutoScroll = true;
            this.pnlResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.pnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResult.Location = new System.Drawing.Point(100, 32);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlResult.Size = new System.Drawing.Size(463, 135);
            this.pnlResult.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel4.Location = new System.Drawing.Point(563, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(111, 135);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel3.Location = new System.Drawing.Point(0, 32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(100, 135);
            this.panel3.TabIndex = 1;
            // 
            // pnlTextbox
            // 
            this.pnlTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.pnlTextbox.Controls.Add(this.txtSerach);
            this.pnlTextbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTextbox.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlTextbox.Location = new System.Drawing.Point(0, 0);
            this.pnlTextbox.Name = "pnlTextbox";
            this.pnlTextbox.Size = new System.Drawing.Size(674, 32);
            this.pnlTextbox.TabIndex = 0;
            // 
            // txtSerach
            // 
            this.txtSerach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSerach.Font = new System.Drawing.Font("IRANSans(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerach.Location = new System.Drawing.Point(100, -1);
            this.txtSerach.Margin = new System.Windows.Forms.Padding(10);
            this.txtSerach.Name = "txtSerach";
            this.txtSerach.NextControl = null;
            this.txtSerach.Size = new System.Drawing.Size(463, 33);
            this.txtSerach.TabIndex = 0;
            this.txtSerach.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSerach.TextChanged += new System.EventHandler(this.TxtSerach_TextChanged);
            this.txtSerach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSerach_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::Atiran.UI.WindowsForms.Resources.Atiran_Spotlight_Background;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(674, 333);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // AtiranSpotlight
            // 
            this.Controls.Add(this.pnlBack);
            this.Controls.Add(this.panel1);
            this.Name = "AtiranSpotlight";
            this.Size = new System.Drawing.Size(674, 368);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlBack.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlTextbox.ResumeLayout(false);
            this.pnlTextbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Drawing.Image GetImageEnviroment(int subsystemId)
        {
            switch (subsystemId)
            {
                case 1:
                    return UI.WindowsForms.Resources.Selling_Tiny;
                case 2:
                    return Resources.Selling_Management_Tiny;
                case 3:
                    return Resources.Reports_Tiny;
                case 4:
                    return Resources.Anbaar_Tiny;
                case 5:
                    return Resources.Hesabdari_Tiny;
                case 6:
                    return Resources.Rahyaab_Tiny;
                case 7:
                    return Resources.Settings_Tiny;
                case 8:
                    return Resources.Backup_Tiny;
                case 9:
                    return Resources.SMS_Tiny;
                case 10:
                    return Resources.EMS_Tiny;
                case 11:
                    return Resources.Basic_Information_Tiny;
                case 12:
                    return Resources.Treasury_Tiny;
                default:
                    return Resources.Basic_Information_Tiny;

            }
        }
        private void AddToResultView(List<Connections.AtiranAccModel.Menu> result)
        {
            result.ForEach(i =>
            {
                System.Drawing.Image image = GetImageEnviroment(i.SubSystemID.Value);
                AtiranSpotlightItem item = new AtiranSpotlightItem(image, i)
                {
                    Dock = System.Windows.Forms.DockStyle.Top
                };
                item.Leave += Item_Leave;
                pnlResult.Controls.Add(item);
                uiItems.Add(item);
            });
        }
        private void Item_Leave(object sender, EventArgs e)
        {
            ((AtiranSpotlightItem)sender).onFocused = false;
            ((AtiranSpotlightItem)sender).BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
        }
        private void TxtSerach_TextChanged(object sender, EventArgs e)
        {

            uiItems.Clear();
            pnlResult.Controls.Clear();
            if (!string.IsNullOrEmpty(txtSerach.Text.Trim()))
            {
                var items = MenuOperaion.GetMenus(txtSerach.Text.Trim());
                if (items != null)
                {
                    pnlResult.BackColor = System.Drawing.Color.Transparent;
                    AddToResultView(items);
                    if (uiItems.Count > 0)
                    {
                        uiItems[0].BackColor = System.Drawing.Color.LightGray;
                        uiItems[0].onFocused = true;
                    }
                }
            }
            else
            {
                pnlResult.Controls.Clear();
                pnlResult.BackColor = System.Drawing.Color.FromArgb(238, 238, 238);
                uiItems.Clear();
            }
        }
        private void TxtSerach_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Down)
                {
                    if (uiItems.Count > 0)
                    {
                        var index = uiItems.FindIndex(i => i.onFocused == true);
                        if (index < 0 | index == uiItems.Count - 1)
                        {
                            uiItems[0].BackColor = System.Drawing.Color.LightGray;
                            uiItems[0].onFocused = true;
                            if (index == uiItems.Count - 1)
                                Item_Leave(uiItems[index], null);
                        }
                        else
                        {
                            Item_Leave(uiItems[index], null);
                            uiItems[++index].BackColor = System.Drawing.Color.LightGray;
                            uiItems[index].onFocused = true;
                        }
                        index = uiItems.FindIndex(i => i.onFocused == true);
                        pnlResult.AutoScrollPosition = new System.Drawing.Point(index, index * 41);
                    }
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.Up)
                {
                    if (uiItems.Count > 0)
                    {
                        var index = uiItems.FindIndex(i => i.onFocused == true);
                        if (index <= 0)
                        {
                            uiItems[uiItems.Count - 1].BackColor = System.Drawing.Color.LightGray;
                            uiItems[uiItems.Count - 1].onFocused = true;
                            Item_Leave(uiItems[0], null);
                        }
                        else
                        {
                            Item_Leave(uiItems[index], null);
                            uiItems[--index].BackColor = System.Drawing.Color.LightGray;
                            uiItems[index].onFocused = true;
                        }
                        index = uiItems.FindIndex(i => i.onFocused == true);
                        pnlResult.AutoScrollPosition = new System.Drawing.Point(index, index * 41);
                    }
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.Enter && uiItems.Count > 0)
                {
                    menu.Add(uiItems.FirstOrDefault(i => i.onFocused == true).menu_);
                    this.ParentForm.Close();

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

        }
    }
}
