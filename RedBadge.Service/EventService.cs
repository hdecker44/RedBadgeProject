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
    public class EventService
    {
        private readonly Guid _userId;
        public EventService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    OwnerId = _userId,
                    EventName = model.EventName,
                    VenueName = model.VenueName,
                    DateTime = model.DateTime
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    EventName = e.EventName,
                                    VenueName = e.VenueName,
                                    Location = e.Location,
                                    DateTime = e.DateTime,
                                   // SoldOut = e.SoldOut
                                }
                        );

                return query.ToArray();
            }
        }
        public EventDetails GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == id && e.OwnerId == _userId);
                return
                    new EventDetails
                    {
                        EventId = entity.EventId,
                        EventName = entity.EventName,
                        VenueName = entity.VenueName,
                        Location = entity.Location,
                        DateTime = entity.DateTime,
                        NumberOfSeats = entity.NumberOfSeats,
                        SeatsAvailable = entity.SeatsAvailable,
                        NumberOfTicketsSold = entity.NumberOfTicketsSold,
                        SoldOut = entity.SoldOut,
                        Description = entity.Description,
                        AvailableTickets = entity.AvailableTickets,
                        SoldTickets = entity.SoldTickets
                    };
            }
        }
        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == model.EventId && e.OwnerId == _userId);

                entity.EventName = model.EventName;
                entity.VenueName = model.VenueName;
                entity.DateTime = model.DateTime;
                entity.Description = model.Description;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEvent(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == eventId && e.OwnerId == _userId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
