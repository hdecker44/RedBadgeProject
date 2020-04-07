using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RedBadge.Data.Event;
using static RedBadge.Data.Ticket;

namespace RedBadge.Models
{
    public class EventCreate
    {
        [Display(Name = "Event")]
        public string EventName { get; set; }

        [Display(Name ="Event Type")]
        public EventTypes EventType { get; set; }

        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        public double Price { get; set; }

        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        public string Description { get; set; }
    }
}
