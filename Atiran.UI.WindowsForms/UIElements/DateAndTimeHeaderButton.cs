using Atiran.UI.WindowsForms.Controls;
using System;
using System.Drawing;
using System.Globalization;

namespace Atiran.UI.WindowsForms.UIElements
{
    public class DateAndTimeHeaderButton : HeaderButton
    {
        PersianCalendar jalaliCalendar;
        Label lblJalaliDateTime;
        public DateAndTimeHeaderButton(Header parent_)
            : base(parent_)
        {
            this.Width = 180;
            this.BackColor = System.Drawing.Color.FromArgb(120,144,156);
            this.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
            jalaliCalendar = new PersianCalendar();
            lblJalaliDateTime = new Label();
            lblJalaliDateTime.Text = GetDate() + "    " + DateTime.Now.ToString("HH:mm:ss");

            lblJalaliDateTime.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            lblJalaliDateTime.Dock = System.Windows.Forms.DockStyle.Fill;
            lblJalaliDateTime.SendToBack();
            lblJalaliDateTime.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Font = FontManager.GetFont("IRANSans", 10, FontStyle.Bold);
            this.Controls.Add(lblJalaliDateTime);
            StartTimer();
            //HeaderSeperator seperator = new HeaderSeperator(this);
           // seperator.Dock = System.Windows.Forms.DockStyle.Right;
           // this.Controls.Add(seperator);
        }
        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
           // t.Start()
        }
        private string GetDate()
        {
            string year = jalaliCalendar.GetYear(DateTime.Now).ToString();
            string month = jalaliCalendar.GetMonth(DateTime.Now).ToString();
            string day = jalaliCalendar.GetDayOfMonth(DateTime.Now).ToString();
            if (int.Parse(month) < 10) month = "0" + month;
            if (int.Parse(day) < 10) day = "0" + day;
            return $"{year}/{month}/{day}";
        }
        void t_Tick(object sender, EventArgs e)
        {
            lblJalaliDateTime.Text = GetDate() + "    " + DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
