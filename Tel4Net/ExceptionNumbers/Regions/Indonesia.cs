using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Indonesia : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "001", "008" };
        public string[] CountryCodes => new[] { "62" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {5, 6, 7, 8, 9, 10};
        public Func<string, bool> CustomValidation => null;
    }
}
