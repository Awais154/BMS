namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TradeMarkUniqueKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountHolder", "TradeMarkUniqueKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccountHolder", "TradeMarkUniqueKey");
        }
    }
}
