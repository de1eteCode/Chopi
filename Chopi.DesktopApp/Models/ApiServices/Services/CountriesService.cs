using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class CountriesService : ApiDatasService<string, DataRequestCollection<string>>
    {
        public CountriesService() : base(new DataRequestCollection<string>(0, 1000), "api/countries/getcountries")
        {
        }
    }

    internal class AddCountryService : ApiService
    {
        public AddCountryService(string namecountry) : base(namecountry)
        {
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var name = ParseParams<string>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/countries/addcountry", Method.POST, DataFormat.Json)
                .AddBody(System.Text.Json.JsonSerializer.Serialize(name));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
