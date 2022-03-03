using System.ComponentModel.DataAnnotations;

namespace Run4Cause.Models
{
    public class Run
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Entry>? Entries { get; set; }

        public ICollection<Edition>? Editions { get; set; }

        public List<RunWaypoint>? RunWaypoints { get; set; }
    }
}