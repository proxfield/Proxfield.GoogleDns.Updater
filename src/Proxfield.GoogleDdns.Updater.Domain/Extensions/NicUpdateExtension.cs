namespace Proxfield.GoogleDdns.Updater.Domain.Extensions
{
    public static class NicUpdateExtension
    {
        public static string ToGoogleNicUrl(this string? hostName, string? overrideIp = null)
        {
            var url = $"https://domains.google.com/nic/update?hostname={hostName}";

            if (!string.IsNullOrEmpty(overrideIp))
                url += $"&myip={overrideIp}";

            return url;
        }
    }
}
