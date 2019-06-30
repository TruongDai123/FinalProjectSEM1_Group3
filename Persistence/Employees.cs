using System;

namespace Persistence
{
    public class Employees
    {
        public int EmplId { get; set; }
        public string EmplPosition { get; set; }
        public string EmplName { get; set; }
        public string EmplPhone { get; set; }

        public Employees() { }
        public Employees(int emplId, string emplPosition, string emplName, string emplPhone)
        {
            this.EmplId = emplId;
            this.EmplPosition = emplPosition;
            this.EmplName = emplName;
            this.EmplPhone = emplPhone;
        }
         public override bool Equals(object obj)
        {
            Employees employees = (Employees)obj;

            return EmplId == employees.EmplId;
        }

        public override int GetHashCode()
        {
            return (EmplId + EmplPosition + EmplName + EmplPhone).GetHashCode();
        }
    }
}