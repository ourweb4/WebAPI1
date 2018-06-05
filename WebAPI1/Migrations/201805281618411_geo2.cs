namespace WebAPI1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geo2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StoreEntities", "Lat", c => c.Double(nullable: false));
            AlterColumn("dbo.StoreEntities", "Lng", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StoreEntities", "Lng", c => c.Single(nullable: false));
            AlterColumn("dbo.StoreEntities", "Lat", c => c.Single(nullable: false));
        }
    }
}
