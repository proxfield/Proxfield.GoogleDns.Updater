using Flurl.Http;
using Microsoft.Extensions.Logging;
using Proxfield.Google.Ddns.Updater.Domain;
using Proxfield.GoogleDdns.Updater.Domain.Extensions;
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

        public async Task UpdateDdnsRegistry()
        {
            try
            {
                var result =
                     await _ddnsSettings.HostName
                     .ToGoogleNicUrl()
                     .WithBasicAuth(_ddnsSettings.User, _ddnsSettings.Password)
                     .GetStringAsync();

                if (result.IsGoodResponse() || result.IsNoChangeResponse())
                    _logger.LogInformation("DDNS records updated sucessfully to {}", result.GetChangedIpAddress());

                _logger.LogInformation("Next update is going to be made in {} seconds", _ddnsSettings.UpdateInterval);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Could not update Google DDNS record {}", ex.Message);
            }
        }
    }
}