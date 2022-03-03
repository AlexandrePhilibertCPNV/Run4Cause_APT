namespace Run4Cause.Models
{
    public class RunWaypoint
    {
        public int Id { get; set; }

        public DateTime Instant { get; set; }

        public int RunId { get; set; }
        public Run Run { get; set; }

        public int WaypointId { get; set; }
        public Waypoint Waypoint { get; set; }
    }
}