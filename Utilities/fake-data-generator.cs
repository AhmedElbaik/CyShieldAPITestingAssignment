using Bogus;

namespace CyShieldAPITestingAssignment.Utilities;

public static class FakeDataGenerator
{
    public static Faker Faker = new Faker("en");

    public static string GenerateName() => Faker.Name.FullName();
    public static string GenerateJob() => Faker.Name.JobTitle();
    public static string GenerateEmail() => Faker.Internet.Email();
}
