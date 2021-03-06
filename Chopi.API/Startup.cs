using Chopi.Modules.EFCore;
using Chopi.Modules.EFCore.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Chopi.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // EF Core
            Loader.LoadModule(services, Configuration);

            // Identity
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();

            DependencyInjection.Inject(ref services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // SignalR hubs
                endpoints.MapHub<Hubs.UserHub>("userhub");
                endpoints.MapHub<Hubs.CarHub>("carhub");
                endpoints.MapHub<Hubs.ProviderHub>("providerhub");
                endpoints.MapHub<Hubs.AutopartHub>("autoparthub");
            });
        }
    }
}
