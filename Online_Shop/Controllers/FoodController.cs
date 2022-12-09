using Online_Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Controllers
{
    class FoodController
    {
        private ShopContext shopContext;

        public List<Food> GetAll()
        {
            using (shopContext = new ShopContext())
            {
                return shopContext.Foods.ToList();
            }
        }
        public List<string> GetFoodDetails(int id)
        {
            using (shopContext = new ShopContext())
            {
                Food food = GetAll()[id];
                return new List<string>() { "Name: "+food.Name, "Price: "+food.Price.ToString(), 
                    "Description: "+food.Description, "Weight: "+food.WeightInGr.ToString()+"gr" };
            }
        }
       
        public void CreateFood(string name, double price, string description, int weightInGr)
        {
            using (shopContext = new ShopContext())
            {
                Food food = new Food();
                if (shopContext.Foods.Count() == 0)
                {
                    food.Id = "0";
                }
                else
                {
                    food.Id = (int.Parse(shopContext.Foods.ToList().Last().Id) + 1).ToString();
                }
                food.Name = name;
                food.Price = price;
                food.Description = description;
                food.WeightInGr = weightInGr;
                shopContext.Foods.Add(food);
                
                shopContext.SaveChanges();
            }
        }
        public void UpdateFood(string id, string name, double price, string description, int weightInGr)
        {
            using (shopContext = new ShopContext())
            {
                Food food = shopContext.Foods.ToList()[int.Parse(id)];
                food.Name = name;
                food.Price = price;
                food.Description = description;
                food.WeightInGr = weightInGr;
                shopContext.SaveChanges();
            }
        }
        public void deleteFood(string id)
        {
            using (shopContext = new ShopContext())
            {
                Food food = shopContext.Foods.ToList()[int.Parse(id)];
                shopContext.Foods.Remove(food);
                shopContext.SaveChanges();
            }
        }
    }
}
