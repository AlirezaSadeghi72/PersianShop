using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Connections.Operaions.UserOp
{
    public class GetCurrentSysUser
    {
        private static AtiranAccModel.User currentUser;
        public static AtiranAccModel.User Instance
        {
            set
            {
                currentUser = value;
            }
            get
            {
                if (currentUser != null)
                    return currentUser;
                else

                    return setCurrentDefaultUser();

            }
        }
        private static Connections.AtiranAccModel.User setCurrentDefaultUser()
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                return Instance = (from us in context.Users where us.UserName.Equals(Connections.AtiranAccModel.ConnectionInfo.User) select us).FirstOrDefault();
            }
        }
        public static System.Collections.Generic.List<Connections.AtiranAccModel.User> SysList()
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                return context.Users.ToList();
            }
        }
        public static void SetCurrentUserByFiscalUserName(string userName)
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                Instance = (from us in context.Users where us.UserName.Equals(userName) select us).FirstOrDefault();
            }
        }
        public static bool CheckDaryaft()
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                if (context.UserFieldPermissions.Count() > 0)
                {
                    if (context.UserFieldPermissions.AsNoTracking().Where(i => i.UserID == GetCurrentSysUser.Instance.UserID & i.Field.FormID == 300).Count() > 0)
                        return true;
                    return false;
                }
                return false;
            }
        }
        public static bool CheckPardakht()
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                if (context.UserFieldPermissions.Count() > 0)
                {
                    if (context.UserFieldPermissions.AsNoTracking().Where(i => i.UserID == GetCurrentSysUser.Instance.UserID & i.Field.FormID == 301).Count() > 0)
                        return true;
                    return false;
                }
                return false;
            }
        }
    }
}
