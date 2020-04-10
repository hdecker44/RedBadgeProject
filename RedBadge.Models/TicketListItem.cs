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
    public class TicketListItem
    {
        [Display(Name ="Ticket ID")]
        public int TicketId { get; set; }
        public string Event { get; set; }
        public EventTypes EventType { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
    }
}
