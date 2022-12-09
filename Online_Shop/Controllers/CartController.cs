using Online_Shop.Data;
using Online_Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Controllers
{
    class CartController
    {
        private ShopContext shopContext;

        public List<CartProduct> GetAll()
        {
            using (shopContext = new ShopContext())
            {
                return shopContext.CartProducts.ToList();
            }
        
        }
        public bool ifAlreadyExists(string name)
        {
            foreach (var item in GetAll())
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public List<string> GetCartProductDetails(int id)
        {
            using (shopContext = new ShopContext())
            {
                CartProduct cartProduct = GetAll()[id];
                return new List<string>() { "Name: "+cartProduct.Name, "Price: "+cartProduct.Price.ToString(),
                    "Description: "+cartProduct.Description, "Weight: "+cartProduct.WeightInGr.ToString()+"gr" };
            }
        }
        public void CreateCartProduct(string name, double price, string description, int weight)
        {
            using (shopContext = new ShopContext())
            {
                CartProduct cartProduct = new CartProduct();
                if (shopContext.CartProducts.Count() == 0)
                {
                    cartProduct.Id = "0";
                }
                else
                {
                    cartProduct.Id = (int.Parse(shopContext.CartProducts.ToList().Last().Id) + 1).ToString();
                }
                cartProduct.Name = name;
                cartProduct.Price = price;
                cartProduct.Description = description;
                cartProduct.WeightInGr = weight;
                shopContext.CartProducts.Add(cartProduct);

                shopContext.SaveChanges();
            }
        }
        
        public void deleteCartProduct(string id)
        {
            using (shopContext = new ShopContext())
            {
                CartProduct cartProduct = shopContext.CartProducts.ToList()[int.Parse(id)];
                shopContext.CartProducts.Remove(cartProduct);
                shopContext.SaveChanges();
            }
        }
        public void increaseNumber(string id)
        {
            using (shopContext = new ShopContext())
            {
                CartProduct cartProduct = shopContext.CartProducts.ToList()[int.Parse(id)];
                cartProduct.Number++;
                shopContext.SaveChanges();
            }
        }
        public void DecreaseNumber(string id)
        {
            using (shopContext = new ShopContext())
            {
                
                CartProduct cartProduct = shopContext.CartProducts.ToList()[int.Parse(id)];
                if(cartProduct.Number > 0)
                cartProduct.Number--;
                shopContext.SaveChanges();
            }
        }
        public double TotalPrice()
        {
            double price = 0;
            foreach (var product in GetAll())
            {
                price += product.Price*product.Number;
            }
            return price;
        }
    }
}

