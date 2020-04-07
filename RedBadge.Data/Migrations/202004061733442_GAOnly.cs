namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GAOnly : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Venue", "Seats", c => c.Int(nullable: false));
            DropColumn("dbo.Event", "PriceVIP");
            DropColumn("dbo.Event", "PriceGA");
            DropColumn("dbo.Venue", "NumberOfVIP");
            DropColumn("dbo.Venue", "NumberOfGA");
            DropColumn("dbo.Ticket", "Seat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "Seat", c => c.Int(nullable: false));
            AddColumn("dbo.Venue", "NumberOfGA", c => c.Int(nullable: false));
            AddColumn("dbo.Venue", "NumberOfVIP", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "PriceGA", c => c.Double(nullable: false));
            AddColumn("dbo.Event", "PriceVIP", c => c.Double(nullable: false));
            DropColumn("dbo.Venue", "Seats");
            DropColumn("dbo.Event", "Price");
        }
    }
}
