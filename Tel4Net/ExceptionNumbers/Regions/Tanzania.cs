using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Tanzania : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "000" };
        public string[] CountryCodes => new[] { "255" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {9};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
