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

namespace Chopi.API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutopartsController : ControllerWithSignalR<AutopartHub, IAutopartHubAction, AutopartData>
    {
        protected override string _groupName => "autopartsgroup";
        private AppDbContext _context;

        public AutopartsController(
            IHubContext<AutopartHub, IAutopartHubAction> hub,
            SignalRConnections connections,
            AppDbContext context) 
            : base(hub, connections)
        {
            _context = context;
        }

        [HttpPost("getautoparts")]
        public async Task<IEnumerable<AutopartData>> GetAutoparts()
        {
            var parts = await _context.Autoparts.Include(a => a.Models).Include(a => a.Manufacturer).ToListAsync();
            
            return parts.Select(e => e.ConvertToData());
        }

        [HttpPost("updateautoparts")]
        public async Task<IActionResult> UpdateAutoparts([FromBody] AutopartData data)
        {
            if (ModelState.IsValid is false)
                return BadRequest();

            var autopart = await _context.Autoparts.Where(e => e.Id == data.Id).FirstAsync();

            if (autopart is null)
                return BadRequest();

            autopart.Article = data.Article;
            autopart.Name = data.Name;
            autopart.Description = data.Description;
            autopart.Manufacturer = await _context.Manufacturers.Where(e => e.Brand == data.ManufactureName).FirstAsync();
            autopart.Price = (int)data.Price;

            _context.Attach(autopart);
            _context.Entry(autopart).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await UpdateEntity(autopart.ConvertToData());

            return Ok();
        }

        [HttpPost("addautoparts")]
        public async Task<IActionResult> AddAutoparts([FromBody] AutopartData data)
        {
            if (ModelState.IsValid is false)
                return BadRequest();

            var manufactor = await _context.Manufacturers.Where(e => e.Brand.Equals(data.ManufactureName)).FirstOrDefaultAsync();
            var models = await _context.Models.Where(m => data.ForModels.Contains(m.Name)).ToListAsync();

            if (manufactor is null || models is null || models.Count < 1)
                return BadRequest();

            var part = new Autopart()
            {
                Id = Guid.NewGuid(),
                Name = data.Name,
                Description = data.Description,
                Article = data.Article,
                Price = (int)data.Price,
                ManufacturerId = manufactor.Id
            };

            var list = new List<ModelToAutopart>();

            models.ForEach(model =>
            {
                list.Add(new ModelToAutopart()
                {
                    ModelId = model.Id,
                    AutopartId = part.Id
                });
            });

            await _context.Autoparts.AddAsync(part);
            await _context.SaveChangesAsync();
            await _context.ModelToAutoparts.AddRangeAsync(list);
            await _context.SaveChangesAsync();

            await AddEntity(part.ConvertToData());

            return Ok();
        }
    }
}
