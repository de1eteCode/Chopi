using Chopi.API.Controllers.Abstracts;
using Chopi.API.Hubs;
using Chopi.API.Models;
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
    public class UsersController : ControllerWithSignalR<UserHub, IUserHubActions, UserData>
    {
        private IUnitOfAccounts _unit;

        protected override string _groupName => "usersgroup";

        public UsersController(
            IHubContext<UserHub, IUserHubActions> hub,
            SignalRConnections connections,
            IUnitOfAccounts unit
            ) : base(hub, connections)
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

        [HttpPut("adduser")]
        public async Task AddUser([FromBody] UserData user)
        {
            await AddEntity(user);
        }

        [HttpPut("updateuser")]
        public async Task UpdateUser([FromBody] UserData user)
        {
            await UpdateEntity(user);

            throw new System.NotImplementedException();
        }
    }
}
