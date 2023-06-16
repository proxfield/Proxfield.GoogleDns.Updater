using FluentValidation;
using FluentValidation.Results;
using Proxfield.GoogleDdns.Updater.Domain.Models;
using Proxfield.GoogleDdns.Updater.Service.Interfaces;
using System.Text.Json;

namespace Proxfield.Google.Ddns.Updater
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IDdnsUpdateService _updateService;
        private readonly DdnsSettings _dnsSettings;
        private readonly IValidator<DdnsSettings> _validator;

        public Worker(ILogger<Worker> logger,
            IDdnsUpdateService updateService,
            DdnsSettings ddnsSettings,
            IValidator<DdnsSettings> validator)
        {
            _logger = logger;
            _updateService = updateService;
            _dnsSettings = ddnsSettings;
            _validator = validator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            ValidationResult result = await _validator.ValidateAsync(_dnsSettings);

            if (!result.IsValid)
            {
                var errors = JsonSerializer.Serialize(result.Errors);
                _logger.LogError("Invalid DDNS settings provided {}", errors);
                return;
            }

            _logger.LogInformation("MaxParallelExecutions set to {}", _dnsSettings.MaxParallelExecutions);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Google Dns Updater running at: {time}", DateTimeOffset.Now);

                await _updateService.UpdateDdnsRegistry(stoppingToken);

                var milliseconds = TimeSpan.FromSeconds(_dnsSettings.UpdateInterval).TotalMilliseconds;
                await Task.Delay((int)milliseconds, stoppingToken);
            }
        }
    }
}