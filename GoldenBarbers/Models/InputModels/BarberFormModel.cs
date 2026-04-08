namespace GoldenBarbers.Models.InputModels
{
    public class BarberFormModel
    {
        public string Name { get; set; } = "";
        public string DescriptionFi { get; set; } = "";
        public string DescriptionEn { get; set; } = "";
        public string PersonalEmail { get; set; } = "";
        public string PersonalPhone { get; set; } = "";
        public string PersonalAddress { get; set; } = "";
        public int PositionId { get; set; }
        public string PositionName { get; set; } = "";
        public string Salary { get; set; } = "";
        public string StartDate { get; set; } = "";
        public IFormFile? File { get; set; }
    }
}
