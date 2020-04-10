using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Data
{
    public class Event
    {
        public enum EventTypes { Concert, Comedy, Play, Basketball, Baseball, Football, Soccer, Hockey} 

        [Key]
        public int EventId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public EventTypes EventType  { get; set; }

        [Required]
        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public bool SoldOut
        {
            get
            {
                int tickets = 25;
                if (Tickets == null)
                {
                    return false;
                }
                foreach (var ticket in Tickets)
                {
                    if (ticket.EventId == EventId)
                    {
                        tickets -= 1;
                    }
                }
                if(tickets == 0)
                {
                    return true;
                }
                return false;
            }
        }
        [Required]
        public string Description { get; set; }

        public virtual Venue Venue { get; set; }
        public string Image
        {
            get
            {
                string image = "assets/";
                if (EventType == EventTypes.Comedy)
                {
                    image += "comedy.png";
                }
                else if (EventType == EventTypes.Play)
                {
                    image += "play.png";
                }
                else if (EventType == EventTypes.Concert)
                {
                    image += "concert.png";
                }
                else if (EventType == EventTypes.Football)
                {
                    image += "nfl.png";
                }
                else if (EventType == EventTypes.Baseball)
                {
                    image += "mlb.png";
                }
                else if (EventType == EventTypes.Soccer)
                {
                    image += "soccer.png";
                }
                else if (EventType == EventTypes.Basketball)
                {
                    image += "nba.png";
                }
                else if (EventType == EventTypes.Hockey)
                {
                    image += "hockey.png";
                }
                return image;
            }
            set { }
        }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
        //VenueFK
        //[Required]
        //public string VenueName { get; set; }

        //VenueFK
        //[Required]
        //public string Location { get; set; }


        //VenueFK
        //[Required]
        //public int NumberOfSeats { get; set; }

        ////VenueFK
        //[Required]
        //public int NumberOfVIP { get; set; }

        ////VenueFK
        //[Required]
        //public int NumberOfGA { get; set; }

        //[Required]
        //public int VIPAvailable
        //{
        //    get
        //    {
        //        int vipAvailable = NumberOfVIP;

        //        /*foreach(var ticket in list)
        //        {
        //            if(ticket.EventId == EventId && ticket.EventType == "VIP")
        //            {
        //                vipAvailable -= 1;
        //            }
        //        }*/
        //        return vipAvailable;
        //    }
        //}

        //[Required]
        //public int GAAvailable
        //{
        //    get
        //    {
        //        int gaAvailable = NumberOfGA;

        //        /*foreach(var ticket in list)
        //        {
        //            if(ticket.EventId == EventId && ticket.EventType == "GA")
        //            {
        //                gaAvailable -= 1;
        //            }
        //        }*/
        //        return gaAvailable;
        //    }
        //}

        //[Required]
        //public int SeatsAvailable
        //{
        //    get
        //    {
        //        return NumberOfSeats - NumberOfTicketsSold;
        //    }
        //}

        //public int NumberOfTicketsSold
        //{
        //    get
        //    {
        //        int ticketsSold = 0;

        //        /*foreach(var ticket in list)
        //        {
        //            if (ticket.EventId == EventId)
        //            {
        //                ticketsSold += 1;
        //            }
        //        }*/
        //        return ticketsSold;
        //    }
        //}

}
