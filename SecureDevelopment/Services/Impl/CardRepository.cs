using Microsoft.EntityFrameworkCore;
using SecureDevelopment.Data;
using SecureDevelopment.M.Requests;
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

        public int Create(CreateCardRequest data)
        {
            _dbContext.Card.Add(data);
            _dbContext.SaveChanges();
            return data.CardId;
        }

        public int Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public Card GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public int Update(Card data)
        {
            throw new NotImplementedException();
        }
    }
}
