using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class PuertoRico:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] {"011"};
        public string[] CountryCodes => new[] {"1"};
        public string[] NationalPrefix => new[] {"1"};
        public string[] NationalNumberPrefix => new[] {"787", "939"};
        public int[] NationalNumberLength => new[] {7};
        public Func<string, bool> CustomValidation => null;
    }
}
