using Online_Shop.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Shop.Data
{
    class ShopContext:DbContext
    {
        public ShopContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Shop;Integrated Security=True")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopContext, Configuration>());
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Dessert> Desserts { get; set; }

        
    }
}
