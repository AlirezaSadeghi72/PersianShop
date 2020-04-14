using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Xml;

namespace Atiran.Connections.AtiranAccModel
{
    public static class ConnectionInfo
    {

        public static string Server { get; set; }
        public static string DatabaseName { get; set; }
        public static string User { get; set; } = "atiranadmin";
        public static string Password { get; set; } = "rafiee_2008";

        public static string AdminUser { get; set; } = null;
        public static string AdminPass { get; set; } = null;

        public const string ActiveForms = "فرم‌هاي فعال";

        public static bool OldSac = false;
        public static string OldDbName;

        public static void ReadData() => SetData();
        private static void SetData()
        {

            try
            {
                XmlTextReader Reader = new XmlTextReader("GetInfo.XML");
                XmlNodeType type;
                while (Reader.Read())
                {
                    type = Reader.NodeType;
                    if (type == XmlNodeType.Element)
                    {

                        if (Reader.Name == "Server")
                        {
                            Reader.Read();
                            Server = Reader.Value;
                        }
                        if (!OldSac)
                        {
                            if (Reader.Name == "DatabaseName")
                            {
                                Reader.Read();
                                DatabaseName = Reader.Value;
                            }
                        }
                        else
                        {
                            DatabaseName = OldDbName;
                        }
                        if (Reader.Name == "Admin")
                        {
                            Reader.Read();
                            AdminUser = Reader.Value;
                        }
                        if (Reader.Name == "Pass")
                        {
                            Reader.Read();
                            AdminPass = Reader.Value;
                        }
                    }
                }

                Reader.Close();
                Reader.Dispose();
            }
            catch (Exception e)
            {

                Server = "192.168.1.220";
                DatabaseName = "sacCustomer";
            }

        }

        public static String BuildConnectionString()
        {
            if (string.IsNullOrEmpty(Server) | string.IsNullOrEmpty(DatabaseName))
                SetData();
            // Build the connection string from the provided datasource and database
            String connString = @"data source=" + Server + ";initial catalog=" + DatabaseName + ";persist security info=True;user id=" + User + ";password=" + Password + ";multipleactiveresultsets=True;application name=EntityFramework&quot;";
            // Build the MetaData... feel free to copy/paste it from the connection string in the config file.
            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            esb.Metadata = @"res://*/";
            esb.Provider = "System.Data.SqlClient";
            esb.ProviderConnectionString = connString;
            // Generate the full string and return it
            return esb.ToString();
        }

        public static string BuildConnectionStringForBackup()
        {
            if (string.IsNullOrEmpty(Server) | string.IsNullOrEmpty(DatabaseName))
                SetData();
            return @"data source=" + Server + ";initial catalog=" + DatabaseName + ";persist security info=True;user id=" + User + ";password=" + Password + ";multipleactiveresultsets=True;application name=EntityFramework&quot;";
        }

        public static String ConnectionString()
        {
            // Build the connection string from the provided datasource and database
            if (string.IsNullOrEmpty(Server) | string.IsNullOrEmpty(DatabaseName))
                SetData();
            //string connString = @"Integrated Security=True;Initial Catalog=sac4;Data Source=.";
            String connString = @"User ID=" + User + ";Integrated Security=False;Data Source=" + Server + ";Initial Catalog=" + DatabaseName + ";Password=" + Password + ";Persist Security Info=True";
            return connString;
        }
    }
}
