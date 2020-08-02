namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trademark", "UniqueKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trademark", "UniqueKey");
        }
    }
}
