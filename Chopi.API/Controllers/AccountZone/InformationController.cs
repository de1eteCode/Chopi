using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
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

        [HttpPost("aboutme")]
        public async Task<IActionResult> AboutMe(DataRequest<UserData> daataRequest)
        {
            var user = await _userManager.GetUserAsync(base.User);

            if (user is null)
            {
                return BadRequest("Не найден текущий пользователь");
            }

            return Ok(user.ToUserData());
        }
    }
}
