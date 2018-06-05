namespace WebAPI1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MadterEntities",
                c => new
                    {
                        MasterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        ShowWebsite = c.Boolean(nullable: false),
                        Website = c.String(),
                        ShowEmail = c.Boolean(nullable: false),
                        Email = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MasterId);
            
            CreateTable(
                "dbo.StoreEntities",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Phone = c.String(),
                        ShowWebsite = c.Boolean(nullable: false),
                        Website = c.String(),
                        ShowEmail = c.Boolean(nullable: false),
                        Email = c.String(),
                        Sun = c.String(),
                        Mon = c.String(),
                        Tue = c.String(),
                        Wed = c.String(),
                        Thu = c.String(),
                        Fri = c.String(),
                        Sat = c.String(),
                        MadterEntity_MasterId = c.Int(),
                    })
                .PrimaryKey(t => t.StoreId)
                .ForeignKey("dbo.MadterEntities", t => t.MadterEntity_MasterId)
                .Index(t => t.MadterEntity_MasterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreEntities", "MadterEntity_MasterId", "dbo.MadterEntities");
            DropIndex("dbo.StoreEntities", new[] { "MadterEntity_MasterId" });
            DropTable("dbo.StoreEntities");
            DropTable("dbo.MadterEntities");
        }
    }
}
