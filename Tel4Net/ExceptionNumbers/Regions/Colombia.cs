using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Colombia : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "005", "007", "009" };
        public string[] CountryCodes => new[] { "57" };
        public string[] NationalPrefix => new[] { "05", "07", "09" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 8, 10 };
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
