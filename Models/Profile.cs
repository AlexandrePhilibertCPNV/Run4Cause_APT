using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Run4Cause.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Image { get; set; }

        public List<string>? Photos { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}