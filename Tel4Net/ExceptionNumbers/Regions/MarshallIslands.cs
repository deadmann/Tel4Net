using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class MarshallIslands: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[]{"011"};
        public string[] CountryCodes => new[] {"692"};
        public string[] NationalPrefix => new[] {"1"};
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {7};
        public Func<string, bool> CustomValidation => null;
    }
}
