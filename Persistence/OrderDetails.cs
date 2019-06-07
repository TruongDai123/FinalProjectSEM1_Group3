using System;
namespace CTS_Persistence
{
    public class OrderDetails
    {
        public int? OrderDetailsId { get; set; }
        public string OrderPrice { get; set; }
        public int? DishId { get; set; }

        public OrderDetails() { }
        public OrderDetails(int? orderDetailsId, int? dishId, string orderPrice)
        {
            this.OrderDetailsId = orderDetailsId;
            this.DishId = dishId;
            this.OrderPrice = orderPrice;
        }
        public override bool Equals(object obj)
        {
            OrderDetails OrderDetails = (OrderDetails)obj;

            return OrderDetailsId == OrderDetails.OrderDetailsId;
        }

        public override int GetHashCode()
        {
            return ("" + OrderDetailsId + DishId + OrderPrice ).GetHashCode();
        }
    }
}