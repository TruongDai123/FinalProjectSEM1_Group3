using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BL;
using Persistence;

namespace PL_Console
{
    public class menuEmployees
    {
        public int input(string str)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(str);
            while ((matchCollection.Count < str.Length) || (str == ""))
            {
                Console.Write("Mời bạn nhập lại: ");
                str = Console.ReadLine();
                matchCollection = regex.Matches(str);
            }
            return Convert.ToInt32(str);
        }
        Dish dish = new Dish();
        Order order = new Order();
        OrderDetails ord = new OrderDetails();

        public void Invoice(User us)
        {
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine("Tạo Order. ");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("[Danh sách món ăn]\n");
            DishBL dbl = new DishBL();
            string[] properties = { "DishId", "DishName", "DishDescription", "DishPrice", "DishQuantity" };
            string[] cols = { "Mã món ăn", "Tên món", "Mô tả", "Giá", "Số lượng" };
            //List<Dish>

            Console.WriteLine("\nChọn món(theo mã): ");
            ord.DishId = input(Console.ReadLine());
            while (dbl.GetDishByDishId(DishId) == null)
            {
                Console.Write("Không có mã này, mời nhập lại: ");
                ord.DishId = input(Console.ReadLine());
            }
            dish = dbl.GetDishByDishId(order.DishId);

            List<Order> lo = obl.GetOrderByDishId(order.DishId);
            List<OrderDetails> lod = new List<OrderDetails>();
            foreach (var itemListOrder in lo)
            {
                List<OrderDetails> newlod = odbl.GetOrderDetailsByOrderId(itemListOrder.OrderId);
                foreach (var itemListOrderDetail in newlod)
                {
                    lod.Add(itemListOrderDetail);
                }
            }
            
        }

    }
}