using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    /// <summary>
    /// International Shared Cost Service (ISCS)
    /// </summary>
    internal class Iscs: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new string[0];
        public string[] CountryCodes => new[] { "808" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {8};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
