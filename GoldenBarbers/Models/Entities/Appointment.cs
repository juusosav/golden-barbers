namespace GoldenBarbers.Models.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }

        public TimeSpan Timeslot { get; set; }

        public Guid BarberId { get; set; }

        public List<Offering> Offerings { get; set; } = [];

    }
}
