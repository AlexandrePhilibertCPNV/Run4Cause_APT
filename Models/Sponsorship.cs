namespace Run4Cause.Models
{
    public class Sponsorship
    {
        public int Id { get; set; }

        public float AmountPerKilometer { get; set; }

        public User? Sponsor { get; set; }
        public User? Performer { get; set; }
    }
}