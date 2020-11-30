using System;
using Tel4Net.RegionValidation;
using Tel4Net.TestCore;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TestValidator tv = new TestValidator();
            TestRegionValidator trv = new TestRegionValidator();
            TestNormalizer tn = new TestNormalizer();
            
            // TODO: Fill free to clear any code below here, and test, or debug your code, in case, same to me, your Unit Test debugger doesn't work

            tn.NormalizePhoneNumber_NaturalCharSet("۵۸۴۱۴۷۹۳", "58414793", "+");
            tn.NormalizePhoneNumber_Simple("+1483542357", "+1483542357", "+");

            trv.ValidateMobileNumber_NoSign(true, "9132198895", Region.Iran);
            trv.ValidateMobileNumber_NoSign(true, "989132198895", Region.Iran);
        }
    }
}
