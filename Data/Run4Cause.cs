using Microsoft.EntityFrameworkCore;
using Run4Cause.Models;

namespace Run4Cause.Data
{
    public class Run4CauseContext : DbContext
    {
        public Run4CauseContext(DbContextOptions<Run4CauseContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Run> Runs { get; set; }
        public virtual DbSet<Edition> Editions { get; set; }
        public virtual DbSet<Waypoint> Waypoints { get; set; }
        public virtual DbSet<Sponsorship> Sponsorships { get; set; }
        public virtual DbSet<Tracking> Trackings { get; set; }
        public virtual DbSet<RunWaypoint> RunWaypoints { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
    }
}