using System.ComponentModel.DataAnnotations;

namespace Run4Cause.Models
{
    public class Trophy
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }
    }
}