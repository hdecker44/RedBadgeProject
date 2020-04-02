namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropdown1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Event", "Venue_VenueId", "dbo.Venue");
            DropIndex("dbo.Event", new[] { "Venue_VenueId" });
            RenameColumn(table: "dbo.Event", name: "Venue_VenueId", newName: "VenueId");
            AlterColumn("dbo.Event", "VenueId", c => c.Int(nullable: false));
            CreateIndex("dbo.Event", "VenueId");
            AddForeignKey("dbo.Event", "VenueId", "dbo.Venue", "VenueId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "VenueId", "dbo.Venue");
            DropIndex("dbo.Event", new[] { "VenueId" });
            AlterColumn("dbo.Event", "VenueId", c => c.Int());
            RenameColumn(table: "dbo.Event", name: "VenueId", newName: "Venue_VenueId");
            CreateIndex("dbo.Event", "Venue_VenueId");
            AddForeignKey("dbo.Event", "Venue_VenueId", "dbo.Venue", "VenueId");
        }
    }
}
