using Microsoft.EntityFrameworkCore;
using ServerApplication.Domain;
using ServerApplication.Enums;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Store;

public class Get: IQueryHandler<object>
{
    private readonly DatabaseContext _databaseContext;
    private readonly RequestContext _requestContext;

    public Get(DatabaseContext databaseContext, RequestContext requestContext)
    {
        _databaseContext = databaseContext;
        _requestContext = requestContext;
    }
    
    public async Task<object> Handle()
    {
        var userId = _requestContext.User?.FindFirst("userId")?.Value;
        if (userId is null) throw new SWUnauthorizedException("Un Authorize to show the result");
        
        // Get user from User Table
        var userDetails = await _databaseContext.Set<User>().FirstOrDefaultAsync(u => u.Id == Guid.Parse(userId));
        
        //Check user role and if existing user
        if (userDetails != null && userDetails.UserRole != Role.Admin)
        {
            throw new SWUnauthorizedException("You're not an admin user, You do not have permission to perform this operation");
        }
        
        // return all stores for the admin user.
        var allStores = await _databaseContext.Set<Stores>().ToListAsync();
        return allStores.OrderBy(a => a.CreatedOn);

    }
}