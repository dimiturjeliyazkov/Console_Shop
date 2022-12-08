using Online_Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Controllers
{
    class DrinkController
    {
        private ShopContext shopContext;

        public List<Drink> GetAll()
        {
            using (shopContext = new ShopContext())
            {
                return shopContext.Drinks.ToList();
            }
        }
        public List<string> GetDrinkDetails(int id)
        {
            using (shopContext = new ShopContext())
            {
                Drink drink = GetAll()[id];
                return new List<string>() { "Name: "+drink.Name, "Price: "+drink.Price.ToString(),
                    "Description: "+drink.Description, "Weight: "+drink.WeightInMl.ToString()+"gr" };
            }
        }
        public void CreateDrink(string name, double price, string description, int weightInGr)
        {
            using (shopContext = new ShopContext())
            {
                Drink drink = new Drink();
                if (shopContext.Drinks.Count() == 0)
                {
                    drink.Id = "0";
                }
                else
                {
                    drink.Id = (int.Parse(shopContext.Drinks.ToList().Last().Id) + 1).ToString();
                }
                drink.Name = name;
                drink.Price = price;
                drink.Description = description;
                drink.WeightInMl = weightInGr;
                shopContext.Drinks.Add(drink);

                shopContext.SaveChanges();
            }
        }
        public void UpdateDrink(string id, string name, double price, string description, int weightInGr)
        {
            using (shopContext = new ShopContext())
            {
                Drink drink = shopContext.Drinks.ToList()[int.Parse(id)];
                drink.Name = name;
                drink.Price = price;
                drink.Description = description;
                drink.WeightInMl = weightInGr;
                shopContext.SaveChanges();
            }
        }
        public void deleteDrink(string id)
        {
            using (shopContext = new ShopContext())
            {
                Drink drink = shopContext.Drinks.ToList()[int.Parse(id)];
                shopContext.Drinks.Remove(drink);
                shopContext.SaveChanges();
            }
        }
    }

}
