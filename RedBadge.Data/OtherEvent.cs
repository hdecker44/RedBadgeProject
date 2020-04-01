using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadge.Data
{
    public class OtherEvent : Event
    {
        public enum EventyType { Comedy, Play, Show}
        [Required]
        public string Artist { get; set; }
        [Required]
        public EventyType Type { get; set; }
    }
}
