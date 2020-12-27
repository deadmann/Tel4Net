using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Chile:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => throw new NullReferenceException(); // new[] { "1YZ0" };
        public string[] CountryCodes => new[] { "56" };
        public string[] NationalPrefix => new[] { "1YZ" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {8, 9};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
