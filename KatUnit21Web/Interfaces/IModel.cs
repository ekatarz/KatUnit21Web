using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatUnit21Web
{
    public interface IModel
    {
        Task<IEnumerable<MemberDonation>> GetDonations();
    }
}
