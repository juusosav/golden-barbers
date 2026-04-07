using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Public
{
    public class BarberDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        public int PositionId { get; set; }

        public string PositionName { get; set; } = "";

        public string DescriptionFi { get; set; } = "";

        public string DescriptionEn { get; set; } = "";

        public string Portrait { get; set; } = "";
    }
}
