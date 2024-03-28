using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace App_Avrora.model
{
    internal class ServerSQL
    {
        private string serverSQL = "localhost";
        public string Test = "Test";
        private SqlConnection sqlConnection;
        private string nameDataBase;

        public SqlConnection SqlConnection { get => sqlConnection; set => sqlConnection = value; }
        public string NameDataBase { get => nameDataBase; set => nameDataBase = value; }

        public ServerSQL(string nameBase) 
        {
            nameDataBase = nameBase;
            SqlConnection = new SqlConnection();
        }

    }
}
