using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Finland: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => throw new NullReferenceException();// new[] { "00", "99X" };
        public string[] CountryCodes => new[] { "358" };
        public string[] NationalPrefix => new[] { "0" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {5, 6, 7, 8, 9, 10, 11, 12};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
