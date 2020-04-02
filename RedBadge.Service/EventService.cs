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
                    EventType = model.EventType,
                    VenueId = model.VenueId,
                    PriceGA = model.PriceGA,
                    PriceVIP = model.PriceVIP,
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
                                    EventType = e.EventType,
                                    VenueName = e.VenueName,
                                    Location = e.Location,
                                    DateTime = e.DateTime,
                                    PriceGA = e.PriceGA,
                                    //SoldOut = e.SoldOut
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
                        EventType = entity.EventType,
                        VenueName = entity.VenueName,
                        Location = entity.Location,
                        DateTime = entity.DateTime,
                        PriceGA = entity.PriceGA,
                        PriceVIP = entity.PriceVIP,
                        NumberOfSeats = entity.NumberOfSeats,
                        NumberOfVIP = entity.NumberOfVIP,
                        NumberOfGA = entity.NumberOfGA,
                        VIPAvailable = entity.VIPAvailable,
                        GAAvailable = entity.GAAvailable,
                        SeatsAvailable = entity.SeatsAvailable,
                        NumberOfTicketsSold = entity.NumberOfTicketsSold,
                        SoldOut = entity.SoldOut,
                        Description = entity.Description,
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
                entity.PriceGA = model.PriceGA;
                entity.PriceVIP = model.PriceVIP;
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
