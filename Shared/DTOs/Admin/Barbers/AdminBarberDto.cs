using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Barbers
{
    public class AdminBarberDto
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string PersonalEmail { get; set; } = "";

        public string PersonalPhone { get; set; } = "";

        public string PersonalAddress { get; set; } = "";

        public int PositionId { get; set; }

        public string PositionName { get; set; } = "";

        public string Portrait { get; set; } = "";

        public decimal Salary { get; set; }

        public DateTime StartDate { get; set; }
    }
}
