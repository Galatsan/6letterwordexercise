using System.Collections.Generic;
using System.Linq;

namespace _6letterwordexercise.Extensions
{
    public static class Extensions
    {
        public static string ConcateStrings(this IEnumerable<string> x, string separator = null)
        {
            if (string.IsNullOrEmpty(separator))
                return x.Aggregate((i, j) => i + j);
            return x.Aggregate((i, j) => $"{i}{separator}{j}");
        }
    }
}
