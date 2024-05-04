using Microsoft.EntityFrameworkCore;
using ServerApplication.Domain;
using ServerApplication.Enums;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Store;

public abstract class ApproveStoreRequest
{
    public string StoreId { get; set; }
}

[HandlerName("/ApproveStore")]
public class ApproveStore: ICommandHandler<ApproveStoreRequest, object?>
{
    private readonly DatabaseContext _databaseContext;
    private readonly RequestContext _requestContext;

    public ApproveStore(DatabaseContext databaseContext, RequestContext requestContext)
    {
        _databaseContext = databaseContext;
        _requestContext = requestContext;
    }

    public async Task<object?> Handle(ApproveStoreRequest request)
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

        var store = await _databaseContext.Set<Stores>().FirstOrDefaultAsync(s => s.Id == Guid.Parse(request.StoreId));
        if (store == null)
        {
            throw new SWNotFoundException("Store not found");
        }
        
        store.isAccepted = true;
        store.UpdatedOn = DateTime.Now;
        
        await _databaseContext.SaveChangesAsync();
        
        return null;
    }
}