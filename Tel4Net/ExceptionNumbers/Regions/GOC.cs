using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    /// <summary>
    /// Group of countries, shared code
    /// </summary>
    internal class Goc:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new string[0];
        public string[] CountryCodes => new[] { "388" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new int[0];
        public Func<string, bool> CustomValidation => null;
    }
}
