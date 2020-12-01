using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Tel4Net
{
    /// <summary>
    /// This class provides phone number Normalizations functionality
    /// </summary>
    public static class TelephoneNormalizer
    {
        private static readonly Regex DigitOnlyRegex = new Regex(@"[^\d]", RegexOptions.Compiled);

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
            //Other 09132198895, 5553254
            return digitOnly;
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
