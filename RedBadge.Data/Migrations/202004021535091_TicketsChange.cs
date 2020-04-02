namespace RedBadge.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketsChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "PriceVIP", c => c.Double(nullable: false));
            AddColumn("dbo.Event", "PriceGA", c => c.Double(nullable: false));
            DropColumn("dbo.Ticket", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ticket", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Event", "PriceGA");
            DropColumn("dbo.Event", "PriceVIP");
        }
    }
}
