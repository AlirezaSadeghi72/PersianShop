using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class GroupByReportsControl : UI.WindowsForms.Controls.UserControl
    {
        public System.Windows.Forms.Control NextControl { get; set; }
        protected UI.WindowsForms.UIElements.Checkbox checkbox1;
        public Controls.ComboBoxes.ComboBox comboBox1;
        public Dictionary<string, string> DictionaryForCombobox;
        public GroupByReportsControl()
        {
            InitializeComponent();
            DictionaryForCombobox = new Dictionary<string, string>();
        }
        private void InitializeComponent()
        {
            this.checkbox1 = new Atiran.UI.WindowsForms.UIElements.Checkbox();
            this.comboBox1 = new Atiran.UI.WindowsForms.Controls.ComboBoxes.ComboBox();
            this.SuspendLayout();
            // 
            // checkbox1
            // 
            this.checkbox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkbox1.AutoSize = true;
            this.checkbox1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.checkbox1.Location = new System.Drawing.Point(180, 5);
            this.checkbox1.Name = "checkbox1";
            this.checkbox1.NextControl = this.comboBox1;
            this.checkbox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkbox1.Size = new System.Drawing.Size(169, 26);
            this.checkbox1.TabIndex = 9;
            this.checkbox1.Text = "دسته بندي گزارش بر اساس";
            this.checkbox1.UseVisualStyleBackColor = true;
            this.checkbox1.CheckedChanged += new System.EventHandler(this.checkbox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 3);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.NextControl = null;
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(179, 30);
            this.comboBox1.TabIndex = 10;
            // 
            // GroupByReportsControl
            // 
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkbox1);
            this.Name = "GroupByReportsControl";
            this.Size = new System.Drawing.Size(352, 36);
            this.Enter += new System.EventHandler(this.GroupByReportsControl_Enter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CustomerGroupControl_KeyPress);
            this.Leave += new System.EventHandler(this.GroupByReportsControl_Leave);
            this.MouseHover += new System.EventHandler(this.GroupByReportsControl_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void FillCombo()
        {
            if (DictionaryForCombobox.Count > 0)
            {
                comboBox1.DataSource = DictionaryForCombobox.ToList();
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
                comboBox1.SelectedIndex = 0;
            }
        }
        private void CustomerGroupControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (NextControl != null)
                    NextControl.Focus();
            }
        }

        private void checkbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox1.Checked)
            {
                comboBox1.Enabled = true;
                comboBox1.Focus();
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Text = string.Empty;
            }
        }

        private void GroupByReportsControl_Enter(object sender, EventArgs e)
        {
            FillCombo();
            checkbox1.NextControl = NextControl;
            comboBox1.NextControl = NextControl;
        }

        private void GroupByReportsControl_Leave(object sender, EventArgs e)
        {
            if (comboBox1.DataSource == null)
            {
                checkbox1.Checked = false;
            }
        }

        private void GroupByReportsControl_MouseHover(object sender, EventArgs e)
        {
        }
    }
}


