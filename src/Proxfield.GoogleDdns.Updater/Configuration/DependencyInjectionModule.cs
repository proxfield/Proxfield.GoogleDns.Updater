using Proxfield.Google.Ddns.Updater.Domain;
using Proxfield.GoogleDdns.Updater.Service.Implementation;
using Proxfield.GoogleDdns.Updater.Service.Interfaces;

namespace Proxfield.GoogleDdns.Updater.Configuration
{
    public static class DependencyInjectionModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var ddnsSettings = configuration.GetSection(nameof(DdnsSettings)).Get<DdnsSettings>();
            services.AddSingleton(ddnsSettings);

            services.AddSingleton<IDdnsUpdateService, DdnsUpdateService>();

            return services;
        }
    }
}
