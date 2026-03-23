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

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string PersonalEmail { get; set; } = "";

        [Required]
        public string PersonalPhone { get; set; } = "";

        [Required]
        public string PersonalAddress { get; set; } = "";

        public int PositionId { get; set; }

        [Required]
        public string PositionName { get; set; } = "";

        public string Portrait { get; set; } = "";

        public string Salary { get; set; } = "";

        public DateTime StartDate { get; set; }
    }
}
