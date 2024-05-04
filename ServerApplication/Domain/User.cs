using System.Text;
using ServerApplication.Enums;

namespace ServerApplication.Domain;



public class User : IEntity
{
    public User()
    {
    }

    public User(string firstName, string middleName, string lastName, string email, string phoneNumber, string password, string role)
    {
        Id = new Guid();
        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = CreatePasswordHash(password);
        CreatedOn = DateTime.Now;
        UserRole = role.ToLower() == "customer" ? Role.Customer : Role.Store;
    }

    public Guid Id { get; set; }
    public Role UserRole { get; set; } = Role.Customer;
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    public bool CheckValidPassword(string userPassword, string enteredPassword)
    {
        if (userPassword == CreatePasswordHash(enteredPassword))
        {
            return true;
        }

        return false;
    }

    // Hashed Password 
    private string CreatePasswordHash(string password)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            // Get the hashed string.
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}

public class CustomerAddress : IEntity
{
    public CustomerAddress() {
    }

    public CustomerAddress(Guid id, string country, string city, string? area, string addressLine1, string? addressLine2, decimal? lng, decimal? lat, bool isRequestedByUser)
    {
        if (isRequestedByUser)
        {
            UserId = id;
        } else
        {
            StoreId = id;
        }
        Country = country;
        City = city;
        Area = area;
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        Lng = lng;
        Lat = lat;
    }

    public Guid Id { get; set; }

    // FK (USER)
    public Guid UserId { get; set; }
    public Guid StoreId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string? Area { get; set; }
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public decimal? Lng { get; set; }

    public decimal? Lat { get; set; }

    // Navigation property (USER)
    public User User { get; set; }
    public Stores Store { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}