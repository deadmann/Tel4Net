using System;

namespace Tel4Net.ExceptionNumbers.Regions
{
    /// <summary>
    /// Global Mobile Satellite System (GMSS), shared
    /// </summary>
    public class Gmss: IExceptionalCountryCode
    {
        public string[] InternationalPrefixes => new string[0];
        public string[] CountryCodes => new[] { "881" };
        public string[] NationalPrefix => new string[0];
        public string[] NationalNumberPrefix => new string[0];
        public int[] NationalNumberLength => new int[0];
        public Func<string, bool> CustomValidation => null;
    }
}
