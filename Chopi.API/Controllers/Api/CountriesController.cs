using Chopi.Modules.EFCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Chopi.API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : Controller
    {
        private AppDbContext _context;

        public CountriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("getcountries")]
        public IEnumerable<string> GetCountries()
        {
            var countries = _context.Countries.Select(e => e.Name);
            return countries;
        }

        [HttpPost("addcountry")]
        public IActionResult AddCountry([FromBody] string countryName)
        {
            if (_context.Countries.Where(e => e.Name.Equals(countryName)).Count() > 0)
            {
                return BadRequest();
            }
            else
            {
                _context.Countries.Add(new Modules.EFCore.Entities.CarDealership.Country() { Name = countryName });
                return Ok();
            }
        }
    }
}
