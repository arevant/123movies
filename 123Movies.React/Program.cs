using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Movies.React
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
            builder.ConfigureSerilogLogging();
            return builder;
        }
    }
}
