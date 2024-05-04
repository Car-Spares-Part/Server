namespace ServerApplication.Domain;

public class Stores: IEntity
{
    public Stores()
    {
    }

    public Stores(string name, Guid ownerId, bool isAccepted= false)
    {
        Id = new Guid();
        Name = name;
        OwnerId = ownerId;
        this.isAccepted = isAccepted;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid OwnerId { get; set; }
    public CustomerAddress CustomerAddresses { get; set; }
    // Out of five
    public int rate { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
    public bool isAccepted { get; set; }
}