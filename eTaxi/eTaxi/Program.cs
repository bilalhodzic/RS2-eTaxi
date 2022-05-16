using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace SpiderJob
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
                    webBuilder.UseKestrel();
                    webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                    webBuilder.UseUrls("http://localhost:44310", "http://192.168.0.15:44310");
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
