using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions.UserOp;

namespace Atiran.Connections.Operaions.UserFormPermissionOp
{
    public class FormPermission
    {
        public static bool AccessUserForm(int FormID)
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                UserFormPermission instance = context.UserFormPermissions.Where(i => i.UserID == GetCurrentSysUser.Instance.UserID && i.FormID == FormID).FirstOrDefault();
                if (instance != null && context.Menus.Any(a => a.FormID == FormID && a.SubSystemID != null))
                    return true;
                return false;
            }
        }
        public static bool AccessUserForm(List<int> FormIDs)
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                if (context.UserFormPermissions.Where(i => i.UserID == GetCurrentSysUser.Instance.UserID && FormIDs.Contains(i.FormID)).Count() > 0)
                    return true;
                return false;
            }
        }

        public static bool CheckBackupPermission()
        {
            using (var context =
                new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo
                    .BuildConnectionString()))
            {
                int userid = Connections.Operaions.UserOp.GetCurrentSysUser.Instance.UserID;
                if (context.UserFormPermissions.Where(i => i.UserID == userid && i.FormID== 109).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
