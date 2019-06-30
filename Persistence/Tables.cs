using System;
namespace Persistence
{
    public class Tables
    {
        public int TablesId { get; set; }
        public int OrderId { get; set; }
        public int CustomerNumber { get; set; }
        public int Capacity { get; set; }

        public Tables() { }
        public Tables(int tablesId, int OrderId, int customerNumber, int capacity)
        {
            this.TablesId = tablesId;
            this.OrderId = OrderId;
            this.CustomerNumber = customerNumber;
            this.Capacity = capacity;
        }
        public override bool Equals(object obj)
        {
            Tables tables = (Tables)obj;

            return TablesId == tables.TablesId;
        }

        public override int GetHashCode()
        {
            return (TablesId + OrderId + CustomerNumber + Capacity ).GetHashCode();
        }
    }
}