
using Serilog;

namespace HomeDeviceMonitor.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            try
            {
                Log.Information("HomeDeviceMonitor: application is starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception) 
            {
                Log.Fatal("HomeDeviceMonitor: application could not start up");
            }
            finally 
            {
                Log.CloseAndFlush();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}

