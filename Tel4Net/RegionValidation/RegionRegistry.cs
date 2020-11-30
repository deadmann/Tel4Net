using Tel4Net.RegionValidation.Regions;

namespace Tel4Net.RegionValidation
{
    /// <summary>
    /// Provide functionality to register or fetch specific region
    /// </summary>
    internal static class RegionRegistry
    {
        /// <summary>
        /// Register all available regions in validation system
        /// </summary>
        /// <param name="container">the container that all validations will registers in</param>
        public static void RegisterRegions(RegionValidatorContainer container)
        {
            // TODO: REGISTER YOUR REGION HERE
            container.RegisterRegions(Region.Iran, new IranValidator());
        }
    }

    /// <summary>
    /// All Regions defined within the system
    /// </summary>
    public enum Region
    {
        /// <summary>
        /// Iran Country
        /// </summary>
        Iran
    }
}