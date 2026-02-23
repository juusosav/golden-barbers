namespace GoldenBarbers.Models.Entities
{ 
    public class Barber
    {
        public Guid Id { get; set; }

        public required string Name { get; set; } = "";

        public int PositionId { get; set; }
        public string PositionName { get; set; } = "";

        public string Description { get; set; } = "";

        public string Portrait { get; set; } = "";
    }
}
