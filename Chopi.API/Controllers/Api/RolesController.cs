using Chopi.Modules.EFCore.Repositories.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Chopi.API.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : Controller
    {
        private IUnitOfRoot _unit;

        public RolesController(IUnitOfRoot unit)
        {
            _unit = unit;
        }

        [HttpGet("getroles")]
        public ActionResult<IEnumerable<string>> GetRoles()
        {
            var roles = _unit.Roles.Select(x => x.DisplayName);
            return Ok(roles);
        }
    }
}
