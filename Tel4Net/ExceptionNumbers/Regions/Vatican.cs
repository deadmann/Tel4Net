using System;
using System.Collections.Generic;
using System.Text;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Vatican : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new string[0];
        public string[] CountryCodes => new[] {"379"};
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new int[0];
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }

    internal class Vatican2 : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] {"00"};
        public string[] CountryCodes => new[] {"39"};
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11}; // Up to  11 Digits
        public Func<string, bool> CustomValidation => null;
        public Func<string, string> CustomNormalizer => null;
    }
}
