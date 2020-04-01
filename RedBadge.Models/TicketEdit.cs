using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RedBadge.Data.Ticket;

namespace RedBadge.Models
{
    public class TicketEdit
    {
        //[Display(Name = "Ticket ID")]
        public int TicketId { get; set; }

        //[Display(Name = "Event")]
        public string EventName { get; set; }

        public string Location { get; set; }

        public double Price { get; set; }

        public SeatType Seat { get; set; }
    }
}
