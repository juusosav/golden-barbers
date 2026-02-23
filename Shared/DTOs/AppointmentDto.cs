using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class AppointmentDto
    {
        public Guid BarberId { get; set; }

        public Guid OfferingId { get; set; }

        public int BarberPositionId { get; set; }

        public DateTime AppointmentDateTime { get; set; }

        public int DurationMinutes { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string CustomerName { get; set; } = "";
        [Required(ErrorMessage = "Email is required")]
        public string CustomerEmail { get; set; } = "";
    }
}
