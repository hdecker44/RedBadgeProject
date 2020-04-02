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

        [Display(Name = "GA Price")]
        public double PriceGA { get; set; }

        [Display(Name = "VIP Price")]
        public double PriceVIP { get; set; }

        [Display(Name = "Number Of Seats")]
        public int NumberOfSeats { get; set; }

        [Display(Name ="VIP Seats")]
        public int NumberOfVIP { get; set; }

        [Display(Name = "GA Seats")]
        public int NumberOfGA { get; set; }

        [Display(Name = "VIP Seats Available")]
        public int VIPAvailable { get; set; }

        [Display(Name = "GA Seats Available")]
        public int GAAvailable { get; set; }

        [Display(Name = "Seats Available")]
        public int SeatsAvailable { get; set; }

        [Display(Name = "Number Of Tickets Sold")]
        public int NumberOfTicketsSold { get; set; }

        [Display(Name = "Sold Out?")]
        public bool SoldOut { get; set; }

        public string Description { get; set; }
    }
}
