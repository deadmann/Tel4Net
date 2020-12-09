using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class HongKongChina: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "001" };
        public string[] CountryCodes => new[] { "852" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 4, 8, 9 };
        public Func<string, bool> CustomValidation => null;
    }
}
