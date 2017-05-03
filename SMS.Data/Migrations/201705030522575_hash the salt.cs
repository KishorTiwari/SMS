namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hashthesalt : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Trader", "Salt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trader", "Salt", c => c.Int(nullable: false));
        }
    }
}
