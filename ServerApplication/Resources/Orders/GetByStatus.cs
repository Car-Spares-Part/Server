using ServerApplication.Domain;
using ServerApplication.Repository;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Orders;

public class GetByStatus : IQueryHandler<string, object>
{
  private readonly IOrdersRepository _ordersRepository;

  public GetByStatus(IOrdersRepository ordersRepository)
  {
    _ordersRepository = ordersRepository;
  }

  public async Task<object> Handle(string request)
  {
    if (Enum.TryParse<EOrderStatus>(request, true, out EOrderStatus status))
    {
      return await _ordersRepository.GetOrdersByStatusAsync(status);
    }
    else
    {
      throw new ArgumentException("Invalid order status provided.");
    }
  }
}