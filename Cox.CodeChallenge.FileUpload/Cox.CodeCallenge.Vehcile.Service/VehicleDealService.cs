using Cox.CodeChallenge.Domain.Command;
using Cox.CodeChallenge.Domain.Query;
using Cox.CodeChallenge.Vehicles.Model.Infrastructure;
using System.Collections.Generic;


namespace Cox.CodeCallenge.Vehcile.Service
{
    public class VehicleDealService : IVehicleDealService
    {
		private readonly IUnitOfWork unitOfWork;

		public VehicleDealService(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}


		public IList<VehicleDealQuery> GetAllVehicleDeals()
        {
			var result = unitOfWork.VehicleDealsRepository.GetAll();

			var queryResult = new List<VehicleDealQuery>();

            foreach (var item in result)
            {
				queryResult.Add(
					new VehicleDealQuery
					{
						CustomerName = item.CustomerName,
						Date = item.Date,
						DealershipName = item.DealershipName,
						DealNumber = item.DealNumber,
						Price = item.Price,
						Vehicle = item.Vehicle,
						VehicleDealId = item.VehicleDealId

					}
					);
            }
			return queryResult;
        }

		public void SaveRecords(List<VehicleDealCommand> itemsToInsert)
        {
            foreach (var item in itemsToInsert)
            {
				unitOfWork.VehicleDealsRepository.Add(new CodeChallenge.Vehicles.Model.Models.VehicleDeal
				{
					CustomerName = item.CustomerName,
					Date = item.Date,
					DealershipName = item.DealershipName,
					DealNumber = item.DealNumber,
					Price = item.Price,
					Vehicle = item.Vehicle
				});

			}

			unitOfWork.Commit();			

		}




	}
}
