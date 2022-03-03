using System.ComponentModel.DataAnnotations;

namespace Run4Cause.Models
{
    public class Edition
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string? Location { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Headline { get; set; }

        public ICollection<Run>? Runs { get; set; }

        public List<Entry>? Entries { get; set; }
    }
}