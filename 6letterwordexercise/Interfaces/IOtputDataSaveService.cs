using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6letterwordexercise.Interfaces
{
    public interface IOtputDataSaveService
    {
        Task Save(IEnumerable<string> lines);
    }
}
