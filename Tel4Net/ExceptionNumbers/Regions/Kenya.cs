using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Kenya:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "000" };
        public string[] CountryCodes => new[] { "254" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 6,7,8,9,10 };
        public Func<string, bool> CustomValidation => null;
    }
}
