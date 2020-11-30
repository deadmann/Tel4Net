using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Tel4Net.TestCore
{
    using static TelephoneValidator;

    [TestFixture]
    public class TestValidator
    {  
        [SetUp]
        public void Setup()
        {

        }

        /// <summary>
        /// Valid Signature: [NUMBER] + - . [SPACE] [ ] ( )
        /// </summary>
        /// <param name="value"></param>
        [Test]
        [TestCase(true,"09132198895")]
        [TestCase(true,"0913-219.8895")]
        [TestCase(true,"0913 - 2198895")]
        [TestCase(true, "2180")]
        [TestCase(true, "+98 (21) 55777721")]
        [TestCase(true, "+98 [31] 34335774")]
        //
        [TestCase(false, "0921\n\r3328197")]
        [TestCase(false, "0921%332#8197")]
        public void ValidateFormat_ContainsValidSignatureSignOnly(bool shouldSuccess, string number)
        {
            var isValid = PhoneNumberValidateFormat(number);
            if (shouldSuccess)
            {
                Assert.True(isValid);
            }
            else
            {
                Assert.False(isValid);
            }
        }

        /// <summary>
        /// [0-9][1-9] 00[1-9] +[1-9]
        /// </summary>
        /// <param name="shouldSuccess"></param>
        /// <param name="number"></param>
        [Test]
        [TestCase(true, "77555521")]
        [TestCase(true, "09132198895")]
        [TestCase(true, "+989213328197")]
        [TestCase(true, "00983134335774")]
        //
        [TestCase(false, "000989132198895")]
        [TestCase(false, "-989132198895")]
        [TestCase(false, "^1-555-4352")]
        [TestCase(false, "*1-555-4352")]
        public void ValidateFormat_ShouldStartWithValidSignature(bool shouldSuccess, string number)
        {
            var isValid = PhoneNumberValidateFormat(number);
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
        [TestCase(true, "+98 (913) 219 88 95")]
        [TestCase(true, "021[633]25436")]
        //
        [TestCase(false, "0913) 2198895")]
        [TestCase(false, "(77555521")]
        [TestCase(false, "77((5555)21")]
        [TestCase(false, "(775)55521)")]
        [TestCase(false, "775555[21")]
        [TestCase(false, "77555521]")]
        [TestCase(false, "775[5[5521]")]
        [TestCase(false, "77555[521]]")]
        public void ValidateFormat_OpeningOrClosingParenthesesOrBracketsShouldHaveMatching(bool shouldSuccess, string number)
        {
            var isValid = PhoneNumberValidateFormat(number);
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
        [TestCase(true, "555986845")]
        //
        [TestCase(false, "0555986845")]
        [TestCase(false, "009887239534")]
        [TestCase(false, "+1 (432) 555-5423")]
        public void ValidateRegion_TestInboundNumbers(bool shouldSuccess, string number)
        {
            var isValid = PhoneNumberInboundValidation(number);
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
        [TestCase(true, "0555986845")]
        //
        [TestCase(false, "555986845")]
        [TestCase(false, "009887239534")]
        [TestCase(false, "+1 (432) 555-5423")]
        public void ValidateRegion_TestCityNumbers(bool shouldSuccess, string number)
        {
            var isValid = PhoneNumberCityValidation(number);
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
        [TestCase(true, "009887239534")]
        [TestCase(true, "+1 (432) 555-5423")]
        //
        [TestCase(false, "555986845")]
        [TestCase(false, "0555986845")]
        public void ValidateRegion_TestI10nNumbers(bool shouldSuccess, string number)
        {
            var isValid = PhoneNumberI10nValidation(number);
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
