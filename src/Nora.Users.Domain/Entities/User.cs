using Nora.Core.Domain.Entities;

namespace Nora.Users.Domain.Entities;

public class User : Entity<int>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string FullName => GetFullName();
    public DateTime DateOfBirth { get; private set; }
    public int Age => GetAge();
    public int AddressId { get; private set; }
    public virtual Address Address { get; private set; }

    private User() { }

    public User(string firstName, string lastName, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;        
    }

    private string GetFullName() => $"{FirstName} {LastName}";
    private int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;

        if (DateOfBirth > today.AddYears(-age))
            age--;

        return age;
    }
}