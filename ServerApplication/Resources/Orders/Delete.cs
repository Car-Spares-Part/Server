using ServerApplication.Repository;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Orders;

public class Delete: ICommandHandler<string, object>
{
  private readonly IOrdersRepository _ordersRepository;

  public Delete(IOrdersRepository ordersRepository)
  {
    _ordersRepository = ordersRepository;
  }

  public async Task<object?> Handle(string request)
  {
    await _ordersRepository.DeleteOrderAsync(Guid.Parse(request));
    return null;
  }
}