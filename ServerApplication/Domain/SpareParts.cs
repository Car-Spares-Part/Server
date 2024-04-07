namespace ServerApplication.Domain;

public class SpareParts: IEntity
{
    public SpareParts () {}
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Brand { get; set; }
    public int? Model { get; set; }
    public int Quantity { get; set; }
    public string? MadeIn { get; set; }
    public bool IsSuspended { get; set; } = false;
    public DateTime CreatedOn { get; set; }
    public DateTime UpdatedOn { get; set; }
}