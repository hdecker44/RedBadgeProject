using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Models
{
    public class VenueCreate
    {
        [Display(Name ="Venue Name")]
        public string VenueName { get; set; }

        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Display(Name = "Number Of Seats")]
        public int Seats { get; set; }
        public string Image { get; set; }

    }
}
