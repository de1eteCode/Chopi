using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chopi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile(path: "Configs/appsettings.json",
                                       optional: true,
                                       reloadOnChange: true);
                    config.AddJsonFile(path: "Configs/appsettings.Development.json",
                                       optional: true,
                                       reloadOnChange: true);
                    config.AddJsonFile(path: "Configs/config.json",
                                       optional: true,
                                       reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(configKestrel =>
                    {
                        configKestrel.ConfigureHttpsDefaults(opt =>
                            opt.ClientCertificateMode = Microsoft.AspNetCore.Server.Kestrel.Https.ClientCertificateMode.NoCertificate
                        );
                        //configKestrel.Listen(new System.Net.IPAddress(new byte[] { 0, 0, 0, 0 }), port: 3000);
                    });
                });
    }
}
