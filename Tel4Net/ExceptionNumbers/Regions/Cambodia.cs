using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Cambodia:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "001", "007" };
        public string[] CountryCodes => new[] { "855" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 8 };
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
