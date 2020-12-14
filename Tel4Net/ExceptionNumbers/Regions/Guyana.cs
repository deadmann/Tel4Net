﻿using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    internal class Guyana:IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new[] { "001" };
        public string[] CountryCodes => new[] { "592" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new[] { 7 };
        public Func<string, bool> CustomValidation => null;
    }
}