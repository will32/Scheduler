using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Models.Schedule
{
    public class EventType
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Repeatable { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}