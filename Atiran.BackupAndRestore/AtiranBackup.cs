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
using Atiran.UI.WindowsForms.MessageBoxes;
using System.Data;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions;
using Atiran.Connections.Operaions.DateOp;
using Ionic.Zip;

namespace Atiran.BackupAndRestore
{
    public class AtiranBackup : UI.WindowsForms.Controls.UserControl
    {
        private UI.WindowsForms.Controls.Label label1;
        private UI.WindowsForms.Controls.Label labelTargetFile;
        private UI.WindowsForms.Controls.Buttons.Button buttonChangeFolder;
        private ProgressBar progressBar1;
        private UI.WindowsForms.Controls.Label labelStatus;
        private UI.WindowsForms.Controls.Label labelDate;
        private FolderBrowserDialog folderBrowserDialog1;
        private UI.WindowsForms.UIElements.Panel panel1;
        private UI.WindowsForms.Controls.Label label5;
        private UI.WindowsForms.Controls.Label label4;
        private UI.WindowsForms.Controls.Label label3;
        private UI.WindowsForms.Controls.Label label2;
        private UI.WindowsForms.Controls.Buttons.Button buttonBackup;
        private System.ComponentModel.IContainer components = null;
        bool FromMain = false;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public AtiranBackup()
        {
            InitializeComponent();
        }
        public AtiranBackup(bool FromMain) : this()
        {
            this.FromMain = true;
        }
        string cpname, servername, TimeNow;
        public void Copyfile(string sourceFileName)
        {
            try
            {
                if (Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام", "آيا مايل به كپي پشتيبان به سيستم خود هستيد؟", "w") == DialogResult.No)
                {
                    return;
                }
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
                    if (i % 100 == 0)
                    {
                        progressBar1.Value = (int)(i * 100 / len) + 1;
                        Application.DoEvents();
                    }
                }
                S_file.Close();
                D_file.Close();
                progressBar1.Value = 100;
                ZipFile(labelTargetFile.Text);
                Atiran.UI.WindowsForms.MessageBoxes.CustomMessageForm.CustomMessageBox.Show("پيغام", "عمليات پشتيبان گيري با موفقيت انجام شد");
                labelStatus.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new Atiran.UI.WindowsForms.Controls.Label();
            this.labelDate = new Atiran.UI.WindowsForms.Controls.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new Atiran.UI.WindowsForms.UIElements.Panel();
            this.label5 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label4 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label3 = new Atiran.UI.WindowsForms.Controls.Label();
            this.label2 = new Atiran.UI.WindowsForms.Controls.Label();
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
            this.buttonBackup.Location = new System.Drawing.Point(509, 263);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.NextControl = null;
            this.buttonBackup.Size = new System.Drawing.Size(83, 36);
            this.buttonBackup.TabIndex = 0;
            this.buttonBackup.Text = "ذخيره ";
            this.buttonBackup.UseVisualStyleBackColor = false;
            this.buttonBackup.Click += new System.EventHandler(this.ButtonBackup_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label1.Location = new System.Drawing.Point(1033, 180);
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
            this.labelTargetFile.Location = new System.Drawing.Point(556, 176);
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
            this.buttonChangeFolder.Location = new System.Drawing.Point(512, 176);
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
            this.progressBar1.ForeColor = System.Drawing.Color.ForestGreen;
            this.progressBar1.Location = new System.Drawing.Point(509, 211);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(635, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelStatus.Font = new System.Drawing.Font("IRANSans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(509, 240);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(635, 23);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelDate
            // 
            this.labelDate.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelDate.Location = new System.Drawing.Point(6, 4);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(132, 27);
            this.labelDate.TabIndex = 8;
            this.labelDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDate.Visible = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.folderBrowserDialog1.Tag = "";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.labelDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.panel1.Location = new System.Drawing.Point(509, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 138);
            this.panel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label5.Location = new System.Drawing.Point(201, 96);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(435, 22);
            this.label5.TabIndex = 13;
            this.label5.Text = "3 - در حين پشتيبان گيري بروي حافظه خارجي، اتصال حافظه با سرور قطع نـكنيد.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label4.Location = new System.Drawing.Point(367, 66);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(269, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "2 - در حين پشتيبان گيري سرور را خاموش نـكنيد.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label3.Location = new System.Drawing.Point(300, 35);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(335, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "1 - قبل از آغاز پشتيبان گيري، تمامي كلاينت هارا خاموش كنيد.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRANSans(FaNum)", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(596, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "!توجه";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AtiranBackup
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonChangeFolder);
            this.Controls.Add(this.labelTargetFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBackup);
            this.Name = "AtiranBackup";
            this.Size = new System.Drawing.Size(1278, 686);
            this.Load += new System.EventHandler(this.AtiranBackup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void buttonChangeFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                labelTargetFile.Text = folderBrowserDialog1.SelectedPath.ToString() + @"\" + TimeNow + ".bak";
        }
        private void ZipFile(string Path)
        {
            try
            {
                var Res = Path.Replace(".bak", ".zip");
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = "sac-100";
                    zip.AddFile(Path);
                    zip.Save(Res);
                }
                System.IO.File.Delete(Path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void ButtonBackup_Click(object sender, EventArgs e)
        {
            try
            {
                buttonChangeFolder.Enabled = false;
                buttonBackup.Enabled = false;
                string Res = BackupOperaion.BackupDatabaseWithShirink();
                Copyfile(Res);
                LoadTime();
                if (FromMain)
                {
                    this.ParentForm.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            finally
            {
                buttonChangeFolder.Enabled = true;
                buttonBackup.Enabled = true;
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
                LoadTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTime()
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            TimeNow = labelDate.Text + "-" + pc.GetHour(DateTime.Now) + "-" + pc.GetMinute(DateTime.Now) + "-" + pc.GetSecond(DateTime.Now);
            labelTargetFile.Text = @"D:\\" + TimeNow + ".bak";
        }
    }
}
