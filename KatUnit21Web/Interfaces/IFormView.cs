using KatUnit21Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatUnit21Web
{
    public interface IFormView
    {
        Task DisplayDonations(IEnumerable<MemberDonation> donations);
    }
}
