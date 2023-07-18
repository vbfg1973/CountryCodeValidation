using CountryCodeApi.Domain.Features.Helpers;
using CountryCodeApi.Domain.Features.QueryCountryCodes;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CountryCodeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryCodeController : ControllerBase
    {
        private readonly ILogger<CountryCodeController> _logger;

        public CountryCodeController(ILogger<CountryCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = nameof(GetCountryCodeValidationResult))]
        public async Task<IActionResult> GetCountryCodeValidationResult([FromQuery] CountryCodeQuery countryCodeQuery)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok("Valid");
        }
    }
}