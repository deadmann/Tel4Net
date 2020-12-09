using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    /// <summary>
    /// Inmarsat SNAC
    /// </summary>
    internal class InmarsatSnac : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new []{ "00" };
        public string[] CountryCodes => new[] {"870"};
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {9};
        public Func<string, bool> CustomValidation => null;
    }
}