using ServerApplication.Repository;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Orders;

public class Create : ICommandHandler<Domain.Orders, object>
{
  private readonly IOrdersRepository _ordersRepository;

  public Create(IOrdersRepository ordersRepository)
  {
    _ordersRepository = ordersRepository;
  }

  public async Task<object> Handle(Domain.Orders request)
  {
    return await _ordersRepository.AddOrderAsync(request);
  }
}