using System;
using System.Collections.Generic;

namespace EnglishAssistant.Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static List<T> Shuffle<T>(this List<T> original)
        {
            var random = new Random();
            int itemsCount = original.Count;

            for (int i = 0; i < itemsCount; i++)
            {
                int randomIndex = random.Next(itemsCount);
                var firstItem = original[i];
                var secondItem = original[randomIndex];

                original[i] = secondItem;
                original[randomIndex] = firstItem;
            }

            return original;
        }
    }
}
