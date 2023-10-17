using Fitnes_3L.Properties;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fitnes_3L
{

    internal class ConnectionSQL
    {
        //Microsoft.Data.SqlClient необходимо установить в проект через nuget пакет

        //private string connectionString = "Server=.\\SQLEXPRES;Database=Фитнесс центр Триэль;Trusted_Connection=True;Trust Server Certificate=true;";


        static private Settings1 settings = new Settings1();
        public SqlConnection connection = new SqlConnection(settings.connectionString);

        public void OpenConnection()
        {
            if (connection is null)
                connection = new SqlConnection(settings.connectionString); // Создание подключения


            if (!CheckConnection())
            {
                try
                {
                    // Открываем подключение
                    connection.Open();
                }
                catch (SqlException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

        }

        public async void AsyncOpenConnection()
        {
            if (connection is null)
                connection = new SqlConnection(settings.connectionString); // Создание подключения

            if (!CheckConnection())
            {
                try
                {
                    // Открываем подключение
                    await connection.OpenAsync();
                }
                catch (SqlException ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }

        }

        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                // закрываем подключение
                connection.Close();
            }
        }

        public bool CheckConnection()
        {
            if (connection.State == ConnectionState.Open)
                return true;
            else if (connection.State == ConnectionState.Connecting)
                return true;
            else return false;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

        public SqlDataReader ReadTable(string nameTable)
        {

            OpenConnection();

            string sqlExpression = GetExpressionTable(nameTable);

            SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = cmdSQL.ExecuteReader();


            return reader;
        }

        private string GetExpressionTable(string nameTable)
        {
            string sqlExpression = "";

            if (nameTable == "Сотрудники" || nameTable == "Услуги" || nameTable == "Тренировки")
                sqlExpression = $"SELECT * FROM {nameTable}";
            else if (nameTable == "Расписание")
                sqlExpression = "SELECT Дата, Время, ФИО, Вид_тренировки, [Наименование услуги] From Расписание " +
                    "left join Сотрудники on Расписание.Код_сотрудника = Сотрудники.Код_сотрудника " +
                    "left join Услуги on Расписание.Код_услуги = Услуги.Код_услуги " +
                    "left join Тренировки on Расписание.Код_тренировки = Тренировки.Код_тренировки";

            return sqlExpression;
        }

        public int AddNewStringTables(string nameTable, Dictionary<string, string> dictData)
        {
            int numberInsert = 0;
            string sqlExpression = "";

            switch (nameTable)
            {
                case "Сотрудники":
                    sqlExpression = $"INSERT INTO {nameTable}(Код_сотрудника, ФИО, Адрес, Дата_Рождения) VALUES ('{dictData["Код_сотрудника"]}', '{dictData["ФИО"]}', '{dictData["Адрес"]}', '{dictData["Дата_рождения"]}')";
                    break;
                case "Услуги":
                    sqlExpression = $"INSERT INTO {nameTable}(Код_услуги, [Наименование услуги]) VALUES ('{dictData["Код_услуги"]}', '{dictData["Наименование услуги"]}')";
                    break;
                case "Тренировки":
                    sqlExpression = $"INSERT INTO {nameTable}(Код_тренировки, Вид_тренировки) VALUES ('{dictData["Код_тренировки"]}', '{dictData["Вид_тренировки"]}')";
                    break;
                case "Расписание":
                    sqlExpression = $"INSERT INTO {nameTable}(Дата, Время, Код_сотрудника, Код_услуги, Код_тренировки) VALUES ('{dictData["Дата"]}', '{dictData["Время"]}', '{dictData["Код_сотрудника"]}', '{dictData["Код_услуги"]}', '{dictData["Код_тренировки"]}')";
                    break;
            }

            OpenConnection();

            SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
            try
            {
                numberInsert = cmdSQL.ExecuteNonQuery();
                return numberInsert;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int deleteRecordFromTheDatabase(ListViewItem listViewItem, string nameTable)
        {
            string sqlExpression = "";

            switch (nameTable)
            {

                case "Сотрудники":
                    sqlExpression = $"DELETE FROM {nameTable} WHERE Код_сотрудника = '{listViewItem.Text}'";
                    break;
                case "Услуги":
                    sqlExpression = $"DELETE FROM {nameTable} WHERE Код_услуги = '{listViewItem.Text}'";
                    break;
                case "Тренировки":
                    sqlExpression = $"DELETE FROM {nameTable} WHERE Код_тренировки = '{listViewItem.Text}'";
                    break;
                case "Расписание":
                    sqlExpression = $"DELETE FROM {nameTable} WHERE (Код_сотрудника = '{listViewItem.SubItems[2].Text}' AND Код_услуги='{listViewItem.SubItems[3].Text}' AND Код_тренировки='{listViewItem.SubItems[4].Text}')";
                    break;
            }

            OpenConnection();

            SqlCommand cmdSQL = new SqlCommand(sqlExpression, connection);
            int numberInsert = 0;

            try
            {
                numberInsert = cmdSQL.ExecuteNonQuery();
                CloseConnection();
                return numberInsert;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                CloseConnection();
                return 0;
            }
        }

        public DataSet ReadTablesDatabaseInDataSet(string sqlExpression)
        {
            OpenConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(sqlExpression, connection);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            return ds;
        }
    }
}
