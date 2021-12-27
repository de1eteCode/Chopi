using Chopi.API.Controllers.Abstracts;
using Chopi.API.Hubs;
using Chopi.API.Models;
using Chopi.Modules.EFCore;
using Chopi.Modules.EFCore.Entities.CarDealership;
using Chopi.Modules.EFCore.Entities.CarDealership.Transits;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
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
            cars.AddRange(_context.CustomCars.Include(e => e.Model).Include(e => e.Autoparts).Include(e => e.Model.Manufacturer).ToList());
            cars.AddRange(_context.CompleteCars.Include(e => e.Complete).Include(e => e.Model).Include(e => e.Model.Manufacturer).ToList());
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

        [HttpPost("addcompletecar")]
        public async Task<IActionResult> AddCompleteCar([FromBody] CarCompleteData car)
        {
            if (ModelState.IsValid is false)
                return BadRequest();

            var model = await _context.Models.Where(e => e.Name == car.ModelName).FirstOrDefaultAsync();
            var complete = await _context.Completes.Where(e => e.Name == car.CompleteName).FirstOrDefaultAsync();

            if (model is null || complete is null)
                return BadRequest();

            var completecar = new CompleteCar()
            {
                Id = Guid.NewGuid(),
                BasePrice = (int)car.BasePrice,
                Color = car.Color,
                Year = car.Year,
                ModelId = model.Id,
                CompleteId = complete.Id
            };

            await _context.CompleteCars.AddAsync(completecar);
            await _context.SaveChangesAsync();

            await AddEntity(completecar.ConvertToData());

            return Ok();
        }

        [HttpPut("updatecompletecar")]
        public async Task<IActionResult> UpdateCompleteCar([FromBody] CarCompleteData car)
        {
            if (ModelState.IsValid is false)
                return BadRequest();

            var completecar = await _context.CompleteCars.Where(e => e.Id == car.Id).FirstOrDefaultAsync();
            var model = await _context.Models.Include(e => e.Manufacturer).Where(e => e.Name.Equals(car.ModelName) && e.Manufacturer.Brand.Equals(car.BrandName)).FirstOrDefaultAsync();
            var complete = await _context.Completes.Where(e => e.Name.Equals(car.CompleteName)).FirstOrDefaultAsync();
            

            if (model is null || complete is null || completecar is null)
                return BadRequest();

            completecar.ModelId = model.Id;
            completecar.CompleteId = complete.Id;
            completecar.BasePrice = (int)car.BasePrice;
            completecar.Year = car.Year;
            completecar.Color = car.Color;

            _context.Attach(completecar);
            _context.Entry(completecar).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await UpdateEntity(completecar.ConvertToData());

            return Ok();
        }

        [HttpPut("addcustomcar")]
        public async Task<IActionResult> AddCustomCar([FromBody] CarCustomData car)
        {
            if (ModelState.IsValid is false)
                return BadRequest();

            var model = await _context.Models.Where(e => e.Name == car.ModelName).FirstOrDefaultAsync();
            var allparts = await _context.Autoparts.ToListAsync();
            var selectedparts = allparts.Where(e => car.Autoparts.Select(e => e.Name).Contains(e.Name)).ToList();

            if (model is null || selectedparts is null || selectedparts.Count < 1)
                return BadRequest();

            var customcar = new CustomCar()
            {
                Id = Guid.NewGuid(),
                BasePrice = (int)car.BasePrice,
                Color = car.Color,
                Year = car.Year,
                ModelId = model.Id
            };

            var customcarTOautoparts = new List<CustomCarToAutopart>();

            selectedparts.ForEach(s =>
            {
                customcarTOautoparts.Add(new CustomCarToAutopart()
                {
                    AutopartId = s.Id,
                    CustomCarId = customcar.Id
                });
            });

            await _context.CustomCars.AddAsync(customcar);
            await _context.SaveChangesAsync();

            await _context.CustomCarToAutoparts.AddRangeAsync(customcarTOautoparts);
            await _context.SaveChangesAsync();

            await AddEntity(car);

            return Ok();
        }

        [HttpPut("updatecustomcar")]
        public async Task<IActionResult> UpdateCustomCar([FromBody] CarCustomData car)
        {
            if (ModelState.IsValid is false)
                return BadRequest();

            var model = await _context.Models.Where(e => e.Name == car.ModelName).FirstOrDefaultAsync();
            var allparts = await _context.Autoparts.ToListAsync();
            var selectedparts = allparts.Where(e => car.Autoparts.Select(e => e.Name).Contains(e.Name)).ToList();
            var customcar = await _context.CustomCars.Where(e => e.Id == car.Id).FirstOrDefaultAsync();

            if (model is null || selectedparts is null || selectedparts.Count < 1 || customcar is null)
                return BadRequest();

            customcar.ModelId = model.Id;
            customcar.Year = car.Year;
            customcar.Color = car.Color;
            customcar.BasePrice = (int)car.BasePrice;
            
            _context.Attach(customcar);
            _context.Entry(customcar).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var currentparts = await _context.CustomCarToAutoparts.Where(e => e.CustomCarId == customcar.Id).ToListAsync();
            var newparts = new List<CustomCarToAutopart>();

            selectedparts.ForEach(e =>
            {
                newparts.Add(new CustomCarToAutopart()
                {
                    AutopartId = e.Id,
                    CustomCarId = customcar.Id
                });
            });

            _context.CustomCarToAutoparts.RemoveRange(currentparts);
            await _context.CustomCarToAutoparts.AddRangeAsync(newparts);

            await UpdateEntity(customcar.ConvertToData());

            return Ok();
        }
    }
}
