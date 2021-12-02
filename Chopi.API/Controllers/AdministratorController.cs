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
    [Route("adm")]
    [Authorize]
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
        [Authorize(Roles = "Администратор")]
        public IActionResult GetUsers()
        {
            return Ok(_unit.UserRepository.GetAll());
        }

        [HttpGet("addadmin")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAdmin()
        {
            if (_unit.RoleRepository.GetAll().Count() != 0)
            {
                string answer = "Роли созданы и добавлены первому пользователю системы\r\n";

                foreach(var roleForeach in _unit.RoleRepository.GetAll())
                {
                    answer += $"{roleForeach.Id} : {roleForeach.Name}\r\n";
                }

                answer += "Пользователи и их роли\r\n";

                foreach (var userForeach in _userManager.Users.ToList())
                {
                    answer += $"Пользователь {userForeach.UserName}:\r\n";
                    int i = 1;
                    foreach (var roleForach in await _userManager.GetRolesAsync(userForeach))
                    {
                        answer += $"{i++}. {roleForach}\r\n";
                    }
                }

                return BadRequest(answer);
            }

            var role = await _roleManager.FindByNameAsync("Администратор");

            if (role is null)
            {
                return BadRequest("Для добавления админа создайте роли");
            }

            var user = await _userManager.FindByNameAsync("testuser1");

            if (user is null)
            {
                return BadRequest("Пользователь не найден");
            }

            if (await _userManager.IsInRoleAsync(user, role.Name) is false)
            {
                await _userManager.AddToRoleAsync(user, role.Name);
                return Ok();
            }
            else
            {
                return BadRequest("Пользователю уже добавлена роль админа");
            }
        }
    }
}
