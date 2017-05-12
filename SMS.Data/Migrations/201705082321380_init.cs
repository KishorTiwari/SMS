namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dealer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TraderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trader", t => t.TraderId, cascadeDelete: true)
                .Index(t => t.TraderId);
            
            CreateTable(
                "dbo.Trader",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false, maxLength: 255),
                        Salt = c.String(),
                        TempPassword = c.String(maxLength: 255),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExtraCost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateEntered = c.DateTime(nullable: false),
                        TraderId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trader", t => t.TraderId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.TraderId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TraderId = c.Int(nullable: false),
                        DateEntered = c.DateTime(nullable: false),
                        Make = c.String(nullable: false, maxLength: 50),
                        Model = c.String(nullable: false, maxLength: 50),
                        Kilometers = c.Int(nullable: false),
                        Rego = c.String(maxLength: 10),
                        CostPrice = c.Decimal(precision: 18, scale: 2),
                        SellingPrice = c.Decimal(precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateSold = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trader", t => t.TraderId, cascadeDelete: false)
                .Index(t => t.TraderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dealer", "TraderId", "dbo.Trader");
            DropForeignKey("dbo.Vehicle", "TraderId", "dbo.Trader");
            DropForeignKey("dbo.ExtraCost", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.ExtraCost", "TraderId", "dbo.Trader");
            DropIndex("dbo.Vehicle", new[] { "TraderId" });
            DropIndex("dbo.ExtraCost", new[] { "VehicleId" });
            DropIndex("dbo.ExtraCost", new[] { "TraderId" });
            DropIndex("dbo.Dealer", new[] { "TraderId" });
            DropTable("dbo.Vehicle");
            DropTable("dbo.ExtraCost");
            DropTable("dbo.Trader");
            DropTable("dbo.Dealer");
        }
    }
}
