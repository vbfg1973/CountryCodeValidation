using CountryCodeApi.Domain.Features.Helpers;
using FluentAssertions;

namespace CountryCodeApi.Tests
{
    public class CountryCodeHelperTests
    {
        [Theory]
        [InlineData("GB")]
        [InlineData("gb")]
        public void Given_Valid_Alpha2_Country_Code_Returns_True(string countryCode)
        {
            countryCode
                .IsAlpha2CountryCodeValid()
                .Should()
                .BeTrue();
        }

        [Theory]
        [InlineData("GBR")]
        [InlineData("FRA")]
        [InlineData("USA")]
        public void Given_Invalid_Alpha2_Country_Code_Returns_False(string countryCode)
        {
            countryCode
                .IsAlpha2CountryCodeValid()
                .Should()
                .BeFalse();
        }
    }
}