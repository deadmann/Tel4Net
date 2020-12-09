using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class China : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "00" };
        public string[] CountryCodes => new[] { "86" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 5,6,7,8,9,10,11,12 };
        public Func<string, bool> CustomValidation => null;
    }
    internal class China2 : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "002" };
        public string[] CountryCodes => new[] { "886" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 8, 9 };
        public Func<string, bool> CustomValidation => null;
    }
}
