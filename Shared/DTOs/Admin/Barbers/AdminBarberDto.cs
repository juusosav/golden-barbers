using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Barbers
{
    public class AdminBarberDto
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage =
            "Name is required and must be between 2 and 50 characters")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [Required(ErrorMessage =
            "Email is required and must be between 2 and 50 characters")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        ErrorMessage = "Invalid email format.")]
        public string PersonalEmail { get; set; } = "";

        [Required(ErrorMessage =
            "Phone number is required and must be between 2 and 50 characters")]
        [StringLength(50, MinimumLength = 2)]
        public string PersonalPhone { get; set; } = "";

        [Required(ErrorMessage =
            "Address is required and must be between 2 and 80 characters")]
        [StringLength(80, MinimumLength = 2)]
        public string PersonalAddress { get; set; } = "";

        [Required]
        [Range(1, 3, ErrorMessage =
            "Position identifier must be between numbers 1 and 3")]
        public int PositionId { get; set; }

        [Required(ErrorMessage =
            "Position name is required and must be between 2 and 50 characters")]
        [StringLength(50, MinimumLength = 2)]
        public string PositionName { get; set; } = "";
        public string Portrait { get; set; } = "";

        [Required]
        [Range(1, 10000, ErrorMessage = "Salary must be within 1 and 10000 range")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Starting date is required")]
        public DateTime StartDate { get; set; }
    }
}
