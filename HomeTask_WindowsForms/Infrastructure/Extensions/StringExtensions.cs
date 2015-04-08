using System;

namespace EnglishAssistant.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsIgnoreWhitespaces(this string source, string toCheck, StringComparison comp)
        {
            source = source.Replace(" ", string.Empty);

            return source.Contains(toCheck, comp);
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (source == null) return false;
            return source.IndexOf(toCheck, comp) >= 0;
        }

        public static bool IsSame(this string source, string toCheck)
        {
            var sourceWithoutWhitespaces = source.Replace(" ", "").ToLower();
            var toCheckWithoutWhitespaces = toCheck.Replace(" ", "").ToLower();

            return string.Equals(sourceWithoutWhitespaces, toCheckWithoutWhitespaces);
        }
    }
}
