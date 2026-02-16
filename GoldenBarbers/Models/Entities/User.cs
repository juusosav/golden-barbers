namespace GoldenBarbers.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public required string Name { get; set; } = "";

        public string Address { get; set; } = "";

        public string City { get; set; } = "";

        public required string Phone { get; set; } = "";

        public required string Email { get; set; } = "";

        public DateTime DateAdded { get; set; }
    }
}
