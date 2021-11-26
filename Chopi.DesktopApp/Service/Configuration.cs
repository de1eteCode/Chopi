using Microsoft.Extensions.Configuration;

namespace Chopi.DesktopApp.Service
{
    class Configuration
    {
        #region Singleton
        private static readonly object _lock = new object();
        private static Configuration? _configuration;
        public static Configuration GetInstance()
        {
            if (_configuration is null)
            {
                lock (_lock)
                {
                    if(_configuration is null)
                    {
                        _configuration = new Configuration();
                    }
                }
            }
            return _configuration;
        }
        #endregion

        private readonly IConfigurationRoot _cfgRoot;

        protected Configuration()
        {
            _cfgRoot = new ConfigurationBuilder()
                .AddJsonFile(path: "config.json", optional: false, reloadOnChange: true)
                .Build();
        }

        /// <summary>
        /// Возвращает ip сервера
        /// </summary>
        public string ServerIp => _cfgRoot["ServerIp"];

        /// <summary>
        /// Возвращает порт сервера
        /// </summary>
        public string ServerPort => _cfgRoot["ServerPort"];

        /// <summary>
        /// Возвращает полный адрес сервера
        /// </summary>
        public string HttpServerAddress => $"http://{ServerIp}:{ServerPort}";
    }
}
