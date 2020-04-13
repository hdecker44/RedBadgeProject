using RedBadge.Data;
using RedBadge.Models;
using RedBadgeProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Service
{
    public class TicketService
    {
        private readonly Guid _userId;
        public TicketService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTicket(TicketCreate model)
        {
            var entity =
                new Ticket()
                {
                    OwnerId = _userId,
                    EventId = model.EventId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Tickets.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TicketListItem> GetTickets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Tickets
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TicketListItem
                                {
                                    TicketId =e.TicketId,
                                    Event = e.Event.EventName,
                                    EventType = e.Event.EventType,
                                    Location = e.Event.Venue.City,
                                    Price = e.Event.Price,
                                }
                        );

                return query.ToArray();
            }
        }
        public TicketDetails GetTicketById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketId == id /*&& e.OwnerId == _userId*/);
                return
                    new TicketDetails
                    {
                        TicketId = entity.TicketId,
                        EventName = entity.Event.EventName,
                        Location = entity.Event.Venue.City,
                        Price = entity.Event.Price,
                    };
            }
        }
        public bool UpdateTicket(TicketEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketId == model.TicketId && e.OwnerId == _userId);

                entity.Event.EventName = model.EventName;
     

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTicket(int ticketId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Tickets
                        .Single(e => e.TicketId == ticketId && e.OwnerId == _userId);

                ctx.Tickets.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
