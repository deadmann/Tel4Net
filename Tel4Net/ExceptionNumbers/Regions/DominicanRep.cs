using System;
using System.Collections.Generic;
using System.Text;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class DominicanRep : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "011" };
        public string[] CountryCodes => new[] { "1" };
        public string[] NationalPrefix => new[] { "1" };
        public string[] NationalNumberPrefix => new[] { "809", "829" };
        public int[] NationalNumberLength => new[] { 7 };
        public Func<string, bool> CustomValidation => null;
    }
}
