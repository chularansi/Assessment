using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assessment;
using System.Threading.Tasks;

namespace AssessmentTests
{
    [TestClass]
    public class UriValidatorTests
    {
        [TestMethod]
        public void AbsoluteRuleMethod_No1()
        {
            UriValidator validator = new UriValidator();
            string[] googleRules = new[]{
                "https://www.google.com/webapp/logincallback" // absolute rule
            };

            var result = validator.Validate(@"https://www.google.com/webapp/logincallback", googleRules);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void AbsoluteRuleMethod_No2()
        {
            UriValidator validator = new UriValidator();
            string[] googleRules = new[]{
                "https://www.google.com/webapp/logincallback" // absolute rule
            };

            var result = validator.Validate(@"https://www.google.com/webapp/logincallback/", googleRules);
            Assert.AreEqual(result, false);
        }
    }
}
