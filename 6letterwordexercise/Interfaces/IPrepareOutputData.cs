using System.Collections.Generic;

namespace _6letterwordexercise.Interfaces
{
    public interface IPrepareOutputData
    {
        IEnumerable<string> Prepare(IEnumerable<IEnumerable<string>> variants, IEnumerable<string> linesFromFile);
    }
}
