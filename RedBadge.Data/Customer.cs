using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName { get; set; }

        //public string Address { get; set; }
        //public IEnumerable<Team> FavoriteTeam { get; set; }
        //public IEnumerable<Artist> FavoriteArtist { get; set; }
        //public int CC { get; set; }
    }
}
