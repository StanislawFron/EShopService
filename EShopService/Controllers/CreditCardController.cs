using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Application.Services;
using EShop.Domain.Enums;
using EShop.Domain.Exceptions;

namespace MyApp.Namespace
{
    [Route("[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardService _creditCardService;

        public CreditCardController(CreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }
        
        [HttpGet("validate")]
        public IActionResult Get(string cardNumber)
        {
            try
            {
                _creditCardService.ValidateNumberLength(cardNumber);
                _creditCardService.ValidateNumberCharset(cardNumber);

                var cardType = _creditCardService.GetCardType(cardNumber);

                return Ok(new { status = "Valid", provider = cardType.ToString() });
            }
        
            catch (CardNumberTooShortException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (CardNumberTooLongException ex)
            {
                return StatusCode(StatusCodes.Status414RequestUriTooLong, new { error = ex.Message });
            }
            catch (CardNumberInvalidException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
             catch(CardTypeInvalidException ex){
                return StatusCode(406, new { error = ex.Message });
            }
        }
    }
}