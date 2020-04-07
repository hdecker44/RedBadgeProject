namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lists : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ticket", "Ticket_TicketId", c => c.Int());
            CreateIndex("dbo.Ticket", "Ticket_TicketId");
            AddForeignKey("dbo.Ticket", "Ticket_TicketId", "dbo.Ticket", "TicketId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "Ticket_TicketId", "dbo.Ticket");
            DropIndex("dbo.Ticket", new[] { "Ticket_TicketId" });
            DropColumn("dbo.Ticket", "Ticket_TicketId");
        }
    }
}
