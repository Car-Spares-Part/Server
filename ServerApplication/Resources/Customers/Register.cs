using Microsoft.EntityFrameworkCore;
using ServerApplication.Domain;
using ServerApplication.Services;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Customers;

public class UserModel
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string PasswordHash { get; set; }
    public string UserRole { get; set; }
}

[Unprotect]
[HandlerName("Register")]
public class Register: ICommandHandler<UserModel, object>
{
    private readonly DatabaseContext _databaseContext;
    private readonly ICreateJWT _createJwt;

    public Register(DatabaseContext databaseContext, ICreateJWT createJwt)
    {
        _databaseContext = databaseContext;
        _createJwt = createJwt;
    }

    public async Task<object> Handle(UserModel request)
    {
        var checkIsCreatedUser =
            await _databaseContext.Set<User>().Where(u => u.Email == request.Email).FirstOrDefaultAsync();
        if (checkIsCreatedUser != null)
        {
            throw new Exception("User with the same email already exists.");
        }
        
        var user = new User(request.FirstName, request.MiddleName, request.LastName, request.Email, request.PhoneNumber,
            request.PasswordHash, request.UserRole);
        
        _databaseContext.Set<User>().Add(user);
        
        await _databaseContext.SaveChangesAsync();
        
        var token = _createJwt.Create(user);
        return token;
    }
}
