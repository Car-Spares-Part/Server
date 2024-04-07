namespace ServerApplication.Domain;

public class Pricing: IEntity
{

    public Pricing()
    {
    }

    public Guid Id { get; set; }
    public decimal Price { get; set; }
    public Guid StoreId { get; set; }
    public Guid SparePartId { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}