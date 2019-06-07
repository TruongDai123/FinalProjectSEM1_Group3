using System;
namespace CTS_Persistence
{
    public class Dish
    {
        public int? DishId { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public string DishPrice { get; set; }
        public int DishQuantyti { get; set; }

        public Dish() { }
        public Dish(int? dishId, string dishName, string dishDescription, string dishPrice, int dishQuantyti)
        {
            this.DishId = dishId;
            this.DishName = dishName;
            this.DishDescription = dishDescription;
            this.DishPrice = dishPrice;
            this.DishQuantyti = dishQuantyti;
        }
         public override bool Equals(object obj)
        {
            Dish dish = (Dish)obj;

            return DishId == dish.DishId;
        }

        public override int GetHashCode()
        {
            return (DishId + DishName + DishDescription + DishPrice + DishQuantyti).GetHashCode();
        }
    }
}