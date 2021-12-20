using Chopi.DesktopApp.Models.ApiServices.Interfaces;
using Chopi.Modules.Share;
using RestSharp;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Chopi.DesktopApp.Models.ApiServices.Abstracts
{
    abstract class ApiDataService<T, TRequest> : ApiService, IApiDataService<T, TRequest>
        where T : class
        where TRequest : DataRequestCollection<T>
    {
        private string _apiPath;

        protected ApiDataService(TRequest @params, string apiPath) : base(@params)
        {
            _apiPath = apiPath;
        }

        public void SetPages(int start, int count)
        {
            var @params = ParseParams<TRequest>();
            @params.SetPage(start, count);
        }

        public void SetPredicate(Expression<Func<T, bool>> expression)
        {
            var @params = ParseParams<TRequest>();
            @params.SetExpression(expression);
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
