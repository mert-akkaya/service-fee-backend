using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using DataAccess;
using DataAccess.EntityFramework;
using DbOperation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace service_fee_backend
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
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "service_fee_backend", Version = "v1" });
            });
            services.AddSingleton<IFeeCustomerService, FeeCustomerService>();
            services.AddSingleton<IFeeCustomerDal, EfFeeCustomerDal>();
            services.AddSingleton<IWritedCustomerService, WritedCustomerService>();
            services.AddSingleton<IWritedCustomerDal, EfWritedCustomerDal>();
            services.AddHttpsRedirection(options => { options.HttpsPort = 443; })
               .AddMvcCore()
               .AddCors(options =>
               {
                   options.AddPolicy("CorsPolicy",
                       builder => builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
               });

            services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                       ForwardedHeaders.XForwardedProto;
            options.KnownNetworks.Clear();
            options.KnownProxies.Clear();
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "service_fee_backend v1"));
            }

            app.UseForwardedHeaders();

            app.UseCors("CorsPolicy");

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
