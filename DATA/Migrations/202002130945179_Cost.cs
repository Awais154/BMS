namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Cost");
        }
    }
}
