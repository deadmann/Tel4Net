using System.Collections.Generic;
using System.Linq;

namespace Tel4Net.ExceptionNumbers
{
    /// <summary>
    /// Provide functionality to register or fetch specific region
    /// </summary>
    internal class ExceptionalContainer
    {
        //private readonly Dictionary<Country, IList<IExceptionalCountryCode>> _exceptionalCountries;
        private readonly Dictionary<Country, IExceptionalCountryCode> _exceptionalCountries;

        public ExceptionalContainer()
        {
            //_exceptionalCountries = new Dictionary<Country, IList<IExceptionalCountryCode>>();
            _exceptionalCountries = new Dictionary<Country, IExceptionalCountryCode>();
            ExceptionalCountryRegistrar.RegisterCountries(this);
        }

        public void RegisterRegions(Country country, IExceptionalCountryCode exceptionalCountry)
        {
            //if (_exceptionalCountries.ContainsKey(country))
            //    _exceptionalCountries[country].Add(exceptionalCountry);
            //else _exceptionalCountries.Add(country, new List<IExceptionalCountryCode> {exceptionalCountry});
            _exceptionalCountries.Add(country, exceptionalCountry);
        }

        //public Dictionary<Country, IList<IExceptionalCountryCode>> GetAll()
        public Dictionary<Country, IExceptionalCountryCode> GetAll()
        {
            return _exceptionalCountries;
        }

        //public List<IList<IExceptionalCountryCode>> GetAllDefinitions()
        public List<IExceptionalCountryCode> GetAllDefinitions()
        {
            return _exceptionalCountries.Values.ToList();
        }

        //public IList<IExceptionalCountryCode> GetRegionDefinitions(Country country) => _exceptionalCountries[country];
        public IExceptionalCountryCode GetRegionDefinition(Country country) => _exceptionalCountries[country];
    }
}
