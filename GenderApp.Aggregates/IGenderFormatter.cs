
namespace GenderApp.Aggregates
{
    public interface IGenderFormatter
    {
        Gender Deserialize(string gender);
    }
}
