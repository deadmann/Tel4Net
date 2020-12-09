using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Nigeria : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] {"009"};
        public string[] CountryCodes => new[] {"234"};
        public string[] NationalPrefix => new[] {"0"};
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {7, 8, 9, 10};
        public Func<string, bool> CustomValidation => null;
    }
}
