using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions.UserOp;
using Menu = Atiran.Connections.AtiranAccModel.Menu;

namespace Atiran.Connections.Operaions.SubSystemPermissionOp
{
    public class SubSystemPermissionOperaion
    {
        //static string path = "";

        static List<Menu> menuList = new List<Menu>();

        public static SubSystemPermission GetUserModulePermissionStatus(int userID, int moduleID)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                try
                {
                    SubSystemPermission find = context.SubSystemPermissions.FirstOrDefault(a => a.UserID == userID && a.SubSystemID == moduleID);
                    return find;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public static void DeleteModulePermission(int userID)
        {
            using (var context = new AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                context.Database.CommandTimeout = 0;
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SubSystemPermissions.RemoveRange(context.SubSystemPermissions.Where(a => a.UserID == userID));
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        public static void insertToModulePermission(int userID, List<int> moduleIDlist, List<int> moduleIDlistOrginal)
        {
            using (var context = new AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                context.Database.CommandTimeout = 0;
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var item in moduleIDlist)
                        {
                            Atiran.Connections.AtiranAccModel.SubSystemPermission mod = new SubSystemPermission
                            {
                                UserID = userID,
                                SubSystemID = item
                            };
                            context.SubSystemPermissions.Add(mod);
                            context.SaveChanges();
                        }
                        List<int> DeleteFormPermisions = moduleIDlistOrginal.Except(moduleIDlist).ToList();
                        foreach (var item in DeleteFormPermisions)
                        {
                            List<int> formIDlist = (from read in context.Menus where read.SubSystemID == item && read.FormID > 0 select read.FormID.Value).Distinct().ToList();
                            var dct = (from read in context.UserFormPermissions where formIDlist.Any(i => read.FormID == i) && read.UserID== userID select read);
                            if (dct != null && dct.Count() > 0)
                            {
                                context.UserFormPermissions.RemoveRange(dct);
                                context.SaveChanges();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        transaction.Rollback();
                    }
                }
            }
        }
        public static void FillMenuList()
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                try
                {
                    menuList = (from read in context.Menus.AsNoTracking() select read).OrderBy(i => i.order).ToList();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }

        public static List<SubSystemPermission> GetListOfPermissionThisUser(int UserID)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                List<SubSystemPermission> PermissionList = context.SubSystemPermissions.Where(i => i.UserID == UserID).ToList();
                return PermissionList;
            }
        }

