namespace GoldenBarbers.Models.Entities
{ 
    public class Barber
    {
        public Guid Id { get; set; }

        public required string Name { get; set; } = "";

        public string Position { get; set; } = "";

        public string Description { get; set; } = "";

        public string Portrait { get; set; } = "";
    }
}
