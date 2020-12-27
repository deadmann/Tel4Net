using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Taiwan: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "002" };
        public string[] CountryCodes => new[] { "886" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {8, 9};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
