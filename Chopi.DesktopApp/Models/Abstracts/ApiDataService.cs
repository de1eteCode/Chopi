using Chopi.DesktopApp.Models.Interfaces;
using Chopi.Modules.Share.Abstracts;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.Abstracts
{
    abstract class ApiDataService<TObj, TRequest> : ApiService, IApiDataService<TObj, TRequest>
        where TObj : class
        where TRequest : IDataRequest<TObj>
    {
        private string _apiPath;

        protected ApiDataService(IDataRequest<TObj> @params, string apiPath) : base(@params)
        {
            _apiPath = apiPath;
        }

        public void SetPredicate(Func<TObj, bool> predicate)
        {
            var @params = ParseParams<IDataRequest<TObj>>();
            @params.Predicate = predicate;
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var @params = ParseParams<TRequest>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/{_apiPath}", Method.POST, DataFormat.Json)
                .AddJsonBody(@params);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
