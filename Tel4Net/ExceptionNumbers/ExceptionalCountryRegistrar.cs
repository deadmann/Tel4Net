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
            container.RegisterRegions(Country.Anguilla, new Anguilla());
            container.RegisterRegions(Country.AntiguaAndBarbuda, new AntiguaAndBarbuda() );
            container.RegisterRegions(Country.Australia,new Australia() );
            container.RegisterRegions(Country.Bahamas, new Bahamas() );
            container.RegisterRegions(Country.Barbados, new Barbados());
            container.RegisterRegions(Country.Belarus, new Belarus() );
            container.RegisterRegions(Country.Bermuda, new Bermuda() );
            container.RegisterRegions(Country.BritishVirginIslands, new BritishVirginIslands());
            container.RegisterRegions(Country.Cambodia, new Cambodia() );
            container.RegisterRegions(Country.Canada, new Canada() );
            container.RegisterRegions(Country.CaymanIslands, new CaymanIslands() );
            container.RegisterRegions(Country.Chile, new Chile() );
            container.RegisterRegions(Country.China, new China() );
            container.RegisterRegions(Country.China, new China2() );
            container.RegisterRegions(Country.Colombia, new Colombia() );
            container.RegisterRegions(Country.Cuba, new Cuba() );
            container.RegisterRegions(Country.Dominica, new Dominica() );
            container.RegisterRegions(Country.DominicanRep, new DominicanRep() );
            container.RegisterRegions(Country.Finland, new Finland() );
            container.RegisterRegions(Country.Grenada,new Grenada() );
            container.RegisterRegions(Country.Guam, new Guam() );
            container.RegisterRegions(Country.Guyana, new Guyana() );
            container.RegisterRegions(Country.HongKongChina, new HongKongChina() );
            container.RegisterRegions(Country.Indonesia, new Indonesia() );
            container.RegisterRegions(Country.Israel, new Israel() );
            container.RegisterRegions(Country.Jamaica, new Jamaica() );
            container.RegisterRegions(Country.Japan, new Japan() );
            container.RegisterRegions(Country.Kazakhstan, new Kazakhstan() );
            container.RegisterRegions(Country.Kenya, new Kenya() );
            container.RegisterRegions(Country.Korea, new Korea() );
            container.RegisterRegions(Country.MarshallIslands, new MarshallIslands() );
            container.RegisterRegions(Country.Micronesia, new Micronesia() );
            container.RegisterRegions(Country.Mongolia, new Mongolia() );
            container.RegisterRegions(Country.Montserrat, new Montserrat() );
            container.RegisterRegions(Country.Nigeria, new Nigeria() );
            container.RegisterRegions(Country.NorthernMarianas, new NorthernMarianas() );
            container.RegisterRegions(Country.Palau, new Palau() );
            container.RegisterRegions(Country.PuertoRico, new PuertoRico() );
            container.RegisterRegions(Country.RussianFederation, new RussianFederation() );
            container.RegisterRegions(Country.SaintKittsAndNevis, new SaintKittsAndNevis() );
            container.RegisterRegions(Country.SaintLucia, new SaintLucia() );
            container.RegisterRegions(Country.SaintVincentAndTheGrenadines, new SaintVincentAndTheGrenadines() );
            container.RegisterRegions(Country.Samoa, new Samoa() );
            container.RegisterRegions(Country.Singapore, new Singapore() );
            container.RegisterRegions(Country.SintMaartenDp, new SintMaartenDp() );
            container.RegisterRegions(Country.Taiwan, new Taiwan() );
            container.RegisterRegions(Country.Tajikistan, new Tajikistan() );
            container.RegisterRegions(Country.Tanzania, new Tanzania() );
            container.RegisterRegions(Country.Thailand, new Thailand() );
            container.RegisterRegions(Country.TrinidadAndTobago, new TrinidadAndTobago() );
            container.RegisterRegions(Country.Turkmenistan, new Turkmenistan() );
            container.RegisterRegions(Country.TurksAndCaicosIslands, new TurksAndCaicosIslands() );
            container.RegisterRegions(Country.Uganda, new Uganda() );
            container.RegisterRegions(Country.UnitedStates, new UnitedStates() );
            container.RegisterRegions(Country.UnitedStatesVirginIslands, new UnitedStatesVirginIslands() );
            container.RegisterRegions(Country.Uzbekistan, new Uzbekistan() );
            container.RegisterRegions(Country.Vatican, new Vatican() );

            container.RegisterRegions(Country.Goc, new Goc());

            container.RegisterRegions(Country.Gmss, new Gmss() );
            container.RegisterRegions(Country.InmarsatSnac, new InmarsatSnac() );
            container.RegisterRegions(Country.InternationalFreephoneService, new InternationalFreephoneService() );
            container.RegisterRegions(Country.InternationalNetworks, new InternationalNetworks() );
            container.RegisterRegions(Country.Iprs, new Iprs() );
            container.RegisterRegions(Country.Iscs, new Iscs() );
            container.RegisterRegions(Country.Tdr, new Tdr() );
            container.RegisterRegions(Country.Tpnis, new Tpnis() );
            container.RegisterRegions(Country.Upt, new Upt() );

            container.RegisterRegions(Country.Reserved, new Reserved() );
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
        /// <summary>
        /// Sint Maarten (Dutch part)
        /// </summary>
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
        /// Group of countries, shared code
        /// </summary>
        Goc,

        /// <summary>
        /// Global Mobile Satellite System (GMSS), shared
        /// </summary>
        Gmss,
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