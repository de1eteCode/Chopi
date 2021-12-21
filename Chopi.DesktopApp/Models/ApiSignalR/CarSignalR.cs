using Chopi.DesktopApp.Models.ApiSinalR.Abstracts;
using Chopi.Modules.Share.DataModels;
using Chopi.Modules.Share.HubInterfaces;
using TypedSignalR.Client;

namespace Chopi.DesktopApp.Models.ApiSignalR
{
    internal class CarSignalR : ApiSignalConroller<CarData, ICarHubActions>
    {
        public CarSignalR(ICarHubActions responser, string urlHub, string urlSub) : base(responser, urlHub, urlSub)
        {
        }

        protected override void RegisterHub()
        {
            _hub.Register(_responser);
        }
    }
}
