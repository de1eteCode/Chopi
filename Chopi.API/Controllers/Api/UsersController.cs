using Chopi.API.Controllers.Abstracts;
using Chopi.API.Hubs;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserIdentity = Chopi.Modules.EFCore.Entities.Identity.User;

namespace Chopi.API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "System Administrator, Administrator")]
    public class UsersController : ControllerWithSIgnalR<UserHub, IUserHubActions, UserData>
    {
        private IUnitOfAccounts _unit;

        public UsersController(IUnitOfAccounts unit, IHubContext<UserHub, IUserHubActions> hub) : base(hub)
        {
            _unit = unit;
        }

        [HttpPost("getusers")]
        public async Task<IEnumerable<UserData>> GetUsers([FromBody] DataRequestCollection<UserData> request)
        {
            // Желательно бы переписать на что-то более эффективное

            // Мб сделать собственное расширение для IQueryable с приведением типов

            IEnumerable<UserIdentity> ident =
                await _unit
                .UserRepository
                .GetAll(e => e.Include(s => s.Passport).Include(s => s.Roles))
                .ToListAsync();

            IEnumerable<UserData> users = ident.Select(e => e.ToUserData());

            if (request.IsSetExpression())
            {
                var func = request.GetExpression();
                users = users.Where(x => func(x));
            }

            users = users.Skip(request.Start).Take(request.Count);

            return users;
        }

        [HttpPut]
        public async Task AddUser(UserData user)
        {
            await AddEntity(user);
            throw new System.NotImplementedException();
        }

        [HttpPut]
        public async Task UpdateUser(UserData user)
        {
            await UpdateEntity(user);

            throw new System.NotImplementedException();
        }
    }
}
