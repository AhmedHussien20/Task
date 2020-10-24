using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var environment = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == EnvironmentName.Development;

            IWebHostBuilder obj;
            if (!isDevelopment)
            {
                var config = new ConfigurationBuilder()
                                                       .SetBasePath(Directory.GetCurrentDirectory())
                                                       .AddJsonFile("hosting.json", optional: true)
                                                       .Build();
                obj = WebHost.CreateDefaultBuilder(args)
                                                    .UseKestrel()
                                                    .UseConfiguration(config)
                                                    .UseContentRoot(Directory.GetCurrentDirectory())
                                                    .UseIISIntegration()
                                                    .UseStartup<Startup>();
            }
            else
            {
                obj = WebHost.CreateDefaultBuilder(args)
                                                    .UseStartup<Startup>();
            }

            return obj;
        }
    }
}
