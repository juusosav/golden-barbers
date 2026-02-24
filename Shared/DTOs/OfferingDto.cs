using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class OfferingDto
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public string Icon { get; set; } = "";

        public int SeniorPrice { get; set; }

        public int JuniorPrice { get; set; }

        public int TraineePrice { get; set; }

    }
}
