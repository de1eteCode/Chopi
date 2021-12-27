using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class ManufacturesService : ApiDatasService<string, DataRequestCollection<string>>
    {
        public ManufacturesService() : base(new DataRequestCollection<string>(0, 1000), "api/manufactures/getmanufactures")
        {
        }
    }

    internal class ModelsService : ApiDatasService<string, DataRequestCollection<string>>
    {
        public ModelsService() : base(new DataRequestCollection<string>(0, 1000), "api/models/getmodels")
        {
        }
    }

    internal class CompletesService : ApiDatasService<string, DataRequestCollection<string>>
    {
        public CompletesService() : base(new DataRequestCollection<string>(0, 1000), "api/completes/getcompletes")
        {
        }
    }
}
