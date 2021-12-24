using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class CarService : ApiDatasService<CarData, DataRequestCollection<CarData>>
    {
        public CarService() : base(new DataRequestCollection<CarData>(0, 10000), "api/cars/getcars")
        {
        }

        public CarService(DataRequestCollection<CarData> @params) : base(@params, "api/cars/getcars")
        {
        }
    }
}
