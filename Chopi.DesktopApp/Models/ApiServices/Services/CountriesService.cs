using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class CountriesService : ApiDatasService<string, DataRequestCollection<string>>
    {
        public CountriesService() : base(new DataRequestCollection<string>(0, 1000), "api/countries/getcountries")
        {
        }
    }
}
