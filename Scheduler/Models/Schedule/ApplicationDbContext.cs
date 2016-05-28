using Scheduler.Models.Schedule;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Scheduler.Models
{
    public partial class ApplicationDbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<EventType> EventType { get; set; }

        private void CreateScheduleModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>()
                .HasRequired(e => e.EventType)
                .WithMany(e => e.Events)
                .HasForeignKey(e => e.EventTypeID);

            modelBuilder.Entity<EventDetail>()
                .HasKey(e => e.EventID)
                .HasRequired(e => e.Event)
                .WithRequiredDependent(e => e.EventDetail)
                .WillCascadeOnDelete();
        }
    }
}