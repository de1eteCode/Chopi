using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Chopi.API.Controllers
{
    /// <summary>
    /// Функции для работы пользователя со своим аккаунтом
    /// </summary>
    
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUnitOfAccounts _unit;

        public AccountController(IUnitOfAccounts unit)
        {
            _unit = unit;
        }

        [HttpPost("auth")]
        public IActionResult Login()
        {
            throw new NotImplementedException();
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            throw new NotImplementedException();
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            throw new NotImplementedException();
        }

        [HttpGet("getinfo")]
        public IActionResult GetInfo()
        {
            throw new NotImplementedException();
        }
    }
}
