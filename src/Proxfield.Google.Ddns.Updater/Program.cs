using Proxfield.Google.Ddns.Updater;
using Proxfield.GoogleDdns.Updater.Configuration;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.AddServices(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
