using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tel4Net
{
    public static class TelephoneUtility
    {
        //Phone Number Length -> 1~13 
        //https://www.quora.com/What-is-maximum-and-minimum-length-of-any-mobile-number-across-the-world
        private static readonly Regex RegexPhoneNumber = new Regex(@"^(\+[^0]?|0[^0]?|00[^0]?)?(\(|\[)?[1-9][\d\ \-\.\[\]\(\)]+\d$", RegexOptions.Compiled);
        private static readonly Regex RegexPhoneNumberBelow3Digit = new Regex(@"^\d{1,2}$", RegexOptions.Compiled);
        private static readonly int MinimumPhoneNumberLength = 1;
        private static readonly int MaximumPhoneNumberLength = 14;//for future 1+

        // ReSharper disable once InconsistentNaming
        public static bool PhoneNumberI10nValidation(string phoneNumber)
        {
            if (!phoneNumber.StartsWith("00") && !phoneNumber.StartsWith("+"))
                return false;

            return PhoneNumberValidateLength(phoneNumber) && PhoneNumberValidateFormat(phoneNumber);
        }

        public static bool PhoneNumberCityValidation(string phoneNumber)
        {
            if (phoneNumber.Length < 2 || phoneNumber[0] != '0' || phoneNumber[1] == '0')
                return false;

            return PhoneNumberValidateLength(phoneNumber) && PhoneNumberValidateFormat(phoneNumber);
        }

        public static bool PhoneNumberInboundValidation(string phoneNumber)
        {
            if (phoneNumber.StartsWith("0") || phoneNumber.StartsWith("+"))
                return false;

            return PhoneNumberValidateLength(phoneNumber) && PhoneNumberValidateFormat(phoneNumber);
        }

        public static bool PhoneNumberValidate(string phoneNumber)
        {
            return PhoneNumberValidateFormat(phoneNumber) && PhoneNumberValidateLength(phoneNumber);
        }

        public static bool PhoneNumberValidateFormat(string phoneNumber)
        {
            if (!CheckOpenCloseCharacter(phoneNumber, new List<OpenClose>
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

        public static bool PhoneNumberValidateLength(string phoneNumber)
        {
            var normalized = ToPhoneNumberNormalization(phoneNumber);
            if (normalized.Length < MinimumPhoneNumberLength || normalized.Length > MaximumPhoneNumberLength)
            {
                return false;
            }
            return true;
        }

        internal static bool CheckOpenCloseCharacter(string input, List<OpenClose> openCloseCharacters)
        {
            Stack<char> charStack = new Stack<char>();
            char? top = null;

            OpenClose search;
            foreach (var @char in input)
            {
                if (openCloseCharacters.Any(w => w.Opening == @char))
                {
                    charStack.Push(@char);

                    top = @char;
                }
                else if ((search = openCloseCharacters.FirstOrDefault(w => w.Closing == @char)) != null && top.Value == search.Opening)
                {
                    charStack.Pop();
                    top = (charStack.Count == 0) ? (char?)null : charStack.Peek();
                }
                else if (search != null)
                {
                    return false;
                }
            }

            if (charStack.Count > 0) return false;
            return true;
        }

        // ReSharper disable once InconsistentNaming
        public static string ToPhoneNumberNormalization(string phoneNumber, string defaultI18nStart = "+")
        {
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
    }
}
