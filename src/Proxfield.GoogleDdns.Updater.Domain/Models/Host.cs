namespace Proxfield.GoogleDdns.Updater.Domain.Models
{
    /// <summary>
    /// Host configuration
    /// </summary>
    public class Host
    {
        /// <summary>
        /// Endpoint of the host (e.g.: local.proxfield.com)
        /// </summary>
        public string? Endpoint { get; set; }
        /// <summary>
        /// Google DDNS User
        /// </summary>
        public string? User { get; set; }
        /// <summary>
        /// Google DDNS Password
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Defines an IP to be override, or leave it empty to 
        /// use the current IP address from the network
        /// </summary>
        public string? OverrideIp { get; set; }
    }
}
