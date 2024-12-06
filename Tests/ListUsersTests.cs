using CyShieldAPITestingAssignment.Utilities;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using RestSharp;
using System.Net;
using xRetry;
using Xunit.Abstractions;

namespace CyShieldAPITestingAssignment.Tests;

public class ListUsersTests : BaseTest
{
    private readonly SchemaValidator _schemaValidator;
    private new readonly ITestOutputHelper _output;

    public ListUsersTests(ITestOutputHelper output) : base(output)
    {
        _output = output;
        _schemaValidator = new SchemaValidator(output);
    }

    [RetryFact]
    public void GetListUsers_ShouldReturnSuccessfulResponse()
    {
        // Arrange
        var request = RequestWithoutAuth("users");
        request.AddQueryParameter("page", "2");

        // Act
        var response = _client.Execute(request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        response.Content.Should().NotBeNullOrEmpty();

        // Schema Validation
        bool isValid = _schemaValidator.ValidateJson(response.Content ?? string.Empty, "ListUsers");
        Assert.True(isValid, "Schema validation failed for list of users response");
    }
}

