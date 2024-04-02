
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HomeDeviceMonitor.Application.Interfaces;
using HomeDeviceMonitor.Infrastructure.FileStore;
using HomeDeviceMonitor.Infrastructure.Services;
using HomeDeviceMonitor.Infrastructure.ExternalAPI.PVmonitor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;


namespace HomeDeviceMonitor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("PVmonitorClient", options =>
            {
                options.BaseAddress = new Uri("http://a01p05.ddns.net:14180/public");
                options.Timeout = new TimeSpan(0, 0, 10);
                options.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler());
            services.AddScoped<IPVmonitorClient, PVmonitorClient>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IFileWrapper, FileWrapper>();
            services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
            services.AddTransient<IFileStore, FileStore.FileStore>();
            return services;
        }
    }
}
