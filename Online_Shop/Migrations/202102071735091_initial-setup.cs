namespace Online_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Desserts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WeightInGr = c.Int(nullable: false),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WeightInMl = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        WeightInGr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Foods");
            DropTable("dbo.Drinks");
            DropTable("dbo.Desserts");
        }
    }
}
