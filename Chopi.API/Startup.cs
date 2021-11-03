using Chopi.Modules.EFCore.Entities.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            services.AddDbContext<Modules.EFCore.AppContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(Configuration["ConnectionStrings:Default"], opt =>
                {
                    opt.MigrationsAssembly(typeof(Modules.EFCore.AppContext).Assembly.FullName);
                });
            });

            // Identity
            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<Modules.EFCore.AppContext>()
                    .AddDefaultTokenProviders();

            DependencyInjection.Inject(ref services);

            services.AddControllers();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Car dealership Chopi API", Version = "v1" });
            });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
