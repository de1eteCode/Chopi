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
    
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfAccounts _unit;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfAccounts unit)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unit = unit;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user is null || await _userManager.CheckPasswordAsync(user, model.Password) is false)
            {
                return Unauthorized();
            }

            await _signInManager.SignInAsync(user, false);

            return Ok();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            //throw new NotImplementedException("read inner todo list");

            //// Вызывает исключение при добавлении,
            //// так как требует обязательное наличие пасспорта


            if (await _userManager.FindByNameAsync(model.Username) is not null
                || await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return BadRequest();
            }

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
                var loging = new LoginModel()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                return await Login(loging);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("getinfo")]
        public async Task<IActionResult> GetPassport()
        {
            var user = await _userManager.GetUserAsync(User);
            return Ok(user.Passport);
        }
    }
}
