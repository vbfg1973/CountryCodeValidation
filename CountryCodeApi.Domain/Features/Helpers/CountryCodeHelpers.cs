using System.Globalization;

namespace CountryCodeApi.Domain.Features.Helpers
{
    public static class CountryCodeHelpers
    {
        /// <summary>
        ///     Returns true if valid ISO 3166 two-letter country code
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public static bool IsAlpha2CountryCodeValid(this string? countryCode)
        {
            if (string.IsNullOrEmpty(countryCode) || countryCode.Length != 2)
            {
                return false;
            }

            return AllRegions()
                .Any(region => region.TwoLetterISORegionName == countryCode.ToUpperInvariant());
        }

        /// <summary>
        ///     Returns true if valid ISO 3166 two-letter country code
        /// </summary>
        /// <param name="countryCode"></param>
        /// <returns></returns>
        public static bool IsAlpha3CountryCodeValid(this string? countryCode)
        {
            if (string.IsNullOrEmpty(countryCode) || countryCode.Length != 3)
            {
                return false;
            }

            return AllRegions()
                .Any(region => region.ThreeLetterISORegionName == countryCode.ToUpperInvariant());
        }

        /// <summary>
        ///     Returns all supported regions
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<RegionInfo> AllRegions()
        {
            return CultureInfo
                .GetCultures(CultureTypes.SpecificCultures)
                .Select(culture => new RegionInfo(culture.Name));
        }
    }
}