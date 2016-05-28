using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Scheduler.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SchedulerLocalDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("ApplicationUserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("ApplicationUserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("ApplicationUserClaims");

            CreateScheduleModel(modelBuilder);
        }
    }
}