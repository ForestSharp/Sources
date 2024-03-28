using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using System.Data;
using System.Collections.Generic;

namespace App_Avrora.model
{
    internal class ServerSQL
    {
        private string serverSQL;
        private bool trustConnection = true;
        
        private SqlConnection sqlConnection;
        private string nameDataBase = "";
        private List<string> databases;

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public string NameDataBase { get => nameDataBase; set => nameDataBase = value; }
        public List<string> Databases { get => databases; set => databases = value; }

        public ServerSQL() 
        {
            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();

            if (servers.Rows.Count == 0)
                throw new ArgumentException("На данном компьютере нет ");

            serverSQL = $"{servers.Rows[0]["ServerName"]}\\{servers.Rows[0]["InstanceName"]}";

            using (SqlConnection sqlConnection = new SqlConnection($"Server={serverSQL};Trusted_Connection={trustConnection};"))
            {
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", sqlConnection))
                    {
                        using (IDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Databases.Add(dr[0].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
