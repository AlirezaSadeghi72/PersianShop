using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Connections.AtiranAccModel;

namespace Atiran.Connections.Operaions.SubSystemOp
{
    public static class SubSystemOperaion
    {
        #region MyRegion

        public static List<Atiran.Connections.AtiranAccModel.SubSystem> ResultAllSubSystem
        {
            get
            {
                if (_allSubSystem == null)
                {
                    SetSubsystem(false);
                }

                return _allSubSystem;
            }
        }

        private static List<Atiran.Connections.AtiranAccModel.SubSystem> _allSubSystem;

        #endregion

        #region TabBar

        public static List<Atiran.Connections.AtiranAccModel.SubSystem> ResultAllSubSystemTabBar
        {
            get
            {
                if (_resultAllSubSystemTabBar == null)
                {
                    SetSubsystem(true);
                }

                return _resultAllSubSystemTabBar;
            }
        }

        private static List<Atiran.Connections.AtiranAccModel.SubSystem> _resultAllSubSystemTabBar;

        private static List<int> HideMenu = new List<int>();
        private static void GetHideMenu()
        {
            //using (var ctx = new Connections.AtiranAccModel.AccModelEntities(Connections.ConnectionInfo.BuildConnectionString()))
            //{
            //    var result = ctx.overal_setting
            //        .Where(o => new List<int> { 74, 75, 76, 88, 126, 268 }.Contains(o.id) && o.value == 0).Select(s => s.id).ToList();
            //    HideMenu = result.Select(o => o == 74 ? 5 : o == 75 ? 6 : o == 76 ? 10 : o == 88 ? 9 : 14).ToList();
            //    if (result.Any(o => o == 268))
            //    {
            //        HideMenu.Add(1);// حذف خريد و فروش از منو
            //        HideMenu.Add(12);// حذف خزانه داري از منو
            //    }
            //}
            HideMenu.Add(13);// حذف ميانبر از منو
            HideMenu.Add(4);// حذف انبار از منو
        }

        #endregion



        private static void SetSubsystem(bool IsTabBar)
        {
            using (var ctx = new Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                if (!IsTabBar)
                {
                    _allSubSystem = ctx.SubSystems.ToList();
                }
                else
                {
                    GetHideMenu();
                    _resultAllSubSystemTabBar = ctx.SubSystems.Where(m => (!HideMenu.Contains(m.SubSystemId))).ToList();
                }
            }
        }

    }
}
