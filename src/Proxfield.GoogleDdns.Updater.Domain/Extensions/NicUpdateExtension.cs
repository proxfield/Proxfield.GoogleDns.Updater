namespace Proxfield.GoogleDdns.Updater.Domain.Extensions
{
    public static class NicUpdateExtension
    {
        public static string ToGoogleNicUrl(this string? hostName)
           => $"https://domains.google.com/nic/update?hostname={hostName}";
    }
}
