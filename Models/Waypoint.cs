using System.ComponentModel.DataAnnotations;

namespace Run4Cause.Models
{
    public class Waypoint
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public List<Tracking>? Trackings { get; set; }
        public List<RunWaypoint> RunWaypoints { get; set; }
    }
}