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
    public class CardController : ControllerBase
    {
        private readonly ILogger<CardController> _logger;
        private readonly ICardRepository _cardRepository;

        public CardController(ILogger<CardController> logger, 
            ICardRepository cardRepository)
        {
            _cardRepository= cardRepository;
            _logger = logger;
        }

        [HttpGet("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateCardRequest request) 
        {
            try
            {
                var cardId = _cardRepository.Create(new Card
                {
                    ClientId = request.ClientId,
                    CardNo = request.CardNo,
                    ExpDate = request.ExpDate,
                    CVV2 = request.CVV2
                });
                return Ok(new CreateCardResponse
                {
                    CardId = cardId.ToString()
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Create card error");
                return Ok(new CreateCardResponse
                {
                    ErrorCode = 1012,
                    ErrorMessage = "Create card error"
                });
            }
        }


    }
}
