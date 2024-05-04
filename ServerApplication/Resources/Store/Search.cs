using Microsoft.EntityFrameworkCore;
using ServerApplication.Domain;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Store;

public class ByIdParams
{
    public string id { get; set; }
}

public class Search: IQueryHandler<ByIdParams, object>
{
    private readonly DatabaseContext _db;
    private readonly RequestContext _request;

    public Search(DatabaseContext db, RequestContext request)
    {
        _db = db;
        _request = request;
    }
    public async Task<object> Handle(ByIdParams request)
    {
        return await _db.Set<Stores>().FirstAsync(s => s.Id == Guid.Parse(request.id));
    }
}