using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AssessmentTests
{
    [TestClass]
    public class ApiTests
    {
        static WebApplicationFactory<Startup> webApplicationFactory;
        static HttpClient httpClient;

        readonly string baseUrl = "http://localhost:65179";

        [ClassInitialize]
        public static async Task ClassStartup(TestContext context)
        {
            webApplicationFactory = new WebApplicationFactory<Startup>();
            httpClient = webApplicationFactory.CreateClient();
        }

        [TestMethod]
        public async Task CallUnsecureApi_NoAuth_Ok()
        {
            string getValues = $"{baseUrl}/api/values";
            var expected = HttpStatusCode.OK;

            var response = await httpClient.GetAsync(getValues);

            Assert.AreEqual(expected, response.StatusCode);

            httpClient.Dispose();
        }

        [TestMethod]
        public async Task CallUnsecureApi_NoAuth_NotFound()
        {
            string getValues = $"{baseUrl}/api/values1";
            var expected = HttpStatusCode.NotFound;

            var response = await httpClient.GetAsync(getValues);

            Assert.AreEqual(expected, response.StatusCode);

            httpClient.Dispose();
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
