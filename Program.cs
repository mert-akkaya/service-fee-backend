using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace service_fee_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOption=>{
                        serverOption.ConfigureHttpsDefaults(configureOptions=>{
                            configureOptions.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                        });
                    });
                    webBuilder.UseStartup<Startup>();
                });
    }
}
