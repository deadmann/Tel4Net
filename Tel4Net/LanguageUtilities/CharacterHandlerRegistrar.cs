using Tel4Net.LanguageUtilities.Handlers;
using Tel4Net.RegionValidation;
using Tel4Net.RegionValidation.Regions;

namespace Tel4Net.LanguageUtilities
{
    /// <summary>
    /// Provide functionality to register or fetch specific Character Handler
    /// </summary>
    internal static class CharacterHandlerRegistrar
    {
        /// <summary>
        /// Register all Character Handlers in normalization system
        /// </summary>
        /// <param name="container">the container that all Character Handlers will registers in</param>
        public static void RegisterCharacterHandlers(CharacterHandlerContainer container)
        {
            // TODO: REGISTER YOUR REGION HERE
            container.RegisterRegions(new PersianHandler());
        }
    }
}