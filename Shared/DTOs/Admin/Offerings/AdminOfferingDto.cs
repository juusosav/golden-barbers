using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Offerings
{
    public class AdminOfferingDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage =
            "Service name is required and must be between 2 and 80 characters")]
        [StringLength(80, MinimumLength = 2)]
        public string Name { get; set; } = "";

        [Required(ErrorMessage =
            "Service description is required and must be between 2 and 300 characters")]
        [StringLength(300, MinimumLength = 2)]
        public string Description { get; set; } = "";

        public string Icon { get; set; } = "";

        [Required]
        [Range(1, 1000, ErrorMessage =
            "Service price must be within 1 and 1000 range")]
        public int SeniorPrice { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage =
            "Service price must be within 1 and 1000 range")]
        public int JuniorPrice { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage =
            "Service price must be within 1 and 1000 range")]
        public int TraineePrice { get; set; }
    }
}
