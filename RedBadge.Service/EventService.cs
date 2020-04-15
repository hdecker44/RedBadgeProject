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
                    Price = model.Price,
                    DateTime = model.DateTime,
                    Description = model.Description
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
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    EventName = e.EventName,
                                    EventType = e.EventType,
                                    Image = e.Image,
                                    VenueName = e.Venue.VenueName,
                                    Location = e.Venue.City,
                                    DateTime = e.DateTime,
                                    Price = e.Price,
                                    VenueId = e.VenueId
                                    
                                    //SoldOut = e.SoldOut
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<EventListItem> GetEventsSport()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.EventType == Event.EventTypes.Baseball | e.EventType == Event.EventTypes.Basketball | e.EventType == Event.EventTypes.Football | e.EventType == Event.EventTypes.Hockey | e.EventType == Event.EventTypes.Soccer)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    EventName = e.EventName,
                                    EventType = e.EventType,
                                    Image = e.Image,
                                    VenueName = e.Venue.VenueName,
                                    Location = e.Venue.City,
                                    DateTime = e.DateTime,
                                    Price = e.Price,
                                    VenueId = e.VenueId

                                    //SoldOut = e.SoldOut
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<EventListItem> GetEventsPlay()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.EventType == Event.EventTypes.Play)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    EventName = e.EventName,
                                    EventType = e.EventType,
                                    Image = e.Image,
                                    VenueName = e.Venue.VenueName,
                                    Location = e.Venue.City,
                                    DateTime = e.DateTime,
                                    Price = e.Price,
                                    VenueId = e.VenueId

                                    //SoldOut = e.SoldOut
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<EventListItem> GetEventsComedy()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.EventType == Event.EventTypes.Comedy)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    EventName = e.EventName,
                                    EventType = e.EventType,
                                    Image = e.Image,
                                    VenueName = e.Venue.VenueName,
                                    Location = e.Venue.City,
                                    DateTime = e.DateTime,
                                    Price = e.Price,
                                    VenueId = e.VenueId

                                    //SoldOut = e.SoldOut
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<EventListItem> GetEventsConcert()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.EventType == Event.EventTypes.Concert)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    EventName = e.EventName,
                                    EventType = e.EventType,
                                    Image = e.Image,
                                    VenueName = e.Venue.VenueName,
                                    Location = e.Venue.City,
                                    DateTime = e.DateTime,
                                    Price = e.Price,
                                    VenueId = e.VenueId

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
                        .Single(e => e.EventId == id /*&& e.OwnerId == _userId*/);
                return
                    new EventDetails
                    {
                        EventId = entity.EventId,
                        EventName = entity.EventName,
                        EventType = entity.EventType,
                        VenueName = entity.Venue.VenueName,
                        Location = entity.Venue.Location,
                        DateTime = entity.DateTime,
                        Price = entity.Price,
                        Seats = entity.Venue.Seats,
                        Description = entity.Description,
                        Tickets =  ConvertICollectionTicketstoList(entity.Tickets),
                        Image = entity.Image,
                        SoldOut = entity.SoldOut
                    };
            }
        }

        public List<TicketListItem> ConvertICollectionTicketstoList(ICollection<Ticket> originalList)       
        {
            // instantiate a new List of TicketListItems
            List<TicketListItem> tickets = new List<TicketListItem>();
            // foreach through originalList and create new TicketListItem for each Ticket
            foreach(var ticket in originalList)
            {
                var entity = new TicketListItem
                {
                    TicketId = ticket.TicketId,
                    Event = ticket.Event.EventName,
                    Location = ticket.Event.Venue.Location,
                    Price = ticket.Event.Price
                };
                tickets.Add(entity);
            }
            return tickets;
            // add that listItem to our new List
            // return the new List
        }

        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == model.EventId && e.OwnerId == _userId);

                entity.EventId = model.EventId;
                entity.EventName = model.EventName;
                entity.Venue.VenueName = model.VenueName;
                entity.Price = model.Price;
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
