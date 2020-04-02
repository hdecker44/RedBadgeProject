using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RedBadge.Data.Event;

namespace RedBadge.Models
{
    public class EventEdit
    {
        [Display(Name = "Event ID")]
        public int EventId { get; set; }

        [Display(Name = "Event")]
        public string EventName { get; set; }

        [Display(Name = "Event Type")]
        public EventTypes EventType { get; set; }

        [Display(Name = "Venue")]
        public string VenueName { get; set; }

        [Display(Name ="GA Price")]
        public double PriceGA { get; set; }

        [Display(Name = "VIP Price")]
        public double PriceVIP { get; set; }

        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        public string Description { get; set; }
    }
}
