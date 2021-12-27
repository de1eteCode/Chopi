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
    }
}
