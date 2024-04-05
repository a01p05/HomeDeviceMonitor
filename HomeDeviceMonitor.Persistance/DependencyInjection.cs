using HomeDeviceMonitor.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeDeviceMonitor.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HDMonitorDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("HDMonitorDatabase")));
            services.AddScoped<IHDMonitorDbContext, HDMonitorDbContext>();
            return services;
        }
    }
}
