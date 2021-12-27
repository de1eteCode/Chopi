using Chopi.Modules.EFCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Chopi.API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelsController : Controller
    {
        private AppDbContext _context;

        public ModelsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("getmodels")]
        public IEnumerable<string> GetModels()
        {
            return _context.Models.Select(e => e.Name);
        }
    }
}
