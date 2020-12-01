namespace Tel4Net.RegionValidation.Regions
{
    /// <summary>
    /// Validate Iranian Phone Numbers
    /// </summary>
    internal class IranValidator : IRegionValidator
    {
        public string EnglishName => "Iran, Persia";
        public string NativeName => "ایران، پرشیا";

        /// <inheritdoc />
        public bool IsMobileNumber(string normalizedPhoneNumber, bool allowNoSign)
        {
            if ((normalizedPhoneNumber.StartsWith("+989") && normalizedPhoneNumber.Length == 13) // Signed Country
                || (normalizedPhoneNumber.StartsWith("09") && normalizedPhoneNumber.Length == 11) // Signed City/Operator
                || ((allowNoSign && normalizedPhoneNumber.StartsWith("989") && normalizedPhoneNumber.Length == 12)) // Unsigned Country
                || ((allowNoSign && normalizedPhoneNumber.StartsWith("9")) && normalizedPhoneNumber.Length == 10)) // Unsigned City
                return true;
            return false;
        }

        /// <inheritdoc />
        public bool IsValidNumber(string normalizedPhoneNumber, bool allowNoSign)
        {
            if ((normalizedPhoneNumber.StartsWith("+98") && normalizedPhoneNumber.Length == 13) // Signed Country
                || (normalizedPhoneNumber.StartsWith("0") && normalizedPhoneNumber.Length == 11) // Signed City/Operator
                || (
                    (!normalizedPhoneNumber.StartsWith("+") && !normalizedPhoneNumber.StartsWith("0")) // Unsigned
                    && ((normalizedPhoneNumber.Length == 8) // Inbound
                        || (allowNoSign && normalizedPhoneNumber.StartsWith("98") && normalizedPhoneNumber.Length == 12) // Unsigned Country
                        || (allowNoSign && normalizedPhoneNumber.Length == 10)) // Unsigned City
                ))
                return true;

            return false;
        }
    }
}
