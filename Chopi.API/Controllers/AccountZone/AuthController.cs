using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chopi.API.Controllers
{
    /// <summary>
    /// Контроллер авторизации пользователя
    /// </summary>
    [ApiController]
    [Route("account/[controller]")]
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="model">Модель данных для авторизации</param>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            // Поиск пользователя
            var user = await _userManager.FindByNameAsync(model.Username);

            // Проверка пароля
            if (user is null || await _userManager.CheckPasswordAsync(user, model.Password) is false)
            {
                // Ошибка, при неверном пароле или логине
                return Unauthorized();
            }

            // Авторизация пользователя
            await _signInManager.SignInAsync(user, false);

            // Возврат статуса + куки
            return Ok();
        }

        /// <summary>
        /// Деавторизация пользователя
        /// </summary>
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Деавторизация пользователя
            await _signInManager.SignOutAsync();

            // Возврат статуса
            return Ok();
        }
    }
}
