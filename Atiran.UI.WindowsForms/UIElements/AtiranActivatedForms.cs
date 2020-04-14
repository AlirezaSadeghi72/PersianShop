using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class AtiranActivatedForms : Atiran.UI.WindowsForms.Controls.UserControl
    {
        private Controls.GroupBox groupBox2;
        private UIElements.Panel pnldgv;
        private Controls.DataGridView dataGridView1;
        private UIElements.Panel pnlsearch;
        private Controls.TextBoxes.TextBox txtsearch;
        private List<Guid> menu;
        private List<TabItems> Result = new List<TabItems>();
        private System.Threading.Thread threadLoad;
        private System.Threading.ThreadStart threadStartLoad;
        private bool isBusyProcessing = false;

        public AtiranActivatedForms(List<Guid> menu_)
        {
            InitializeComponent();
            menu = menu_;
            Result = (from read in Atiran.UI.WindowsForms.UIElements.TabBar.StaticTabs
                      select new TabItems
                      {
                          TabName = read.Title.Text,
                          GUIDCode = read.control.UcGuid,
                      }).ToList();
            dataGridView1.DataSource = Result;
            SetGridView();
        }
        private void SetGridView()
        {
            foreach (System.Windows.Forms.DataGridViewColumn item in dataGridView1.Columns)
            {
                item.Visible = false;
            }
            string Col1 = "TabName";
            dataGridView1.Columns[Col1].Visible = true;
            dataGridView1.Columns[Col1].HeaderText = "نام فرم";
            dataGridView1.Columns[Col1].DisplayIndex = 0;
            dataGridView1.AutoGenerateColumns = false;
        }
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new Atiran.UI.WindowsForms.Controls.GroupBox();
            this.pnldgv = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.dataGridView1 = new Atiran.UI.WindowsForms.Controls.DataGridView();
            this.pnlsearch = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.txtsearch = new Atiran.UI.WindowsForms.Controls.TextBoxes.TextBox();
            this.groupBox2.SuspendLayout();
            this.pnldgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlsearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnldgv);
            this.groupBox2.Controls.Add(this.pnlsearch);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 400);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "فرم‌هاي فعال";
            // 
            // pnldgv
            // 
            this.pnldgv.Controls.Add(this.dataGridView1);
            this.pnldgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnldgv.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnldgv.Location = new System.Drawing.Point(3, 54);
            this.pnldgv.Name = "pnldgv";
            this.pnldgv.Size = new System.Drawing.Size(294, 343);
            this.pnldgv.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(294, 343);
            this.dataGridView1.TabIndex = 0;
            // 
            // pnlsearch
            // 
            this.pnlsearch.Controls.Add(this.txtsearch);
            this.pnlsearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlsearch.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.pnlsearch.Location = new System.Drawing.Point(3, 25);
            this.pnlsearch.Name = "pnlsearch";
            this.pnlsearch.Size = new System.Drawing.Size(294, 29);
            this.pnlsearch.TabIndex = 2;
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.Color.White;
            this.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtsearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtsearch.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.txtsearch.ForeColor = System.Drawing.Color.Black;
            this.txtsearch.Location = new System.Drawing.Point(0, 0);
            this.txtsearch.Margin = new System.Windows.Forms.Padding(10);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.NextControl = null;
            this.txtsearch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtsearch.Size = new System.Drawing.Size(294, 29);
            this.txtsearch.TabIndex = 0;
            this.txtsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtsearch.TextChanged += new System.EventHandler(this.Txtsearch_TextChanged);
            this.txtsearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtsearch_KeyDown);
            // 
            // AtiranActivatedForms
            // 
            this.Controls.Add(this.groupBox2);
            this.Name = "AtiranActivatedForms";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(300, 400);
            this.Load += new System.EventHandler(this.UserControl_Load);
            this.groupBox2.ResumeLayout(false);
            this.pnldgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlsearch.ResumeLayout(false);
            this.pnlsearch.PerformLayout();
            this.ResumeLayout(false);

        }
        private class TabItems
        {
            public string TabName { get; set; }
            public Guid GUIDCode { get; set; }
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
                txtsearch.Focus();
            }));
        }
        private void SetActiveRow(Atiran.UI.WindowsForms.Controls.DataGridView DG, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                string ColName = "TabName";
                int selected = 0;
                if (DG.RowCount > 0)
                {
                    if (DG.CurrentRow == null)
                    {
                        DG.CurrentCell = DG.Rows[0].Cells[ColName];
                    }
                    else
                    {
                        selected = DG.CurrentRow.Index;
                    }
                }

                if (txtsearch.Text.StartsWith(" "))
                {
                    txtsearch.Text = "";
                }
                if (e.KeyCode == System.Windows.Forms.Keys.Down && DG.RowCount > 0)
                {
                    if (selected < DG.Rows.Count - 1)
                        DG.CurrentCell = DG.Rows[selected + 1].Cells[ColName];
                    else
                        DG.CurrentCell = DG.Rows[0].Cells[ColName];
                    System.Windows.Forms.SendKeys.Send("{END}");
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.Up && DG.RowCount > 0)
                {
                    if (selected > 0)
                        DG.CurrentCell = DG.Rows[selected - 1].Cells[ColName];
                    else
                        DG.CurrentCell = DG.Rows[DG.Rows.Count - 1].Cells[ColName];
                    System.Windows.Forms.SendKeys.Send("{END}");
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.PageDown)
                {
                    DG.Focus();
                    txtsearch.Focus();
                    if (DG.RowCount > 0)
                    {
                        int CountRows = DG.RowCount;
                        int CurrentPosition = DG.CurrentRow.Index;
                        int NextPosition = CurrentPosition + 10;
                        int RemainTolast = (CountRows - 1) - CurrentPosition;
                        if (CurrentPosition < CountRows - 1)
                        {
                            if (NextPosition < CountRows - 1)
                            {
                                DG.Rows[DG.CurrentRow.Index].Selected = false;
                                DG.Rows[DG.CurrentRow.Index + 10].Selected = true;
                                DG.CurrentCell = DG.Rows[DG.CurrentRow.Index + 10].Cells[ColName];
                            }
                            else
                            {
                                DG.Rows[DG.CurrentRow.Index].Selected = false;
                                DG.Rows[DG.CurrentRow.Index + RemainTolast].Selected = true;
                                DG.CurrentCell = DG.Rows[DG.CurrentRow.Index + RemainTolast].Cells[ColName];
                            }

                        }
                    }
                    System.Windows.Forms.SendKeys.Send("{END}");
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.PageUp)
                {
                    DG.Focus();
                    txtsearch.Focus();
                    if (DG.RowCount > 0)
                    {
                        int CountRows = DG.RowCount;
                        int CurrentPosition = DG.CurrentRow.Index;
                        int NextPosition = CurrentPosition - 10;
                        int RemainToFirst = CurrentPosition;
                        if (CurrentPosition > 0)
                        {
                            if (RemainToFirst > 10)
                            {
                                DG.Rows[DG.CurrentRow.Index].Selected = false;
                                DG.Rows[DG.CurrentRow.Index - 10].Selected = true;
                                DG.CurrentCell = DG.Rows[DG.CurrentRow.Index - 10].Cells[ColName];
                            }
                            else
                            {
                                DG.Rows[DG.CurrentRow.Index].Selected = false;
                                DG.Rows[DG.CurrentRow.Index - RemainToFirst].Selected = true;
                                DG.CurrentCell = DG.Rows[DG.CurrentRow.Index - RemainToFirst].Cells[ColName];
                            }

                        }
                    }
                    System.Windows.Forms.SendKeys.Send("{END}");
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                {
                    AddToMenu();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        private void AddToMenu()
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["TabName"];
                }
                menu.Add(((TabItems)dataGridView1.CurrentRow.DataBoundItem).GUIDCode);
            }
            this.ParentForm.Close();
        }
        private void Txtsearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            SetActiveRow(dataGridView1, e);
        }
        private async void Txtsearch_TextChanged(object sender, EventArgs e)
        {
            while (isBusyProcessing)
                await Task.Delay(50);
            try
            {
                isBusyProcessing = true;
                var ResStr = txtsearch.Text.Trim();
                dataGridView1.DataSource = await System.Threading.Tasks.Task.Run(() => ResStr == string.Empty ? Result : Result.Where(a => a.TabName.Contains(ResStr)).ToList());
            }
            finally
            {
                isBusyProcessing = false;
            }
        }
    }
}
