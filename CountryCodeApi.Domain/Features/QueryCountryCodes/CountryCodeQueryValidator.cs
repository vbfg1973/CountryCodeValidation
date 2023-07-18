using CountryCodeApi.Domain.Features.Helpers;
using FluentValidation;

namespace CountryCodeApi.Domain.Features.QueryCountryCodes
{
    /// <summary>
    ///     Custom validation for country codes
    /// </summary>
    public class CountryCodeQueryValidator : AbstractValidator<CountryCodeQuery>
    {
        public CountryCodeQueryValidator()
        {
            // Limit rule to CountryCode property
            RuleFor(query => query.CountryCode)

                // Insist length is two characters
                .Length(2)
                .WithMessage("Country code must be two characters long") // "Length" has a default error message but this overrides it

                // Insist on validity (using helper extension method). Custom error message attached
                .Must(countryCode => countryCode.IsAlpha2CountryCodeValid())
                .WithMessage("Not a valid country code")

                // RuleSet kicks in only when CountryCode is not null or empty
                .When(query => !string.IsNullOrEmpty(query.CountryCode));
        }
    }
}