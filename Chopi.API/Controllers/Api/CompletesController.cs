using Chopi.Modules.EFCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Chopi.API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompletesController : Controller
    {
        private AppDbContext _context;

        public CompletesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("getcompletes")]
        public IEnumerable<string> GetModels()
        {
            return _context.Completes.Select(e => e.Name);
        }
    }
}