        public static void GetFormEnvironmentList(TreeView treeView, int EnvironmentID, int userID, List<long> formNodes, List<long> fieldNodes, List<long> allFormNodes, List<long> allFieldNodes)
        {
            using (var context = new Atiran.Connections.AtiranAccModel.AccModelEntities(Atiran.Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                List<Menu> allMenu = context.Menus.ToList();
                List<Field> allField = context.Fields.ToList();
                List<User> allSysUsers = context.Users.ToList();
                List<UserFieldPermission> allUserFieldPermission = context.UserFieldPermissions.Include("Field").AsNoTracking().Where(m => m.UserID == userID ).ToList();
                List<UserFormPermission> allUserFormPermission = context.UserFormPermissions.AsNoTracking().Where(a => a.UserID== userID).ToList();
                if (EnvironmentID == 1000)
                {
                }
                else
                {
                    treeView.Nodes.Clear();
                    formNodes.Clear(); fieldNodes.Clear(); allFieldNodes.Clear(); allFormNodes.Clear();
                    TreeNode MainNode = new TreeNode("انتخاب همه")
                    {
                        ForeColor = System.Drawing.Color.Blue
                    };
                    MainNode.Expand();
                    MainNode.Tag = "select";
                    List<Menu> parentformlist = ((from m in context.Menus.Include("Form").Include("Form.Fields").Include("Form.UserFormPermissions").AsNoTracking() where m.ParentMenuID == 0 && m.SubSystemID == EnvironmentID select m).OrderBy(i => i.order).ToList());
                    foreach (Menu item in parentformlist)
                    {
                        MainNode.Nodes.Add(item.Titel.ToString());
                        if (SetCheckParent(item.MenuID, EnvironmentID, userID, allMenu, allUserFormPermission))
                        {
                            MainNode.LastNode.Checked = true;
                        }
                        else if (SetCheckParent(item.MenuID, EnvironmentID, userID, allMenu, allUserFormPermission, false))
                        {
                            MainNode.LastNode.ForeColor = System.Drawing.Color.Chocolate;
                        }
                        if (allMenu.Where(i => i.MenuID == item.MenuID).FirstOrDefault().FormID == null)
                        {
                            MainNode.LastNode.Tag = "MI" + item.MenuID;
                        }
                        else
                        {
                            MainNode.LastNode.Tag = "FI" + item.FormID;
                            allFormNodes.Add(item.FormID.Value);
                            if (allUserFormPermission.Where(i => i.UserID == userID && i.FormID== item.FormID).Count() > 0)
                            {
                                MainNode.LastNode.Checked = true;
                                formNodes.Add(item.FormID.Value);
                                if (CheckForUserFieldPermissions(allField, allUserFieldPermission, item))
                                {
                                    MainNode.LastNode.ForeColor = System.Drawing.Color.Chocolate; ;
                                }
                            }
                            else
                            {
                                MainNode.LastNode.Checked = false;
                            }

                        }
                        SubNodes(MainNode, int.Parse(item.MenuID.ToString()), formNodes, fieldNodes, allFormNodes, allFieldNodes, userID, allMenu, allField, allUserFieldPermission, allSysUsers, allUserFormPermission);
                    }
                    treeView.Nodes.Add(MainNode);
                }
            }
        }

        private static bool SetCheckParent(int parentmenuid, int env, int userID, List<Menu> menues, List<UserFormPermission> allUserFormPermission, bool HaveAll = true)
        {
            List<int> MenuID = (from read in menues where read.SubSystemID == env && read.ParentMenuID == parentmenuid select read.MenuID).ToList();
            List<int> ParentMenuID = (from read in menues where read.SubSystemID == env && MenuID.Any(c => read.ParentMenuID == c) select read.MenuID).ToList();
            menues = menues.Where(i => i.FormID > 0 && i.SubSystemID == env && (i.ParentMenuID == parentmenuid || MenuID.Any(c => i.MenuID == c) || ParentMenuID.Any(c => i.MenuID == c))).ToList();
            foreach (var item in menues)
            {
                if (HaveAll && allUserFormPermission.Where(i => i.UserID == userID && i.FormID == item.FormID).Count() == 0)
                {
                    return false;
                }
                else if (!HaveAll && allUserFormPermission.Where(i => i.UserID == userID && i.FormID== item.FormID).Count() > 0)
                {
                    return true;
                }
            }
            return true && HaveAll;
        }

        private static bool CheckForUserFieldPermissions(List<Field> allField, List<UserFieldPermission> allUserFieldPermission, Menu item)
        {
            return allUserFieldPermission.Where(a => a.Field.FormID == item.FormID).Count() != allField.Where(a => a.FormID == item.FormID).Count();
        }

        private static void SubNodes(TreeNode MainNode, int menuid, List<long> formNodes, List<long> fieldNodes, List<long> allFormNodes, List<long> allFieldNodes, int userID, List<Menu> allmenu, List<Field> allField, List<UserFieldPermission> allUserFieldPermission, List<User> allsys_users, List<UserFormPermission> allUserFormPermission)
        {
            try
            {
                List<Menu> result = allmenu.Where(i => i.ParentMenuID == menuid).OrderBy(i => i.order).ToList();
                if (result.Count == 0)
                {
                    int FormIDHere = (int?)allmenu.Find(i => i.MenuID == menuid).FormID ?? 0;
                    if (FormIDHere > 0 && (allField.Where(i => i.FormID == FormIDHere).Count() > 0))
                    {
                        List<int> fieldidList = (from read in allField where read.FormID == FormIDHere select read.FieldID).ToList();
                        foreach (int fieldid in fieldidList)
                        {
                            MainNode.LastNode.Nodes.Add(allField.Where(i => i.FieldID == fieldid).FirstOrDefault().Description.ToString());
                            MainNode.LastNode.LastNode.Tag = "FP" + fieldid;

                            allFieldNodes.Add(fieldid);
                            if (allUserFieldPermission.Where(i => i.UserID == userID && i.FieldID == fieldid).Count() > 0)
                            {
                                MainNode.LastNode.LastNode.Checked = true;
                                fieldNodes.Add(fieldid);
                            }
                            else
                            {
                                MainNode.LastNode.LastNode.Checked = false;
                                fieldNodes.Remove(FormIDHere);
                            }
                            int Currentuserid = GetCurrentSysUser.Instance.UserID;
                        }
                    }
                }
                foreach (Menu item in result)
                {
                    if (allmenu.Where(i => i.MenuID == item.MenuID && item.FormID != null && item.SubSystemID != null).Count() > 0)
                    {
                        MainNode.LastNode.Nodes.Add(item.Titel.ToString());
                        MainNode.LastNode.LastNode.Tag = "FI" + item.FormID;
                        if (allUserFormPermission.Where(i => i.UserID== userID && i.FormID== item.FormID).Count() > 0)
                        {
                            MainNode.LastNode.LastNode.Checked = true;
                            formNodes.Add(item.FormID.Value);
                            if (CheckForUserFieldPermissions(allField, allUserFieldPermission, item))
                            {
                                MainNode.LastNode.LastNode.ForeColor = System.Drawing.Color.Chocolate;
                            }
                        }
                        allFormNodes.Add(int.Parse(item.FormID.ToString()));
                        if (allField.Where(i => i.FormID == item.FormID).Count() > 0)
                        {
                            List<int> fieldidList = (from read in allField where read.FormID == item.FormID select read.FieldID).ToList();
                            foreach (int fieldid in fieldidList)
                            {
                                MainNode.LastNode.LastNode.Nodes.Add(allField.Where(i => i.FieldID == fieldid).FirstOrDefault().Description.ToString());
                                MainNode.LastNode.LastNode.LastNode.Tag = "FP" + fieldid;

                                allFieldNodes.Add(fieldid);
                                if (allUserFieldPermission.Where(i => i.UserID == userID && i.FieldID == fieldid).Count() > 0)
                                {
                                    MainNode.LastNode.LastNode.LastNode.Checked = true;
                                    fieldNodes.Add(fieldid);
                                }
                                else
                                {
                                    MainNode.LastNode.LastNode.LastNode.Checked = false;
                                    fieldNodes.Remove(item.FormID.Value);
                                }
                                int Currentuserid = GetCurrentSysUser.Instance.UserID;
                            }
                        }
                    }
                    else
                    {
                        SubNodes(MainNode, item.MenuID, formNodes, fieldNodes, allFormNodes, allFieldNodes, userID, allmenu, allField, allUserFieldPermission, allsys_users, allUserFormPermission);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        public static async System.Threading.Tasks.Task DeleteFormPermission(int userID, List<long> formIDlist)
        {
            using (var context = new AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                context.Database.CommandTimeout = 0;
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var dct = (from read in context.UserFormPermissions where formIDlist.Any(i => read.FormID == i) && read.UserID== userID select read);
                        if (dct != null && dct.Count() > 0)
                        {
                            context.UserFormPermissions.RemoveRange(dct);
                            await context.SaveChangesAsync();
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        transaction.Rollback();
                    }
                }
            }
        }
        public static async System.Threading.Tasks.Task DeleteFieldPermission(int userID, List<long> fieldIDlist)
        {
            using (var context = new AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                context.Database.CommandTimeout = 0;
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var dct = (from read in context.UserFieldPermissions where fieldIDlist.Any(i => read.FieldID == i) && read.UserID == userID select read);
                        if (dct != null && dct.Count() > 0)
                        {
                            context.UserFieldPermissions.RemoveRange(dct);
                            await context.SaveChangesAsync();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        public static async System.Threading.Tasks.Task insertToFormPermission(int userID, List<long> formIDlist)
        {
            using (var context = new AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                context.Database.CommandTimeout = 0;
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<UserFormPermission> details = (from item in formIDlist
                                                        select new UserFormPermission()
                                                        {
                                                            FormID = (int)item,
                                                            UserID = userID
                                                        }).ToList();
                        context.UserFormPermissions.AddRange(details);
                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        transaction.Rollback();
                    }
                }
            }
        }

        public static async System.Threading.Tasks.Task insertToFieldPermission(int userID, List<long> fieldIDlist)
        {
            using (var context = new AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                context.Database.CommandTimeout = 0;
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<UserFieldPermission> details = (from item in fieldIDlist
                                                        select new UserFieldPermission()
                                                        {
                                                            FieldID = (int)item,
                                                            UserID = userID
                                                        }).ToList();
                        context.UserFieldPermissions.AddRange(details);
                        await context.SaveChangesAsync();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        transaction.Rollback();
                    }
                }
            }
        }

    }
}
