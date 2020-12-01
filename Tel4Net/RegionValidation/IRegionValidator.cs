namespace Tel4Net.RegionValidation
{
    /// <summary>
    /// Provide region based validation interface
    /// </summary>
    internal interface IRegionValidator
    {
        /// <summary>
        /// Check if phone number is a valid mobile number in the country
        /// </summary>
        /// <param name="normalizedPhoneNumber">the normalized phone number to validate</param>
        /// <param name="allowNoSign">Allow phone number to not include a city or international signature such as + or 00</param>
        /// <returns></returns>
        bool IsMobileNumber(string normalizedPhoneNumber, bool allowNoSign);

        /// <summary>
        /// Check if phone number is valid number in country
        /// </summary>
        /// <param name="normalizedPhoneNumber">the normalized phone number to validate</param>
        /// <param name="allowNoSign">Allow phone number to not include a city or international signature such as + or 00</param>
        /// <returns></returns>
        bool IsValidNumber(string normalizedPhoneNumber, bool allowNoSign);
    }
}
