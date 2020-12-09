﻿using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Uganda : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] {"000"};
        public string[] CountryCodes => new[] {"256"};
        public string[] NationalPrefix => new[] {"0"};
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] {9};
        public Func<string, bool> CustomValidation => null;
    }
}
