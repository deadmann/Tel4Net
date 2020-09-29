using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Tel4Net
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class TelephoneValidator
    {
        //Phone Number Length -> 1~13 
        //https://www.quora.com/What-is-maximum-and-minimum-length-of-any-mobile-number-across-the-world
        private static readonly Regex RegexPhoneNumber = new Regex(@"^(\+[^0]?|0[^0]?|00[^0]?)?(\(|\[)?[1-9][\d\ \-\.\[\]\(\)]+\d$", RegexOptions.Compiled);
        private static readonly Regex RegexPhoneNumberBelow3Digit = new Regex(@"^\d{1,2}$", RegexOptions.Compiled);
        private static readonly int MinimumPhoneNumberLength = 1;
        private static readonly int MaximumPhoneNumberLength = 14;//for future 1+


        // ReSharper disable once InconsistentNaming
        public static bool PhoneNumberI10nValidation(string phoneNumber, TelephoneOptions options = null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            if (!phoneNumber.StartsWith("00") && !phoneNumber.StartsWith("+"))
                return false;

            return PhoneNumberValidateLength(phoneNumber, options) && PhoneNumberValidateFormat(phoneNumber, options);
        }

        public static bool PhoneNumberCityValidation(string phoneNumber, TelephoneOptions options = null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            if (phoneNumber.Length < 2 || phoneNumber[0] != '0' || phoneNumber[1] == '0')
                return false;

            return PhoneNumberValidateLength(phoneNumber, options) && PhoneNumberValidateFormat(phoneNumber, options);
        }

        public static bool PhoneNumberInboundValidation(string phoneNumber, TelephoneOptions options = null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            if (phoneNumber.StartsWith("0") || phoneNumber.StartsWith("+"))
                return false;

            return PhoneNumberValidateLength(phoneNumber, options) && PhoneNumberValidateFormat(phoneNumber, options);
        }

        public static bool PhoneNumberValidate(string phoneNumber, TelephoneOptions options =null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            return PhoneNumberValidateFormat(phoneNumber, options) && PhoneNumberValidateLength(phoneNumber, options);
        }

        public static bool PhoneNumberValidateFormat(string phoneNumber, TelephoneOptions options =null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            if (!TelephoneUtility.CheckOpenCloseCharacter(phoneNumber, new List<OpenClose>
            {
                new OpenClose('(', ')'),
                new OpenClose('[', ']')
            }))
            {
                return false;
            }

            if (RegexPhoneNumberBelow3Digit.IsMatch(phoneNumber))
                return true;

            return RegexPhoneNumber.IsMatch(phoneNumber);
        }

        public static bool PhoneNumberValidateLength(string phoneNumber, TelephoneOptions options = null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            var normalized = TelephoneNormalizer.ToPhoneNumberNormalization(phoneNumber, options);
            if (normalized.Length < MinimumPhoneNumberLength || normalized.Length > MaximumPhoneNumberLength)
            {
                return false;
            }
            return true;
        }

        private static string PreValidateHandling(string input, TelephoneOptions options)
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
