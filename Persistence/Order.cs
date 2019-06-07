using System;
namespace CTS_Persistence
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderDetailsId { get; set; }
        public int TablesId { get; set; }
        public int EmplId { get; set; }
        public string OrderPaymen { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderDetails OrderDetails { get; set; }

        public Order() { }
        public Order(int orderId, int orderDetailsId, int tablesId, int emplId, DateTime orderDate, string orderPaymen, OrderDetails orderDetails)
        {
            this.OrderId = orderId;
            this.OrderDetailsId = orderDetailsId;
            this.TablesId = tablesId;
            this.EmplId = emplId;
            this.OrderDate = orderDate;
            this.OrderPaymen = orderPaymen;

            this.OrderDetails = orderDetails;
        }
        public override bool Equals(object obj)
        {
            Order order = (Order)obj;

            return OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            return (OrderId + OrderDetailsId + TablesId + EmplId + OrderPaymen + OrderDate ).GetHashCode();
        }
    }
}