using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Israel:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new []{ "00", "012", "013", "014" };
        public string[] CountryCodes => new[] { "972" };
        public string[] NationalPrefix => new[] {"0"};
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {8, 9};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
