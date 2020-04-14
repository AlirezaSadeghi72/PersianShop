using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.Operaions.FormOp;
using Atiran.Connections.Operaions.ShortcutKeyOp;

namespace Atiran.Main
{
    public class Help : Atiran.UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.UIElements.Panel pnlFooter;
        private UI.WindowsForms.UIElements.Panel pnlMain;
        private UI.WindowsForms.UIElements.Panel panel1;
        public UI.WindowsForms.Controls.Label lblGuid;
        private UI.WindowsForms.UIElements.Panel panel2;
        public UI.WindowsForms.Controls.Label label1;
        public UI.WindowsForms.Controls.Label lblDatabaseVersion;
        public UI.WindowsForms.Controls.Label lblProductVersion;
        private DataGridView dataGridView1;
        private UI.WindowsForms.Controls.TextBoxes.TextBox txtSearch;
        private UI.WindowsForms.UIElements.Panel pnlTop;
        private List<Connections.AtiranAccModel.ShortcutKey> resultKeys;
        public Help()
        {
            InitializeComponent();
            lblProductVersion.Text = Application.ProductVersion;
            //lblDatabaseVersion.Text = "ورژن ديتابيس : " + GetHubForm.GetDatabaseVersion().VersionName;
            lblGuid.Text = "راهنماي نرم افزار " /*+ GetHubForm.ProgramVersion()*/;
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.lblGuid = new Atiran.UI.WindowsForms.Controls.Label();
            this.pnlFooter = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.panel2 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.lblDatabaseVersion = new Atiran.UI.WindowsForms.Controls.Label();
            this.lblProductVersion = new Atiran.UI.WindowsForms.Controls.Label();
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.pnlMain = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.panel1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(600, 43);
            this.pnlTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.lblGuid);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 43);
            this.panel1.TabIndex = 17;
            // 
            // lblGuid
            // 
            this.lblGuid.AutoSize = true;
            this.lblGuid.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblGuid.Font = new System.Drawing.Font("IRANSans(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuid.ForeColor = System.Drawing.Color.White;
            this.lblGuid.Location = new System.Drawing.Point(494, 0);
            this.lblGuid.Name = "lblGuid";
            this.lblGuid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblGuid.Size = new System.Drawing.Size(106, 25);
            this.lblGuid.TabIndex = 11;
            this.lblGuid.Text = "راهنماي سيستم";
            this.lblGuid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.panel2);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlFooter.Location = new System.Drawing.Point(0, 566);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(600, 34);
            this.pnlFooter.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.lblDatabaseVersion);
            this.panel2.Controls.Add(this.lblProductVersion);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 34);
            this.panel2.TabIndex = 18;
            // 
            // lblDatabaseVersion
            // 
            this.lblDatabaseVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDatabaseVersion.Font = new System.Drawing.Font("IRANSans(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabaseVersion.ForeColor = System.Drawing.Color.Black;
            this.lblDatabaseVersion.Location = new System.Drawing.Point(3, 3);
            this.lblDatabaseVersion.Name = "lblDatabaseVersion";
            this.lblDatabaseVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblDatabaseVersion.Size = new System.Drawing.Size(279, 25);
            this.lblDatabaseVersion.TabIndex = 14;
            this.lblDatabaseVersion.Text = "راهنماي سيستم";
            this.lblDatabaseVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductVersion
            // 
            this.lblProductVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProductVersion.Font = new System.Drawing.Font("IRANSans(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductVersion.ForeColor = System.Drawing.Color.Black;
            this.lblProductVersion.Location = new System.Drawing.Point(299, 3);
            this.lblProductVersion.Name = "lblProductVersion";
            this.lblProductVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProductVersion.Size = new System.Drawing.Size(184, 25);
            this.lblProductVersion.TabIndex = 12;
            this.lblProductVersion.Text = "راهنماي سيستم";
            this.lblProductVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(489, 1);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "ورژن نرم افزار:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dataGridView1);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlMain.Location = new System.Drawing.Point(0, 43);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(600, 523);
            this.pnlMain.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 29);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(600, 494);
            this.dataGridView1.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Font = new System.Drawing.Font("AtiranFont", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.NextControl = null;
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSearch.Size = new System.Drawing.Size(600, 29);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // Help
            // 
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTop);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Help";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(600, 600);
            this.Load += new System.EventHandler(this.UserControl_Load);
            this.pnlTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.ParentForm.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Private const SetGrid 

        private const string Col1 = nameof(Atiran.Connections.AtiranAccModel.ShortcutKey.Dis);
        private const string Col2 = nameof(Atiran.Connections.AtiranAccModel.ShortcutKey.Shurtcut);

        #endregion
        private void SetGridView()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Visible = false;
            }

            dataGridView1.Columns[Col1].Visible = true;
            dataGridView1.Columns[Col2].Visible = true;
            //==================================================
            dataGridView1.Columns[Col1].HeaderText = "عملیات";
            dataGridView1.Columns[Col2].HeaderText = "کلید میانبر";
            //==================================================
            dataGridView1.Columns[Col1].Width = 430;
            dataGridView1.Columns[Col2].Width = 150;
            //==================================================
            dataGridView1.Columns[Col1].DisplayIndex = 0;
            dataGridView1.Columns[Col2].DisplayIndex = 1;
            //==================================================
            dataGridView1.Columns[Col2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //==================================================
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            dataGridView1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            dataGridView1.RowsDefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255);

            dataGridView1.AutoGenerateColumns = false;
        }

        //================================================================
        /// <summary>
        ///  Load User Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Load(object sender, EventArgs e)
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
                System.Threading.ThreadStart threadStartLoad = new System.Threading.ThreadStart(MTF_UserControlLoad_Load);
                System.Threading.Thread threadLoad = new System.Threading.Thread(threadStartLoad)
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
                resultKeys = HelpOperaion.ReturnAllShortcutKeys();
                dataGridView1.DataSource = resultKeys;
                SetGridView();
                txtSearch.Focus();
            }));
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            var StringSearch = txtSearch.Text.Trim().ToUpper();
            dataGridView1.DataSource = resultKeys
                .Where(w => w.Dis.ToUpper().Contains(StringSearch) || w.Shurtcut.ToUpper().Contains(StringSearch)).ToList();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                if (dataGridView1.RowCount > 0 && dataGridView1.SelectedRows.Count > 0)
                {
                    var index = (dataGridView1.SelectedRows[0].Index + 1) % dataGridView1.RowCount;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[Col1];
                }
                e.Handled = true;
            }
            else if (e.KeyData == Keys.Up)
            {
                if (dataGridView1.RowCount > 0 && dataGridView1.SelectedRows.Count > 0)
                {
                    var index = (dataGridView1.SelectedRows[0].Index - 1 >= 0)
                        ? dataGridView1.SelectedRows[0].Index - 1
                        : dataGridView1.RowCount - 1;
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[Col1];
                }
                e.Handled = true;
            }
        }
    }
}
