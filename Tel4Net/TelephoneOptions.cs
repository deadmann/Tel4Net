namespace Tel4Net
{
    /// <summary>
    /// Provides extra options while validating a telephone number
    /// </summary>
    public class TelephoneOptions
    {
        /// <summary>
        /// If true:  ignores any characters beside formal ascii english numbers. <br />
        /// If false: (default) try to convert undefined characters (number from other languages) to ascii english corresponding characters, and then normalize.
        /// </summary>
        public bool ProcessNaturalCharacterOnly { get; set; }

        #region Defaults
        /// <summary>
        /// The default sets of configurations
        /// </summary>
        public static readonly TelephoneOptions Default;

        static TelephoneOptions()
        {
            Default = new TelephoneOptions
            {
                ProcessNaturalCharacterOnly = false
            };
        }

        #endregion Defaults
    }

    /// <summary>
    /// Provides extra options while validating a mobile number
    /// </summary>
    public class RegionalOptions : TelephoneOptions
    {
        /// <summary>
        /// (default is false) Allow phone number to not include a city or international signature such as + or 00
        /// </summary>
        public bool AllowNoSign { get; set; }

        #region Defaults
        /// <summary>
        /// The default sets of configurations
        /// </summary>
        public new static readonly RegionalOptions Default;
        static RegionalOptions()
        {
            Default = new RegionalOptions
            {
                AllowNoSign = false,
                ProcessNaturalCharacterOnly = false
            };
        }
        #endregion Defaults
    }
}