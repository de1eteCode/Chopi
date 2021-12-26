using Chopi.API.Controllers.Abstracts;
using Chopi.API.Hubs;
using Chopi.API.Models;
using Chopi.Modules.EFCore;
using Chopi.Modules.EFCore.Entities.CarDealership;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerWithSignalR<CarHub, ICarHubActions, CarData>
    {
        protected override string _groupName => "carsgroup";

        private readonly AppDbContext _context;

        public CarsController(
            IHubContext<CarHub, ICarHubActions> hub,
            SignalRConnections connections,
            AppDbContext context)
            : base(hub, connections)
        {
            _context = context;
        }

        [HttpPost("getcars")]
        public IEnumerable<CarData> GetAllCars()
        {
            var cars = new List<Car>();
            cars.AddRange(_context.CustomCars.Include(e => e.Model).ToList());
            cars.AddRange(_context.CompleteCars.ToList());
            return cars.Select(c => c.ConvertToData());
        }

        [HttpGet("customcars")]
        public IEnumerable<CarData> GetCustomCars()
        {
            var cars = _context.CustomCars.Include(x => x.Autoparts).Include(s => s.Model).Include(s => s.Model.Manufacturer).ToList().Select(e => e.ConvertToData());
            return cars;
        }

        [HttpGet("completecars")]
        public IEnumerable<CarData> GetCompleteCars()
        {
            var cars = _context.CompleteCars.Include(x => x.Complete).Include(s => s.Model).Include(s => s.Model.Manufacturer).ToList().Select(e => e.ConvertToData());
            return cars;
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
