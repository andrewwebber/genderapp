namespace GenderApp.Aggregates
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

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
