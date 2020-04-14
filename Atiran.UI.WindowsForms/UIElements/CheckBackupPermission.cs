using Atiran.Connections.AtiranAccModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.UI.WindowsForms.Controls;

namespace Atiran.UI.WindowsForms.UIElements
{
    class CheckBackupPermission
    {
        public static bool HavePermission()
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                int userid = Connections.Operaions.UserOp.GetCurrentSysUser.Instance.UserID;
                if (context.UserFormPermissions.Where(i => i.UserID == userid && i.FormID == 109).Count() > 0)
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
