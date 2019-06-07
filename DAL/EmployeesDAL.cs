using System;
using CTS_Persistence;
using DAL;
using MySql.Data.MySqlClient;

namespace CTS_DAL
{
    public class EmployeesDAL
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;

        public EmployeesDAL()
        {
            Connection = DBHelper.OpenConnection();
        }

        public object Connection { get; }

        public Employees GetEmployeesByCineId(int? emplId)
        {
            if (emplId == null)
            {
                return null;
            }
            if (connection == null)
            {
                connection = DBHelper.OpenConnection();
            }
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            query = $"select * from Employee where employee_id = " + emplId + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            Employees employees = null;
            using (reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    employees = GetEmployees(reader);
                }
            }

            connection.Close();

            return employees;
        }

        private Employees GetEmployees(MySqlDataReader reader)
        {
            int emplId = reader.GetInt32("employee_id");
            string emplPosition = reader.GetString("employee_position");
            string emplName = reader.GetString("employee_name");
            string emplPhone = reader.GetString("phone_number");

            Employees employees = new Employees(emplId, emplPosition, emplName, emplPhone);

            return employees;
        }

        internal Employees GetEmployeesEmplId(int emplId)
        {
            throw new NotImplementedException();
        }
    }
}