using System.Text.RegularExpressions;

namespace Correios.Pacotes.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveQuebraLinha(this string text)
        {
            return Regex.Replace(text, @"(\r\n?|\n)", " ").Trim();
        }
    }
}
