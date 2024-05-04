using Microsoft.EntityFrameworkCore;
using ServerApplication.Domain;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Store;

public class Request
{
    public string StoreName { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Area { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public decimal? Lng { get; set; }
    public decimal? Lat { get; set; }
}

public class Create : ICommandHandler<Request, Stores>
{
    private readonly DatabaseContext _databaseContext;
    private readonly RequestContext _request;

    public Create(DatabaseContext databaseContext, RequestContext requestContext)
    {
        _databaseContext = databaseContext;
        _request = requestContext;
    }

    public async Task<Stores>? Handle(Request request)
    {
        var loggenInUserID = _request.User?.FindFirst("userId")?.Value;
        var loggedInUser = await _databaseContext.Set<User>()
            .FirstOrDefaultAsync(u => u.Id == Guid.Parse(loggenInUserID!));
        if (loggedInUser is null) throw new Exception("You not logged in user");

        var newStore = new Stores(request.StoreName, loggedInUser.Id);
        _databaseContext.Set<Stores>().Add(newStore);
        await _databaseContext.SaveChangesAsync();
        
        var customerAddress = new CustomerAddress(newStore.Id, request.Country, request.City, request.Area,
            request.AddressLine1, request.AddressLine2, request.Lng, request.Lat, true);
        _databaseContext.Set<CustomerAddress>().Add(customerAddress);
        await _databaseContext.SaveChangesAsync();

        newStore.CustomerAddresses = customerAddress;
        await _databaseContext.SaveChangesAsync();
        return newStore;
    }
}