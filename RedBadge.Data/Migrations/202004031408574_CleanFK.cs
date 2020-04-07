namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanFK : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Event", "VenueName");
            DropColumn("dbo.Event", "Location");
            DropColumn("dbo.Event", "NumberOfSeats");
            DropColumn("dbo.Event", "NumberOfVIP");
            DropColumn("dbo.Event", "NumberOfGA");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Event", "NumberOfGA", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "NumberOfVIP", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "NumberOfSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Event", "VenueName", c => c.String(nullable: false));
        }
    }
}
