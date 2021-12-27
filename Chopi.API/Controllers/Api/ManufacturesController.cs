using Chopi.Modules.EFCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturesController : Controller
    {
        private AppDbContext _context;

        public ManufacturesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("getmanufactures")]
        public IEnumerable<string> GetManufactures()
        {
            return _context.Manufacturers.Select(e => e.Brand);
        }
    }
}
