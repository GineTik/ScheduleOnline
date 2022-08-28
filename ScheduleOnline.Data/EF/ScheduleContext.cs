using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScheduleOnline.Data.Entities;

namespace ScheduleOnline.Data.EF
{
    public class ScheduleContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<HistoryItem> History { get; set; }

        public ScheduleContext(DbContextOptions<ScheduleContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(u => u.DateOfRegistration)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Schedule>()
                .Property(u => u.DateOfCreation)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Day>()
                .Property(u => u.DateOfCreation)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Lesson>()
                .Property(u => u.DateOfCreation)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Comment>()
                .Property(u => u.DateOfCreation)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<HistoryItem>()
                .Property(u => u.DateOfAction)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
