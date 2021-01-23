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

        [TestMethod]
        public void WildcardRuleMethod_No1()
        {
            UriValidator validator = new UriValidator();
            string[] githubRules = new[]{
                "https://*.github.com/*/logincallback", // wildcard rule
	            "https://*.github.com/webapp/login" // wildcard rule
            };

            var result = validator.Validate(@"https://www.github.com/webapp/login", githubRules);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void WildcardRuleMethod_No2()
        {
            UriValidator validator = new UriValidator();
            string[] confirmitRules = new[]{
                "https://*.confirmit.com/*/logincallback" // wildcard rule
            };

            var result = validator.Validate(@"https://app.confirmit.com/auth/folder/logincallback", confirmitRules);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void WildcardRuleMethod_No3()
        {
            UriValidator validator = new UriValidator();
            string[] confirmitRules = new[]{
                "https://*.confirmit.com/*/logincallback" // wildcard rule
            };

            var result = validator.Validate(@"https://confirmit.com/logincallback", confirmitRules);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void RegexRuleMethod_No1()
        {
            UriValidator validator = new UriValidator();
            string[] aspRules = new[]{
                @"@https://([\w-]+\.)*asp\.net\/logincallback" // literal regex rule	
            };

            var result = validator.Validate(@"https://www.asp.net/webapp/login", aspRules);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void RegexRuleMethod_No2()
        {
            UriValidator validator = new UriValidator();
            string[] confirmitRules = new[]{
                @"@https://([\w-]+\.)*confirmit\.com\/logincallback" // literal regex rule	
            };

            var result = validator.Validate(@"https://confirmit.com/logincallback", confirmitRules);
            Assert.AreEqual(result, true);
        }
    }
}
