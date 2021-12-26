using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValueController : Controller
    {
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
            return Ok(_unit.UserRepository.GetAll());
        }
        
        [HttpGet("Roles")]
        public IActionResult Roles()
        {
            return Ok(_unit.Roles.GetAll());
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Debug mode off");
        }
    }
}
