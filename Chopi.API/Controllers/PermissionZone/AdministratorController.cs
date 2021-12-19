using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
    }
}
