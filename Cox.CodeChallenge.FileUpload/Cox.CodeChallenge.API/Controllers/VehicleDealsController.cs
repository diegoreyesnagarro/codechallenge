using Cox.CodeCallenge.Vehcile.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cox.CodeChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleDealsController : ControllerBase
    {
        private readonly IVehicleDealService vehicleDealService;
        private readonly ICsvFileReaderService csvFileReaderService;
        public VehicleDealsController(IVehicleDealService vehicleDealService, ICsvFileReaderService csvFileReaderService)
        {
            this.vehicleDealService = vehicleDealService;
            this.csvFileReaderService = csvFileReaderService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post(IFormFile FormFile)
        {
            if (Request.Form.Files.Count == 0)
            {
                throw new ArgumentNullException(nameof(FormFile));
            }

            try
            {
                
                var postedFile = Request.Form.Files[0];
                
                if (postedFile.Length > 0)
                {

                    var items = csvFileReaderService.ImportData(postedFile.OpenReadStream());
                    vehicleDealService.SaveRecords(items);

                    return Ok($"File is uploaded Successfully");
                }
                else
                {
                    return BadRequest("The File is not received.");
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Some Error Occcured while uploading File {ex.Message}");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAllDeals()
        {
            var items = vehicleDealService.GetAllVehicleDeals();
            if (items != null) return Ok(items);
            else return NotFound();
        }
    }
}
