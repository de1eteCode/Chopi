using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValueController : Controller
    {
#if DEBUG
        private IUnitOfRoot _unit;

        public ValueController(IUnitOfRoot unit)
        {
            _unit = unit;
        }

        [HttpGet("Passports")]
        public IActionResult Passports()
        {
            return Ok(_unit.Passports.GetAll());
        }

        [HttpGet("Users")]
        public IActionResult Users()
        {
            return Ok(_unit.Users.GetAll());
        }
        
        [HttpGet("Roles")]
        public IActionResult Roles()
        {
            return Ok(_unit.Roles.GetAll());
        }
#else
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Debug mode off");
        }
#endif
    }
}
