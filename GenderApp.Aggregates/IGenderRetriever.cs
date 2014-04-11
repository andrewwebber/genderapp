using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenderApp.Aggregates
{
    public interface IGenderRetriever
    {
        Task<IReadOnlyCollection<GenderResult>> GetContactsAsync(IEnumerable<GenderRequest> sequenceOfNames);
    }
}
