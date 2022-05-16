using System.Text.RegularExpressions;

namespace OpheliaCommerce.Domain.Infrastructure.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static bool IsValidEmail(this string email)
        {
            string pattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex myRegex = new Regex(pattern);
            var match = myRegex.IsMatch(email);
            return match;
        }
    }
}
