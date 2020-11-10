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

        [Test]
        [TestCase(true, "77555521")]
        [TestCase(true, "09132198895")]
        [TestCase(true, "+989213328197")]
        [TestCase(true, "00983134335774")]
        //
        [TestCase(false, "-989132198895")]
        [TestCase(false, "^1-555-4352")]
        [TestCase(false, "1-555-4352")]
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
    }
}
