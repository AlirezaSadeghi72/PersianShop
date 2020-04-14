using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
   public class SortControl:Atiran.UI.WindowsForms.Controls.UserControl
    {
        public Controls.ComboBoxes.ComboBox comboFields;
        private Controls.FlowLayoutPanel flowLayoutPanel1;
        public Controls.RadioButton rbnozuli;
        public Controls.RadioButton rbsoudi;
        private Controls.Label label1;
        private Controls.Label label2;
        private Controls.pictureBox pictureBox1;
        private GradientPanel gradientPanel1;
        public Controls.Label lblSort;
        public Dictionary<string, string> DataSourceCombobox;
        //در فرمي كه از اين كنترل استفاده مي شود لطفا مرتب سازي آن را با كليد اف 5 ست كنيد
        public SortControl()
        {
            InitializeComponent();
            DataSourceCombobox = new Dictionary<string, string>();
        }

        public void FillCombo()
        {
            comboFields.DataSource = DataSourceCombobox.ToList();
            comboFields.DisplayMember = "Value";
            comboFields.ValueMember = "Key";
            comboFields.SelectedIndex = 0;
        }
        public IOrderedQueryable<T> MyListForOrder<T>(IQueryable<T> source,bool dynamicList = false)
        {
            try
            {
                if (rbnozuli.Checked)
                return Atiran.UI.WindowsForms.UIElements.SortService.ApplyOrder(source, comboFields.SelectedValue.ToString(), "OrderByDescending",dynamicList);
                else      
                return Atiran.UI.WindowsForms.UIElements.SortService.ApplyOrder(source, comboFields.SelectedValue.ToString(), "OrderBy",dynamicList);
            }
            catch (Exception ex)
            {
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("خطا",ex.Message,"e");
                return null;
            }
        }
        private void InitializeComponent()
        {
            this.comboFields = new Atiran.UI.WindowsForms.Controls.ComboBoxes.ComboBox();
            this.flowLayoutPanel1 = new Atiran.UI.WindowsForms.Controls.FlowLayoutPanel();
            this.rbnozuli = new Atiran.UI.WindowsForms.Controls.RadioButton();
            this.rbsoudi = new Atiran.UI.WindowsForms.Controls.RadioButton();
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label2 = new Atiran.UI.WindowsForms.Controls.Label();
            this.pictureBox1 = new Atiran.UI.WindowsForms.Controls.pictureBox();
            this.gradientPanel1 = new Atiran.UI.WindowsForms.UIElements.GradientPanel();
            this.lblSort = new Atiran.UI.WindowsForms.Controls.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboFields
            // 
            this.comboFields.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboFields.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboFields.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboFields.FormattingEnabled = true;
            this.comboFields.Location = new System.Drawing.Point(17, 7);
            this.comboFields.Margin = new System.Windows.Forms.Padding(10);
            this.comboFields.Name = "comboFields";
            this.comboFields.NextControl = null;
            this.comboFields.Size = new System.Drawing.Size(142, 30);
            this.comboFields.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.rbnozuli);
            this.flowLayoutPanel1.Controls.Add(this.rbsoudi);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 38);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(139, 29);
            this.flowLayoutPanel1.TabIndex = 100;
            // 
            // rbnozuli
            // 
            this.rbnozuli.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbnozuli.AutoSize = true;
            this.rbnozuli.Location = new System.Drawing.Point(3, 3);
            this.rbnozuli.Name = "rbnozuli";
            this.rbnozuli.NextControl = null;
            this.rbnozuli.Size = new System.Drawing.Size(56, 26);
            this.rbnozuli.TabIndex = 3;
            this.rbnozuli.Text = "نزولي";
            this.rbnozuli.UseVisualStyleBackColor = true;
            // 
            // rbsoudi
            // 
            this.rbsoudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbsoudi.AutoSize = true;
            this.rbsoudi.Checked = true;
            this.rbsoudi.Location = new System.Drawing.Point(65, 3);
            this.rbsoudi.Name = "rbsoudi";
            this.rbsoudi.NextControl = null;
            this.rbsoudi.Size = new System.Drawing.Size(67, 26);
            this.rbsoudi.TabIndex = 4;
            this.rbsoudi.TabStop = true;
            this.rbsoudi.Text = "صعودي";
            this.rbsoudi.UseVisualStyleBackColor = true;
            this.rbsoudi.CheckedChanged += new System.EventHandler(this.rbsoudi_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.Location = new System.Drawing.Point(162, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 22);
            this.label1.TabIndex = 101;
            this.label1.Text = "براساس";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label2.Location = new System.Drawing.Point(163, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 22);
            this.label2.TabIndex = 101;
            this.label2.Text = "به صورت";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Atiran.UI.WindowsForms.Resources.Sort;
            this.pictureBox1.Location = new System.Drawing.Point(0, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.gradientPanel1.BorderColor = System.Drawing.Color.LightGoldenrodYellow;
            this.gradientPanel1.Controls.Add(this.lblSort);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.comboFields);
            this.gradientPanel1.Controls.Add(this.flowLayoutPanel1);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gradientPanel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.gradientPanel1.GradientEndColor = System.Drawing.Color.LightCyan;
            this.gradientPanel1.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(227)))), ((int)(((byte)(241)))));
            this.gradientPanel1.Image = null;
            this.gradientPanel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.gradientPanel1.Location = new System.Drawing.Point(45, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(226, 99);
            this.gradientPanel1.TabIndex = 104;
            // 
            // lblSort
            // 
            this.lblSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSort.AutoSize = true;
            this.lblSort.BackColor = System.Drawing.Color.Transparent;
            this.lblSort.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.lblSort.Location = new System.Drawing.Point(6, 67);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(108, 22);
            this.lblSort.TabIndex = 102;
            this.lblSort.Text = "Alt+S:مرتب سازي";
            this.lblSort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SortControl
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.gradientPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SortControl";
            this.Size = new System.Drawing.Size(271, 99);
            this.Load += new System.EventHandler(this.SortControl_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }


        private void SortControl_Load(object sender, EventArgs e)
        {
            gradientPanel1.Visible = false;
            this.Size = new System.Drawing.Size(34, 33);
        }
        public void ChangeVisabilitySortControl()
        {
            if (gradientPanel1.Visible == false)
            {
                this.Size = new System.Drawing.Size(260, 93);
                gradientPanel1.Visible = true;
                this.BringToFront();
                gradientPanel1.BringToFront();
            }
            else
            {
                this.Size = new System.Drawing.Size(34, 33);
                gradientPanel1.Visible = false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ChangeVisabilitySortControl();
            
        }

      

        private void rbsoudi_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
