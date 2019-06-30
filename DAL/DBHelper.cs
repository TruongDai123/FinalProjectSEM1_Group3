using System;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DBHelper
    {
        private static MySqlConnection Connection;
        public static MySqlConnection GetConnection()
        {
            if (Connection == null)
            {
                Connection = new MySqlConnection
                {
                    ConnectionString = @"server=localhost; user id=root; port=3306;
                                        password=dai123456789;
                                        database=RestaurantManagement"
                };
            }
            return Connection;
        }
        public static MySqlConnection OpenConnection()
        {
            if (Connection == null)
            {
                GetConnection();
            }
            Connection.Open();
            return Connection;
        }
        public static void CloseConnection()
        {
            if(Connection != null)
            {
                Connection.Close();
            }
        }
        public static MySqlDataReader ExecQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, Connection);
            return command.ExecuteReader();
        }
    }
}
