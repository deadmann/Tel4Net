using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Belarus: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "810" };
        public string[] CountryCodes => new[] { "375" };
        public string[] NationalPrefix => new[] { "8" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 9, 10 };
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
