using SecureDevelopment.Data;

namespace SecureDevelopment.Services
{

    public interface ICardRepository : IRepository<Card, string> 
    {
        IList<Card> GetByClientId(string id);
    }
}
