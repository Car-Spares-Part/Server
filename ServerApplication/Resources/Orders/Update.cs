using ServerApplication.Repository;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Orders;

public class Update: ICommandHandler<Domain.Orders, Domain.Orders>
{
  private readonly IOrdersRepository _ordersRepository;

  public Update(IOrdersRepository ordersRepository)
  {
    _ordersRepository = ordersRepository;
  }

  public async Task<Domain.Orders> Handle(Domain.Orders request)
  {
    return await _ordersRepository.UpdateOrderAsync(request);
  }
}