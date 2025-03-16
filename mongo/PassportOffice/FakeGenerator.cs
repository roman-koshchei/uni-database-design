
namespace PassportOffice;
public static class FakeGenerator
{
    private static readonly Random random = new Random();

    public static string GetRandomFirstName()
    {
        var firstNames = new[] { "John", "Jane", "Alex", "Chris", "Sam", "Pat" };
        return firstNames[random.Next(firstNames.Length)];
    }

    public static string GetRandomMiddleName()
    {
        var middleNames = new[] { "Paul", "Marie", "Lee", "Taylor", "Jordan" };
        return middleNames[random.Next(middleNames.Length)];
    }

    public static string GetRandomLastName()
    {
        var lastNames = new[] { "Smith", "Johnson", "Brown", "Taylor", "Lee", "Davis" };
        return lastNames[random.Next(lastNames.Length)];
    }

    public static string GetRandomPassport()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] passport = new char[9];
        for (int i = 0; i < passport.Length; i++)
        {
            passport[i] = chars[random.Next(chars.Length)];
        }
        return new string(passport);
    }

    public static string GetRandomGender()
    {
        return random.Next(0, 2) == 0 ? "Male" : "Female";
    }

    public static string GetRandomInstitution()
    {
        var institutions = new[] { "School A", "School B", "Institute C", "Academy D" };
        return institutions[random.Next(institutions.Length)];
    }

    public static int GetRandomAge(int minAge = 18, int maxAge = 30)
    {
        return random.Next(minAge, maxAge);
    }

    public static List<Child> GenerateRandomChildren()
    {
        var children = new List<Child>();

        for (int i = 0; i < 2; i++)
        {
            var child = new Child
            {
                FirstName = GetRandomFirstName(),
                LastName = GetRandomLastName(),
                Age = random.Next(1, 10), 
                Institution = new Institution
                {
                    Name = GetRandomInstitution(),
                    Price = random.Next(50, 200) 
                }
            };
            children.Add(child);
        }

        return children;
    }

    public static Person GetRandomPerson()
    {
        return new Person
        {
            FirstName = GetRandomFirstName(),
            MiddleName = GetRandomMiddleName(),
            LastName = GetRandomLastName(),
            Passport = GetRandomPassport(),
            Gender = GetRandomGender(),
            Age = GetRandomAge(18, 30), 
            Children = GenerateRandomChildren()
        };
    }
}