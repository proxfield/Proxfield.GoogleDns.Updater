using FluentValidation;
using Proxfield.GoogleDdns.Updater.Domain.Models;
using Proxfield.GoogleDdns.Updater.Service.Implementation;
using Proxfield.GoogleDdns.Updater.Service.Interfaces;
using Proxfield.GoogleDdns.Updater.Validators;

namespace Proxfield.GoogleDdns.Updater.Configuration
{
    public static class DependencyInjectionModule
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var ddnsSettings = configuration.GetSection(nameof(DdnsSettings)).Get<DdnsSettings>();
            services.AddSingleton(ddnsSettings);

            services.AddSingleton<IValidator<DdnsSettings>, DdnsValidator>();
            services.AddSingleton<IDdnsUpdateService, DdnsUpdateService>();

            return services;
        }
    }
}
