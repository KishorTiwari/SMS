namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class saltfortraderpassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trader", "Salt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trader", "Salt");
        }
    }
}
