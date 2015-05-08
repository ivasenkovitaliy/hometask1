using System;
using EnglishAssistant.Entities;

namespace EnglishAssistant.Infrastructure.Extensions
{
    public static class WordExtensions
    {
        public static bool IsOriginalOrTranslation(this Word source, string searchingValue)
        {
           return source.Original.ContainsIgnoreWhitespaces(searchingValue, StringComparison.InvariantCultureIgnoreCase) ||
                 source.Translate.ContainsIgnoreWhitespaces(searchingValue, StringComparison.InvariantCultureIgnoreCase) ||
                 source.TranslateSecond.ContainsIgnoreWhitespaces(searchingValue, StringComparison.InvariantCultureIgnoreCase) ||
                 source.TranslateThird.ContainsIgnoreWhitespaces(searchingValue, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
