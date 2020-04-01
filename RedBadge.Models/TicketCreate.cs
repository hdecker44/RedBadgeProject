using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RedBadge.Data.Ticket;

namespace RedBadge.Models
{
    public class TicketCreate
    {
        [Required]
        public string Event { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public SeatType Seat { get; set; }
    }
}
