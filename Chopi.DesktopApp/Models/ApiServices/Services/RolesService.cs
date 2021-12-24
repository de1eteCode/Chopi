using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class RolesService : ApiDatasService<string, DataRequestCollection<string>>
    {
        public RolesService() : base(new DataRequestCollection<string>(0, 1000), "api/roles/getroles")
        {
        }
    }
}
