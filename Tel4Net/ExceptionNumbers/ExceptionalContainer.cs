using System.Collections.Generic;
using System.Linq;
using Tel4Net.RegionValidation;

namespace Tel4Net.ExceptionNumbers
{
    /// <summary>
    /// Provide functionality to register or fetch specific region
    /// </summary>
    internal class ExceptionalContainer
    {
        private readonly Dictionary<Country, IExceptionalCountryCode> _exceptionalCountries;

        public ExceptionalContainer()
        {
            _exceptionalCountries = new Dictionary<Country, IExceptionalCountryCode>();
            ExceptionalCountryRegistrar.RegisterCountries(this);
        }

        public void RegisterRegions(Country country, IExceptionalCountryCode exceptionalCountry)
        {
            _exceptionalCountries.Add(country, exceptionalCountry);
        }

        public List<IExceptionalCountryCode> GetAllDefinitions()
        {
            return _exceptionalCountries.Values.ToList();
        }

        public IExceptionalCountryCode GetRegionDefinitions(Country country) => _exceptionalCountries[country];
    }
}
