namespace GoldenBarbers.Models.Entities
{
    public class Timeslot
    {
        public DateTime Start { get; set; }

        public DateTime End => Start.AddMinutes(Duration);

        public int Duration { get; set; } = 30;

        public Guid BarberId { get; set; }

        public string BarberName { get; set; } = "";

        public bool IsAvailable { get; set; }


    }
}
