﻿using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Turkmenistan : IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "810" };
        public string[] CountryCodes => new[] { "993" };
        public string[] NationalPrefix => new[] { "8" };
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 8 };
        public Func<string, bool> CustomValidation => null;
    }
}