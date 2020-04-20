using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6letterwordexercise.Interfaces
{
    public interface IWriteFileService
    {
        Task Write(string fileName, IEnumerable<string> lines);
    }
}
