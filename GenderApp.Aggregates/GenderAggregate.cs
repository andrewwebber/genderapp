namespace GenderApp.Aggregates
{
    using Microsoft.Phone.UserData;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.Phone.PersonalInformation;

    public class GenderAggregate : IGenderAggregate
    {
        private IGenderRetriever genderRetriever;
        private IGenderContactsRetriever genderContactsRetriever;

        public GenderAggregate(IGenderRetriever genderRetriever, IGenderContactsRetriever genderContactsRetriever)
        {
            this.genderRetriever = genderRetriever;
            this.genderContactsRetriever = genderContactsRetriever;
        }

        public async Task<IEnumerable<GenderResult>> RetrieveGenderForContacts()
        {
            var users = await this.genderContactsRetriever.GetContacts();
            var codedFirstNames = await this.genderRetriever.GetContactsAsync(users);

            return codedFirstNames;
        }
    }
}
