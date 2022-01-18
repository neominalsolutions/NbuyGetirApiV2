using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NbuyGetir.Core.Events;
using NbuyGetir.Core.Services;
using NbuyGetir.Infrastructure.Events.AspNetCoreDI;
using NBuyGetir.Domain.Events;
using NBuyGetir.Domain.Handlers;
using NBuyGetir.Domain.Repositories;
using NBuyGetir.Domain.Services;
using NBuyGetir.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NbuyGetir.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NbuyGetir.API", Version = "v1" });
            });

            
            services.AddTransient<IDomainEventHandler<StockedIn> ,StockInHandler>();
            services.AddSingleton<IDomainEventDispatcher, DotNetDomainEventDispatcher>();


            services.AddTransient<IProductRepository, EfCoreProductRepository>();
            services.AddTransient<StockInService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NbuyGetir.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
