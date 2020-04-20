using System.Collections.Generic;
using System.Threading.Tasks;

namespace _6letterwordexercise.Interfaces
{
    public interface IInputDataReadService
    {
        Task<IEnumerable<string>> Read(); 
    }
}
