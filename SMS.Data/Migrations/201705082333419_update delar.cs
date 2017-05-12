namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedelar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "DealerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicle", "DealerId");
            AddForeignKey("dbo.Vehicle", "DealerId", "dbo.Dealer", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicle", "DealerId", "dbo.Dealer");
            DropIndex("dbo.Vehicle", new[] { "DealerId" });
            DropColumn("dbo.Vehicle", "DealerId");
        }
    }
}
