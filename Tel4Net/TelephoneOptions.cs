namespace Tel4Net
{
    /// <summary>
    /// Provides extra options while validating a telephone number
    /// </summary>
    public class TelephoneOptions
    {
        /// <summary>
        /// If true:  ignores any characters beside formal ascii english numbers. <br />
        /// If false: try to convert undefined characters (number from other languages) to ascii english corresponding characters, and then normalize.
        /// </summary>
        public bool ProcessNaturalCharacterOnly { get; set; }

        #region Defaults
        /// <summary>
        /// The default sets of configurations
        /// </summary>
        public static readonly TelephoneOptions Default = new TelephoneOptions
        {
            ProcessNaturalCharacterOnly = false
        };
        #endregion Defaults
    }
}