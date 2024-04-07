namespace ServerApplication.Domain;

public enum EOrderStatus
{
    InProgress,
    Shipped,
    Delivered,
    Canceled
}

public class Orders: IEntity
{
    
    public Orders (){}
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid PartId { get; set; }
    public Guid StoreId { get; set; }
    public int Quantities { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; } = new DateTime();
    public EOrderStatus OrderStatus { get; set; } = EOrderStatus.InProgress;
    
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}