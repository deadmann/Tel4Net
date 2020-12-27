using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    /// <summary>
    /// Universal Personal Telecommunication (UPT)
    /// </summary>
    internal class Upt : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new string[0];
        public string[] CountryCodes => new[] { "878" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new int[0];
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
