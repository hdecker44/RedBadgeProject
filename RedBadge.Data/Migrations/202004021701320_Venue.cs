namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Venue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venue", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venue", "OwnerId");
        }
    }
}
