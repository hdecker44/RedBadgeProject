namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imageNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venue", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Venue", "Image");
        }
    }
}
