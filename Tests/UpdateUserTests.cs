using CyShieldAPITestingAssignment.DataProviders;
using CyShieldAPITestingAssignment.Utilities;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using xRetry;
using Xunit.Abstractions;

namespace CyShieldAPITestingAssignment.Tests;

public class UpdateUserTests : BaseTest
{
    private readonly SchemaValidator _schemaValidator;
    private new readonly ITestOutputHelper _output;

    public UpdateUserTests(ITestOutputHelper output) : base(output)
    {
        _output = output;
        _schemaValidator = new SchemaValidator(output);
    }

    [RetryTheory]
    [MemberData(nameof(UserDataProvider.UpdateUserData), MemberType = typeof(UserDataProvider))]
    public void UpdateUser_ShouldReturnSuccessfulResponse(dynamic updatePayload)
    {
        // Arrange
        var request = RequestWithoutAuth("users/2");
        request.Method = Method.Put;
        RestRequestExtensions.AddJsonBody(request, updatePayload);

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content!);

        // Convert to string explicitly
        string responseName = responseData!.name.ToString();
        string responseJob = responseData.job.ToString();

        responseName.Should().Be(updatePayload.name.ToString());
        responseJob.Should().Be(updatePayload.job.ToString());

        // Schema Validation
        bool isValid = _schemaValidator.ValidateJson(response.Content ?? string.Empty, "UpdateUser");
        Assert.True(isValid, "Schema validation failed for list of users response");
    }
}