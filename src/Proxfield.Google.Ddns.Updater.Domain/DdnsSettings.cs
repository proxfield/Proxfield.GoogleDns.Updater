namespace Proxfield.Google.Ddns.Updater.Domain
{
    public class DdnsSettings
    {
        public string? HostName { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public int UpdateInterval { get; set; }
    }
}