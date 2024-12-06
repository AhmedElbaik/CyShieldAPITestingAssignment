using System.Threading.Tasks;
using RestSharp;
using Xunit;
using AventStack.ExtentReports;
using CyShieldAPITestingAssignment.Utilities;
using Xunit.Abstractions;

namespace CyShieldAPITestingAssignment.Tests
{
    public class BaseTest : IAsyncLifetime, IDisposable
    {
        protected RestClient _client;
        protected ExtentTest _test;
        private static ExtentReports? _extent;
        protected readonly ITestOutputHelper _output;

        public BaseTest(ITestOutputHelper output)
        {
            _output = output;
            _client = new RestClient("https://reqres.in/api/");

            // Initialize Extent Reports if not already initialized
            if (_extent == null)
            {
                _extent = InitializationForExtentReports.InitializeExtentReports();
            }

            // Create a test in Extent Reports
            _test = _extent.CreateTest(GetType().Name);
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }

        protected RestRequest RequestWithoutAuth(string resource)
        {
            return new RestRequest(resource);
        }

        public void Dispose()
        {
            // Flush Extent Reports when all tests are completed
            InitializationForExtentReports.FlushExtentReports();
        }
    }
}