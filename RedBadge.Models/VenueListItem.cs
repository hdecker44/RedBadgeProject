﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class VenueListItem
    {
        [Display(Name = "Venue ID")]
        public int VenueId { get; set; }

        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }

        public string City { get; set; }

        [Display(Name = "Number Of VIP Seats")]
        public int NumberOfVIP { get; set; }

        [Display(Name = "Number Of GA Seats")]
        public int NumberOfGA { get; set; }
    }
}
