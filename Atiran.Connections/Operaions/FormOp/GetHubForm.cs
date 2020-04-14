using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atiran.Connections.Operaions.FormOp
{
    public class GetHubForm
    {
        public static Atiran.Connections.AtiranAccModel.Form GetNameSpaceForm(int formID)
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                return context.Forms.Find(formID);
            }
        }

    }
}
