using Microsoft.EntityFrameworkCore;
using ServerApplication.Domain;

namespace ServerApplication.Repository;

public interface IOrdersRepository
{
  Task<Orders> AddOrderAsync(Orders order);
  Task<Orders?> GetOrderByIdAsync(Guid id);
  Task<Orders> UpdateOrderAsync(Orders order);
  Task DeleteOrderAsync(Guid id);
  Task<List<Orders>> GetAllOrdersAsync();
  Task<List<Orders>> GetOrdersByStatusAsync(EOrderStatus status);
}

public class OrdersRepository : IOrdersRepository
{
  private readonly DatabaseContext _databaseContext;

  public OrdersRepository(DatabaseContext databaseContext)
  {
    _databaseContext = databaseContext;
  }

  public async Task<Orders> AddOrderAsync(Orders order)
  {
    _databaseContext.Set<Orders>().Add(order);
    await _databaseContext.SaveChangesAsync();
    return order;
  }

  public async Task<Orders?> GetOrderByIdAsync(Guid id)
  {
    return await _databaseContext.Set<Orders>().FindAsync(id);
  }

  public async Task<Orders> UpdateOrderAsync(Orders order)
  {
    _databaseContext.Entry(order).State = EntityState.Modified;
    await _databaseContext.SaveChangesAsync();
    return order;
  }

  public async Task DeleteOrderAsync(Guid id)
  {
    var order = await _databaseContext.Set<Orders>().FindAsync(id);
    if (order != null)
    {
      _databaseContext.Set<Orders>().Remove(order);
      await _databaseContext.SaveChangesAsync();
    }
  }

  public async Task<List<Orders>> GetAllOrdersAsync()
  {
    return await _databaseContext.Set<Orders>().ToListAsync();
  }

  public async Task<List<Orders>> GetOrdersByStatusAsync(EOrderStatus status)
  {
    return await _databaseContext.Set<Orders>().Where(o => o.OrderStatus == status).ToListAsync();
  }
}