using Chopi.API.Controllers.CreatorsControllers.Abstracts;
using Chopi.API.Models;
using Chopi.Modules.EFCore.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.CreatorsControllers
{
    public class RoleCreatorController : CreatorController
    {
        public RoleCreatorController(UserManager<User> userManager, RoleManager<Role> roleManager) : base(userManager, roleManager)
        {
        }

        [HttpGet("createclientrole")]
        public async Task<IActionResult> CreateClientRole()
        {
            return await CreateRole("Клиент",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.ReadSelfAccount)
                });
        }

        [HttpGet("createpersonalrole")]
        public async Task<IActionResult> CreatePersonalRole()
        {
            return await CreateRole("Персонал",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.ReadSelfAccount)
                });
        }

        [HttpGet("createmanagerrole")]
        public async Task<IActionResult> CreateManagerRole()
        {
            return await CreateRole("Менеджер",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.ReadSelfAccount)
                });
        }

        [HttpGet("createdirectorrole")]
        public async Task<IActionResult> CreateDirectorRole()
        {
            return await CreateRole("Директор",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.ReadSelfAccount)
                });
        }

        [HttpGet("createadminrole")]
        public async Task<IActionResult> CreateAdminRole()
        {
            return await CreateRole("Администратор",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.ReadSelfAccount),
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.UpdateSelfAccount),
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.ReadAnotherAccount),
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.UpdateAnotherAccount),
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.UpdateRoleAccount),
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.ReadRole),
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.CreateRole),
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.UpdateRole),
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.DeleteRole)
                });
        }

        [HttpDelete("deleteall")]
        public async Task<IActionResult> DeleteAllRoles()
        {
            var answer = "";
            var roles = await _roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                var result = await _roleManager.DeleteAsync(role);
                
                if (result.Succeeded)
                {
                    answer += $"Роль {role.Name} успешно удалена\r\n";
                }
                else
                {
                    answer += $"Роль {role.Name} не удалось удалить, ошибки:\r\n";
                    foreach (var error in result.Errors)
                    {
                        answer += $"- {error.Code} {error.Description}";
                    }
                }
            }

            return Ok(answer);
        }

        private async Task<IActionResult> CreateRole(string name, Claim[] claims)
        {
            if (await _roleManager.FindByNameAsync(name) is not null)
            {
                return BadRequest($"Роль \"{name}\" создана уже");
            }
            else
            {
                var role = new Role(name);
                await _roleManager.CreateAsync(role);

                foreach (var claim in claims)
                {
                    await _roleManager.AddClaimAsync(role, claim);
                }

                var roleCheck = await _roleManager.FindByNameAsync(role.Name);
                if (roleCheck is not null)
                {
                    return Ok($"Роль \"{name}\" создана");
                }
                else
                {
                    return BadRequest($"Ошибка при создании роли \"{name}\"");
                }
            }
        }
    }
}
