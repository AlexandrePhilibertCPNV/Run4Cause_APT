using System.ComponentModel.DataAnnotations;

namespace Run4Cause.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [MaxLength(16)]
        public string? PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public float TotalDistanceCovered { get; set; }

        public List<Entry>? Entries { get; set; }

        public List<Tracking>? Trackings { get; set; }
    }
}