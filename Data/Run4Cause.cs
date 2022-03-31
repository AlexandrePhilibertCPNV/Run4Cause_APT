using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Run4Cause.Models;

namespace Run4Cause.Data
{
    public class Run4CauseContext : DbContext
    {
        public Run4CauseContext(DbContextOptions<Run4CauseContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<IdentityUserClaim<int>> UserClaims { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Run> Runs { get; set; }
        public virtual DbSet<Edition> Editions { get; set; }
        public virtual DbSet<Waypoint> Waypoints { get; set; }
        public virtual DbSet<Sponsorship> Sponsorships { get; set; }
        public virtual DbSet<Tracking> Trackings { get; set; }
        public virtual DbSet<RunWaypoint> RunWaypoints { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "Alexandre",
                LastName = "Philibert",
                Email = "alexandre.philibert@cpnv.ch",
                PhoneNumber = "0781234567",
                TotalDistanceCovered = 12.4m
            });

            modelBuilder.Entity<Profile>().HasData(new Profile
            {
                Id = 1,
                Description = "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Maiores, vero!",
                UserId = 1,
            });
        }
    }
}