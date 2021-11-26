using Chopi.DesktopApp.Network.ApiServices.Abstracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Network.ApiServices
{
    class AuthService : ApiService
    {
        public AuthService(IRestClient client) : base(client)
        {
        }

        public async Task<IRestResponse> Authorizate(string login, string password)
        {
            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/account/login", Method.POST, DataFormat.Json)
                .AddJsonBody(new {login, password});

            var response = await Client.ExecuteAsync(request);
            return response;
        }
    }
}
