using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class UnitedStates:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "011" };
        public string[] CountryCodes => new[] { "1" };
        public string[] NationalPrefix => new[] { "1" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 10 };
        public Func<string, bool> CustomValidation => null;
    }
}
