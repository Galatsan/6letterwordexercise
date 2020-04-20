using System.Collections.Generic;
using System.Linq;
using _6letterwordexercise.Interfaces;

namespace _6letterwordexercise.Services
{
    public class VariantsBuilderService : IVariantsBuilderService
    {
        public IEnumerable<IEnumerable<string>> GetVariants(IEnumerable<string> source, int lengthOfVariant)
        {
            if (source.Count() == 1)
            {
                yield return new List<string> { source.First() };
            }
            else if (lengthOfVariant == 1)
            {
                for (var n = 0; n < source.Count(); n++)
                {
                    yield return new List<string> { source.Skip(n).First() };
                }
            }
            else
            {
                for (var n = 0; n < source.Count(); n++)
                {
                    var subSourses = source.Take(n).Concat(source.Skip(n + 1).Take(source.Count() - n - 1));
                    var subVariants = GetVariants(subSourses.ToList(), lengthOfVariant - 1);
                    foreach (var subVariant in subVariants)
                    {
                        var variation = new List<string> { source.Skip(n).First() };
                        yield return variation.Concat(subVariant);
                    }
                }
            }
        }
    }
}
