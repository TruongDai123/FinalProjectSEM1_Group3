using System;
using Persistence;
using DAL;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BL
{
    public class DishBL
    {
        private DishDAL ddal = new DishDAL();
        public Dish GetDishByDishId(int? DishId)
        {
            if (DishId == null)
            {
                return null;
            }
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollection = regex.Matches(DishId.ToString());

            if (matchCollection.Count < DishId.ToString().Length)
            {
                return null;
            }
            return ddal.GetDishByDishId(DishId);
        }
    }
}