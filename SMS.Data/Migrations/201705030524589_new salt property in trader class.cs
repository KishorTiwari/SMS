namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newsaltpropertyintraderclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trader", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trader", "Salt");
        }
    }
}
