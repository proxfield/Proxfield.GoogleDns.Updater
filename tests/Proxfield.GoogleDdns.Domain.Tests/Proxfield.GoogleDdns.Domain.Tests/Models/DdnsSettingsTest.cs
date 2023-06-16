using Proxfield.GoogleDdns.Updater.Domain.Models;
using Xunit;

namespace Proxfield.GoogleDdns.Domain.Tests.Models
{
    public class DdnsSettingsTest
    {
        [Fact]
        public void DnsSettings_ShouldBeEqualGivenValues()
        {
            //Arrange
            const int maxParallelExecutions = 10;
            const int updateInterval = 1000;

            //Act
            var settings  = new DdnsSettings()
            {
               MaxParallelExecutions= maxParallelExecutions,
               UpdateInterval= updateInterval,
            };

            //Assert
            Assert.Equal(updateInterval, settings.UpdateInterval);
            Assert.Equal(maxParallelExecutions, settings.MaxParallelExecutions);
        }
    }
}
