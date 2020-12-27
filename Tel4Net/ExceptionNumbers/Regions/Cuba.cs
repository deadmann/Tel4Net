using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Cuba : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "119" };
        public string[] CountryCodes => new[] { "53" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 6, 8 };
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
