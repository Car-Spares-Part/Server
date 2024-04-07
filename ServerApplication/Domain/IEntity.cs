namespace ServerApplication.Domain;

public interface IEntity
{
    Guid Id { get; set; }
    DateTime CreatedOn { get; set; }
    DateTime UpdatedOn { get; set; }
}