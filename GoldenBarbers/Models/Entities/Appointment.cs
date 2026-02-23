namespace GoldenBarbers.Models.Entities
{
    public class Appointment
    {
        public Guid Id { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public int DurationMinutes { get; set; }

        public Guid BarberId { get; set; }

        public Guid OfferingId { get; set; }

        public int BarberPositionId { get; set; }

        public string CustomerName { get; set; } = "";

        public string CustomerEmail { get; set; } = "";

        public List<Offering> Offerings { get; set; } = [];

    }
}
