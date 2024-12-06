# REQRES API Testing Assignment

This project is designed to test the APIs for the [REQRES](https://reqres.in/) website, which provides a RESTful API for testing and demonstration purposes.

## Project Structure

The project structure is as follows:

```
CyShieldAPiTestingAssignment
├── DataProviders
│   └── C# UserDataProvider.cs
├── Models
│   └── C# CreateUserTests.cs
├── Resources
│   └── Schemas
│       ├── create-user-schema.json
│       └── update-user-schema.json
├── Tests
│   ├── C# CreateUserTests.cs
│   ├── C# ListUserTests.cs
│   └── C# UpdateUserTests.cs
├── Utilities
│   ├── C# fake-data-generator.cs
│   └── C# SchemaValidator.cs
└── README.md
```

The project includes the following key components:

1. **DataProviders**: This folder contains the `UserDataProvider.cs` class, which is responsible for generating test data using the Bogus library.
2. **Models**: This folder contains the data models used in the tests, such as `CreateUserTests.cs`.
3. **Resources/Schemas**: This folder contains the JSON schema files used for response validation, such as `create-user-schema.json` and `update-user-schema.json`.
4. **Tests**: This folder contains the test classes, such as `CreateUserTests.cs`, `ListUserTests.cs`, and `UpdateUserTests.cs`.
5. **Utilities**: This folder contains utility classes, such as `fake-data-generator.cs` for generating fake data and `SchemaValidator.cs` for validating response schemas.

## Dependencies

The project uses the following NuGet packages:

- **Bogus**: A simple and fast data generator for C#, used to generate test data.
- **FluentAssertions**: A fluent interface for asserting the results of unit tests.
- **Microsoft.NET.Test.Sdk**: The .NET Core test SDK, providing a testing framework and runner.
- **Newtonsoft.Json.Schema**: A JSON Schema validation library, used to validate response schemas.
- **RestSharp**: A simple HTTP and REST client library, used to make API requests.
- **Newtonsoft.Json**: A popular JSON serialization library, used for handling JSON data.
- **ExtentReports**: A reporting library for creating detailed test reports.
- **xunit**: A unit testing framework for .NET.
- **xunit.runner.visualstudio**: The Visual Studio test runner for xUnit.

## Running the Tests

To run the tests, you can use your preferred test runner, such as the Visual Studio Test Explorer or the `dotnet test` command.

The tests cover the following API endpoints:

- `POST /api/users`: Create a new user
- `GET /api/users`: List all users
- `PUT /api/users/{id}`: Update a user
- `DELETE /api/users/{id}`: Delete a user

The tests include assertions for the response schema, status codes, and other relevant data.

## Reporting

The project uses the ExtentReports library to generate detailed test reports. The reports can be found in the `bin/Debug/net8.0/extent.html` file after running the tests.

## Conclusion

This project provides a comprehensive test suite for the REQRES API, covering the key functionality and validating the response schemas. The project structure, dependencies, and reporting capabilities make it a robust and professional testing solution.