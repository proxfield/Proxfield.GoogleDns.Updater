using Proxfield.GoogleDdns.Updater.Domain.Models;
using Xunit;

namespace Proxfield.GoogleDdns.Domain.Tests.Models
{
    public class HostTest
    {
        [Fact]
        public void Host_ShouldBeEqualGivenValues()
        {
            //Arrange
            const string endpoint = "127.0.0.1";
            const string overrideIp = "127.0.0.1";
            const string user = "user";
            const string password = "password";

            //Act
            var host = new Host()
            {
                Endpoint = endpoint,
                OverrideIp = overrideIp,
                Password = password,
                User = user
            };

            //Assert
            Assert.Equal(endpoint, host.Endpoint); 
            Assert.Equal(password, host.Password);
            Assert.Equal(user, host.User);
            Assert.Equal(overrideIp, host.OverrideIp);
        }
    }
}
