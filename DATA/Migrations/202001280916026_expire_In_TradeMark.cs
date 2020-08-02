namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class expire_In_TradeMark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trademark", "OnTrial", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trademark", "TrialExpired", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trademark", "TrialExpired");
            DropColumn("dbo.Trademark", "OnTrial");
        }
    }
}
