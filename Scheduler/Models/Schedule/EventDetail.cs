using System;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Models.Schedule
{
    public class EventDetail
    {
        public int EventID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTIme { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Event Event { get; set; }
    }
}