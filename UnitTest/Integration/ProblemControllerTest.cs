using KnownProblem.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Integration
{
    public class ProblemControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ProblemControllerTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetAllProblems()
        {
            var response = await _client.GetAsync("/api/Problem");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            Assert.True(content.Length > 0);
        }
    }
}
