using System;
using System.Drawing;
using System.Windows.Forms;

namespace Atiran.UI.WindowsForms.Controls
{
    public class DateControl : System.Windows.Forms.Control
    {
        private ToolTip tt = new ToolTip();
        public System.Windows.Forms.FlowLayoutPanel Wrapper;
        public NumericTextBox Year;
        public NumericTextBox Year2CH;
        public NumericTextBox Month;
        public NumericTextBox Day;
        public System.Windows.Forms.Label YearMonth;
        public System.Windows.Forms.Label MonthDay;
        public bool SendTabKey = false;
        private bool isUpDowningKey = false;
        public bool FutureConfirm { get; set; } = true;
        private bool _dateCriterionFromServer = false;
        public bool DateCriterionFromServer
        {
            get { return _dateCriterionFromServer; }
            set
            {
                if (value == true)
                {
                    string today = TodayFullChar();
                    Day.Text = today.Substring(8, 2);
                    Month.Text = today.Substring(5, 2);
                    Year.Text = today.Substring(0, 4);
                    this.Enabled = false;
                }
                _dateCriterionFromServer = value;
            }
        }

        public System.Windows.Forms.Control NextControl { get; set; }
        public string NowShamsi10Cahracter { get; set; }
        public string NowShamsi8Character { get; set; }
        public string Value10Cahracter { get; set; }
        public string Value8Character { get; set; }
        public bool CanGoForward { get; set; }
        public bool CanGoBackward { get; set; }
        public System.Windows.Forms.Control Next;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            int width = 120;//Year.ClientSize.Width + YearMonth.ClientSize.Width + Month.ClientSize.Width + MonthDay.ClientSize.Width + Day.ClientSize.Width;
            int height = 20; //Year.ClientSize.Height;
            //this.ClientSize = new Size(width, height);
            this.Size = new Size(width, height);
            //this.Font = new Font("AtiranFont", 9.5f, FontStyle.Regular);

        }
        public DateControl()
        {
            CanGoBackward = true;
            CanGoForward = false;
            this.ParentChanged += DateControl_ParentChanged;
            Wrapper = new System.Windows.Forms.FlowLayoutPanel();
            Wrapper.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            Wrapper.Margin = System.Windows.Forms.Padding.Empty;
            Wrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            Year = new NumericTextBox();
            YearMonth = new System.Windows.Forms.Label();
            Month = new NumericTextBox();
            MonthDay = new System.Windows.Forms.Label();
            Day = new NumericTextBox();
            this.Enter += Atiran2DateControl_Enter;
            this.Disposed += (sender, args) =>
            {
                tt.RemoveAll();
                tt.Dispose();
            };
            this.Leave += Atiran2DateControl_Leave;

            //set Today values
            string today = TodayFullChar();

            Year.Text = today.Substring(0, 4);

            Month.Text = today.Substring(5, 2);

            Day.Text = today.Substring(8, 2);

            Day.TextChanged += Day_TextChanged;
            Month.TextChanged += Month_TextChanged;

            Day.Leave += Day_Leave;
            Month.Leave += Month_Leave;
            Year.Leave += Year_Leave;
            //Year
            Year.TabIndex = 2;
            Year.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            SetTextBoxWidthAndHeight(Year, 4);
            RemoveMargin(Year);
            RemoveBorder(Year);
            Wrapper.Controls.Add(Year);

            RemoveMargin(YearMonth);
            YearMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            YearMonth.Text = "/";
            YearMonth.BackColor = Color.White;
            YearMonth.AutoSize = true;
            Wrapper.Controls.Add(YearMonth);
            Month.TabIndex = 1;
            Month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            SetTextBoxWidthAndHeight(Month, 2);
            RemoveBorder(Month);
            RemoveMargin(Month);
            Wrapper.Controls.Add(Month);

            RemoveMargin(MonthDay);
            MonthDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            MonthDay.Height = this.Height;
            MonthDay.Text = "/";
            MonthDay.BackColor = Color.White;
            MonthDay.AutoSize = true;

            Wrapper.Controls.Add(MonthDay);
            Day.TabIndex = 0;
            Day.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            SetTextBoxWidthAndHeight(Day, 2);
            RemoveBorder(Day);
            RemoveMargin(Day);
            Day.Height = this.Height;
            Wrapper.Controls.Add(Day);
            this.Controls.Add(Wrapper);
            this.FontChanged += DateControl_FontChanged;
            Day.KeyDown += Day_KeyDown;
            Month.KeyDown += Month_KeyDown;
            Year.KeyDown += Year_KeyDown;
            YearMonth.BackColor = Year.LeaveBackColor;
            MonthDay.BackColor = Year.LeaveBackColor;
            YearMonth.ForeColor = Year.LeaveForColor;
            MonthDay.ForeColor = Year.LeaveForColor;
        }
        private void Year_Leave(object sender, EventArgs e)
        {
            if (!ValdateYear())
            {
                ShowToolTip((Control)sender);
                //MessageBoxes.CustomMessageForm.CustomMessageBox.Show("خطا", ResourceManager.GetResourceManager().GetString("InvalidDate"), "e");
            }

        }
        private void Year_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //this.Parent.Parent.Parent.Parent.GetNextControl(this, true).Focus();
                //if (e.KeyCode == Keys.Enter)
                //    SendKeys.Send("{TAB}");
                if (e.KeyCode == Keys.Enter)
                {
                    if (NextControl != null && NextControl.Visible && NextControl.Enabled)
                    {
                        NextControl.Focus();
                    }
                    else if (NextControl != null && (!NextControl.Visible | !NextControl.Enabled))
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    CheckKeyUpDown(e, Year, 2200);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public string ShamsiFullCharacteriValue()
        {
            return Year.Text + "/" + Month.Text + "/" + Day.Text;
        }
        private void Month_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Year.Focus();
            }
            else
            {
                CheckKeyUpDown(e, Month, 12);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Day_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Day.Focused)
            {
                Month.Focus();
                Month.Focus();
                Month.Select(0, 3);
            }
            else
            {
                CheckKeyUpDown(e, Day, 31);
            }

        }
        private void CheckKeyUpDown(KeyEventArgs e, NumericTextBox textBox, int bound)
        {
            if (e.KeyCode == Keys.Up)
            {
                isUpDowningKey = true;
                textBox.Text = (textBox.Value % bound) + 1 + "";
                textBox.SelectionStart = textBox.Text.Length;
                isUpDowningKey = false;
                return;
            }
            else if (e.KeyCode == Keys.Down)
            {
                isUpDowningKey = true;
                if (textBox.Value <= 1)
                    textBox.Text = bound.ToString();
                else
                    textBox.Text = (textBox.Value - 1) % bound + "";
                textBox.SelectionStart = textBox.Text.Length;
                isUpDowningKey = false;
            }
        }
        public DateTime GetDate()
        {
            try
            {
                return new DateTime((int)Year.Value, (int)Month.Value, (int)Day.Value, new System.Globalization.PersianCalendar());
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public string GetDateFullChar()
        {
            return $"{Year.Text}/{Month.Text}/{Day.Text}";
        }
        public void SetDate(DateTime value)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            int year = pc.GetYear(value);
            int month = pc.GetMonth(value);
            int day = pc.GetDayOfMonth(value);
            Year.Text = year.ToString("00");
            Month.Text = month.ToString("00");
            Day.Text = day.ToString("00");
        }
        void Month_Leave(object sender, EventArgs e)
        {
            if (Month.Text.Length == 1)
            {
                Month.Text = string.Concat("0", Month.Text);
            }

            else if (Month.Text.Length == 0)
            {
                Month.Text = TodayFullChar().Substring(5, 2);
            }
            if (!ValidateMonth())
            {
                ShowToolTip((Control)sender);
                //MessageBoxes.CustomMessageForm.CustomMessageBox.Show("خطا", ResourceManager.GetResourceManager().GetString("InvalidDate"), "e");
            }
        }
        void Day_Leave(object sender, EventArgs e)
        {
            if (Day.Text.Length == 1)
            {
                Day.Text = String.Concat("0", Day.Text);
            }

            if (Day.Text.Length == 0)
            {
                Day.Text = TodayFullChar().Substring(8, 2);
            }

            if (!ValidateDay())
            {
                ShowToolTip((Control)sender);
                //MessageBoxes.CustomMessageForm.CustomMessageBox.Show("خطا", ResourceManager.GetResourceManager().GetString("InvalidDate"), "e");
            }
        }
        void Day_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Tag))
            {
                if (Day.Text.Length == 2 && !isUpDowningKey)
                {
                    Month.Focus();
                    Month.Focus();
                }
            }
            else
            {
                Tag = true;
            }
        }
        void Month_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Tag))
            {
                if (Month.Text.Length == 2 && !isUpDowningKey)
                    Year.Focus();
            }
            else
            {
                Tag = true;
            }
        }
        void Atiran2DateControl_Enter(object sender, EventArgs e)
        {
            if (_dateCriterionFromServer)
            {
                if (NextControl != null && NextControl.Visible && NextControl.Enabled)
                {
                    NextControl.Focus();
                }
                else if (NextControl != null && (!NextControl.Visible | !NextControl.Enabled))
                {
                    SendKeys.Send("{TAB}");
                }
                this.Enabled = false;
            }
            else
            {
                Day.Focus();
            }
        }
        private void Atiran2DateControl_Leave(object sender, EventArgs e)
        {
            if (int.Parse(Year.Text) % 4 != 3 && int.Parse(Month.Text) == 12 && int.Parse(Day.Text) > 29)
            {
                Tag = false;
                Day.Text = "29";
            }
            if (!FutureConfirm)
            {
                var DateServer = Atiran.Connections.Operaions.DateOp.DateServer.ReturnDateServer();
                if (GetDateFullChar().CompareTo(DateServer) > 0)
                {
                    Tag = false;
                    Day.Text = DateServer.Substring(8, 2);
                    Month.Text = DateServer.Substring(5, 2);
                    Year.Text = DateServer.Substring(0, 4);
                }
            }
        }
        public bool ValidateDay()
        {
            if (int.Parse(Day.Text) > 31 || int.Parse(Day.Text) <= 0)
            {
                Day.Text = (int.Parse(Day.Text) > 31) ? "31" : "01";
                Day.Focus();
                return false;
            }
            else
                return true;
        }
        public bool ValidateMonth()
        {

            if (int.Parse(Month.Text) > 12 || int.Parse(Month.Text) <= 0)
            {
                Month.Text = (int.Parse(Month.Text) > 12) ? "12" : "01";
                Month.Focus();
                return false;
            }
            else if (int.Parse(Day.Text) == 31 && int.Parse(Month.Text) > 6)
            {
                Day.Text = "30";
                Day.Focus();
                return false;
            }
            else
                return true;
        }
        public bool ValdateYear()
        {
            if (int.Parse(Year.Text) < 1370)
            {
                Year.Text = "1370";
                Year.Focus();
                return false;
            }
            else
                return true;
        }
        void DateControl_ParentChanged(object sender, EventArgs e)
        {
            // this.Font = this.Parent.Font;
        }
        void DateControl_FontChanged(object sender, EventArgs e)
        {
            SetTextBoxWidthAndHeight(Year, 4);
            SetTextBoxWidthAndHeight(Month, 2);
            SetTextBoxWidthAndHeight(Day, 2);
        }
        public void RemoveMargin(System.Windows.Forms.Control con)
        {
            con.Margin = System.Windows.Forms.Padding.Empty;
        }
        public string TodayFullChar()
        {
            string today;
            if (_dateCriterionFromServer)
            {
                today = Atiran.Connections.Operaions.DateOp.DateServer.TodayDateServer;
            }
            else
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                int M = pc.GetMonth(DateTime.Now);
                int d = pc.GetDayOfMonth(DateTime.Now);
                today = pc.GetYear(DateTime.Now).ToString() + "/";

                if (M < 10)
                    today += "0" + M.ToString() + "/";
                else
                    today += M.ToString() + "/";
                if (d < 10)
                    today += "0" + d.ToString();
                else
                    today += d.ToString();
            }

            NowShamsi10Cahracter = today;
            NowShamsi8Character = today;
            return today;
        }
        public static void RefreshDateControl(ref Atiran.UI.WindowsForms.Controls.DateControl DateControl)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            int M = pc.GetMonth(DateTime.Now);
            int d = pc.GetDayOfMonth(DateTime.Now);
            int Y = pc.GetYear(DateTime.Now);
            if (d < 10)
                DateControl.Day.Text = "0" + d.ToString();
            else
                DateControl.Day.Text = d.ToString();
            if (M < 10)
                DateControl.Month.Text = "0" + M.ToString();
            else
                DateControl.Month.Text = M.ToString();
            DateControl.Year.Text = Y.ToString();
        }
        public static void SetDateControl10Char(ref Atiran.UI.WindowsForms.Controls.DateControl DateControl, string date10Char)
        {
            date10Char = date10Char.Trim();
            int M = int.Parse(date10Char.Substring(5, 2));
            int d = int.Parse(date10Char.Substring(8, 2));
            int Y = int.Parse(date10Char.Substring(0, 4));
            if (d < 10)
                DateControl.Day.Text = "0" + d.ToString();
            else
                DateControl.Day.Text = d.ToString();
            if (M < 10)
                DateControl.Month.Text = "0" + M.ToString();
            else
                DateControl.Month.Text = M.ToString();
            DateControl.Year.Text = Y.ToString();
        }
        public void SetTextBoxWidthAndHeight(System.Windows.Forms.TextBox textBox, int maxLength)
        {
            textBox.MaxLength = maxLength;

            using (Graphics G = textBox.CreateGraphics())
            {
                //textBox.Width = (int)(maxLength * (G.MeasureString("X", textBox.Font)).Width);
                //textBox.Height = (int) (G.MeasureString("X", textBox.Font).Height);
                textBox.Width = 28;
                //textBox.Height = 34;


            }

            ////int width = Year.ClientSize.Width + YearMonth.ClientSize.Width + Month.ClientSize.Width + MonthDay.ClientSize.Width + Day.ClientSize.Width;
            ////int height = Year.ClientSize.Height;
            ////this.ClientSize = new Size(width, height);
            //this.Size=new Size(width,height);

        }
        public void RemoveBorder(System.Windows.Forms.TextBox textBox)
        {
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        }

        private void ShowToolTip(Control control)
        {
            tt.RemoveAll();
            tt.OwnerDraw = true;
            tt.Draw += (s, e) =>
            {
                e.Graphics.FillRectangle(SystemBrushes.Info, e.Bounds);
                e.DrawBorder();
                e.DrawText(TextFormatFlags.RightToLeft | TextFormatFlags.Right);
            };
            tt.Show("تاریخ معتبر نیست\nتغییر به حالت معتبر", control, 0, 25, 2000);
        }

        public bool CheckDateByDateServer()
        {
            var dateServer = Atiran.Connections.Operaions.DateOp.DateServer.ReturnDateServer();
            var DateControl = GetDateFullChar();
            return (DateControl == dateServer);
        }


    }
}
