using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Data
{
    public class Ticket
    {
        public enum SeatType { VIP, GA}
        [Key]
        public int TicketId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        [ForeignKey("Event")]
        //EventFK
        public int EventId { get; set; }

        [Required]
        //EventFK
        public string EventName { get; set; }

        [Required]
        //EventFK
        public string Location { get; set; }

        [Required]
        public double Price
        {
            get
            {
                double price;
                if(Seat == 0)
                {
                    price = Event.PriceVIP;
                }
                else
                {
                    price = Event.PriceGA;
                }
                return price;
            }
        }

        [Required]
        public SeatType Seat { get; set; }
        public virtual Event Event { get; set; }

    }
}
