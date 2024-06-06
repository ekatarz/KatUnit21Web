using KatUnit21Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatUnit21Web.Interfaces
{
    public interface IMpService
    {
        Task<IEnumerable<MP>> GetMpsAsync();
    }
}
