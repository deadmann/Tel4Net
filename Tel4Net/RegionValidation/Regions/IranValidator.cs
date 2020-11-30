namespace Tel4Net.RegionValidation.Regions
{
    /// <summary>
    /// Validate Iranian Phone Numbers
    /// </summary>
    internal class IranValidator : IRegionValidator
    {
        /// <inheritdoc />
        public bool IsMobileNumber(string normalizedPhoneNumber, bool allowNoSign)
        {
            if (!IsValidNumber(normalizedPhoneNumber, allowNoSign))
                return false;

            if (normalizedPhoneNumber.StartsWith("+989")
                || normalizedPhoneNumber.StartsWith("09")
                || (allowNoSign && normalizedPhoneNumber.StartsWith("989"))
                || (allowNoSign && normalizedPhoneNumber.StartsWith("9")))
                return true;
            return false;

        }

        /// <inheritdoc />
        public bool IsValidNumber(string normalizedPhoneNumber, bool allowNoSign)
        {
            if (normalizedPhoneNumber.StartsWith("+")
                && normalizedPhoneNumber.Length == 13)
            {
                return true;
            }
            else if (normalizedPhoneNumber.StartsWith("0") 
                     && normalizedPhoneNumber.Length == 11)
            {
                return true;
            }
            else if ((!normalizedPhoneNumber.StartsWith("+")
                      && !normalizedPhoneNumber.StartsWith("0")
                ) && (normalizedPhoneNumber.Length == 7
                      || (allowNoSign
                          && (normalizedPhoneNumber.Length == 12 || normalizedPhoneNumber.Length == 10))))
            {
                return true;
            }

            return false;
        }
    }
}
