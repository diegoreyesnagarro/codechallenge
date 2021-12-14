using Cox.CodeChallenge.Vehicles.Model.Context;
using Cox.CodeChallenge.Vehicles.Model.Repositories;
using System.Threading.Tasks;

namespace Cox.CodeChallenge.Vehicles.Model.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public VehcileDealsDbContext DbContext { get; private set; }

        public UnitOfWork(VehcileDealsDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private IVehicleDealsRepository vehicleDealsRepository;
        public IVehicleDealsRepository VehicleDealsRepository => vehicleDealsRepository ??= new VehicleDealsRepository(DbContext);
        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
