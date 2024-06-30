using ServerApplication.Repository;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Orders;

public class Get: IQueryHandler<object>
{

  private readonly IOrdersRepository _ordersRepository;

  public Get(IOrdersRepository ordersRepository)
  {
    _ordersRepository = ordersRepository;
  }
  
  public async Task<object> Handle()
  {
    return await _ordersRepository.GetAllOrdersAsync();
  }
}