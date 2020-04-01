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
        [Key]
        public int EventId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string EventName { get; set; }
        [Required]
        public string VenueName { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public int SeatsAvailable
        {
            get
            {
                return NumberOfSeats - NumberOfTicketsSold;
            }
        }

        public int NumberOfTicketsSold
        {
            get
            {
                int numberOfTicketsSold = 0;
                foreach(var ticket in SoldTickets)
                {
                    numberOfTicketsSold += 1;
                }
                return numberOfTicketsSold;
            }
        }

        [Required]
        public bool SoldOut
        {
            get
            {
                if(SeatsAvailable == 0)
                {
                    return true;
                }
                return false;
            }
        }
        [Required]
        public string Description { get; set; }
        public ICollection<Ticket> AvailableTickets { get; set; }
        public ICollection<Ticket> SoldTickets { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
