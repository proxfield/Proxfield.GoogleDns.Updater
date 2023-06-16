using Flurl.Http;
using Microsoft.Extensions.Logging;
using Proxfield.GoogleDdns.Updater.Domain.Extensions;
using Proxfield.GoogleDdns.Updater.Domain.Models;
using Proxfield.GoogleDdns.Updater.Service.Interfaces;

namespace Proxfield.GoogleDdns.Updater.Service.Implementation
{
    public class DdnsUpdateService : IDdnsUpdateService
    {
        private readonly ILogger<IDdnsUpdateService> _logger;
        private readonly DdnsSettings _ddnsSettings;

        public DdnsUpdateService(ILogger<IDdnsUpdateService> logger,
            DdnsSettings ddnsSettings)
        {
            _logger= logger;
            _ddnsSettings= ddnsSettings;
        }

        public async Task UpdateDdnsRegistry(CancellationToken cancellationToken)
        { 
            try
            {
                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = _ddnsSettings.MaxParallelExecutions
                };

                await Parallel.ForEachAsync(_ddnsSettings.Hosts, options, async (host, _) => {
                    var result =
                     await host.Endpoint
                     .ToGoogleNicUrl(host.OverrideIp)
                     .WithBasicAuth(host.User, host.Password)
                     .GetStringAsync();

                    if (result.IsGoodResponse() || result.IsNoChangeResponse())
                        _logger.LogInformation("DDNS records updated sucessfully to {}", result.GetChangedIpAddress());
                });               

                _logger.LogInformation("Next update is going to be made in {} seconds", _ddnsSettings.UpdateInterval);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not update Google DDNS record {}", ex.Message);
            }
        }
    }
}