using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    /// <summary>
    /// International Premium Rate Service (IPRS)
    /// </summary>
    internal class Iprs : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new string[0];
        public string[] CountryCodes => new[] { "979" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {9};
        public Func<string, bool> CustomValidation => null;
    }
}
