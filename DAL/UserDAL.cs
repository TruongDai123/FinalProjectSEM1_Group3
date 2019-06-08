using System;
using System.Text.RegularExpressions;
using CTS_Persistence;
using DAL;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class UserDAL
    {
        private MySqlConnection Connection;
        private MySqlDataReader reader;
        private string query;
        public UserDAL()
        {
            Connection = DBHelper.OpenConnection();
        }

        public User Login(string username, string password)
        {
            if ((username == null) || (password == null))
            {
                return null;
            }
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionUsername = regex.Matches(username);
            MatchCollection matchCollectionPassword = regex.Matches(password);
            if (matchCollectionUsername.Count < username.Length || matchCollectionPassword.Count < password.Length)
            {
                return null;
            }

            if (Connection == null)
            {
                Connection = DBHelper.OpenConnection();
            }

            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }

            query = @"select * from Employee where employee_username = '" + username + "' and employee_password= '" + password + "';";
            MySqlCommand command = new MySqlCommand(query, Connection);
            User user = null;
            using (reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    user = GetUser(reader);
                }
            }

            Connection.Close();

            // if (user != null)
            // {
            //     EmployeesDAL employeesDAL = new EmployeesDAL();
            //     Employees employees = employeesDAL.GetEmployeesEmplId(user.Empl.EmplId);
            // }

            return user;
        }

        private User GetUser(MySqlDataReader reader)
        {
            string username = reader.GetString("employee_username");
            string password = reader.GetString("employee_password");
            string name = reader.GetString("employee_name");
            string type = reader.GetString("employee_position");
            Employees employees = new Employees(reader.GetInt32("employee_id"), null, null, null);

            User user = new User(username, password, name, type, employees);

            return user;
        }
    }

}
