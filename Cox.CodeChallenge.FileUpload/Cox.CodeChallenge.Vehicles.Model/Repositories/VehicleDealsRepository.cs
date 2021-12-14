using Cox.CodeChallenge.Vehicles.Model.Context;
using Cox.CodeChallenge.Vehicles.Model.Models;


namespace Cox.CodeChallenge.Vehicles.Model.Repositories
{
    public class VehicleDealsRepository : RepositoryBase<VehicleDeal>, IVehicleDealsRepository
    {
        public VehicleDealsRepository(VehcileDealsDbContext dbContext) : base(dbContext) { }
    }
}
