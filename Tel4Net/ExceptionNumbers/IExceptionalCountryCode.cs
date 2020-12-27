using System;

namespace Tel4Net.ExceptionNumbers
{
    /// <summary>
    /// Provides workarounds for exceptional phone numbers codes, when 00 doesn't applies for example  (810, or 000, or 011)
    /// </summary>
    internal interface IExceptionalCountryCode
    {
        string[] InternationalPrefixes { get; }
        string[] CountryCodes { get; }
        string[] NationalPrefix { get; }
        string[] NationalNumberPrefix { get; }
        int[] NationalNumberLength { get; }

        /// <summary>
        /// Optional
        /// </summary>
        Func<string, bool> CustomValidation { get; }
        /// <summary>
        /// Optional
        /// </summary>
        Func<string, string> CustomNormalizer { get; }
    }
}
