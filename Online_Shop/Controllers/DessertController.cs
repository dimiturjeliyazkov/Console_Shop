using Online_Shop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Controllers
{
    class DessertController
    {
        private ShopContext shopContext;

        public List<Dessert> GetAll()
        {
            using (shopContext = new ShopContext())
            {
                return shopContext.Desserts.ToList();
            }
        }
        public List<string> GetDessertDetails(int id)
        {
            using (shopContext = new ShopContext())
            {
                Dessert dessert = GetAll()[id];
                return new List<string>() { "Name: "+dessert.Name, "Price: "+dessert.Price.ToString(),
                    "Description: "+dessert.Description, "Weight: "+dessert.WeightInGr.ToString()+"gr" };
            }
        }
        public void CreateDessert(string name, double price, string description, int weightInGr)
        {
            using (shopContext = new ShopContext())
            {
                Dessert dessert = new Dessert();
                if (shopContext.Desserts.Count() == 0)
                {
                    dessert.Id = "0";
                }
                else
                {
                    dessert.Id = (int.Parse(shopContext.Desserts.ToList().Last().Id) + 1).ToString();
                }
                dessert.Name = name;
                dessert.Price = price;
                dessert.Description = description;
                dessert.WeightInGr = weightInGr;
                shopContext.Desserts.Add(dessert);

                shopContext.SaveChanges();
            }
        }
        public void UpdateDessert(string id, string name, double price, string description, int weightInGr)
        {
            using (shopContext = new ShopContext())
            {
                Dessert dessert = shopContext.Desserts.ToList()[int.Parse(id)];
                dessert.Name = name;
                dessert.Price = price;
                dessert.Description = description;
                dessert.WeightInGr = weightInGr;
                shopContext.SaveChanges();
            }
        }
        public void deleteDessert(string id)
        {
            using (shopContext = new ShopContext())
            {
                Dessert dessert = shopContext.Desserts.ToList()[int.Parse(id)];
                shopContext.Desserts.Remove(dessert);
                shopContext.SaveChanges();
            }
        }
    }
}
