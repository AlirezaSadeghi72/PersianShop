using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Connections.AtiranAccModel;

namespace Atiran.Connections.Operaions.ShortcutKeyOp
{
    public static class HelpOperaion
    {
        public static List<ShortcutKey> ReturnAllShortcutKeys()
        {
            using (var context = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                var AllList = context.ShortcutKeys.AsNoTracking().ToList();

                var resultList = AllList.Where(w => w.MainForm.ToLower() == "main").OrderBy(o => o.Shurtcut.Length).ToList();

                resultList.AddRange(context.ShortcutKeys.AsNoTracking()
                    .Where(w => w.MainForm.ToLower() != "main")
                    .OrderBy(o => new { o.MainForm, o.Shurtcut.Length }).ToList());

                return resultList;
            }
        }
    }
}
