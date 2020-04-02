﻿using System;
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
        public enum EventTypes { Concert, Comedy, Play, Basketball, Baseball, Football, Soccer, Hockey} 
        [Key]
        public int EventId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string EventName { get; set; }
        [Required]
        public EventTypes EventType  { get; set; }
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
                int ticketsSold = 0;

                /*foreach(var ticket in list)
                {
                    if (ticket.EventId == EventId)
                    {
                        ticketsSold += 1;
                    }
                }*/
                return ticketsSold;
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

        public virtual Venue Venue { get; set; }
    }
}