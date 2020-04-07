namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Ticket", "EventName");
            DropColumn("dbo.Ticket", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Ticket", "EventName", c => c.String(nullable: false));
        }
    }
}
