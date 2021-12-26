using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share.RequestModels;
using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class RegisterService : ApiService
    {
        public RegisterService(RegisterModel @params) : base(@params)
        {
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var rModel = ParseParams<RegisterModel>();

            var json = System.Text.Json.JsonSerializer.Serialize(rModel);

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/account/registeradvanced", Method.POST, DataFormat.Json)
                .AddJsonBody(json);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
