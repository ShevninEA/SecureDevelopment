using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SecureDevelopment.Data;
using SecureDevelopment.Models;
using SecureDevelopment.Models.Requests;
using SecureDevelopment.Services;

namespace MebelShop.Services.Impl
{

    public class CardRepository : ICardRepository
    {
        private readonly SecureDevelopmentDbContext _dbContext;
        private readonly ILogger<CardRepository> _logger;
        private readonly IOptions<DatabaseOptions> _databaseOptions;

        public CardRepository(SecureDevelopmentDbContext dbContext, ILogger<CardRepository> logger, IOptions<DatabaseOptions> databaseOptions)
        {
            _dbContext = dbContext;
            _logger = logger;
            _databaseOptions = databaseOptions;
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

        public void Delete(string id)
        {
            Card сard = GetById(id);
            if (сard != null)
            {
                _dbContext.Cards.Remove(сard);
                _dbContext.SaveChanges();
            }
            else new Exception("Error delete"); ;
        }

        public IList<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Card> GetByClientId(string id)
        {
            List<Card> cards = new List<Card>();
            using (SqlConnection sqlConnection = new SqlConnection(_databaseOptions.Value.ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand(String.Format("select * from cards where ClientId = {0}", id), sqlConnection)) 
                {
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        cards.Add(new Card
                        {
                            CardId = new Guid(reader["CardId"].ToString()),
                            CardNo = reader["CardNo"]?.ToString(),
                            Name = reader["Name"]?.ToString(),
                            CVV2 = reader["CVV2"]?.ToString(),
                            ExpDate = Convert.ToDateTime(reader["ExpDate"])
                        });
                    }
                }
            }
            return cards;
        }

        public Card GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Card data)
        {
            Card сard = GetById(data.CardId);
            if (сard != null)
            {
                _dbContext.Cards.Update(сard);
                _dbContext.SaveChanges();
            }
        }

    }
}
