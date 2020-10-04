using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Tel4Net.RegionValidation;

namespace Tel4Net
{
    /// <summary>
    /// This class provides phone number Validations functionality
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class TelephoneValidator
    {
        //Phone Number Length -> 1~13 
        //https://www.quora.com/What-is-maximum-and-minimum-length-of-any-mobile-number-across-the-world
        private static readonly Regex RegexPhoneNumber = new Regex(@"^(\+[^0]?|0[^0]?|00[^0]?)?(\(|\[)?[1-9][\d\ \-\.\[\]\(\)]+\d$", RegexOptions.Compiled);
        private static readonly Regex RegexPhoneNumberBelow3Digit = new Regex(@"^\d{1,2}$", RegexOptions.Compiled);
        private static readonly int MinimumPhoneNumberLength = 1;
        private static readonly int MaximumPhoneNumberLength = 14;//for future 1+

        private static readonly RegionValidatorContainer RegionValidatorContainer = new RegionValidatorContainer();

        #region Mobile Validators

        /// <summary>
        /// Validates mobile number [1/3 In all available regions]
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool MobileValidator(string phoneNumber, RegionalOptions options = null)
        {
            return MobileValidator(phoneNumber, RegionValidatorContainer.GetAllValidators(), options);
        }

        /// <summary>
        /// Validates mobile number [2/3 In a single region]
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="region"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool MobileValidator(string phoneNumber, Region region, RegionalOptions options = null)
        {
            var regionValidator = RegionValidatorContainer.GetRegionValidator(region);
            if(regionValidator==null)
                throw new NotImplementedException("No Validator implementation found for this region");
            return MobileValidator(phoneNumber, new List<IRegionValidator>{regionValidator}, options);
        }

        /// <summary>
        /// Validates mobile number [3/3 In a list of selected regions]
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="regions"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool MobileValidator(string phoneNumber,IEnumerable<Region> regions, RegionalOptions options = null)
        {
            List<IRegionValidator> validators = new List<IRegionValidator>();
            foreach (var region in regions)
            {
                var regionValidator = RegionValidatorContainer.GetRegionValidator(region);
                if (regionValidator == null)
                    throw new NotImplementedException($"No Validator implementation found for {region} region");
                validators.Add(regionValidator);
            }

            return MobileValidator(phoneNumber, validators, options);
        }

        private static bool MobileValidator(string phoneNumber, List<IRegionValidator> validators, RegionalOptions options = null)
        {
            if (options == null)
            {
                options = RegionalOptions.Default;
            }
            
            phoneNumber = PreValidateHandling(phoneNumber, options);
            var normalizedNumber = TelephoneNormalizer.ToPhoneNumberNormalization(phoneNumber, options, "+");

            if (!(PhoneNumberValidateLength(phoneNumber, options) && PhoneNumberValidateFormat(phoneNumber, options)))
                return false;

            foreach (var validator in validators)
            {
                if (validator.IsMobileNumber(normalizedNumber, options.AllowNoSign))
                    return true;
            }

            return false;
        }
        #endregion Mobile Validators

        #region Any Telephone Validators

        /// <summary>
        /// Validates telephone number [1/3 In all available regions]
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool NumberValidator(string phoneNumber, RegionalOptions options = null)
        {
            return NumberValidator(phoneNumber, RegionValidatorContainer.GetAllValidators(), options);
        }

        /// <summary>
        /// Validates telephone number [2/3 In a single region]
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="region"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool NumberValidator(string phoneNumber, Region region, RegionalOptions options = null)
        {
            var regionValidator = RegionValidatorContainer.GetRegionValidator(region);
            if (regionValidator == null)
                throw new NotImplementedException("No Validator implementation found for this region");
            return NumberValidator(phoneNumber, new List<IRegionValidator> { regionValidator }, options);
        }

        /// <summary>
        /// Validates telephone number [3/3 In a list of selected regions]
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="regions"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool NumberValidator(string phoneNumber, IEnumerable<Region> regions, RegionalOptions options = null)
        {
            List<IRegionValidator> validators = new List<IRegionValidator>();
            foreach (var region in regions)
            {
                var regionValidator = RegionValidatorContainer.GetRegionValidator(region);
                if (regionValidator == null)
                    throw new NotImplementedException($"No Validator implementation found for {region} region");
                validators.Add(regionValidator);
            }

            return NumberValidator(phoneNumber, validators, options);
        }

        private static bool NumberValidator(string phoneNumber, List<IRegionValidator> validators, RegionalOptions options = null)
        {
            if (options == null)
            {
                options = RegionalOptions.Default;
            }

            phoneNumber = PreValidateHandling(phoneNumber, options);
            var normalizedNumber = TelephoneNormalizer.ToPhoneNumberNormalization(phoneNumber, options, "+");

            if (!(PhoneNumberValidateLength(phoneNumber, options) && PhoneNumberValidateFormat(phoneNumber, options)))
                return false;

            foreach (var validator in validators)
            {
                if (validator.IsValidNumber(normalizedNumber, options.AllowNoSign))
                    return true;
            }

            return false;
        }
        #endregion Telephone Validators

        /// <summary>
        /// Validate a phone number in length and signature of against an international phone number rules
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public static bool PhoneNumberI10nValidation(string phoneNumber, TelephoneOptions options = null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            if (!phoneNumber.StartsWith("00") && !phoneNumber.StartsWith("+"))
                return false;

            return PhoneNumberValidateLength(phoneNumber, options) && PhoneNumberValidateFormat(phoneNumber, options);
        }

        /// <summary>
        /// Validate a phone number in length and signature of against an city phone number rules
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool PhoneNumberCityValidation(string phoneNumber, TelephoneOptions options = null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            if (phoneNumber.Length < 2 || phoneNumber[0] != '0' || phoneNumber[1] == '0')
                return false;

            return PhoneNumberValidateLength(phoneNumber, options) && PhoneNumberValidateFormat(phoneNumber, options);
        }

        /// <summary>
        /// Validate a phone number in length and signature of against an inbound (local) phone number rules
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool PhoneNumberInboundValidation(string phoneNumber, TelephoneOptions options = null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            if (phoneNumber.StartsWith("0") || phoneNumber.StartsWith("+"))
                return false;

            return PhoneNumberValidateLength(phoneNumber, options) && PhoneNumberValidateFormat(phoneNumber, options);
        }

        /// <summary>
        /// Validates phone number in length and signatures regardless that if the phone number is local, city or international number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool PhoneNumberValidate(string phoneNumber, TelephoneOptions options =null)
        {
            phoneNumber = PreValidateHandling(phoneNumber, options);

            return PhoneNumberValidateFormat(phoneNumber, options) && PhoneNumberValidateLength(phoneNumber, options);
        }

        /// <summary>
        /// Validations only the signatures of the phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Validates only the total length of the phone number
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="options"></param>
        /// <returns></returns>
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
