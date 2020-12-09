using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Palau : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] {"011"};
        public string[] CountryCodes => new[] {"680"};
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {7};
        public Func<string, bool> CustomValidation => null;
    }
}
