using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tel4Net.RegionValidation
{
    /// <summary>
    /// Provide functionality to register or fetch specific region
    /// </summary>
    internal class RegionValidatorContainer
    {
        private readonly Dictionary<Region, IRegionValidator> _regionValidators;

        public RegionValidatorContainer()
        {
            _regionValidators = new Dictionary<Region, IRegionValidator>();
            RegionRegistry.RegisterRegions(this);
        }

        public void RegisterRegions(Region region, IRegionValidator validator)
        {
            _regionValidators.Add(region, validator);
        }

        public List<IRegionValidator> GetAllValidators()
        {
            return _regionValidators.Values.ToList();
        }

        public IRegionValidator GetRegionValidator(Region region) => _regionValidators[region];
    }
}
