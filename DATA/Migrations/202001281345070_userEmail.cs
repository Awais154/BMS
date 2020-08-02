namespace DATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userEmail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 20));
        }
    }
}
