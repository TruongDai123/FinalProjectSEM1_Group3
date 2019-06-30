using System;

namespace Persistence
{
    public class Order
    {
        public int OrderId { get; set; }
        public int OrderDetailsId { get; set; }
        public int TablesId { get; set; }
        public int EmplId { get; set; }
        public string OrderPayment { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderDetails OrderDetails { get; set; }

        public Order() { }
        public Order(int orderId, int orderDetailsId, int tablesId, int emplId, DateTime orderDate, string orderPayment, OrderDetails orderDetails)
        {
            this.OrderId = orderId;
            this.OrderDetailsId = orderDetailsId;
            this.TablesId = tablesId;
            this.EmplId = emplId;
            this.OrderDate = orderDate;
            this.OrderPayment = orderPayment;

            this.OrderDetails = orderDetails;
        }
        public override bool Equals(object obj)
        {
            Order order = (Order)obj;

            return OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            return (OrderId + OrderDetailsId + TablesId + EmplId + OrderPayment + OrderDate).GetHashCode();
        }
    }
}