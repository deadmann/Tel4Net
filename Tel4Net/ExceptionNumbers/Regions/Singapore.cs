using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Singapore:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "001", "008" };
        public string[] CountryCodes => new[] { "65" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 8,9,10,11,12 };
        public Func<string, bool> CustomValidation => null;
    }
}
