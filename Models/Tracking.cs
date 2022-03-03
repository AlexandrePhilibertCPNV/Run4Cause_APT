namespace Run4Cause.Models
{
    public class Tracking
    {
        public int Id { get; set; }

        public DateTime Instant { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int WaypointId { get; set; }
        public Waypoint Waypoint { get; set; }
    }
}