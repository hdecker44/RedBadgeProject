using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Data
{
    public class SportEvent : Event
    {
        public enum SportType { Football, Basketball, Baseball, Soccer, Hockey, Golf}
        [Required]
        public string Team { get; set; }
        [Required]
        [Display(Name ="Opposing Team")]
        public string OpposingTeam { get; set; }
        [Required]
        public SportType Sport { get; set; }
    }
}
