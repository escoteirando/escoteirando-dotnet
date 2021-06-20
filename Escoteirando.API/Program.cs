using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Escoteirando.API
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
                    var wwwroot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    Console.WriteLine(wwwroot);
                    webBuilder
                        .UseStartup<Startup>()
                        .UseWebRoot(wwwroot);
                });
    }
}