using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Uzbekistan: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "810" };
        public string[] CountryCodes => new[] { "998" };
        public string[] NationalPrefix => new[] { "8" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {9};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
