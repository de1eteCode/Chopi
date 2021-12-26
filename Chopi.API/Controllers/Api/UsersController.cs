using Chopi.API.Controllers.Abstracts;
using Chopi.API.Hubs;
using Chopi.API.Models;
using Chopi.Modules.EFCore.Entities.Identity;
using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private IUnitOfRoot _unit;
        private RoleManager<Role> _roleManager;
        private UserManager<User> _userManager;

        protected override string _groupName => "usersgroup";

        public UsersController(
            IHubContext<UserHub, IUserHubActions> hub,
            SignalRConnections connections,
            IUnitOfRoot unit,
            RoleManager<Role> roleManager,
            UserManager<User> userManager
            ) : base(hub, connections)
        {
            _unit = unit;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("getusers")]
        public async Task<IEnumerable<UserData>> GetUsers([FromBody] DataRequestCollection<UserData> request)
        {
            // Желательно бы переписать на что-то более эффективное

            // Мб сделать собственное расширение для IQueryable с приведением типов
            System.Console.WriteLine("get users");
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

        [HttpPut("updateuser")]
        public async Task<IActionResult> UpdateUser([FromBody] UserData user)
        {
            if (ModelState.IsValid is false)
                return BadRequest(ModelState);

            var identUser = _unit.UserRepository.Where(e => e.Id == user.Id, i => i.Include(e => e.Roles)).FirstOrDefault();

            if (identUser is null)
                return BadRequest();

            // Обновление пользователя
            identUser.Email = user.Email;
            identUser.NormalizedEmail = user.Email.Normalize();
            identUser.Passport.FirstName = user.FirstName;
            identUser.Passport.SecondName = user.SecondName;
            identUser.Passport.MiddleName = user.MiddleName;
            identUser.Passport.Series = user.Series;
            identUser.Passport.ResidenceRegistration = user.ResidenceRegistration;
            identUser.Passport.Citizenship = user.Citizenship;

            await _userManager.UpdateAsync(identUser);

            var currentRoles = await _userManager.GetRolesAsync(identUser);
            var selectedRoles = _unit.Roles.Where(role => user.Roles.Contains(role.DisplayName)).Select(e => e.Name).ToList();

            var rolesToAdd = selectedRoles.Except(currentRoles);
            var rolesToRemove = currentRoles.Except(selectedRoles);
            
            await _userManager.RemoveFromRolesAsync(identUser, rolesToRemove);

            await _userManager.AddToRolesAsync(identUser, rolesToAdd);

            // Синхронизация
            await UpdateEntity(user);

            var str = $"Добавлено: {rolesToAdd.Count()}. Удалено: {rolesToRemove.Count()}";

            return Ok(str);
        }
    }
}
