namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtraCostViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateEntered = c.DateTime(nullable: false),
                        TraderId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 255),
                        Cost = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExtraCostViewModel");
        }
    }
}
