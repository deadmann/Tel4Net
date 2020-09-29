using System;
using System.Text.RegularExpressions;

namespace Tel4Net
{
    public static class TelephoneNormalizer
    {
        // ReSharper disable once InconsistentNaming
        public static string ToPhoneNumberNormalization(string phoneNumber, TelephoneOptions options = null, string defaultI18nStart = "+")
        {
            phoneNumber = PreNormalizationHandling(phoneNumber, options);

            if (defaultI18nStart != "+" && defaultI18nStart != "00")
                throw new ArgumentOutOfRangeException(nameof(defaultI18nStart), defaultI18nStart, "parameter can only contains value of '+' or '00'");

            if (phoneNumber == null)
                return null;

            var digitOnly = Regex.Replace(phoneNumber, @"[^\d]", "").Trim();

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

            TelephoneUtility.PreProcessingHandling(input, options);

            return input;
        }
    }

}
