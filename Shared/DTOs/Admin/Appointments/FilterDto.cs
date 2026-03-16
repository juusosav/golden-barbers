using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Admin.Appointments
{
    public class FilterDto
    {
        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public string BarberName { get; set; } = "";

        public string OfferingName { get; set; } = "";

        public string CustomerName { get; set; } = "";

        public string SortBy { get; set; } = "date";

        public string SearchTerm { get; set; } = "";
        public string SearchBy { get; set; } = "customer";
        public bool SortByDescending { get; set; } = false;

        public int Page { get; set; } = 1;

        public int PageSize { get; set; } = 20;

        public int PageItems { get; set; }
    }
}
