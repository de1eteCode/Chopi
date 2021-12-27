using Chopi.DesktopApp.Models.ApiServices.Abstracts;
using Chopi.Modules.Share;
using Chopi.Modules.Share.DataModels;
using RestSharp;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Chopi.DesktopApp.Models.ApiServices.Services
{
    internal class CarService : ApiDatasService<CarData, DataRequestCollection<CarData>>
    {
        public CarService() : base(new DataRequestCollection<CarData>(0, 10000), "api/cars/getcars")
        {
        }

        public CarService(DataRequestCollection<CarData> @params) : base(@params, "api/cars/getcars")
        {
        }
    }

    internal class CarCompleteAddService : ApiService
    {
        public CarCompleteAddService(CarCompleteData @params) : base(@params)
        {
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var data = ParseParams<CarCompleteData>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/cars/addcompletecar", Method.POST, DataFormat.Json)
                .AddJsonBody(JsonSerializer.Serialize(data));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }

    internal class CarCompleteUpdateService : ApiService
    {
        public CarCompleteUpdateService(CarCompleteData @params) : base(@params)
        {
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var data = ParseParams<CarCompleteData>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/cars/updatecompletecar", Method.POST, DataFormat.Json)
                .AddJsonBody(JsonSerializer.Serialize(data));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }

    internal class CarCustomAddService : ApiService
    {
        public CarCustomAddService(CarCustomData @params) : base(@params)
        {
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var data = ParseParams<CarCustomData>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/cars/addcustomcar", Method.POST, DataFormat.Json)
                .AddJsonBody(JsonSerializer.Serialize(data));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }

    internal class CarCustomUpdateService : ApiService
    {
        public CarCustomUpdateService(CarCustomData @params) : base(@params)
        {
        }

        public override async Task<IRestResponse> ExecuteAsync(IRestClient client)
        {
            var data = ParseParams<CarCustomData>();

            IRestRequest request = new RestRequest($"{Cfg.HttpServerAddress}/api/cars/updatecustomcar", Method.POST, DataFormat.Json)
                .AddJsonBody(JsonSerializer.Serialize(data));

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
