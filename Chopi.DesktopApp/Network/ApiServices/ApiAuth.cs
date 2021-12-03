using RestSharp;
using RestSharp.Authenticators;

namespace Chopi.DesktopApp.Network.ApiServices
{
    class ApiAuth : IAuthenticator
    {
#pragma warning disable CS0618 // Тип или член устарел
        private readonly HttpCookie _authCookie;

        protected ApiAuth(HttpCookie authCookie)
        {
            _authCookie = authCookie;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddCookie(_authCookie.Name, _authCookie.Value);
        }

        public static void AddAuthenticator(IRestClient client, HttpCookie authCookie)
        {
            client.Authenticator = new ApiAuth(authCookie);
        }

        public static void AddAuthenticator(IRestClient client, RestResponseCookie authCookie)
        {
            client.Authenticator = new ApiAuth(authCookie.HttpCookie);
        }

#pragma warning restore CS0618 // Тип или член устарел
    }
}
