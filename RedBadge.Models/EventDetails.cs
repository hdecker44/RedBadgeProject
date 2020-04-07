using RedBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RedBadge.Data.Event;

namespace RedBadge.Models
{
    public class EventDetails
    {
        [Display(Name ="Event ID")]
        public int EventId { get; set; }

        [Display(Name = "Event")]
        public string EventName { get; set; }

        [Display(Name = "Event Type")]
        public EventTypes EventType { get; set; }

        [Display(Name = "Venue")]
        public string VenueName { get; set; }

        public string Location { get; set; }

        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        public double Price { get; set; }


        [Display(Name = "Number Of Seats")]
        public int Seats { get; set; }

        [Display(Name = "Seats Available")]
        public int SeatsAvailable
        {
            get
            {
                return Seats - NumberOfTicketsSold;
            }
        }

        [Display(Name = "Number Of Tickets Sold")]
        public int NumberOfTicketsSold
        {
            get
            {
                int ticketsSold = 0;


                foreach (var ticket in Tickets)
                {
                    if (ticket.Event == EventName)
                    {
                        ticketsSold += 1;
                    }
                }
                return ticketsSold;

            }
        }
        [Display(Name = "Sold Out?")]
        public bool SoldOut
        {
            get
            {
                if (SeatsAvailable == 0)
                {
                    return true;
                }
                return false;
            }
        }

        public string Description { get; set; }
        public List<TicketListItem> Tickets { get; set; }
    }
}
