using CarseerNewProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarseerNewProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarMakeController : ControllerBase
    {
        private readonly ICarModelClass _ICarModelClass;
       
        public CarMakeController(ICarModelClass ICarModelClass)
        {
            _ICarModelClass = ICarModelClass;
        }

        [HttpGet]
        public async Task<ActionResult> GetModels(string CarMake, int ManufactureYear)
        {
            var makeId = _ICarModelClass.LoadCarMakes(CarMake);
            if (makeId == null)
            {
                return BadRequest("Invalid car make");
            }

            var models =   _ICarModelClass.GetModelsForMakeIdYear(makeId  , ManufactureYear);
            if (models == null)
            {
                return StatusCode(500, "Failed to retrieve models");
            }

            return Ok(new { Models = models });
        }
    }
}
