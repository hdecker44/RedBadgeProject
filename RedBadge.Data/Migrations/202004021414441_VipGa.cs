namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VipGa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ticket", "Event_EventId", "dbo.Event");
            DropForeignKey("dbo.Ticket", "Event_EventId1", "dbo.Event");
            DropIndex("dbo.Ticket", new[] { "Event_EventId" });
            DropIndex("dbo.Ticket", new[] { "Event_EventId1" });
            AddColumn("dbo.Event", "EventType", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "NumberOfVIP", c => c.Int(nullable: false));
            AddColumn("dbo.Event", "NumberOfGA", c => c.Int(nullable: false));
            AddColumn("dbo.Venue", "NumberOfVIP", c => c.Int(nullable: false));
            AddColumn("dbo.Venue", "NumberOfGA", c => c.Int(nullable: false));
            DropColumn("dbo.Event", "Artist");
            DropColumn("dbo.Event", "Type");
            DropColumn("dbo.Event", "Team");
            DropColumn("dbo.Event", "OpposingTeam");
            DropColumn("dbo.Event", "Sport");
            DropColumn("dbo.Event", "Discriminator");
            DropColumn("dbo.Ticket", "SeatNumber");
            DropColumn("dbo.Ticket", "Event_EventId");
            DropColumn("dbo.Ticket", "Event_EventId1");
            DropColumn("dbo.Venue", "NumberOfSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Venue", "NumberOfSeats", c => c.Int(nullable: false));
            AddColumn("dbo.Ticket", "Event_EventId1", c => c.Int());
            AddColumn("dbo.Ticket", "Event_EventId", c => c.Int());
            AddColumn("dbo.Ticket", "SeatNumber", c => c.String(nullable: false));
            AddColumn("dbo.Event", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Event", "Sport", c => c.Int());
            AddColumn("dbo.Event", "OpposingTeam", c => c.String());
            AddColumn("dbo.Event", "Team", c => c.String());
            AddColumn("dbo.Event", "Type", c => c.Int());
            AddColumn("dbo.Event", "Artist", c => c.String());
            DropColumn("dbo.Venue", "NumberOfGA");
            DropColumn("dbo.Venue", "NumberOfVIP");
            DropColumn("dbo.Event", "NumberOfGA");
            DropColumn("dbo.Event", "NumberOfVIP");
            DropColumn("dbo.Event", "EventType");
            CreateIndex("dbo.Ticket", "Event_EventId1");
            CreateIndex("dbo.Ticket", "Event_EventId");
            AddForeignKey("dbo.Ticket", "Event_EventId1", "dbo.Event", "EventId");
            AddForeignKey("dbo.Ticket", "Event_EventId", "dbo.Event", "EventId");
        }
    }
}
