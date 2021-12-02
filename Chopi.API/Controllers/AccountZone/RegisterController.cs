using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.AccountZone
{
    [ApiController]
    [Route("account")]
    [Authorize]
    public class RegisterController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost("register")]
        [Authorize(Roles = "Менеджер, Директор")]
        public async Task<IActionResult> Register(RegisterModel model)
        {


            throw new NotImplementedException();
        }

        [HttpPost("registeradvanced")]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Register(RegisterModel model, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
