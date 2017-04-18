namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialisedatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtraCost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraderId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trader", t => t.TraderId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.TraderId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Trader",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        CurrentPassword = c.String(nullable: false, maxLength: 255),
                        OldPassword = c.String(maxLength: 255),
                        TempPassword = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 50),
                        Make = c.String(nullable: false, maxLength: 50),
                        Kilometers = c.Int(nullable: false),
                        CostPrice = c.Single(nullable: false),
                        SellingPrice = c.Single(),
                        Trader_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trader", t => t.Trader_Id)
                .Index(t => t.Trader_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExtraCost", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.ExtraCost", "TraderId", "dbo.Trader");
            DropForeignKey("dbo.Vehicle", "Trader_Id", "dbo.Trader");
            DropIndex("dbo.Vehicle", new[] { "Trader_Id" });
            DropIndex("dbo.ExtraCost", new[] { "VehicleId" });
            DropIndex("dbo.ExtraCost", new[] { "TraderId" });
            DropTable("dbo.Vehicle");
            DropTable("dbo.Trader");
            DropTable("dbo.ExtraCost");
        }
    }
}
