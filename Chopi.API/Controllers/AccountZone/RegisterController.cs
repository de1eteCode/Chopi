using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.AccountZone
{
    /// <summary>
    /// Контроллер для регистрации пользователей
    /// </summary>
    [ApiController]
    [Route("account")]
    [Authorize]
    public class RegisterController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Регистрация клиентов. Для пользователей с ролей менеджера или директора
        /// </summary>
        /// <param name="model">Модель данных для регистрации</param>
        [HttpPost("register")]
        [Authorize(Roles = "Менеджер, Директор")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            return await Register(model, "Клиент");
        }

        /// <summary>
        /// Регистрация пользователей с ролей. Для пользователей с ролей админов
        /// </summary>
        /// <param name="model">Модель данных для регистрации</param>
        /// <param name="roleName">Наименование роли</param>
        [HttpPost("registeradvanced")]
        [Authorize(Roles = Roles.AdministratorSystemRole)]
        public async Task<IActionResult> Register([FromBody] RegisterModel model, string roleName)
        {
            // Проверка на наличие аккаунта со сходными данными
            if (await _userManager.FindByNameAsync(model.Username) is not null
                || await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return BadRequest();
            }

            // Создание пользователя
            var user = new User()
            {
                Email = model.Email,
                UserName = model.Username,
                NormalizedUserName = model.Username.Normalize(),
                Passport = new Passport()
                {
                    Citizenship = model.Citizenship,
                    SecondName = model.SecondName,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    DateOfBirth = model.DateOfBirth,
                    Series = model.Series,
                    Number = model.Number,
                    ResidenceRegistration = model.ResidenceRegistration
                }
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Поиск роли для клиента
                var role = await _roleManager.FindByNameAsync(roleName);

                // Проверка пользователя на наличие роли (навсякий)
                if (role is not null && await _userManager.IsInRoleAsync(user, role.Name) is false)
                {
                    // Добавление роли для созданного пользователя
                    await _userManager.AddToRoleAsync(user, role.Name);
                }

                // Ответ
                string answer = $"{model.SecondName} {model.FirstName} успешно зарегистрирован ({model.Username})";
                return Ok(answer);
            }
            else
            {
                // Ошибки при регистрации
                return BadRequest(result.Errors);
            }
        }

#if DEBUG

        /// <summary>
        /// Регистрация пользователей с ролей. Для пользователей без роли. Доступен только в DEBUG режиме сервера
        /// </summary>
        /// <param name="model">Модель данных для регистрации</param>
        /// <param name="roleName">Наименование роли</param>
        /// <param name="notUse">Чисто для переопределения. Можно не использовать.</param>
        [HttpPost("registerdebug")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model, string roleName, string notUse = "")
        {
            // Создание пользователя с ролей (для дебага, без аутентификации)
            return await Register(model, roleName);
        }

#endif
    }
}
