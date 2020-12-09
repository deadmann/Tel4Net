using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Japan:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "010" };
        public string[] CountryCodes => new[] { "81" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 5,6,7,8,9,10,11,12,13 };
        public Func<string, bool> CustomValidation => null;
    }
}
