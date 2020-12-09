using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Mongolia: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] {"001"};
        public string[] CountryCodes => new[] {"976"};
        public string[] NationalPrefix => new[] {"0"};
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {7, 8};
        public Func<string, bool> CustomValidation => null;
    }
}
