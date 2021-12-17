using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Linq;

namespace Chopi.DesktopApp.Models.ApiServices
{
    class ApiAuth : IAuthenticator
    {
#pragma warning disable CS0618 // Тип или член устарел

        private readonly IList<HttpCookie> _authCookies;

        protected ApiAuth(IList<HttpCookie> authCookies)
        {
            _authCookies = authCookies;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            foreach (var cookie in _authCookies)
            {
                request.AddCookie(cookie.Name, cookie.Value);
            }
        }

        public static void AddAuthenticator(IRestClient client, IList<HttpCookie> authCookie)
        {
            client.Authenticator = new ApiAuth(authCookie);
        }

        public static void AddAuthenticator(IRestClient client, IList<RestResponseCookie> authCookie)
        {
            var listCookies = new List<HttpCookie>();

            foreach (var cookie in authCookie)
            {
                listCookies.Add(cookie.HttpCookie);
            }

            client.Authenticator = new ApiAuth(listCookies);
        }

#pragma warning restore CS0618 // Тип или член устарел
    }
}
