namespace GoldenBarbers.Models.Entities

{
    public class Offering
    {
        public Guid Id { get; set; }
        public string NameFi { get; set; } = "";
        public string NameEn { get; set; } = "";
        public string DescriptionFi { get; set; } = "";
        public string DescriptionEn { get; set; } = "";
        public string Icon { get; set; } = "";
        public int SeniorPrice { get; set; }
        public int JuniorPrice { get; set; }
        public int TraineePrice { get; set; }
        public List<Appointment> Appointments { get; set; } = [];
    }
}
