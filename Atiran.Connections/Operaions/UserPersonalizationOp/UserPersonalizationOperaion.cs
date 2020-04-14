using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Connections.AtiranAccModel;
using Atiran.Connections.Operaions.UserOp;
using System.Data.Entity.Core.EntityClient;
using System.Xml;

namespace Atiran.Connections.Operaions.UserPersonalizationOp
{
    public static class UserPersonalizationOperaion
    {

        public static bool InsertIntoUserPersonalization(
           List<Atiran.Connections.AtiranAccModel.UserPersonalizationForColor> UserPersonalizationForColor,
           List<Atiran.Connections.AtiranAccModel.UserPersonalizationForFont> UserPersonalizationForFont, string ImageAddres, bool Default = false)
        {
            //Color
            var PersonalizationColorID = PersonalizationForColor.Where(w => UserPersonalizationForColor.Any(a =>
                a.ControlColorID == w.ControlColorID && a.ControlNameID == w.ControlNameID)).Select(s => s.PersonalizationColorID).ToList();
            //Font
            List<int> PersonalizationFontID = PersonalizationForFont.Where(w => UserPersonalizationForFont.Any(a => a.ControlNameID == w.ControlNameID)).Select(s => s.PersonalizationFontID).ToList();

            using (var ctx = new Atiran.Connections.AtiranAccModel.AccModelEntities(Connections.AtiranAccModel.ConnectionInfo.BuildConnectionString()))
            {
                ctx.Database.CommandTimeout = 0;
                using (var trans = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (Default)
                        {
                            //Color
                            ctx.UserPersonalizationForColors.RemoveRange(ctx.UserPersonalizationForColors.Where(w => w.UserID == GetCurrentSysUser.Instance.UserID).ToList());

                            //Font
                            ctx.UserPersonalizationForFonts.RemoveRange(ctx.UserPersonalizationForFonts.Where(w => w.UserID == GetCurrentSysUser.Instance.UserID).ToList());
                                GetCurrentSysUser.Instance.BackGroundAddress = "";
                            Atiran.Connections.AtiranAccModel.User temp = ctx.Users.FirstOrDefault(f =>
                                f.UserID == GetCurrentSysUser.Instance.UserID);
                            {
                                temp.BackGroundAddress = "";
                                GetCurrentSysUser.Instance.BackGroundAddress = "";
                            }

                        }
                        else
                        {
                            //Color
                            ctx.UserPersonalizationForColors.RemoveRange(ctx.UserPersonalizationForColors.Where(w => PersonalizationColorID.Contains(w.PersonalizationColorID)));

                            ctx.UserPersonalizationForColors.AddRange(UserPersonalizationForColor);

                            //Font
                            ctx.UserPersonalizationForFonts.RemoveRange(ctx.UserPersonalizationForFonts.Where(w => PersonalizationFontID.Contains(w.PersonalizationFontID)).ToList());

                            ctx.UserPersonalizationForFonts.AddRange(UserPersonalizationForFont);

                            if (ImageAddres != GetCurrentSysUser.Instance.BackGroundAddress)
                            {
                                Atiran.Connections.AtiranAccModel.User temp = ctx.Users.FirstOrDefault(f =>
                                    f.UserID == GetCurrentSysUser.Instance.UserID);
                                {
                                    temp.BackGroundAddress = ImageAddres;
                                    GetCurrentSysUser.Instance.BackGroundAddress = ImageAddres;
                                }
                            }
                        }

                        //save
                        ctx.BulkSaveChanges();
                        trans.Commit();

                        Atiran.Connections.Operaions.UserPersonalizationOp.UserPersonalizationOperaion.SetUserPersonalization();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.ToString());
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public static List<Atiran.Connections.AtiranAccModel.UserPersonalizationForColor> PersonalizationForColor;
        public static List<Atiran.Connections.AtiranAccModel.UserPersonalizationForFont> PersonalizationForFont;

        public static void SetUserPersonalization()
        {
            using (var ctx = new Connections.AtiranAccModel.AccModelEntities(ConnectionInfo.BuildConnectionString()))
            {
                PersonalizationForColor = ctx.UserPersonalizationForColors.AsNoTracking()
                    .Where(w => w.UserID == GetCurrentSysUser.Instance.UserID).ToList();

                PersonalizationForFont = ctx.UserPersonalizationForFonts.AsNoTracking()
                    .Where(w => w.UserID == GetCurrentSysUser.Instance.UserID).ToList();
            }
        }


        #region TabBar

        public static string ImageBackgroundAddres => Atiran.Connections.Operaions.UserOp.GetCurrentSysUser.Instance.BackGroundAddress;

        public static Color BackgroundColorInItemTitre
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID ==
                    (int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorIn &&
                    f.ControlNameID ==
                    (int)Atiran.Connections.Enums.ControlNamesEnum.Titre);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.Teal;
            }
        }

        public static Color ColorFrontTitre
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID == (int)Atiran.Connections.Enums.ControlColorsEnum.ForColorOut &&
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Titre);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.White;
            }
        }

        public static Color BackgroundColorOutTitre
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID ==
                    (int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorOut &&
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Titre);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.FromArgb(21, 100, 123);
            }
        }

        public static Color ForColorOutMenu
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID == (int)Atiran.Connections.Enums.ControlColorsEnum.ForColorOut &&
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Menu);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.White;
            }
        }

        public static Color ForColorInMenu
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID == (int)Atiran.Connections.Enums.ControlColorsEnum.ForColorIn &&
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Menu);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.White;
            }
        }

        public static Color BackgroundColorOutMenu
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID ==
                    (int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorOut &&
                    f.ControlNameID ==
                    (int)Atiran.Connections.Enums.ControlNamesEnum.Menu);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.FromArgb(20, 130, 150);
            }
        }

        public static Color BackgroundColorInMenu
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID ==
                    (int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorIn &&
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Menu);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.Teal;
            }
        }

        public static int FontSizeMenu
        {
            get
            {
                var Result = PersonalizationForFont.FirstOrDefault(f =>
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Menu);
                return (Result != null) ? Result.FontSize : 11;
            }
        }

        public static Color BackgroundColorFooter
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID ==
                    (int)Atiran.Connections.Enums.ControlColorsEnum.BackgroundColorOut &&
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Footer);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.White;
            }
        }

        public static Color ForColorFooter
        {
            get
            {
                var Result = PersonalizationForColor.FirstOrDefault(f =>
                    f.ControlColorID == (int)Atiran.Connections.Enums.ControlColorsEnum.ForColorOut &&
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Footer);
                return (Result != null) ? Color.FromArgb(Result.R, Result.G, Result.B) : System.Drawing.Color.Black;
            }
        }

        public static int FontSizeFooter
        {
            get
            {
                var Result = PersonalizationForFont.FirstOrDefault(f =>
                    f.ControlNameID == (int)Atiran.Connections.Enums.ControlNamesEnum.Footer);
                return (Result != null) ? Result.FontSize : 10;
            }
        }

        #endregion
    }
}
