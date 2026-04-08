using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Public
{
    public class CarouselDto
    {
        public Guid Id { get; set; }
        public string Image { get; set; } = "";
        public string NameFi { get; set; } = "";
        public string NameEn { get; set; } = "";
    }
}
