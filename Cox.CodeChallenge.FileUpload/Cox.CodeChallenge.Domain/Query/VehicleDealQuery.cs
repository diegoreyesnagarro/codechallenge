using System;
using System.Collections.Generic;
using System.Text;

namespace Cox.CodeChallenge.Domain.Query
{
    public class VehicleDealQuery
    {
        public int VehicleDealId { get; set; }
        public int DealNumber { get; set; }

        public string CustomerName { get; set; }

        public string DealershipName { get; set; }

        public string Vehicle { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
