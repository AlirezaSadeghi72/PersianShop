using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atiran.Connections.AtiranAccModel;

namespace Atiran.Connections.Operaions
{
    public class BackupOperaion
    {
        public static string BackupDatabaseWithShirink()
        {
            using (var connection = new SqlConnection(ConnectionInfo.BuildConnectionStringForBackup()))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("BackupWithShirink", connection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 0,
                };
                var outParam = new SqlParameter("@role", SqlDbType.NVarChar)
                {
                    Direction = ParameterDirection.Output,
                    Size = 500,
                };
                command.Parameters.Add(outParam);
                command.ExecuteNonQuery();
                return command.Parameters["@role"].Value.ToString();
            }
        }
    }
}
