using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Connections.AtiranAccModel;

namespace Atiran.Connections.Operaions.DateOp
{
    public class DateServer
    {
        private static string _dateServer;

        public static string TodayDateServer
        {
            get
            {
                if (_dateServer == null)
                    _dateServer = ReturnDateServer();
                return _dateServer;
            }
        }

        public static string ReturnDateServer()
        {
            string ServerTime = DateServer.ServerTime();
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = ConnectionInfo.BuildConnectionString()
            };
            conn.Open();
            SqlCommand c1 = new SqlCommand
            {
                Connection = conn,
                CommandText = ServerTime.CompareTo("12:00:00.0") > 0 ? $"select dbo.[UDF_Gregorian_To_Persian](GETDATE()-1)" : $"select dbo.[UDF_Gregorian_To_Persian](GETDATE())"
            };
            object Result = c1.ExecuteScalar();
            conn.Close();
            return Result.ToString();
        }
        public static string ReturnDateServerMiladi()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = ConnectionInfo.BuildConnectionString()
            };
            conn.Open();
            SqlCommand c1 = new SqlCommand
            {
                Connection = conn,
                CommandText = "select  cast(cast(GETDATE() as date) as nvarchar(400))",
            };
            object Result = c1.ExecuteScalar();
            conn.Close();
            return Result.ToString();
        }
        public static string ReturnDateServer(string Diff)
        {
            string ServerTime = DateServer.ServerTime();
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = ConnectionInfo.BuildConnectionString()
            };
            conn.Open();
            SqlCommand c1 = new SqlCommand
            {
                Connection = conn,
                CommandText = ServerTime.CompareTo("12:00:00.0") > 0 ? $"select dbo.[UDF_Gregorian_To_Persian](GETDATE()-{Diff}-1)" : $"select dbo.[UDF_Gregorian_To_Persian](GETDATE()-{Diff})"
            };
            object Result = c1.ExecuteScalar();
            conn.Close();
            return Result.ToString();
        }
        public static string ServerTime()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = ConnectionInfo.BuildConnectionString()
            };
            conn.Open();
            SqlCommand c1 = new SqlCommand
            {
                Connection = conn,
                CommandText = $"SELECT cast(CONVERT (time, GETDATE()) as nvarchar(8))"
            };
            object Result = c1.ExecuteScalar();
            conn.Close();
            return Result.ToString();
        }
        public static string ServerDateAndTime()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = ConnectionInfo.BuildConnectionString()
            };
            conn.Open();
            SqlCommand c1 = new SqlCommand
            {
                Connection = conn,
                CommandText = $"SELECT GETDATE()"
            };
            object Result = c1.ExecuteScalar();
            conn.Close();
            return Result.ToString();
        }
        public static string AddDayHijri(string Date10Char, int AddDays)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            int year = int.Parse(Date10Char.Substring(0, 4));
            int month = int.Parse(Date10Char.Substring(5, 2));
            int day = int.Parse(Date10Char.Substring(8, 2));
            DateTime dt = new DateTime(year, month, day, pc);
            dt = dt.AddDays(AddDays);
            int yearSH = pc.GetYear(dt);
            int monthSH = pc.GetMonth(dt);
            int daySH = pc.GetDayOfMonth(dt);
            string monthSHStr = monthSH < 10 ? $"0{monthSH.ToString()}" : monthSH.ToString();
            string DaySHStr = daySH < 10 ? $"0{daySH.ToString()}" : daySH.ToString();
            string shamsi = yearSH + "/" + monthSHStr + "/" + DaySHStr;
            return shamsi;
        }
        public static (int Year, int Month, int Day) AddMonthAndDayForGhest(int AddedMonth, int AddedDay, int BaseYear, int BaseMonth, int BaseDay)
        {
            BaseMonth += AddedMonth;
            if (BaseMonth > 12)
            {
                BaseYear += 1;
                return AddMonthAndDayForGhest(0, AddedDay, BaseYear, (BaseMonth % 12), BaseDay);
            }
            BaseDay += AddedDay;
            if (BaseDay > 31)
            {

                return AddMonthAndDayForGhest(1, 0, BaseYear, BaseMonth, (BaseMonth <= 6 ? (BaseDay % 31) : (BaseMonth < 12 ? (BaseDay % 30) : (BaseMonth == 12 && BaseYear % 4 != 3 ? (BaseDay % 29) : (BaseDay % 30)))));
            }
            if (BaseDay == 31 && BaseMonth > 6)
            {
                return AddMonthAndDayForGhest(0, 0, BaseYear, BaseMonth, 30);
            }
            if (BaseDay == 30 && BaseMonth == 12 && (BaseYear % 4) != 3)
            {
                return AddMonthAndDayForGhest(0, 0, BaseYear, BaseMonth, 29);
            }
            return (BaseYear, BaseMonth, BaseDay);
        }
        public static string ReturnDateByValue(int Year, int Month, int Day)
        {
            return $"{Year.ToString()}/{Month.ToString("00")}/{Day.ToString("00")}";
        }
        public static int DiffDate(string Date10Char)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            int year = int.Parse(Date10Char.Substring(0, 4));
            int month = int.Parse(Date10Char.Substring(5, 2));
            int day = int.Parse(Date10Char.Substring(8, 2));
            DateTime dtIn = new DateTime(year, month, day, pc);
            string dateServer = ReturnDateServer();
            int yearS = int.Parse(dateServer.Substring(0, 4));
            int monthS = int.Parse(dateServer.Substring(5, 2));
            int dayS = int.Parse(dateServer.Substring(8, 2));
            DateTime dtServer = new DateTime(yearS, monthS, dayS, pc);
            return (int)((dtIn - dtServer).TotalDays);

        }
        public static string ServerComputerName()
        {
            SqlConnection conn = new SqlConnection
            {
                ConnectionString = ConnectionInfo.ConnectionString()
            };
            conn.Open();
            SqlCommand c1 = new SqlCommand
            {
                Connection = conn,
                CommandText = $"SELECT SERVERPROPERTY('MACHINENAME')"
            };
            object Result = c1.ExecuteScalar();
            conn.Close();
            return Result.ToString();
        }
    }
}
