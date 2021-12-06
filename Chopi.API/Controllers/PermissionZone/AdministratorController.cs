using Chopi.API.Models;
using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("admin")]
    [Authorize(Roles = "Системный Администратор, Администратор")]
    public class AdministratorController : Controller
    {
        private IUnitOfAccounts _unit;
        private RoleManager<Role> _roleManager;
        private UserManager<User> _userManager;

        public AdministratorController(IUnitOfAccounts unit, RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _unit = unit;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            return Ok(_unit.UserRepository.GetAll());
        }
    }
}
