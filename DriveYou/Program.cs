using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace DriveYou
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            CreateHostBuilder(args).Build().Run();
            
        }
         public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseIIS().UseIISIntegration();
                });

     /*   public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel(o =>
            {
                o.ConfigureHttpsDefaults(o => o.ClientCertificateMode = ClientCertificateMode.RequireCertificate);
            });
        });
        }*/

        #region Old Code
        /* public static IHostBuilder CreateHostBuilder(string[] args)
         {
             var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
             store.Open(OpenFlags.ReadOnly);
             var certificate = store.Certificates.OfType<X509Certificate2>()
                 .First(c => c.FriendlyName == "ASP.NET Core HTTPS development certificate");

             return Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseKestrel(options =>
                     {
                         options.Listen(System.Net.IPAddress.Parse("192.168.100.142"), 5001, listenOptions =>
                         {
                             var connectionOptions = new HttpsConnectionAdapterOptions();
                             connectionOptions.ServerCertificate = certificate;

                             listenOptions.UseHttps(connectionOptions);
                         });
                     }).UseIIS().UseStartup<Startup>();
                 });

         }*/
        #endregion

    }
}
