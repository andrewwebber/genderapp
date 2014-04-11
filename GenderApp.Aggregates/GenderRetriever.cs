using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GenderApp.Aggregates
{
    public class GenderRetriever : IGenderRetriever
    {
        IGenderFormatter genderFormatter;

        public GenderRetriever(IGenderFormatter genderFormatter)
        {
            this.genderFormatter = genderFormatter;
        }

        public async Task<IReadOnlyCollection<GenderResult>> GetContactsAsync(IEnumerable<GenderRequest> sequenceOfNames)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://api.onomatic.com/onomastics/api/gendre/");

            var resultsCollection = new Collection<GenderResult>();
            foreach (var request in sequenceOfNames)
            {
                var query = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/us", request.FirstName, request.LastName);
                var responseMessage = await client.GetAsync(query);
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                var gender = this.genderFormatter.Deserialize(responseContent);
                resultsCollection.Add(new GenderResult() { FirstName = request.FirstName, LastName = request.LastName, Gender = gender });
            }

            return resultsCollection;
        }
    }
}
