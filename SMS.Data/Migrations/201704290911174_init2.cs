namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Vehicle", "IsSold");
            DropColumn("dbo.Vehicle", "IsPending");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicle", "IsPending", c => c.Boolean(nullable: false));
            AddColumn("dbo.Vehicle", "IsSold", c => c.Boolean(nullable: false));
            DropColumn("dbo.Vehicle", "Status");
        }
    }
}
