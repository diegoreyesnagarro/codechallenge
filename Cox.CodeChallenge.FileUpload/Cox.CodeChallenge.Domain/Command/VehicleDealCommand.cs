using System;

namespace Cox.CodeChallenge.Domain.Command
{
    public class VehicleDealCommand
    {
        public int DealNumber { get; set; }

        public string CustomerName { get; set; }

        public string DealershipName { get; set; }

        public string Vehicle { get; set; }

        public decimal Price { get; set; }

        public DateTime Date { get; set; }
    }
}
