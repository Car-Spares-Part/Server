using ServerApplication.Repository;
using SW.PrimitiveTypes;

namespace ServerApplication.Resources.Orders;

public class GetById: IQueryHandler<string, Domain.Orders>
{
  private readonly IOrdersRepository _ordersRepository;

  public GetById(IOrdersRepository ordersRepository)
  {
    _ordersRepository = ordersRepository;
  }


  public async Task<Domain.Orders?> Handle(string request)
  {
    return await _ordersRepository.GetOrderByIdAsync(Guid.Parse(request));
  }
}