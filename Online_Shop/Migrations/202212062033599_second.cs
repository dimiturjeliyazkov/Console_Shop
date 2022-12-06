namespace Online_Shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Desserts");
            DropPrimaryKey("dbo.Drinks");
            DropPrimaryKey("dbo.Foods");
            AlterColumn("dbo.Desserts", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Drinks", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Foods", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Desserts", "Id");
            AddPrimaryKey("dbo.Drinks", "Id");
            AddPrimaryKey("dbo.Foods", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Foods");
            DropPrimaryKey("dbo.Drinks");
            DropPrimaryKey("dbo.Desserts");
            AlterColumn("dbo.Foods", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Drinks", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Desserts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Foods", "Id");
            AddPrimaryKey("dbo.Drinks", "Id");
            AddPrimaryKey("dbo.Desserts", "Id");
        }
    }
}
