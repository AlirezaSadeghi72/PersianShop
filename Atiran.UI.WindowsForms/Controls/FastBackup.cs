using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions;
using Atiran.Connections.Operaions.DateOp;
using Atiran.UI.WindowsForms.MessageBoxes;
namespace Atiran.UI.WindowsForms.Controls
{
    public class FastBackup : UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.Controls.Label label1;
        private UI.WindowsForms.Controls.Label labelTargetFile;
        private UI.WindowsForms.Controls.Buttons.Button buttonChangeFolder;
        private ProgressBar progressBar1;
        private UI.WindowsForms.Controls.Label labelStatus;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label labelDate;
        private Buttons.CancelButton cancelButton1;
        private UIElements.Panel panel1;
        private UI.WindowsForms.Controls.Buttons.Button buttonBackup;
        public FastBackup()
        {
            InitializeComponent();
        }
        string cpname, servername, TimeNow;
        public void Copyfile(string sourceFileName)
        {
            try
            {
                if (cpname != DateServer.ServerComputerName())
                {
                    sourceFileName = @"\\" + servername + @"\" + sourceFileName;
                }
                else
                {
                    sourceFileName = @"D:\" + sourceFileName;
                }
                labelStatus.ForeColor = Color.Black;
                labelStatus.Text = "در حال انتقال بر روي مسير انتخاب شده";
                progressBar1.Visible = true;
                progressBar1.Value = 0;
                System.IO.FileStream S_file = new System.IO.FileStream(sourceFileName, System.IO.FileMode.Open);
                System.IO.FileStream D_file = new System.IO.FileStream(labelTargetFile.Text, System.IO.FileMode.Create);
                Int64 len = S_file.Length;
                for (Int64 i = 0; i < len; i++)
                {
                    D_file.WriteByte((byte)S_file.ReadByte());
                    if (i % 1000 == 0)
                    {
                        progressBar1.Value = (int)(i * 100 / len) + 1;
                        Application.DoEvents();
                    }
                }
                S_file.Close();
                D_file.Close();
                progressBar1.Value = 100;
                this.ParentForm.Close();
            }
            catch
            {
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("خطا", "خطا در عمليات كپي برداري از سرور", "e");
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }
        public void ProgressEventHandler(object sender, PercentCompleteEventArgs e)
        {
            progressBar1.Value = e.Percent;
        }
        private void InitializeComponent()
        {
            this.buttonBackup = new Atiran.UI.WindowsForms.Controls.Buttons.Button();
            this.label1 = new Atiran.UI.WindowsForms.Controls.Label();
            this.labelTargetFile = new Atiran.UI.WindowsForms.Controls.Label();
            this.buttonChangeFolder = new Atiran.UI.WindowsForms.Controls.Buttons.Button();
            this.progressBar1 = new Atiran.UI.WindowsForms.Controls.ProgressBar();
            this.labelStatus = new Atiran.UI.WindowsForms.Controls.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelDate = new Atiran.UI.WindowsForms.Controls.Label();
            this.cancelButton1 = new Atiran.UI.WindowsForms.Controls.Buttons.CancelButton();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBackup
            // 
            this.buttonBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(140)))), ((int)(((byte)(231)))));
            this.buttonBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackup.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.buttonBackup.ForeColor = System.Drawing.Color.White;
            this.buttonBackup.Location = new System.Drawing.Point(5, 3);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.NextControl = null;
            this.buttonBackup.Size = new System.Drawing.Size(83, 36);
            this.buttonBackup.TabIndex = 0;
            this.buttonBackup.Text = "ذخيره ";
            this.buttonBackup.UseVisualStyleBackColor = false;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.Location = new System.Drawing.Point(552, 65);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(118, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "مسير پشتيبان گيري:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTargetFile
            // 
            this.labelTargetFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTargetFile.BackColor = System.Drawing.Color.White;
            this.labelTargetFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTargetFile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelTargetFile.Location = new System.Drawing.Point(75, 61);
            this.labelTargetFile.Name = "labelTargetFile";
            this.labelTargetFile.Size = new System.Drawing.Size(475, 30);
            this.labelTargetFile.TabIndex = 3;
            this.labelTargetFile.Text = "D:";
            this.labelTargetFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonChangeFolder
            // 
            this.buttonChangeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeFolder.BackColor = System.Drawing.Color.White;
            this.buttonChangeFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonChangeFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangeFolder.Font = new System.Drawing.Font("IRANSans", 10.25F, System.Drawing.FontStyle.Bold);
            this.buttonChangeFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonChangeFolder.Location = new System.Drawing.Point(31, 61);
            this.buttonChangeFolder.Name = "buttonChangeFolder";
            this.buttonChangeFolder.NextControl = null;
            this.buttonChangeFolder.Size = new System.Drawing.Size(44, 30);
            this.buttonChangeFolder.TabIndex = 5;
            this.buttonChangeFolder.Text = "...";
            this.buttonChangeFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonChangeFolder.UseVisualStyleBackColor = false;
            this.buttonChangeFolder.Click += new System.EventHandler(this.buttonChangeFolder_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(31, 96);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(632, 23);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.Font = new System.Drawing.Font("IRANSans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(28, 125);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(635, 23);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.Tag = "";
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelDate.Location = new System.Drawing.Point(534, 15);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(132, 27);
            this.labelDate.TabIndex = 8;
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDate.Visible = false;
            // 
            // cancelButton1
            // 
            this.cancelButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton1.BackColor = System.Drawing.Color.White;
            this.cancelButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.cancelButton1.ForeColor = System.Drawing.Color.Gray;
            this.cancelButton1.Location = new System.Drawing.Point(94, 4);
            this.cancelButton1.Name = "cancelButton1";
            this.cancelButton1.NextControl = null;
            this.cancelButton1.Size = new System.Drawing.Size(81, 34);
            this.cancelButton1.TabIndex = 9;
            this.cancelButton1.Text = "انصراف";
            this.cancelButton1.UseVisualStyleBackColor = false;
            this.cancelButton1.Click += new System.EventHandler(this.cancelButton1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonBackup);
            this.panel1.Controls.Add(this.cancelButton1);
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(33, 163);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(223, 42);
            this.panel1.TabIndex = 10;
            // 
            // FastBackup
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonChangeFolder);
            this.Controls.Add(this.labelTargetFile);
            this.Controls.Add(this.label1);
            this.Name = "FastBackup";
            this.Size = new System.Drawing.Size(700, 304);
            this.Load += new System.EventHandler(this.AtiranBackup_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void buttonChangeFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                labelTargetFile.Text = folderBrowserDialog1.SelectedPath.ToString() + @"\" + TimeNow + ".bak";
        }
        private void cancelButton1_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        private void buttonBackup_Click(object sender, EventArgs e)
        {
            try
            {

                string Res = BackupOperaion.BackupDatabaseWithShirink();
                Copyfile(Res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        private void AtiranBackup_Load(object sender, EventArgs e)
        {
            try
            {
                cpname = System.Windows.Forms.SystemInformation.ComputerName;
                char ch = '\u005c';
                int index = ConnectionInfo.Server.IndexOf(ch);
                if (index == -1)
                    index = ConnectionInfo.Server.Length;
                servername = ConnectionInfo.Server.ToString().Substring(0, index);
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                labelDate.Text = pc.GetYear(DateTime.Now) + "-" + pc.GetMonth(DateTime.Now) + "-" + pc.GetDayOfMonth(DateTime.Now);
                TimeNow = labelDate.Text + "-" + pc.GetHour(DateTime.Now) + "-" + pc.GetMinute(DateTime.Now) + "-" + pc.GetSecond(DateTime.Now);
                labelTargetFile.Text = @"D:\\" + TimeNow + ".bak";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}