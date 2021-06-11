using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CommonLibs.Utils
{
    public class DbUtils
    {
        // 1. Create a connection with Database
        // 2. Prepare an sql query
        // 3. Execute the query (select --> Table-- ExecuteReader()) or (Non-Select query --> int --> ExecuteNonQuery())
        // 4. Process the response
        // 5. Close the connection

        private SqlConnection connection;

        public void CreateConnection(string dataSource, string userId, string password, string dbName)
        {

            SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder()
            {
                DataSource = dataSource,
                UserID = userId,
                Password = password,
                InitialCatalog = dbName

            };

            connection = new SqlConnection(sqlConnection.ConnectionString);

            connection.Open();

        }

        public DataTable ExecuteSelectQuery(string sqlQuery)
        {
            SqlCommand command = new SqlCommand(sqlQuery,connection);

            SqlDataReader response = command.ExecuteReader();

            DataTable dataTable = new DataTable();

            dataTable.Load(response);

            return dataTable;
        }

        public int ExecuteNonSelectQuery(string sqlQuery)
        {
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            return command.ExecuteNonQuery();

        }

        public void CloseConnection()
        {
            connection.Close();
        }

    }
}
