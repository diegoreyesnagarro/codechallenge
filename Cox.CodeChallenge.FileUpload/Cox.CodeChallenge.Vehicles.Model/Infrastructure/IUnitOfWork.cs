
using Cox.CodeChallenge.Vehicles.Model.Repositories;
using System.Threading.Tasks;

namespace Cox.CodeChallenge.Vehicles.Model.Infrastructure
{
    public interface IUnitOfWork
    {
        public IVehicleDealsRepository VehicleDealsRepository {get;}
        int Commit();
        Task CommitAsync();
        void Dispose();
    }
}
