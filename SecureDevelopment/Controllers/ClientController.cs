using MebelShop.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecureDevelopment.Data;
using SecureDevelopment.Models.Requests;
using SecureDevelopment.Models.Response;
using SecureDevelopment.Services;

namespace SecureDevelopment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<ClientController> _logger;
        private readonly IClientRepository _clientRepository;

        public ClientController(ILogger<ClientController> logger,
            IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }
        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateClientRequest request)
        {
            try
            {
                var clientId = _clientRepository.Create(new Client
                {
                    FirstName = request.FirstName,
                    SurName = request.SurName,
                    Patronymic = request.Patronymic
                });
                return Ok(new CreateClientResponse
                {
                    ClientId = clientId
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create client error");
                return Ok(new CreateClientResponse
                {
                    ErrorCode = 912,
                    ErrorMessage = "Create client error"
                });
            }
        }
    }
}
