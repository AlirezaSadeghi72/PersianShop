﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.CustomDocking.MessageBox
{
    public static class ShowPersianMessageBox
    {
        public static System.Windows.Forms.DialogResult ShowMessge(string Caption, string Message, System.Windows.Forms.MessageBoxButtons buttons, bool FocuseOnYes = true,bool ShowAllButton = true)
        {
            System.Windows.Forms.DialogResult Result = System.Windows.Forms.DialogResult.None;
            switch (buttons)
            {
                case System.Windows.Forms.MessageBoxButtons.OK:
                    using (var Temp = new System.Windows.Forms.Form())
                    {
                        Temp.Dock = System.Windows.Forms.DockStyle.Fill;
                        Temp.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        Temp.BackColor = System.Drawing.Color.Silver;
                        Temp.Opacity = 0.7D;
                        Temp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        Temp.KeyDown += (sender, e) =>
                        {
                            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                            {
                                Temp.Close();
                            }
                        };
                        Temp.Load += (sender, e) =>
                        {
                            using (var Confirm = new ConfirmMessageBox())
                            {
                                Confirm.Caption = Caption;
                                Confirm.SetMessage = Message;
                                Result = Confirm.ShowDialog();
                                Temp.Close();
                            }
                        };
                        Temp.ShowDialog();
                    }
                    break;
                case System.Windows.Forms.MessageBoxButtons.OKCancel:
                    break;
                case System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore:
                    break;
                case System.Windows.Forms.MessageBoxButtons.YesNoCancel:
                    break;
                case System.Windows.Forms.MessageBoxButtons.YesNo:
                    using (var Temp = new System.Windows.Forms.Form())
                    {
                        Temp.BackColor = System.Drawing.Color.Black;
                        Temp.ClientSize = new System.Drawing.Size(1280, 769);
                        Temp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                        Temp.Opacity = 0.7D;
                        Temp.ShowIcon = false;
                        Temp.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                        Temp.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                        Temp.ResumeLayout(false);
                        Temp.KeyDown += (sender, e) =>
                        {
                            if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                            {
                                Temp.Close();
                            }
                        };
                        Temp.Load += (sender, e) =>
                        {
                            using (var Confirm = new YesNoMessageBox())
                            {
                                Confirm.Caption = Caption;
                                Confirm.SetMessage = Message;
                                Confirm.LoadOnYesButton = FocuseOnYes;
                                Confirm.ShowAllButton = ShowAllButton;
                                Result = Confirm.ShowDialog();
                                Temp.Close();
                            }
                        };
                        Temp.ShowDialog();
                    }
                    break;
                case System.Windows.Forms.MessageBoxButtons.RetryCancel:
                    break;
            }
            return Result;
        }
    }
}
