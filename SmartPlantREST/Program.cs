using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SmartPlantREST
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://*:5566")
                .UseKestrel(options => {
                    options.Listen(IPAddress.Parse("172.20.158.154"), 5080); //HTTP port
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                
                .UseStartup<Startup>()
                .Build();
    }
}
