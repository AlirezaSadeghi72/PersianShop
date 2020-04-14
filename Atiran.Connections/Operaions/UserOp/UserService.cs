using Atiran.Connections.AtiranAccModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Connections.Operaions.UserOp
{
    public class UserService
    {
        public static void UserLogined(int userID)
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                User instance = context.Users.First(i => i.UserID == userID);
                context.SaveChanges();
            }
        }
        public static bool HaveRoleID(int userid)
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                int roleid = context.Users.Where(i => i.UserID == userid).Select(i => i.UserID).FirstOrDefault();
                if (roleid != 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        private static string GetLocalIPAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        public static Atiran.Connections.AtiranAccModel.User GetUserByID(int UserID)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                return context.Users.AsNoTracking().Single(a => a.UserID == UserID);
            }
        }
        public static bool CheckPasswordForDeleteAllInfo(string password)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                byte[] bytePassword = Encoding.UTF8.GetBytes(password);
                return context.Users.Any(i => i.UserName.Equals(Connections.Operaions.UserOp.GetCurrentSysUser.Instance.UserName) & i.UserPassWord.Equals(bytePassword));
            }
        }


        /// <summary>
        /// Check if this username exists or not
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>True if username exists, otherwise false</returns>
        public bool UserExists(string username)
        {

            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                return context.Users.Any(a => a.UserName == username);
            }
        }

        /// <summary>
        /// Check if username / password matches or not
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>True if username / password matches, otherwise false</returns>
        public bool UsernamePasswordMatches(string username, string password)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                byte[] bytePassword = Encoding.UTF8.GetBytes(password);
                Connections.AtiranAccModel.User user = context.Users.Where(u => u.UserName.Equals(username) && u.UserPassWord.Equals(bytePassword)).FirstOrDefault();
                if (user != null)
                    return true;

                return false;
            }
        }
    }
}