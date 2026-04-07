namespace GoldenBarbers.Models.Entities
{ 
    public class Barber
    {
        public Guid Id { get; set; }

        public required string Name { get; set; } = "";

        public int PositionId { get; set; }

        public string PositionName { get; set; } = "";

        public string DescriptionFi { get; set; } = "";

        public string DescriptionEn { get; set; } = "";

        public string Portrait { get; set; } = "";

        public decimal Salary { get; set; }

        public DateTime StartDate { get; set; }

        public string PersonalEmail { get; set; } = "";

        public string PersonalPhone { get; set; } = "";

        public string PersonalAddress { get; set; } = "";
    }
}
