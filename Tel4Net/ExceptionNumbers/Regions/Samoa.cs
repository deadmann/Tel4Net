using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Samoa : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] {"0"};
        public string[] CountryCodes => new[] { "685" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 3,4,5,6,7};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
