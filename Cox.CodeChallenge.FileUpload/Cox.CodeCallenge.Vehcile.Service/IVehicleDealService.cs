using Cox.CodeChallenge.Domain.Command;
using Cox.CodeChallenge.Domain.Query;
using System.Collections.Generic;

namespace Cox.CodeCallenge.Vehcile.Service
{
    public interface IVehicleDealService
    {
        IList<VehicleDealQuery> GetAllVehicleDeals();
        void SaveRecords(List<VehicleDealCommand> itemsToInsert);


    }
}
