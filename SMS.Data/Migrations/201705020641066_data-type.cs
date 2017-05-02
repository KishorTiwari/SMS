namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datatype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExtraCost", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "CostPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Vehicle", "SellingPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicle", "SellingPrice", c => c.Single());
            AlterColumn("dbo.Vehicle", "CostPrice", c => c.Single());
            AlterColumn("dbo.ExtraCost", "Cost", c => c.Single(nullable: false));
        }
    }
}
