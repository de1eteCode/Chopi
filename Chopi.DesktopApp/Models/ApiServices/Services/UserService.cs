using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using RestSharp;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class UserService : ApiDatasService<UserData, DataRequestCollection<UserData>>
    {
        public UserService() : base(new DataRequestCollection<UserData>(0, 10000), "api/users/getusers")
        {
        }

        public UserService(DataRequestCollection<UserData> @params) : base(@params, "api/users/getusers")
        {
        }
    }

    class UpdateUserService : ApiService
    {
        public UpdateUserService(object @params) : base(@params) { }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var dModel = ParseParams<UserData>();

            var json = System.Text.Json.JsonSerializer.Serialize(dModel);

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/users/updateuser", Method.PUT, DataFormat.Json)
                .AddJsonBody(json);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
