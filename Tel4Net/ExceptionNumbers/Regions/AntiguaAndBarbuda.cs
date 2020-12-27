using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class AntiguaAndBarbuda : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] {"011"};
        public string[] CountryCodes => new[] {"1"};
        public string[] NationalPrefix => new[]{"1"};
        public string[] NationalNumberPrefix => new[] {"268"};
        public int[] NationalNumberLength => new[] {7};
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
