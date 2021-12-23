using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiSignalR
{
    internal class CarSignalR : ApiSignalController<CarData>
    {
        public CarSignalR()
            : base("carhub", "api/cars/sub")
        {
        }
    }
}
