using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenderApp.Aggregates
{
    public interface IGenderContactsRetriever
    {
        Task<IEnumerable<GenderRequest>> GetContacts();
    }
}
