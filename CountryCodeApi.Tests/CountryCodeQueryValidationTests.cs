using CountryCodeApi.Domain.Features.QueryCountryCodes;
using FluentAssertions;
using FluentValidation;

namespace CountryCodeApi.Tests
{
    public class CountryCodeQueryValidationTests
    {
        private readonly IValidator<CountryCodeQuery> _validator;

        public CountryCodeQueryValidationTests()
        {
            _validator = new CountryCodeQueryValidator();
        }

        [Fact]
        public void Given_Null_Country_Code_Validation_Succeeds()
        {
            // Arrange
            var queryObject = new CountryCodeQuery();

            // Act
            var validationResult = _validator.Validate(queryObject);

            // Assert
            validationResult
                .IsValid
                .Should()
                .BeTrue();
        }

        [Theory]
        [InlineData("FR")] // France
        [InlineData("DE")] // German
        [InlineData("GB")] // Great Britain (not UK!)
        [InlineData("US")] // US of A
        public void Given_Valid_ISO3661_Alpha2_Country_Code_Validation_Succeeds(string countryCode)
        {
            // Arrange
            var queryObject = new CountryCodeQuery { CountryCode = countryCode };

            // Act
            var validationResult = _validator.Validate(queryObject);

            // Assert
            validationResult
                .IsValid
                .Should()
                .BeTrue();
        }

        [Theory]
        [InlineData("AA")]
        [InlineData("DD")]
        [InlineData("YY")]
        [InlineData("UK")]
        public void Given_Invalid_ISO3661_Alpha2_Country_Code_Validation_Fails(string countryCode)
        {
            // Arrange
            var queryObject = new CountryCodeQuery { CountryCode = countryCode };

            // Act
            var validationResult = _validator.Validate(queryObject);

            // Assert

            // Overall validation fails
            validationResult
                .IsValid
                .Should()
                .BeFalse();

            // Errors contains correct error message for failure type
            validationResult
                .Errors
                .Select(err => err.ErrorMessage)
                .Should()
                .Contain("Not a valid country code"); // This message is defined in the validator explicitly
        }

        [Theory]
        [InlineData("FRA")] // France
        [InlineData("DEU")] // Germany
        [InlineData("GBR")] // Great Britain
        [InlineData("USA")] // US of A
        public void Given_Valid_ISO3661_Alpha3_Country_Code_Validation_Fails_As_Not_A_Valid_Country_Code(
            string countryCode)
        {
            // Arrange
            var queryObject = new CountryCodeQuery { CountryCode = countryCode };

            // Act
            var validationResult = _validator.Validate(queryObject);

            // Assert

            // Overall validation fails
            validationResult
                .IsValid
                .Should()
                .BeFalse();

            // Errors contains correct error message for failure type
            validationResult
                .Errors
                .Select(err => err.ErrorMessage)
                .Should()
                .Contain("Not a valid country code"); // This message is defined in the validator explicitly
        }

        [Theory]
        [InlineData("FRA")] // France
        [InlineData("DEU")] // Germany
        [InlineData("GBR")] // Great Britain
        [InlineData("USA")] // US of A
        public void Given_Valid_ISO3661_Alpha3_Country_Code_Validation_Fails_As_Incorrect_Length(string countryCode)
        {
            // Arrange
            var queryObject = new CountryCodeQuery { CountryCode = countryCode };

            // Act
            var validationResult = _validator.Validate(queryObject);

            // Assert

            // Overall validation fails
            validationResult
                .IsValid
                .Should()
                .BeFalse();

            // Errors contains correct error message for failure type
            validationResult
                .Errors
                .Select(err => err.ErrorMessage)
                .Should()
                .Contain("Country code must be two characters long"); // This message is defined in the validator explicitly
        }
    }
}