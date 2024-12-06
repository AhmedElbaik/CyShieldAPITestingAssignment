using CyShieldAPITestingAssignment.DataProviders;
using CyShieldAPITestingAssignment.Utilities;
using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using System.Net;
using xRetry;
using Xunit.Abstractions;

namespace CyShieldAPITestingAssignment.Tests;

public class CreateUserTests : BaseTest
{
    private readonly SchemaValidator _schemaValidator;
    private new readonly ITestOutputHelper _output;

    public CreateUserTests(ITestOutputHelper output) : base(output)
    {
        _output = output;
        _schemaValidator = new SchemaValidator(output);
    }

    public ITestOutputHelper Output => _output;

    [RetryTheory]
    [MemberData(nameof(UserDataProvider.CreateUserData), MemberType = typeof(UserDataProvider))]
    public void CreateUser_ShouldReturnSuccessfulResponse(dynamic userPayload)
    {
        // Arrange
        var request = RequestWithoutAuth("users");
        request.Method = Method.Post;
        RestRequestExtensions.AddJsonBody(request, userPayload);

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        var responseData = JsonConvert.DeserializeObject<dynamic>(response.Content!);

        // Convert to string explicitly
        string responseName = responseData!.name.ToString();
        string responseJob = responseData.job.ToString();

        responseName.Should().Be(userPayload.name.ToString());
        responseJob.Should().Be(userPayload.job.ToString());

        // Schema Validation
        bool isValid = _schemaValidator.ValidateJson(response.Content ?? string.Empty, "CreateUser");
        Assert.True(isValid, "Schema validation failed for list of users response");
    }
}