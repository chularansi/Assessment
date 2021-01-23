using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentTests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async Task CallUnsecureApi_NoAuth_Ok()
        {
            // Arrange
            /*
             * use TestServer class to create a client and call "api/values"
             */
            var expected = HttpStatusCode.OK;

            // Act

            // uncomment the line below
            // var response = await client.GetAsync(url);

            // Assert that response.StatusCode matches expectedStatus
        }

        [TestMethod]
        public async Task CallSecureApiRoot_WithToken_ResponseOk()
        {
            // Arrange
            /*
             * use TestServer class to create a client and call "api/securevalues"
             * get a valid access token from https://demo.identityserver.io and use it in the request
             */
            var expectedStatus = HttpStatusCode.OK;

            // Act

            // uncomment the line below
            // var response = await client.GetAsync(url);

            // Assert that response.StatusCode matches expectedStatus
        }
    }
}
