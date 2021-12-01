using Chopi.API.Controllers.CreatorsControllers.Abstracts;
using Chopi.API.Models;
using Chopi.Modules.EFCore.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chopi.API.Controllers.CreatorsControllers
{
    public class RoleController : CreatorController
    {
        public RoleController(UserManager<User> userManager, RoleManager<Role> roleManager) : base(userManager, roleManager)
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
                    new Claim(CustomClaimTypes.Permmision, CustomClaimValues.ReadAnotherAccount)
                });
        }

        private async Task<IActionResult> CreateRole(string name, Claim[] claims)
        {
            if (await _roleManager.FindByNameAsync(name) is not null)
            {
                return BadRequest($"Роль \"{name}\" создана уже");
            }
            else
            {
                var role = new Role("Клиент");
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
