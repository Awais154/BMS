namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrialPeriod_In_TradeMark : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trademark", "TrialStartedOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Trademark", "TrialPeriod", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trademark", "TrialPeriod");
            DropColumn("dbo.Trademark", "TrialStartedOn");
        }
    }
}
