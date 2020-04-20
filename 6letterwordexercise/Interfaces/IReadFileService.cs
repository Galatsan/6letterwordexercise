using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6letterwordexercise.Interfaces
{
    public interface IReadFileService
    {
        Task<IEnumerable<string>> Read(string fileName); 
    }
}
