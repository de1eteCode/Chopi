using Chopi.Modules.EFCore.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.AccountZone
{
    [ApiController]
    [Route("account/[controller]")]
    [Authorize]
    public class InformationController : Controller
    {
        private readonly UserManager<User> _userManager;

        public InformationController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("aboutme")]
        public async Task<IActionResult> AboutMe()
        {
            var user = await _userManager.GetUserAsync(base.User);

            if (user is null)
            {
                return BadRequest("Не найден текущий пользователь");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var rolesString = "";

            if (roles is not null && roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    rolesString += role + ", ";
                }
                rolesString = rolesString.Remove(rolesString.Length - 2, 2);
            }
            else
            {
                rolesString = "нет";
            }

            var result = new
            {
                Username = user.UserName,
                Firstname = user.Passport.FirstName,
                Secondname = user.Passport.SecondName,
                DateOfBirth = user.Passport.DateOfBirth,
                Roles = rolesString
            };

            return Ok(result);
        }
    }
}
