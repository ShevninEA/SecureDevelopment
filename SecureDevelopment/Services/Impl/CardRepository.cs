using Microsoft.EntityFrameworkCore;
using SecureDevelopment.Data;
using SecureDevelopment.Models.Requests;
using SecureDevelopment.Services;

namespace MebelShop.Services.Impl
{

    public class CardRepository : ICardRepository
    {
        private readonly SecureDevelopmentDbContext _dbContext;
        private readonly ILogger<CardRepository> _logger;

        public CardRepository(SecureDevelopmentDbContext dbContext, ILogger<CardRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public string Create(Card data)
        {
            var client = _dbContext.Client.FirstOrDefault(client => client.ClientId == data.ClientId);
            if (client == null)
                throw new Exception("Client not found");

            _dbContext.Cards.Add(data);
            _dbContext.SaveChanges();
            return data.CardId.ToString();

        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IList<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Card> GetByClientId(string id)
        {
            throw new NotImplementedException();
        }

        public Card GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int Update(Card data)
        {
            throw new NotImplementedException();
        }

        int IRepository<Card, string>.Create(Card data)
        {
            throw new NotImplementedException();
        }
    }
}
