using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using IdentityModel.Client;
using System;

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
            var token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjVDQ0FBMDNFRERFMjZENTMxMDRDQzM1RDBENEIyOTlDIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2MTE1MTUxMzQsImV4cCI6MTYxMTUxODczNCwiaXNzIjoiaHR0cHM6Ly9kZW1vLmlkZW50aXR5c2VydmVyLmlvIiwiYXVkIjoiYXBpIiwiY2xpZW50X2lkIjoibTJtIiwianRpIjoiRjkyQzk1MUMzQjczN0E3NkY5OTNFODc0NTE3OTlGQUUiLCJpYXQiOjE2MTE1MTUxMzQsInNjb3BlIjpbImFwaSJdfQ.FDQqH5PzFe_yg102wKNwSIoUhAswsVc7dygTpyTXe7FpmHfuXtposmwZdxPubcyXnjsYndSp5DeJSvlzSiMqpnC_HP-Ybp24SohjAi2FPynTafn7FeAKIHua2-XZMTNakZM8A-SPLr11XP_gWC72psoEjl5iMUIHWkGr_2kTJYPfRygHAD-J-zV3oapFssesbTMVfwwJJI7b3CzvkmmdpFAc-vLsIIpMWnxrACTrFC6XZfCagAa8Dvt9Sat-VrsrEEzqIDviqbvpdmsRE2XxAUpvqBXPDqs2htgFs8p1KcoVa1PAwzno326wmN0Kw6XOh_7iOkGBuODzdBotc6HtBQ";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            string getValues = $"{baseUrl}/api/securevalues";
            var expected = HttpStatusCode.OK;

            var response = await httpClient.GetAsync(getValues);

            Assert.AreEqual(expected, response.StatusCode);

            httpClient.Dispose();
        }
    }
}
