using Chopi.DesktopApp.Network.ApiServices.Abstracts;
using Chopi.Modules.Share;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Network.ApiServices.Service
{
    class AuthService : ApiService
    {
        public AuthService(object @params) : base(@params)
        {
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var lModel = ParseParams<LoginModel>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/account/auth/login", Method.POST, DataFormat.Json)
                .AddJsonBody(lModel);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
