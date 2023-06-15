using Proxfield.Google.Ddns.Updater.Domain;
using Proxfield.GoogleDdns.Updater.Service.Interfaces;

namespace Proxfield.Google.Ddns.Updater
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDdnsUpdateService _updateService;
        private readonly DdnsSettings _dnsSettings;

        public Worker(ILogger<Worker> logger, 
            IDdnsUpdateService updateService,
            DdnsSettings ddnsSettings)
        {
            _logger = logger;
            _updateService = updateService;
            _dnsSettings = ddnsSettings;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Google Dns Updater running at: {time}", DateTimeOffset.Now);

                 await _updateService.UpdateDdnsRegistry();

                var milliseconds = TimeSpan.FromSeconds(_dnsSettings.UpdateInterval).TotalMilliseconds;
                await Task.Delay((int)milliseconds, stoppingToken);
            }
        }
    }
}