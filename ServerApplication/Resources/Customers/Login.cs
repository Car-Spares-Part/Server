using Microsoft.EntityFrameworkCore;
using ServerApplication.Domain;
using ServerApplication.Services;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Customers;

public class CustomerRequest {
    public string Email { get; set; }
    public string Password { get; set; }
}

[Unprotect]
[HandlerName("Login")]
public class Login: ICommandHandler<CustomerRequest, object>
{
    private readonly DatabaseContext _databaseContext;
    private readonly ICreateJWT _createJwt;

    public Login(DatabaseContext databaseContext, ICreateJWT createJwt)
    {
        _databaseContext = databaseContext;
        _createJwt = createJwt;
    }
    
    public async Task<object> Handle(CustomerRequest request)
    {
        var user = await _databaseContext.Set<User>()
            .Where(u => u.Email == request.Email).FirstOrDefaultAsync();

        if (user != null) 
        {
            if (user.CheckValidPassword(user.PasswordHash, request.Password)) {
                return await _createJwt.Create(user);
            }
        }

        throw new SWUnauthorizedException("Invalid Credentials");
    }
}