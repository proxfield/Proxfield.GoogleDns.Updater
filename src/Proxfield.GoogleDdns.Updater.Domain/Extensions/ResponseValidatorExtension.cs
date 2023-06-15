using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Proxfield.GoogleDdns.Updater.Domain.Extensions
{
    public static class ResponseValidatorExtension
    {
        public static bool IsGoodResponse(this string response)
        {
            var regex = @"^(good.)((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}";
            return Regex.IsMatch(response, regex);
        }

        public static bool IsNoChangeResponse(this string response)
        {
            var regex = @"^(nochg.)((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4}";
            return Regex.IsMatch(response, regex);
        }

        public static string GetChangedIpAddress(this string response)
        {
            var regex = @"((good|nochg).)(((25[0-5]|(2[0-4]|1\d|[1-9]|)\d)\.?\b){4})";
            RegexOptions options = RegexOptions.IgnoreCase;
            var matches = Regex.Matches(response, regex, options);
            return matches.First().Groups[3].Value;
        }
    }
}
