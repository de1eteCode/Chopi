using Chopi.DesktopApp.Network.ApiServices.Abstracts;
using Chopi.Modules.Share;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Network.ApiServices
{
    class AuthService : ApiService
    {
        public AuthService(IRestClient client) : base(client)
        {
        }

        public async Task<bool> Authorizate(string username, string password)
        {
            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/account/auth/login", Method.POST, DataFormat.Json)
                .AddJsonBody(new LoginModel() { Username = username, Password = password});

            var response = await Client.ExecuteAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var cookies = response.Cookies;
                ApiAuth.AddAuthenticator(Client, cookies.First());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
