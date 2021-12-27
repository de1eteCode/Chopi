using Chopi.API.Hubs;
using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share;
using Chopi.Modules.Share.HubInterfaces;
using Chopi.Modules.Share.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
        private string _groupName => "usersgroup";
        private IUnitOfRoot _unit;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IHubContext<UserHub, IUserHubActions> _hub;

        public RegisterController(
            IHubContext<UserHub, IUserHubActions> hub, 
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IUnitOfRoot unit)
        {
            _unit = unit;
            _hub = hub;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Регистрация пользователей с ролей. Для пользователей с ролей админов
        /// </summary>
        /// <param name="model">Модель данных для регистрации</param>
        /// <param name="roleName">Наименование роли</param>
        [HttpPost("registeradvanced")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // Проверка на наличие аккаунта со сходными данными
            if (ModelState.IsValid is false)
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
                foreach (var roleName in model.Roles)
                {
                    var systemNameRole = await _unit.Roles.Where(e => e.DisplayName == roleName).Select(e => e.Name).FirstAsync();

                    // Поиск роли для клиента
                    var role = await _roleManager.FindByNameAsync(systemNameRole);

                    // Проверка пользователя на наличие роли (навсякий)
                    if (role is not null && await _userManager.IsInRoleAsync(user, role.Name) is false)
                    {
                        // Добавление роли для созданного пользователя
                        await _userManager.AddToRoleAsync(user, role.Name);
                    }
                }

                var data = _unit.UserRepository.Where(e => e.UserName == user.UserName, i => i.Include(s => s.Roles)).Select(s => s.ToUserData()).First();

                await _hub.Clients.Group(_groupName).Add(data);

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
    }
}
