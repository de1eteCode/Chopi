using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Chopi.API.Controllers
{
    /// <summary>
    /// Функции для работы пользователя со своим аккаунтом
    /// </summary>
    
    //[ApiController]
    //[Route("[controller]")]
    //[Authorize]
    //public class AccountController : Controller
    //{
    //    private readonly UserManager<User> _userManager;
    //    private readonly SignInManager<User> _signInManager;
    //    private readonly RoleManager<Role> _roleManager;
    //    private readonly IUnitOfAccounts _unit;

    //    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IUnitOfAccounts unit)
    //    {
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //        _roleManager = roleManager;
    //        _unit = unit;
    //    }

        

    //    [HttpPost("register")]
    //    [AllowAnonymous]
    //    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    //    {
    //        throw new NotImplementedException("необходимо переделать метод, или контроллер по регистрации персонала/клиентов или" +
    //            " сделать отдельный контроллер для админов/директоров чтобы они могли регистрировать как клиентов так и персонал, или только персонал и" +
    //            " отдельный контроллер для самостоятельной регистрации клиентов");

    //        if (await _userManager.FindByNameAsync(model.Username) is not null
    //            || await _userManager.FindByEmailAsync(model.Email) is not null)
    //        {
    //            return BadRequest();
    //        }

    //        var user = new User()
    //        {
    //            Email = model.Email,
    //            UserName = model.Username,
    //            NormalizedUserName = model.Username.Normalize(),
    //            Passport = new Passport()
    //            {
    //                Citizenship = model.Citizenship,
    //                SecondName = model.SecondName,
    //                FirstName = model.FirstName,
    //                MiddleName = model.MiddleName,
    //                DateOfBirth = model.DateOfBirth,
    //                Series = model.Series,
    //                Number = model.Number,
    //                ResidenceRegistration = model.ResidenceRegistration
    //            }
    //        };

    //        var result = await _userManager.CreateAsync(user, model.Password);


    //        if (result.Succeeded)
    //        {
    //            var loging = new LoginModel()
    //            {
    //                Username = model.Username,
    //                Password = model.Password
    //            };
    //            return RedirectToAction("login", "auth", loging);
    //            //return await Login(loging);
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }
    //    }


    //    [HttpGet("getinfo")]
    //    public async Task<IActionResult> GetPassport()
    //    {
    //        var user = await _userManager.GetUserAsync(User);
    //        return Ok(user.Passport);
    //    }
    //}
}
