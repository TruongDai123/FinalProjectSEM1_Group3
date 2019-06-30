// using System;
// using Persistence;
// using DAL;
// using System.Collections.Generic;

// namespace BL
// {
//     public class OrderBL
//     {
//         OrderDAL odal = new OrderDAL();
//         public bool CreateOrder(Order ord)
//         {
//             return odal.CreateOrder(ord);
//         }
//         public List<Order> GetOrderByOrderId(int? OrderId)
//         {
//             if(OrderId ==null)
//             {
//                 return null;
//             }
//             return odal.GetOrderByOrderId(OrderId);
//         }
        
//     }
// }