using System.Collections.Generic;

namespace _6letterwordexercise.Interfaces
{
    public interface IVariantsBuilderService
    {
        IEnumerable<IEnumerable<string>> GetVariants(IEnumerable<string> source, int lengthOfVariant);
    }
}
