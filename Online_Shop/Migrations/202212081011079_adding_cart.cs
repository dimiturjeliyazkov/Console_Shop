namespace Online_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_cart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartProducts", "Description", c => c.String());
            AddColumn("dbo.CartProducts", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.CartProducts", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartProducts", "Name");
            DropColumn("dbo.CartProducts", "Price");
            DropColumn("dbo.CartProducts", "Description");
        }
    }
}
