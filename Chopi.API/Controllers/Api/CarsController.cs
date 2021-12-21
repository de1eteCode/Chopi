using Chopi.API.Controllers.Abstracts;
using Chopi.API.Hubs;
using Chopi.API.Models;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Linq;
using System.Threading.Tasks;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerWithSignalR<CarHub, ICarHubActions, CarData>
    {
        protected override string _groupName => "carsgroup";

        private readonly IUnitOfCars _unit;

        public CarsController(
            IHubContext<CarHub, ICarHubActions> hub,
            SignalRConnections connections,
            IUnitOfCars unit
            ) : base(hub, connections)
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

        [HttpPut("addcar")]
        public async Task AddCar(CarData car)
        {
            await AddEntity(car);

            throw new System.NotImplementedException();
        }

        [HttpPut("updatecar")]
        public async Task UpdateCar(CarData car)
        {
            await UpdateEntity(car);

            throw new System.NotImplementedException();
        }
    }
}
