using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Community.CsharpSqlite.SQLiteClient;

namespace CodeShare
{
    public static class SQLHepler
    {
        public static string ConnectionString
        {
            get;
            set;
        }

        public static int ExecuteNonQuery(string sql)
        {
            using (SqliteConnection connection = new SqliteConnection())
            {
                connection.ConnectionString = ConnectionString;
                System.Data.IDbCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                connection.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
