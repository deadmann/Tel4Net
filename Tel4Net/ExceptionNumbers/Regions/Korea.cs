using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Korea:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "001", "002"};
        public string[] CountryCodes => new[] { "82" };
        public string[] NationalPrefix => new[] { "0", "082" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {8, 9, 10, 11};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
