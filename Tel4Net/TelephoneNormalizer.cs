using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using Tel4Net.ExceptionNumbers;

namespace Tel4Net
{
    /// <summary>
    /// This class provides phone number Normalizations functionality
    /// </summary>
    public static class TelephoneNormalizer
    {
        private static readonly Regex DigitOnlyRegex = new Regex(@"[^\d]", RegexOptions.Compiled);

        private static readonly ExceptionalContainer ExceptionalContainer = new ExceptionalContainer();

        /// <summary>
        /// Normalize a phone number, with respect to parts which that phone number provides (e.g. it won't change an international phone number to city phone number).
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <param name="defaultI18nStart">while normalizing an international phone number, let you choose that number start with 00 or +.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static string ToPhoneNumberNormalization(string phoneNumber, TelephoneOptions options = null, string defaultI18nStart = "+")
        {
            phoneNumber = PreNormalizationHandling(phoneNumber, options);

            if (defaultI18nStart != "+" && defaultI18nStart != "00")
                throw new ArgumentOutOfRangeException(nameof(defaultI18nStart), defaultI18nStart, "parameter can only contains value of '+' or '00'");

            if (phoneNumber == null)
                return null;

            var digitOnly = DigitOnlyRegex.Replace(phoneNumber, "").Trim();
            // var digitOnly = Regex.Replace(phoneNumber, @"[^\d]", "").Trim(); // TODO: Performance Monitor

            #region Exceptional Normalizer
            if (IsExceptionalPhoneNumber(out var exception, phoneNumber))
            {
                if (exception.CustomNormalizer != null)
                    return exception.CustomNormalizer(phoneNumber);

                #region International Prefix
                if (phoneNumber.Trim().StartsWith("+"))
                    return (defaultI18nStart == "+" ? "+" : exception.InternationalPrefixes[0]) + digitOnly;

                foreach (var intPrefix in exception.InternationalPrefixes)
                    if(digitOnly.StartsWith(intPrefix))
                        if (digitOnly.Length > intPrefix.Length)
                            return (defaultI18nStart == "+" ? "+" : intPrefix) + digitOnly.Substring(intPrefix.Length);
                #endregion International Prefix

                return digitOnly; // National Prefix & No Prefix
            }
            #endregion Exceptional Normalizer

            #region Default Normalizer (ITU-T Recommendation)

            if (phoneNumber.Trim().StartsWith("+"))
            {
                return defaultI18nStart + digitOnly;
            }

            if (digitOnly.StartsWith("00"))
            {
                if (digitOnly.Length > 2)
                {
                    return defaultI18nStart + digitOnly.Substring(2);
                }
                return defaultI18nStart;
            }

            #endregion Default Normalizer (ITU-T Recommendation)

            //Other 09132198895, 5553254
            return digitOnly; // National Prefix & No Prefix
        }

        /// <summary>
        /// Find countries that do not follows the ITU-T recommendations
        /// </summary>
        /// <param name="selectedException"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        private static bool IsExceptionalPhoneNumber(out IExceptionalCountryCode selectedException, string phoneNumber)
        {
            foreach (var definition in ExceptionalContainer.GetAllDefinitions())
            {
                if (definition.CustomValidation != null &&
                    definition.CustomValidation(phoneNumber))
                {
                    selectedException = definition;
                    return true;
                }

                if (MatchCombination(phoneNumber, definition))
                {
                    selectedException = definition;
                    return true;
                }
            }

            selectedException = null;
            return false;
        }

        private static bool MatchCombination(string phoneNumber, IExceptionalCountryCode definition)
        {
            return definition.InternationalPrefixes.Any(internationalPrefix =>
                definition.CountryCodes.Any(countryCode =>
                    phoneNumber.StartsWith(internationalPrefix + countryCode)
                )
            );
        }

        private static string PreNormalizationHandling(string input, TelephoneOptions options)
        {
            if (options == null)
            {
                options = TelephoneOptions.Default;
            }

            input = TelephoneUtility.PreProcessingHandling(input, options);

            return input;
        }
    }

}
