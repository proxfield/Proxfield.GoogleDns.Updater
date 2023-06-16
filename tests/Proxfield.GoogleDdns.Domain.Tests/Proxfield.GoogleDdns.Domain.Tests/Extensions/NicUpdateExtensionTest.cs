using Proxfield.GoogleDdns.Updater.Domain.Extensions;
using Xunit;
using static System.Net.WebRequestMethods;

namespace Proxfield.GoogleDdns.Domain.Tests.Extensions
{
    public class NicUpdateExtensionTest
    {
        public readonly string GoogleNicUpdateUrl;

        public NicUpdateExtensionTest()
        { 
            GoogleNicUpdateUrl = "https://domains.google.com/nic/update?hostname=";
        }

        [Fact]
        public void ToGoogleNicUrl_WhenHostNameIsNull()
        {
            //Arrange
            const string? endpointUrl = null;
            //Act
            var result = endpointUrl.ToGoogleNicUrl();
            //Assert
            Assert.Equal(result, GoogleNicUpdateUrl);
        }

        [Fact]
        public void ToGoogleNicUrl_WhenHostNameIsNotNull()
        {
            //Arrange
            const string endpointUrl = "abc.proxfield.com";
            //Act
            var result = endpointUrl.ToGoogleNicUrl();
            //Assert
            Assert.Equal(result, string.Join(string.Empty, GoogleNicUpdateUrl, endpointUrl));
        }

        [Fact]
        public void ToGoogleNicUrl_WhenOverrideIpIsNotNull()
        {
            //Arrange
            const string endpointUrl = "abc.proxfield.com";
            const string myIp = "127.0.0.1";
            //Act
            var result = endpointUrl.ToGoogleNicUrl(myIp);
            //Assert
            Assert.Equal(result, string.Join(string.Empty, GoogleNicUpdateUrl, endpointUrl, "&myip=", myIp));
        }
    }
}
