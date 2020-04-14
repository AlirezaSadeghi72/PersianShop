using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Xml;
using Atiran.Connections.AtiranAccModel;


namespace Atiran.Connections.Operaions.MenuOp
{
    public static class MenuOperaion
    {
        #region Hub

        public static List<Atiran.Connections.AtiranAccModel.Menu> ResultAllMenu
        {
            get
            {
                if (_allMenu == null)
                {
                    SetMenu(false);
                }

                return _allMenu;
            }
        }

        private static List<Atiran.Connections.AtiranAccModel.Menu> _allMenu;

        #endregion

        #region TabBar

        private static List<Atiran.Connections.AtiranAccModel.Menu> _resultAllMenuTabBar;

        public static List<Atiran.Connections.AtiranAccModel.Menu> ResultAllMenuTabBar
        {
            get
            {
                if (_resultAllMenuTabBar == null)
                {
                    SetMenu(true);
                }

                return _resultAllMenuTabBar;
            }
        }

        #endregion


        private static void SetMenu(bool IsTabBar)
        {
            using (var ctx =
                new Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                if (!IsTabBar)
                {

                    _allMenu = ctx.Menus.Include("Form").Include("Form.UserFormPermissions").ToList();
                }
                else
                {
                    _resultAllMenuTabBar = ctx.Menus.Include("Form").Include("Form.UserFormPermissions").Where(m =>
                            m.SubSystemID != null ||
                            m.FormID == null && ctx.Menus.Any(m1 => m1.ParentMenuID == m.MenuID))
                        .ToList();
                }
            }
        }

        public static List<Atiran.Connections.AtiranAccModel.Menu> GetMenus(string text)
        {
            using (var ctx = new Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                return ctx.Menus.Where(m => m.Titel.Contains(text) & m.FormID > 0 & m.SubSystemID != null).OrderBy(m => m.SubSystemID).ToList();
            }
        }

    }
}
