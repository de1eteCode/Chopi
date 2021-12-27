using Chopi.API.Controllers.Abstracts;
using Chopi.API.Hubs;
using Chopi.API.Models;
using Chopi.Modules.EFCore;
using Chopi.Modules.EFCore.Entities.CarDealership;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvidersController : ControllerWithSignalR<ProviderHub, IProviderHubActions, ProviderData>
    {
        protected override string _groupName => "providersgroup";

        private AppDbContext _context;

        public ProvidersController(
            IHubContext<ProviderHub, IProviderHubActions> hub,
            SignalRConnections connections,
            AppDbContext context)
            : base(hub, connections)
        {
            _context = context;
        }

        [HttpPost("getproviders")]
        public async Task<IEnumerable<ProviderData>> GetProviders()
        {
            var providers = await _context.Manufacturers.Include(s => s.Country).ToListAsync();
            return providers.Select(e => e.ConvetToData());
        }

        [HttpPost("updateprovider")]
        public async Task<IActionResult> UpdateProvider([FromBody] ProviderData data)
        {
            if (ModelState.IsValid is false)
                return BadRequest(ModelState);

            var provider = await _context.Manufacturers.Include(e => e.Country).Where(e => e.Id == data.Id).FirstAsync();

            if (provider is null)
                return BadRequest();

            provider.Address = data.Address;
            provider.Brand = data.Brand;
            provider.Country = await _context.Countries.Where(e => e.Name == data.CountryName).FirstAsync();
            provider.INN = data.INN;
            provider.PhoneNumber = data.PhoneNumber;

            _context.Attach(provider);
            _context.Entry(provider).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            await UpdateEntity(provider.ConvetToData());

            return Ok();
        }

        [HttpPost("addprovider")]
        public async Task<IActionResult> AddProvider([FromBody] ProviderData data)
        {
            if (ModelState.IsValid is false)
                return BadRequest(ModelState);

            var c = await _context.Countries.Where(e => e.Name == data.CountryName).FirstAsync();

            if (c is null)
                return BadRequest();

            var provider = new Manufacturer()
            {
                Address = data.Address,
                Brand = data.Brand,
                Id = System.Guid.NewGuid(),
                INN = data.INN,
                PhoneNumber = data.PhoneNumber,
                CountryId = c.Id
            };

            await _context.Manufacturers.AddAsync(provider);
            await _context.SaveChangesAsync();

            await AddEntity(provider.ConvetToData());

            return Ok();
        }
    }
}
