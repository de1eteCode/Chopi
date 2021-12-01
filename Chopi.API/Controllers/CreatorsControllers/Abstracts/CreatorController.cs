using Chopi.Modules.EFCore.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chopi.API.Controllers.CreatorsControllers.Abstracts
{
    [ApiController]
    [Route("creators/[controller]")]
    public class CreatorController : Controller
    {
        protected readonly UserManager<User> _userManager;
        protected readonly RoleManager<Role> _roleManager;

        protected CreatorController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
    }
}
