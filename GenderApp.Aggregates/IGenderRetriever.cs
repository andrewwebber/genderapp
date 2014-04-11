using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenderApp.Aggregates
{
    public interface IGenderRetriever
    {
        Task<IReadOnlyCollection<GenderResult>> GetContactsAsync(IEnumerable<GenderRequest> sequenceOfNames);
    }
}
