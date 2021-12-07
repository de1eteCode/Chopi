using Chopi.API.Models;
using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.AccountZone
{
    [ApiController]
    [Route("account/[controller]")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RoleController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string nameRole)
        {
            var res = await _roleManager.FindByNameAsync(nameRole);
            if (res is null)
            {
                return NotFound($"Роли {nameRole} не существует");
            }
            else
            {
                return Ok($"{res.Id} : {res.Name}");
            }
        }

        [HttpGet("getallroleswithpermssions")]
        public async Task<IActionResult> Get()
        {
            var answer = "";

            var roles = await _roleManager.Roles.ToListAsync();

            if (roles.Count == 0)
            {
                return Ok("Ролей нет");
            }

            foreach (var role in roles)
            {
                answer += $"{role.Name}\r\n";

                var claims = await _roleManager.GetClaimsAsync(role);

                if (claims.Count == 0)
                {
                    answer += "\tУ данной роли нет разрешений";
                    continue;
                }

                foreach (var claim in claims)
                {
                    answer += $"\t- {claim.Type} | {claim.Value}\r\n";
                }
                answer += "\r\n";
            }

            return Ok(answer);
        }

        [HttpPost("addusertorole")]
        public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            var role = await _roleManager.FindByNameAsync(model.Rolename);

            if (user is null)
            {
                return NotFound("Пользователь не найден");
            }

            if (role is null)
            {
                return NotFound("Роль не найдена");
            }

            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                return BadRequest($"Пользователь {user.UserName} уже имеет роль {role.DisplayName} ({role.Name})");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, role.Name);
                return Ok($"Пользователю {user.UserName} добавлена роль {role.DisplayName} ({role.Name})");
            }
        }

        [HttpGet("getmypermission")]
        public ActionResult<IEnumerable<Claim>> GetMyPermissions()
        {
            var claims = User.Claims.ToList();
            var claimString = "";
            foreach (var claim in claims)
            {
                claimString += $"- {claim.Type} {claim.Value}\r\n";
            }
            return Ok(claimString);
        }
    }
}
