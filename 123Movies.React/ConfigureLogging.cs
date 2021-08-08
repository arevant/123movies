using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;
using System.Reflection;

namespace Movies.React
{
    public static class ConfigureLogging
    {
        public static IHostBuilder ConfigureSerilogLogging(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureLogging(logging =>
            {
                logging.ClearProviders();
            }).UseSerilog();

            var loggerConfig = new LoggerConfiguration();

            var logLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetCallingAssembly().Location), "Logs", "log_.txt");

            loggerConfig = loggerConfig.WriteTo.File(logLocation, rollingInterval: RollingInterval.Day);

            Log.Logger = loggerConfig.CreateLogger();

            return hostBuilder;
        }
    }
}
