using Microsoft.EntityFrameworkCore;
using SecureDevelopment.Data;
using SecureDevelopment.Models.Requests;
using SecureDevelopment.Services;

namespace MebelShop.Services.Impl
{

    public class ClientRepository : IClientRepository
    {
        private readonly SecureDevelopmentDbContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(SecureDevelopmentDbContext dbContext, ILogger<ClientRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public int Create(Client data)
        {
            _dbContext.Client.Add(data);
            _dbContext.SaveChanges();
            return data.ClientId;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Client> GetAll()
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Client data)
        {
            throw new NotImplementedException();
        }
    }
}
