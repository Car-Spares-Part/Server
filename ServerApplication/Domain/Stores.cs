namespace ServerApplication.Domain;

public class Stores: IEntity
{
    public Stores()
    {
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public ICollection<CustomerAddress> CustomerAddresses { get; set; }
    // Out of five
    public int rate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}