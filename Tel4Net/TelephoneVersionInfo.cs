using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Tel4Net.RegionValidation;

namespace Tel4Net
{
    /// <summary>
    /// Provide info about Tel4Net and if it is beneficial for you
    /// </summary>
    public class TelephoneVersionInfo
    {
        /// <summary>
        /// Get supporting numeric charsets language name, in english.
        /// </summary>
        /// <returns></returns>
        public string[] GetSupportingLanguageEnglishName()
        {
            var result = new string[TelephoneUtility.LanguageHandlers.Count];
            for (var index = 0; index < TelephoneUtility.LanguageHandlers.Count; index++)
            {
                result[index] = TelephoneUtility.LanguageHandlers[index].EnglishName;
            }

            return result;
        }

        /// <summary>
        /// Get supporting numeric charsets language name, in native language.
        /// </summary>
        /// <returns></returns>
        public string[] GetSupportingLanguageNativeName()
        {
            var result = new string[TelephoneUtility.LanguageHandlers.Count];
            for (var index = 0; index < TelephoneUtility.LanguageHandlers.Count; index++)
            {
                result[index] = TelephoneUtility.LanguageHandlers[index].EnglishName;
            }

            return result;
        }

        /// <summary>
        /// Get supporting region specific validators, named in english.
        /// </summary>
        /// <returns></returns>
        public string[] GetSupportingRegionEnglishName()
        {
            RegionValidatorContainer rvc = new RegionValidatorContainer();
            var result = new string[rvc.GetAllValidators().Count];
            for (var index = 0; index < rvc.GetAllValidators().Count; index++)
            {
                result[index] = rvc.GetAllValidators()[index].EnglishName;
            }

            return result;
        }

        /// <summary>
        /// Get supporting region specific validator, named in their native language.
        /// </summary>
        /// <returns></returns>
        public string[] GetSupportingRegionNativeName()
        {
            RegionValidatorContainer rvc = new RegionValidatorContainer();
            var result = new string[rvc.GetAllValidators().Count];
            for (var index = 0; index < rvc.GetAllValidators().Count; index++)
            {
                result[index] = rvc.GetAllValidators()[index].NativeName;
            }

            return result;
        }
    }
}
