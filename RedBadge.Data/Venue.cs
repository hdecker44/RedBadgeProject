using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Data
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string VenueName { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public int ZipCode { get; set; }
        public string Location { get => City + ", " + State; }
        public string Address
        {
            get
            {
                return StreetNumber + ", " + City + ", " + State + " " + ZipCode;
            }
        }

        [Required]
        public int Seats { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
