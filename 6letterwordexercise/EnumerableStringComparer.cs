using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using _6letterwordexercise.Extensions;

namespace _6letterwordexercise
{
    public class EnumerableStringComparer : IEqualityComparer<IEnumerable<string>>
    {
        public bool Equals([AllowNull] IEnumerable<string> x, [AllowNull] IEnumerable<string> y)
        {
            return x.ConcateStrings().GetHashCode() == y.ConcateStrings().GetHashCode();
        }

        public int GetHashCode([DisallowNull] IEnumerable<string> obj)
        {
            return obj.ConcateStrings().GetHashCode();
        }
    }
}
