using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class UserService : ApiService
    {
        public UserService(int start, int count)
        {
            SetParams(new UserDataRequest( start, count));
        }

        public UserService(Func<UserData, bool> predicate, int start, int count)
        {
            SetParams(new UserDataRequest(predicate, start,  count));
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var @params = ParseParams<UserDataRequest>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/admin/getusers", Method.POST, DataFormat.Json)
                .AddJsonBody(@params);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
