using System;
using Oracle.ManagedDataAccess.Client;

namespace CSharpOracleDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "SELECT * FROM USERS";
            try
            {
                using (OracleConnection connect = new OracleConnection())
                {
                    connect.ConnectionString = "User ID=SYSTEM; Password=toshinomi; Data Source=localhost/TEST_ORCL";
                    connect.Open();
                    using (OracleCommand cmd = new OracleCommand(sql, connect))
                    {
                        //cmd.CommandText = sql;
                        //cmd.Connection = connect;
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine(reader["ID"] + ":" + reader["NAME"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}
