using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenderApp.Aggregates
{
    public interface IGenderAggregate
    {
        Task<IEnumerable<GenderResult>> RetrieveGenderForContacts();
    }
}
