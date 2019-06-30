using System;
using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DishDAL
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string query;

        public DishDAL()
        {
            connection = DBHelper.OpenConnection();
        }

        public Dish GetDishByDishId(int? DishId)
        {
            if (DishId == null)
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

            query = $"select * from Dish where dish_id = " + DishId + ";";
            MySqlCommand command = new MySqlCommand(query, connection);
            Dish dish = null;
            using (reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    dish = GetDish(reader);
                }
            }

            connection.Close();

            return dish;
        }
        private Dish GetDish(MySqlDataReader reader)
        {
            int DishId = reader.GetInt32("dish_id");
            string DishName = reader.GetString("dish_name");
            string DishDescription = reader.GetString("dish_description");
            string DishPrice = reader.GetString("price");
            int DishQuantity = reader.GetInt32("quantity");

            Dish dish = new Dish(DishId, DishName, DishDescription, DishPrice, DishQuantity);

            return dish;
        }
    }
}