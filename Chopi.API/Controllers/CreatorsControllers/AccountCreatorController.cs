using Chopi.API.Controllers.CreatorsControllers.Abstracts;
using Chopi.Modules.EFCore.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Chopi.API.Controllers.CreatorsControllers
{
    public class AccountCreatorController : CreatorController
    {
        protected AccountCreatorController(UserManager<User> userManager, RoleManager<Role> roleManager) : base(userManager, roleManager)
        {
        }

    }
}
