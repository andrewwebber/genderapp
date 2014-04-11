using GenderApp.Aggregates;
using Microsoft.Phone.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenderApp
{
    public class GenderContactsRetriever : IGenderContactsRetriever
    {
        public Task<IEnumerable<GenderRequest>> GetContacts()
        {
            TaskCompletionSource<IEnumerable<GenderRequest>> retrieveContactsTask = new TaskCompletionSource<IEnumerable<GenderRequest>>();

            var contacts = new Contacts();

            contacts.SearchCompleted += (o, contactResults) =>
            {
                var genderRequests = from user in contactResults.Results
                                     where user.CompleteName != null
                                     select new GenderRequest() { FirstName = user.CompleteName.FirstName, LastName = user.CompleteName.LastName };                
                retrieveContactsTask.SetResult(genderRequests);
            };

            contacts.SearchAsync(string.Empty, FilterKind.None, "GenderContacts");
            return retrieveContactsTask.Task;
        }
    }
}
