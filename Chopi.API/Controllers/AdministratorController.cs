using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chopi.API.Controllers
{
    [ApiController]
    [Route("api/adm")]
    [Authorize(Roles = "Администратор")]
    public class AdministratorController : Controller
    {

    }
}
