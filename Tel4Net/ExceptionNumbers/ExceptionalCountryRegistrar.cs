using Tel4Net.ExceptionNumbers.Regions;

namespace Tel4Net.ExceptionNumbers
{
    /// <summary>
    /// Provide functionality to register or fetch specific region
    /// </summary>
    internal static class ExceptionalCountryRegistrar
    {
        /// <summary>
        /// Register all available regions in validation system
        /// </summary>
        /// <param name="container">the container that all validations will registers in</param>
        public static void RegisterCountries(ExceptionalContainer container)
        {
            // TODO: REGISTER YOUR REGION HERE
            container.RegisterRegions(Country.AmericanSamoa, new AmericanSamoa());
            container.RegisterRegions(Country.Anguilla, );
            container.RegisterRegions(Country.AntiguaAndBarbuda, );
            container.RegisterRegions(Country.Australia, );
            container.RegisterRegions(Country.Bahamas, );
            container.RegisterRegions(Country.Barbados, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
            container.RegisterRegions(, );
        }
    }

    /// <summary>
    /// All Regions defined within the system
    /// </summary>
    public enum Country
    {
        AmericanSamoa,
        Anguilla,
        AntiguaAndBarbuda,
        Australia,
        Bahamas,
        Barbados,
        Belarus,
        Bermuda,
        BritishVirginIslands,
        Cambodia,
        Canada,
        CaymanIslands,
        Chile,
        China,
        Colombia,
        Cuba,
        Dominica,
        DominicanRep,
        Finland,
        Grenada,
        Guam,
        Guyana,
        HongKongChina,
        Indonesia,
        Israel,
        Jamaica,
        Japan,
        Kazakhstan,
        Kenya,
        Korea,
        MarshallIslands,
        Micronesia,
        Mongolia,
        Montserrat,
        Nigeria,
        NorthernMarianas,
        Palau,
        PuertoRico,
        RussianFederation,
        SaintKittsAndNevis,
        SaintLucia,
        SaintVincentAndTheGrenadines,
        Samoa,
        Singapore,
        SintMaartenDp,
        Taiwan,
        Tajikistan,
        Tanzania,
        Thailand,
        TrinidadAndTobago,
        Turkmenistan,
        TurksAndCaicosIslands,
        Uganda,
        UnitedStates,
        UnitedStatesVirginIslands,
        Uzbekistan,
        Vatican,


        /// <summary>
        /// Global Mobile Satellite System (GMSS), shared
        /// </summary>
        Gmss,
        /// <summary>
        /// Group of countries, shared code
        /// </summary>
        Goc,
        /// <summary>
        /// Inmarsat SNAC
        /// </summary>
        InmarsatSnac,
        InternationalFreephoneService,
        /// <summary>
        /// International Networks, shared code
        /// </summary>
        InternationalNetworks,
        /// <summary>
        /// International Premium Rate Service (IPRS)
        /// </summary>
        Iprs,
        /// <summary>
        /// International Shared Cost Service (ISCS)
        /// </summary>
        Iscs,
        /// <summary>
        /// Telecommunications for Disaster Relief (TDR)
        /// </summary>
        Tdr,
        /// <summary>
        /// Trial of a proposed new international service
        /// </summary>
        Tpnis,
        /// <summary>
        /// Universal Personal Telecommunication (UPT)
        /// </summary>
        Upt,

        /// <summary>
        /// **Reserved**
        /// </summary>
        Reserved
    }
}