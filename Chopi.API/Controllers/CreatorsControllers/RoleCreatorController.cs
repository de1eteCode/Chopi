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

        [HttpGet("all")]
        public async Task<IActionResult> RegisterAll()
        {
            var res1 = await CreateClientRole();
            var res2 = await CreateAccountantRole();
            var res3 = await CreatePersonalRole();
            var res4 = await CreateManagerRole();
            var res5 = await CreateAdminRole();
            var res6 = await CreateDirectorRole();
            var res7 = await CreateSysAdminRole();
            var res = 
                (res1 as OkObjectResult)?.Value.ToString() + "\r\n" +
                (res2 as OkObjectResult)?.Value.ToString() + "\r\n" +
                (res3 as OkObjectResult)?.Value.ToString() + "\r\n" +
                (res4 as OkObjectResult)?.Value.ToString() + "\r\n" +
                (res5 as OkObjectResult)?.Value.ToString() + "\r\n" +
                (res6 as OkObjectResult)?.Value.ToString() + "\r\n" +
                (res7 as OkObjectResult)?.Value.ToString() + "\r\n";

            return Ok(res);
        }

        [HttpGet("createclientrole")]
        public async Task<IActionResult> CreateClientRole()
        {
            return await CreateRole("Клиент", "Client",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.MaintenanceSelf, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.MaintenanceSelf, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Update),
                });
        }

        [HttpGet("createpersonalrole")]
        public async Task<IActionResult> CreatePersonalRole()
        {
            return await CreateRole("Персонал", "Personal",
                new Claim[]
                {

                });
        }

        [HttpGet("createmanagerrole")]
        public async Task<IActionResult> CreateManagerRole()
        {
            return await CreateRole("Менеджер", "Manager",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.CarsSell, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsSell, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsSell, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.MaintenanceAll, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.MaintenanceAll, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.MaintenanceAll, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Update)

                });
        }

        [HttpGet("createaccountantrole")]
        public async Task<IActionResult> CreateAccountantRole()
        {
            return await CreateRole("Бухгалтер", "Accountant",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.Accountent, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Accountent, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Accountent, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.Accountent, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Read)
                });
        }

        [HttpGet("createadminrole")]
        public async Task<IActionResult> CreateAdminRole()
        {
            return await CreateRole("Администратор", "Administrator",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.Role, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Update),

                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Update)
                });
        }

        [HttpGet("createdirectorrole")]
        public async Task<IActionResult> CreateDirectorRole()
        {
            return await CreateRole("Директор", "Director",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.Role, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Read),

                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Update)
                });
        }

        [HttpGet("createsysadminrole")]
        public async Task<IActionResult> CreateSysAdminRole()
        {
            return await CreateRole("Системный Администратор", "System Administrator",
                new Claim[]
                {
                    new Claim(CustomClaimTypes.Accountent, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Accountent, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Accountent, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.Accountent, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.AnotherAccount, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.Autoparts, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.AutopartsProvider, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.Cars, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsSell, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsSell, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsSell, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsSell, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsOrderedAll, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsOrderedSelf, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsAllHistory, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsSelfHistory, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.CarsProvider, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.MaintenanceAll, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.MaintenanceAll, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.MaintenanceAll, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.MaintenanceAll, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.MaintenanceSelf, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.MaintenanceSelf, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.MaintenanceSelf, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.MaintenanceSelf, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.Role, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.Role, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.Role, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.Role, CustomClaimValues.Delete),

                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Create),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Read),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Update),
                    new Claim(CustomClaimTypes.SelfAccount, CustomClaimValues.Delete)
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
                    answer += $"Роль {role.DisplayName} ({role.Name}) успешно удалена\r\n";
                }
                else
                {
                    answer += $"Роль {role.DisplayName} ({role.Name}) не удалось удалить, ошибки:\r\n";
                    foreach (var error in result.Errors)
                    {
                        answer += $"- {error.Code} {error.Description}";
                    }
                }
            }

            return Ok(answer);
        }

        private async Task<IActionResult> CreateRole(string dispName, string sysName, Claim[] claims)
        {
            if (await _roleManager.FindByNameAsync(sysName) is not null)
            {
                return BadRequest($"Роль \"{dispName}\" ({sysName}) создана уже");
            }
            else
            {
                var role = new Role(dispName, sysName);
                await _roleManager.CreateAsync(role);

                foreach (var claim in claims)
                {
                    await _roleManager.AddClaimAsync(role, claim);
                }

                var roleCheck = await _roleManager.FindByNameAsync(role.Name);
                if (roleCheck is not null)
                {
                    return Ok($"Роль \"{dispName}\" ({sysName}) создана");
                }
                else
                {
                    return BadRequest($"Ошибка при создании роли \"{dispName}\" ({sysName})");
                }
            }
        }
    }
}
