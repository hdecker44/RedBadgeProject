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
                    EventName = model.Event,
                    Location = model.Location,
                    Price = model.Price,
                    Seat = model.Seat,
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
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new TicketListItem
                                {
                                    TicketId =e.TicketId,
                                    Event = e.EventName,
                                    Location = e.Location,
                                    Price = e.Price,
                                    Seat = e.Seat,
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
                        .Single(e => e.TicketId == id && e.OwnerId == _userId);
                return
                    new TicketDetails
                    {
                        TicketId = entity.TicketId,
                        EventName = entity.EventName,
                        Location = entity.Location,
                        Price = entity.Price,
                        Seat = entity.Seat,
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

                entity.EventName = model.EventName;
                entity.Price = model.Price;
                entity.Location = model.Location;
                entity.Seat = model.Seat;
     

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
