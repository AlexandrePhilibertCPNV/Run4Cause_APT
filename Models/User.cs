using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Run4Cause.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [MaxLength(16)]
        public string? PhoneNumber { get; set; }

        public float TotalDistanceCovered { get; set; }

        public List<Entry>? Entries { get; set; }

        public List<Tracking>? Trackings { get; set; }

        public List<Trophy>? Trophies { get; set; }

        public int? ProfileId { get; set; }
        public virtual Profile? Profile { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}