using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using Tel4Net.RegionValidation;

namespace Tel4Net.TestCore
{
    using static TelephoneValidator;

    [TestFixture]
    public class TestRegionValidator
    {  
        [SetUp]
        public void Setup()
        {
            MobileValidator(""); // First Access -- Init Statics
        }

        [Test]
        // TODO: Add Valid Mobile Number SortBy country code  in comment
        [TestCase(true,"09132198895")]          // IR   --Valid Operator/City
        [TestCase(true, "+989213328197")]       // IR   --Valid Country
        // TODO: Add Invalid Mobile Number SortBy country code in comment
        [TestCase(false, "+982144995762")]      // IR   --Inbound Number
        [TestCase(false, "02177555521")]        // IR   --City Number
        [TestCase(false, "4337774")]            // IR   --Inbound Number
        public void ValidateMobileNumber_AllAvailableRegions(bool shouldSuccess, string number)
        {
            var isValid = MobileValidator(number);
            if (shouldSuccess)
            {
                Assert.True(isValid);
            }
            else
            {
                Assert.False(isValid);
            }
        }


        [Test]
        // TODO: Add Valid Mobile Number SortBy country code  in comment
        [TestCase(true, "09132198895", Region.Iran)]            // IR   --Valid Operator/City
        [TestCase(true, "+989213328197", Region.Iran)]          // IR   --Valid Country
        // TODO: Add Invalid Mobile Number SortBy country code in comment
        [TestCase(false, "02177555521", Region.Iran)]           // IR   --City Number
        [TestCase(false, "77555521", Region.Iran)]              // IR   --Inbound Number
        [TestCase(false, "9122697896", Region.Iran)]            // IR   --No Sign Valid Operator/City
        [TestCase(false, "989122697896", Region.Iran)]          // IR   --No Sign Valid Country
        [TestCase(false, "+1 914-720-1278", Region.Iran)]       // IR   --I10n Number
        public void ValidateMobileNumber_SpecificRegion(bool shouldSuccess, string number, Region region)
        {
            var isValid = MobileValidator(number, region, RegionalOptions.Default);
            if (shouldSuccess)
            {
                Assert.True(isValid);
            }
            else
            {
                Assert.False(isValid);
            }
        }

        [Test]
        // TODO: Add Valid Mobile Number SortBy country code  in comment
        [TestCase(true, "09132198895", new []{Region.Iran})]            // IR   --Valid Operator/City
        [TestCase(true, "+989213328197", new[] { Region.Iran })]        // IR   --Valid Country
        // TODO: Add Invalid Mobile Number SortBy country code in comment
        [TestCase(false, "02136512551", new[] { Region.Iran })]         // IR   --City Number
        [TestCase(false, "61512521", new[] { Region.Iran })]            // IR   --Inbound Number
        [TestCase(false, "+1 914-720-1278", new[] { Region.Iran })]     // IR   --I10n Number
        public void ValidateMobileNumber_SpecificRangeOfRegion(bool shouldSuccess, string number, Region[] region)
        {
            var isValid = MobileValidator(number, region);
            if (shouldSuccess)
            {
                Assert.True(isValid);
            }
            else
            {
                Assert.False(isValid);
            }
        }

        [Test]
        // TODO: Add Valid Mobile Number SortBy country code  in comment
        [TestCase(true, "9132198895", Region.Iran )]           // IR   --Valid Operator/City
        [TestCase(true, "989213328197", Region.Iran )]         // IR   --Valid Country
        // TODO: Add Invalid Mobile Number SortBy country code in comment
        [TestCase(false, "02173755521", Region.Iran )]         // IR   --City Number
        [TestCase(false, "123456789", Region.Iran )]           // IR   --Inbound Number
        [TestCase(false, "+1 914-720-1278", Region.Iran)]       // IR   --I10n Number
        public void ValidateMobileNumber_NoSign(bool shouldSuccess, string number, Region region)
        {
            var isValid = MobileValidator(number, region, new RegionalOptions
            {
                AllowNoSign = true
            });
            if (shouldSuccess)
            {
                Assert.True(isValid);
            }
            else
            {
                Assert.False(isValid);
            }
        }

        [Test]
        // TODO: Add Valid Mobile Number SortBy country code in comment
        [TestCase("۵۸۴۱۴۷۹۳", Region.Iran)] // IR   --Valid Inbound - Farsi Norm
        [TestCase("09154475591", Region.Iran)] // IR   --Valid Operator/City - ASCII Charset 
        [TestCase("٠٠٩٨٨٣٥٨٦٢١٣١٠", Region.Iran)] // IR   --Valid I10n - Farsi IOS
        public void ValidatePhoneNumber_NonNaturalCharacterTesting(string number, Region region)
        {
            var isValid = NumberValidator(number, region, new RegionalOptions
            {
                ProcessNaturalCharacterOnly = false
            });
            Assert.True(isValid);
        }

        [Test]
        // TODO: Add Valid Mobile Number SortBy country code  in comment
        [TestCase(true, "09154475591", Region.Iran)] // IR   --Valid Operator/City - ASCII Charset 
        // TODO: Add Invalid Mobile Number SortBy country code in comment
        [TestCase(false, "۵۸۴۱۴۷۹۳", Region.Iran)] // IR   --Valid Inbound - Farsi Norm
        [TestCase(false, "٠٠٩٨٨٣٥٨٦٢١٣١٠", Region.Iran)] // IR   --Valid I10n - Farsi IOS
        public void ValidatePhoneNumber_NaturalCharacterOnly(bool shouldSuccess, string number, Region region)
        {
            var isValid = NumberValidator(number, region, new RegionalOptions
            {
                ProcessNaturalCharacterOnly = true
            });
            if (shouldSuccess)
            {
                Assert.True(isValid);
            }
            else
            {
                Assert.False(isValid);
            }
        }
    }
}
