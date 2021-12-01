using Chopi.API.Controllers.CreatorsControllers.Abstracts;
using Chopi.Modules.EFCore.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Chopi.API.Controllers.CreatorsControllers
{
    public class AccountController : CreatorController
    {
        protected AccountController(UserManager<User> userManager, RoleManager<Role> roleManager) : base(userManager, roleManager)
        {
        }


    }
}
