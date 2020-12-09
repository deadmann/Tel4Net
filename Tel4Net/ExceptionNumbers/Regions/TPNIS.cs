using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    /// <summary>
    /// Trial of a proposed new international service
    /// </summary>
    internal class Tpnis: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new string[0];
        public string[] CountryCodes => new[] { "991" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new int[0];
        public Func<string, bool> CustomValidation => null;
    }
}
