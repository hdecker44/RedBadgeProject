using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RedBadge.Data.Ticket;

namespace RedBadge.Models
{
    public class EventCreate
    {
        [Display(Name = "Event")]
        public string EventName { get; set; }

        [Display(Name = "Venue")]
        public string VenueName { get; set; }

        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }
    }
}
