using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : Controller
    {
        private readonly IUnitOfCars _unit;

        public CarsController(IUnitOfCars unit)
        {
            _unit = unit;
        }

        [HttpGet("customcars")]
        public IActionResult GetCustomCars()
        {
            return Ok(_unit.CustomCar.GetAll());
        }

        [HttpGet("completecars")]
        public IActionResult GetCompleteCars()
        {
            return Ok(_unit.CompleteCar.GetAll());
        }
    }
}
