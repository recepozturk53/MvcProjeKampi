namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headstatcontentstat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingtStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "HeadingtStatus");
        }
    }
}
