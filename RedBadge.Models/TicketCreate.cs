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
        [Display(Name ="Event")]
        public int EventId { get; set; }
    }
}
