using Chopi.API.Models;
using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share;
using Chopi.Modules.Share.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using UserIdentity = Chopi.Modules.EFCore.Entities.Identity.User;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("admin")]
    [Authorize(Roles = "System Administrator, Administrator")]
    public class AdministratorController : Controller
    {
        private IUnitOfAccounts _unit;

        public AdministratorController(IUnitOfAccounts unit)
        {
            _unit = unit;
        }

        [HttpPost("getusers")]
        public IEnumerable<UserData> GetUsers([FromBody] DataRequest<UserData> request)
        {
            IEnumerable<UserIdentity> identityUsers;

            if (request.Predicate is null)
            {
                identityUsers = 
                    _unit
                    .UserRepository
                    .GetAll()
                    .Skip(request.Start)
                    .Take(request.Count);
            }
            else
            {
                identityUsers = _unit
                    .UserRepository
                    .Where(user => request.Predicate(UserIdentity.ConvertToUserData(user)))
                    .Skip(request.Start)
                    .Take(request.Count);
            }

            var users = new List<UserData>();

            foreach (var user in identityUsers)
            {
                users.Add(UserIdentity.ConvertToUserData(user));
            }

            return users;
        }
    }
}
