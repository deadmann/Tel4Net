using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    /// <summary>
    /// **Reserved**
    /// </summary>
    internal class Reserved: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new string[0];
        public string[] CountryCodes => new[] {"970"};
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new int[0];
        public Func<string, bool> CustomValidation => (_) => false;
        public Func<string, string> CustomNormalizer => null;
    }
}
