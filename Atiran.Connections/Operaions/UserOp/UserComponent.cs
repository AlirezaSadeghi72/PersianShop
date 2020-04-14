using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Connections.AtiranAccModel;


namespace Atiran.Connections.Operaions.UserOp
{
    public class UserComponent
    {
        public static int InserToUser(string userName, string passWord)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                int result = 0;
                try
                {
                    Atiran.Connections.AtiranAccModel.User usr = new Atiran.Connections.AtiranAccModel.User()
                    {
                        UserName = userName,
                        UserPassWord = System.Text.Encoding.UTF8.GetBytes(passWord),
                        Active = true
                    };
                    context.Users.Add(usr);
                    context.SaveChanges();
                    context.AddUser(usr.UserID, Connections.AtiranAccModel.ConnectionInfo.DatabaseName.ToString());
                    result = usr.UserID;
                    return result;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return result;
                }
            }
        }
        public static dynamic GetUsers()
        {
            var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString());
            try
            {
                return (from read in context.Users where read.Active == true select read).ToList();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static List<User> GetAtiranUsers()
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                try
                {
                    return (from read in context.Users where read.Active == true select read).ToList();

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }
        public static bool ChangePassword(int userID, string usrname, string password)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                try
                {
                    User ss = context.Users.Where(i => i.UserID == userID).FirstOrDefault();
                    {
                        ss.UserPassWord = System.Text.Encoding.UTF8.GetBytes(password);
                    }
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.InnerException.ToString());
                    return false;
                }
            }
        }

        public static List<User> GetUserInformation(int userID)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                List<User> find = null;
                try
                {
                    find = (from read in context.Users where read.UserID == userID select read).ToList();
                    return find;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return find;
                }
            }
        }
        public static int checkAtiranUserName(string username)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                try
                {
                    return context.Users.Count(a => a.UserName.ToLower() == username.ToLower());
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }
        public static bool EditUser(int UserID, string userName, string passWord)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                bool result = false;
                try
                {
                    Atiran.Connections.AtiranAccModel.User usr = context.Users.Where(i => i.UserID == UserID).FirstOrDefault();
                    {
                        //usr.UserName = userName;
                        usr.UserPassWord = System.Text.Encoding.UTF8.GetBytes(passWord);
                    };
                    context.SaveChanges();
                    result = true;
                    return result;

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return result;
                }
            }
        }
    }
}
