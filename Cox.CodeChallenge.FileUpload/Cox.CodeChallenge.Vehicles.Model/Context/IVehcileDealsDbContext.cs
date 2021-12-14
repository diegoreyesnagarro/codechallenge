using Cox.CodeChallenge.Vehicles.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Cox.CodeChallenge.Vehicles.Model.Context
{
    public interface IVehcileDealsDbContext
    {
        DbSet<VehicleDeal> VehicleDeals { get; set; }

        
    }
}