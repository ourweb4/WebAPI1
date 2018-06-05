namespace WebAPI1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreEntities", "Lat", c => c.Single(nullable: false));
            AddColumn("dbo.StoreEntities", "Lng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreEntities", "Lng");
            DropColumn("dbo.StoreEntities", "Lat");
        }
    }
}
