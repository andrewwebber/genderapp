using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenderApp.Aggregates
{
    public interface IGenderAggregate
    {
        Task<IEnumerable<GenderResult>> RetrieveGenderForContacts();
    }
}
