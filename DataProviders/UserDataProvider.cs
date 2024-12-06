using CyShieldAPITestingAssignment.Utilities;

namespace CyShieldAPITestingAssignment.DataProviders;

public class UserDataProvider
{
    public static IEnumerable<object[]> CreateUserData()
    {
        yield return new object[]
        {
                new {
                    name = FakeDataGenerator.GenerateName(),
                    job = FakeDataGenerator.GenerateJob()
                }
        };
    }

    public static IEnumerable<object[]> UpdateUserData()
    {
        yield return new object[]
        {
                new {
                    name = FakeDataGenerator.GenerateName(),
                    job = FakeDataGenerator.GenerateJob()
                }
        };
    }
}
