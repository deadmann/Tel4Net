using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using Tel4Net.RegionValidation;

namespace Tel4Net.TestCore
{
    using static TelephoneNormalizer;

    [TestFixture]
    public class TestNormalizer
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        // Simple
        [TestCase("62374695", "62374695", "+")]
        [TestCase("09134328695", "09134328695", "+")]
        [TestCase("+1483542357", "+1483542357", "+")]
        [TestCase("001483542357", "+1483542357", "+")]
        [TestCase("+989174321543", "00989174321543", "00")]
        [TestCase("00989174321543", "00989174321543", "00")]
        // Complex
        [TestCase("555-5322", "5555322", "00")]
        [TestCase("+93 (127) 123 546", "+93127123546", "+")]
        [TestCase("+1 [482] 555-5512", "0014825555512", "00")]
        [TestCase("(61) 745 423.5512", "617454235512", "+")]
        [TestCase("0(61) 745 423.5512", "0617454235512", "+")]
        public void NormalizePhoneNumber_Simple(string number, string expected, string normalizeSign)
        {
            var normalizedNumber = ToPhoneNumberNormalization(number,null,normalizeSign);
            Assert.AreEqual(expected, normalizedNumber);
        }


        [Test]
        [TestCase("۵۸۴۱۴۷۹۳", "58414793", "+")]                     // IR - Farsi Normal
        [TestCase("٠٠٩٨٨٣٥٨٦١٢١٣١٠", "+9883586121310", "+")]        // IR - Farsi IOS
        public void NormalizePhoneNumber_NaturalCharSet(string number, string expected, string normalizeSign = null)
        {
            var normalizedNumber = ToPhoneNumberNormalization(number, new TelephoneOptions{ProcessNaturalCharacterOnly = false}, normalizeSign);
            Assert.AreEqual(expected, normalizedNumber);
        }
    }
}
