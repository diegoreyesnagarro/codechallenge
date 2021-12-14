using Cox.CodeChallenge.Vehicles.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cox.CodeChallenge.Vehicles.Model.Context
{
    public class VehcileDealsDbContext : DbContext, IVehcileDealsDbContext
    {
        public VehcileDealsDbContext()
        {

        }

        public VehcileDealsDbContext(DbContextOptions<VehcileDealsDbContext> options)
           : base(options)
        {

        }
        public DbSet<VehicleDeal> VehicleDeals { get; set; }
       
    }
}
