using Scheduler.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Models.Schedule
{
    public class Event
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime TimeStamp { get; set; }

        public int EventTypeID { get; set; }
        public int EventDetailID { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual EventDetail EventDetail { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}