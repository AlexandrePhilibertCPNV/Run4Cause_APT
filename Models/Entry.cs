namespace Run4Cause.Models
{
    public class Entry
    {
        public int Id { get; set; }

        public DateTime Register { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RunId { get; set; }
        public Run Run { get; set; }

        public int EditionId { get; set; }
        public Edition Edition { get; set; }
    }
}
